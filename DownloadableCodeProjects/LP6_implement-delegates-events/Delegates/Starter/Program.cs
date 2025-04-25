using Delegates;

using System;
using System.IO;
using System.Text;
using System.Text.Json;

class Program
{
    static async Task Main()
    {
        // Create a bank object
        Bank bank = new Bank();

        // Generate 2 years of transactions for 50 customers
        await CreateDataLogsAsync.GenerateCustomerDataAsync();

        // Load the customer data asynchronously from the file
        var asyncLoadTask = LoadCustomerLogsAsync.ReadCustomerDataAsync(bank);

        // Wait for the async task to complete
        await asyncLoadTask;

        // Get the bank information
        int countBankCustomers = 0;
        int countBankAccounts = 0;
        int countBankTransactions = 0;

        foreach (var customer in bank.GetAllCustomers())
        {
            countBankCustomers++;
            foreach (var account in customer.Accounts)
            {
                countBankAccounts++;
                foreach (var transaction in account.Transactions)
                {
                    countBankTransactions++;
                }
            }
        }

        Console.WriteLine($"\nBank information...");
        Console.WriteLine($"Number of customers: {countBankCustomers}");
        Console.WriteLine($"Number of accounts: {countBankAccounts}");
        Console.WriteLine($"Number of transactions: {countBankTransactions}");
    }
}
