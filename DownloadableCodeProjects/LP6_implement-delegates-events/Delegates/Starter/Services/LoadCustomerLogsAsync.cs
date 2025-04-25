using System;
using System.IO;
using System.Threading.Tasks;

namespace Delegates
{
    public class LoadCustomerLogsAsync
    {
        public static async Task ReadCustomerDataAsync(Bank bank)
        {
            string configDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Config");
            string customersDirectoryPath = Path.Combine(configDirectoryPath, "Customers");
            string accountsDirectoryPath = Path.Combine(configDirectoryPath, "Accounts");
            string transactionsDirectoryPath = Path.Combine(configDirectoryPath, "Transactions");

            var customers = await JsonRetrievalAsync.LoadAllCustomersAsync(bank, configDirectoryPath, accountsDirectoryPath, transactionsDirectoryPath);
            foreach (var customer in customers)
            {
                bank.AddCustomer(customer);
            }
        }
    }
}