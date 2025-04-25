using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Delegates;

public static class JsonStorageAsync
{
    private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
    {
        WriteIndented = true,
        MaxDepth = 64,
        ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
    };

    public static async Task SaveBankCustomerAsync(BankCustomer customer, string directoryPath)
    {
        var customerDTO = new BankCustomerDTO
        {
            CustomerId = customer.CustomerId,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            AccountNumbers = new List<int>()
        };

        foreach (var account in customer.Accounts)
        {
            customerDTO.AccountNumbers.Add(account.AccountNumber);
        }

        string customerFilePath = Path.Combine(directoryPath, "Customers", $"{customer.CustomerId}.json");

        var customerDirectoryPath = Path.GetDirectoryName(customerFilePath);
        if (customerDirectoryPath != null && !Directory.Exists(customerDirectoryPath))
        {
            Directory.CreateDirectory(customerDirectoryPath);
        }

        string json = JsonSerializer.Serialize(customerDTO, _options);
        await File.WriteAllTextAsync(customerFilePath, json);

        await SaveAllAccountsAsync(customer.Accounts, directoryPath);
    }

    public static async Task SaveAllCustomersAsync(IEnumerable<BankCustomer> customers, string directoryPath)
    {
        foreach (var customer in customers)
        {
            await SaveBankCustomerAsync(customer, directoryPath);
        }
    }

    public static async Task SaveBankAccountAsync(BankAccount account, string directoryPath)
    {
        var accountDTO = new BankAccountDTO
        {
            AccountNumber = account.AccountNumber,
            CustomerId = account.CustomerId,
            Balance = account.Balance,
            AccountType = account.AccountType,
            InterestRate = account.InterestRate
        };

        string accountFilePath = Path.Combine(directoryPath, "Accounts", $"{account.AccountNumber}.json");

        var accountDirectoryPath = Path.GetDirectoryName(accountFilePath);
        if (accountDirectoryPath != null && !Directory.Exists(accountDirectoryPath))
        {
            Directory.CreateDirectory(accountDirectoryPath);
        }

        string json = JsonSerializer.Serialize(accountDTO, _options);
        await File.WriteAllTextAsync(accountFilePath, json);

        await SaveAllTransactionsAsync(account.Transactions, directoryPath, account.AccountNumber);
    }

    public static async Task SaveAllAccountsAsync(IEnumerable<IBankAccount> accounts, string directoryPath)
    {
        foreach (var account in accounts)
        {
            await SaveBankAccountAsync((BankAccount)account, directoryPath);
        }
    }

    public static async Task SaveTransactionAsync(Transaction transaction, string directoryPath, int accountNumber)
    {
        string year = transaction.TransactionDate.Year.ToString();
        string month = transaction.TransactionDate.Month.ToString("D2");

        string transactionFilePath = Path.Combine(directoryPath, "Transactions", accountNumber.ToString(), $"Y{year}", $"M{month}", $"{transaction.TransactionId}.json");

        var transactionDirectoryPath = Path.GetDirectoryName(transactionFilePath);
        if (transactionDirectoryPath != null && !Directory.Exists(transactionDirectoryPath))
        {
            Directory.CreateDirectory(transactionDirectoryPath);
        }

        string json = JsonSerializer.Serialize(transaction, _options);
        await File.WriteAllTextAsync(transactionFilePath, json);
    }

    public static async Task SaveAllTransactionsAsync(IEnumerable<Transaction> transactions, string directoryPath, int accountNumber)
    {
        string transactionsFilePath = Path.Combine(directoryPath, "Transactions", $"{accountNumber}-transactions.json");

        var transactionsDirectoryPath = Path.GetDirectoryName(transactionsFilePath);
        if (transactionsDirectoryPath != null && !Directory.Exists(transactionsDirectoryPath))
        {
            Directory.CreateDirectory(transactionsDirectoryPath);
        }

        string json = JsonSerializer.Serialize(transactions, _options);
        await File.WriteAllTextAsync(transactionsFilePath, json);
    }
}