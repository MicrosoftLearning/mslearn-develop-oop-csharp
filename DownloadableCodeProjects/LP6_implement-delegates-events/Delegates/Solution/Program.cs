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

        var sortedCustomers = bank.GetSortedCustomers((x, y) =>
        {
            double balanceX = x.Accounts.Sum(a => a.Balance);
            double balanceY = y.Accounts.Sum(a => a.Balance);
            return balanceY.CompareTo(balanceX); // Descending order
        });

        Console.WriteLine("\nCustomers sorted by total balance:");
        foreach (var customer in sortedCustomers)
        {
            Console.WriteLine($"{customer.ReturnFullName()} - Total Balance: {customer.Accounts.Sum(a => a.Balance):C}");
        }

        var sortedCustomersByName = bank.GetSortedCustomers((x, y) =>
        {
            int lastNameComparison = x.LastName.CompareTo(y.LastName);
            return lastNameComparison != 0 ? lastNameComparison : x.FirstName.CompareTo(y.FirstName);
        });
        
        Console.WriteLine("\nCustomers sorted by name:");
        foreach (var customer in sortedCustomersByName)
        {
            Console.WriteLine($"{customer.ReturnFullName()} - Total Balance: {customer.Accounts.Sum(a => a.Balance):C}");
        }
    }
}
