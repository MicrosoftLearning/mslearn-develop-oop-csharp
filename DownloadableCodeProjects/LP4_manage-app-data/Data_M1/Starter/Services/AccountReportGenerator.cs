using System;

namespace Data_M1;

public class AccountReportGenerator : IMonthlyReportGenerator, IQuarterlyReportGenerator, IYearlyReportGenerator
{
    private readonly IBankAccount _account;

    public AccountReportGenerator(IBankAccount account)
    {
        _account = account;
    }

    public void GenerateMonthlyReport(Transaction[] transactions, DateOnly reportDate)
    {
        Console.WriteLine($"Generating the {reportDate.ToString("MMMM")} {reportDate.Year} report for account: {_account.AccountNumber}");

        // Display the properties of the account object
        Console.WriteLine($"Account Number: {_account.AccountNumber}");
        Console.WriteLine($"Account Type: {_account.AccountType}");
        Console.WriteLine($"Account Balance: {_account.Balance}");

        // Logic for generating monthly report based on transaction history
        foreach (var transaction in transactions)
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
                // Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    public void GenerateCurrentMonthToDateReport(Transaction[] transactions, DateOnly endDate)
    {
        Console.WriteLine($"Generating current month-to-date report for account: {_account.AccountNumber}");
        // Logic for generating current month-to-date report based on transaction history
    }

    public void GeneratePrevious30DayReport(Transaction[] transactions, DateOnly endDate)
    {
        Console.WriteLine($"Generating previous 30 days report for account: {_account.AccountNumber}");
        // Logic for generating previous 30 days report based on transaction history
    }

    public void GenerateQuarterlyReport(Transaction[] transactions, DateOnly reportDate)
    {
        Console.WriteLine($"Generating quarterly report for account: {_account.AccountNumber}");
        // Logic for generating quarterly report based on transaction history
    }

    public void GeneratePreviousYearReport(Transaction[] transactions, DateOnly reportDate)
    {
        Console.WriteLine($"Generating previous year report for account: {_account.AccountNumber}");
        // Logic for generating previous year report based on transaction history
    }

    public void GenerateCurrentYearToDateReport(Transaction[] transactions, DateOnly endDate)
    {
        Console.WriteLine($"Generating current year-to-date report for account: {_account.AccountNumber}");
        // Logic for generating current year-to-date report based on transaction history
    }

    public void GenerateLast365DaysReport(Transaction[] transactions, DateOnly endDate)
    {
        Console.WriteLine($"Generating last 365 days report for account: {_account.AccountNumber}");
        // Logic for generating last 365 days report based on transaction history
    }
}