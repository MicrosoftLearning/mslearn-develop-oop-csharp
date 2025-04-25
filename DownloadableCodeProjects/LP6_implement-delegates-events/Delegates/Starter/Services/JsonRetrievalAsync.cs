using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Delegates;

public static class JsonRetrievalAsync
{
    private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
    {
        MaxDepth = 64,
        ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
    };

    public static async Task<BankCustomerDTO> LoadBankCustomerDTOAsync(string filePath)
    {
        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous);
        var customerDTO = await JsonSerializer.DeserializeAsync<BankCustomerDTO>(stream, _options);

        if (customerDTO == null)
        {
            throw new Exception("Customer could not be deserialized.");
        }

        return customerDTO;
    }

    public static async Task<BankCustomer> LoadBankCustomerAsync(Bank bank, string filePath, string accountsDirectoryPath, string transactionsDirectoryPath)
    {
        var customerDTO = await LoadBankCustomerDTOAsync(filePath);

        var bankCustomer = bank.GetCustomerById(customerDTO.CustomerId);

        if (bankCustomer == null)
        {
            bankCustomer = new BankCustomer(customerDTO.FirstName, customerDTO.LastName, customerDTO.CustomerId, bank);
            bank.AddCustomer(bankCustomer);
        }

        foreach (var accountNumber in customerDTO.AccountNumbers)
        {
            var existingAccount = bankCustomer.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);

            if (existingAccount == null)
            {
                var accountFilePath = Path.Combine(accountsDirectoryPath, $"{accountNumber}.json");
                var recoveredAccount = await LoadBankAccountAsync(accountFilePath, transactionsDirectoryPath, bankCustomer);

                if (recoveredAccount != null)
                {
                    bankCustomer.AddAccount(recoveredAccount);
                }
            }
            else
            {
                bankCustomer.AddAccount(existingAccount);
            }
        }

        return bankCustomer;
    }

    public static async Task<IEnumerable<BankCustomer>> LoadAllCustomersAsync(Bank bank, string directoryPath, string accountsDirectoryPath, string transactionsDirectoryPath)
    {
        List<BankCustomer> customers = new List<BankCustomer>();
        foreach (var filePath in Directory.GetFiles(Path.Combine(directoryPath, "Customers"), "*.json"))
        {
            // the LoadBankCustomerAsync method will add the customer to the bank
            await LoadBankCustomerAsync(bank, filePath, accountsDirectoryPath, transactionsDirectoryPath);
        }
        return customers;
    }

    public static async Task<BankAccount> LoadBankAccountAsync(string accountFilePath, string transactionsDirectoryPath, BankCustomer customer)
    {
        var accountDTO = await LoadBankAccountDTOAsync(accountFilePath);

        var existingAccount = customer.Accounts.FirstOrDefault(a => a.AccountNumber == accountDTO.AccountNumber);

        if (existingAccount != null)
        {
            return (BankAccount)existingAccount;
        }
        else
        {
            var recoveredBankAccount = new BankAccount(customer, customer.CustomerId, accountDTO.Balance, accountDTO.AccountType);

            string transactionsFilePath = Path.Combine(transactionsDirectoryPath, $"{accountDTO.AccountNumber}-transactions.json");

            if (File.Exists(transactionsFilePath))
            {
                var recoveredTransactions = await LoadAllTransactionsAsync(transactionsFilePath);
                foreach (var transaction in recoveredTransactions)
                {
                    recoveredBankAccount.AddTransaction(transaction);
                }
            }

            return recoveredBankAccount;
        }
    }

    public static async Task<IEnumerable<Transaction>> LoadAllTransactionsAsync(string filePath)
    {
        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous);
        var transactions = await JsonSerializer.DeserializeAsync<IEnumerable<Transaction>>(stream, _options);

        if (transactions == null)
        {
            throw new Exception("Transactions could not be deserialized.");
        }

        return transactions;
    }

    public static async Task<BankAccountDTO> LoadBankAccountDTOAsync(string filePath)
    {
        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous);
        var accountDTO = await JsonSerializer.DeserializeAsync<BankAccountDTO>(stream, _options);

        if (accountDTO == null)
        {
            throw new Exception("Account could not be deserialized.");
        }

        return accountDTO;
    }
}

