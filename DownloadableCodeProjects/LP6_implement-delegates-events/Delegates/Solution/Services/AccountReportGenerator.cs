using System;

namespace Delegates;

public class AccountReportGenerator : IMonthlyReportGenerator, IQuarterlyReportGenerator, IYearlyReportGenerator
{
    private readonly BankAccount _account;

    public AccountReportGenerator(BankAccount account)
    {
        _account = account;
    }

    //public void GenerateMonthlyReport(BankAccount account, DateOnly reportDate)
    public void GenerateMonthlyReport(BankCustomer bankCustomer, int accountNumber, DateOnly reportDate)
    {

        foreach (BankAccount account in bankCustomer.Accounts.Cast<BankAccount>())
        {
            if (account.AccountNumber == accountNumber)
            {
                Console.WriteLine($"\nGenerating the {reportDate.ToString("MMMM")} {reportDate.Year} report for {account.AccountType} account: {account.AccountNumber}");

                // Display the properties of the account object
                Console.WriteLine($"Account Number: {account.AccountNumber}");
                Console.WriteLine($"Account Type: {account.AccountType}");

                //Console.WriteLine($"Account Balance: {account.Balance:C}");

                foreach (var transaction in account.Transactions)
                {
                    if (transaction.TransactionDate.Month == reportDate.Month && transaction.TransactionDate.Year == reportDate.Year)
                    {
                        if (transaction.TransactionDate.Day == 1)
                        {
                            double getBalance = transaction.PriorBalance;
                            Console.WriteLine($"Starting Balance on {transaction.TransactionDate}: {getBalance:C}\n");
                        }
                    }
                }

                // display transaction history
                foreach (var transaction in account.Transactions)
                {
                    try
                    {
                        if (transaction.TransactionDate.Month == reportDate.Month && transaction.TransactionDate.Year == reportDate.Year)
                        {
                            Console.WriteLine($"{transaction.ReturnTransaction()}");
                        }
                    }
                    catch (Exception ex)
                    {
                        string errorMessage = ex.Message;
                    }
                }
            }
        }
    }

    public void GenerateCurrentMonthToDateReport(BankCustomer bankCustomer, int accountNumber, DateOnly endDate)
    {
        Console.WriteLine($"\nGenerating current month-to-date report for account: {_account.AccountNumber}");
        // Logic for generating current month-to-date report based on transaction history
    }

    public void GeneratePrevious30DayReport(BankCustomer bankCustomer, int accountNumber, DateOnly endDate)
    {
        Console.WriteLine($"Generating previous 30 days report for account: {_account.AccountNumber}");
        // Logic for generating previous 30 days report based on transaction history
    }

    public void GenerateQuarterlyReport(BankCustomer bankCustomer, int accountNumber, DateOnly reportDate)
    {
        Console.WriteLine($"Generating quarterly report for account: {_account.AccountNumber}");
        // Logic for generating quarterly report based on transaction history
    }

    public void GeneratePreviousYearReport(BankCustomer bankCustomer, int accountNumber, DateOnly reportDate)
    {
        Console.WriteLine($"Generating previous year report for account: {_account.AccountNumber}");
        // Logic for generating previous year report based on transaction history
    }

    public void GenerateCurrentYearToDateReport(BankCustomer bankCustomer, int accountNumber, DateOnly endDate)
    {
        Console.WriteLine($"Generating current year-to-date report for account: {_account.AccountNumber}");
        // Logic for generating current year-to-date report based on transaction history
    }

    public void GenerateLast365DaysReport(BankCustomer bankCustomer, int accountNumber, DateOnly endDate)
    {
        Console.WriteLine($"Generating last 365 days report for account: {_account.AccountNumber}");
        // Logic for generating last 365 days report based on transaction history
    }
}