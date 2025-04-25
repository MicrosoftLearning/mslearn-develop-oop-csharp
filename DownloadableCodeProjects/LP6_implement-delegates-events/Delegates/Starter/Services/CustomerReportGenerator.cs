using System;

namespace Delegates;

public class CustomerReportGenerator : IMonthlyReportGenerator, IQuarterlyReportGenerator, IYearlyReportGenerator
{
    private readonly BankCustomer _customer;

    public CustomerReportGenerator(BankCustomer customer)
    {
        _customer = customer;
    }

    public void GenerateMonthlyReport(BankCustomer bankCustomer, int accountNumber, DateOnly reportDate)
    {
        Console.WriteLine($"\nGenerating the {reportDate.ToString("MMMM")} {reportDate.Year} report for customer: {_customer.ReturnFullName()}");

        // Display customer information
        Console.WriteLine($"Customer Name: {_customer.ReturnFullName()}");
        Console.WriteLine($"Customer ID: {_customer.CustomerId}");

        double customerDeposits = 0;
        double customerWithdrawals = 0;
        double customerFees = 0;
        double customerRefunds = 0;
        int customerTransactions = 0;

        foreach (BankAccount account in bankCustomer.Accounts.Cast<BankAccount>())
        {
            double accountTotalDeposits = 0;
            double accountTotalWithdrawals = 0;
            double accountTotalTransfers = 0;
            double accountTotalFees = 0;
            double accountTotalRefunds = 0;
            int accountTotalTransactions = 0;

            // Display the properties of the account objects
            Console.WriteLine($"\nInformation for account number: {account.AccountNumber}");
            Console.WriteLine($"Account Type: {account.AccountType}");
            Console.WriteLine($"Account Balance: {account.Balance:C}");

            foreach (Transaction transaction in account.Transactions)
            {
                try
                {
                    // check transaction for correct date range
                    if (transaction.TransactionDate.Month == reportDate.Month && transaction.TransactionDate.Year == reportDate.Year)
                    {
                        accountTotalTransactions++;
                        customerTransactions++;
                        switch (transaction.TransactionType)
                        {
                            case "Deposit":
                                accountTotalDeposits += transaction.TransactionAmount;
                                break;
                            case "Withdraw":
                                accountTotalWithdrawals += transaction.TransactionAmount;
                                break;
                            case "Transfer":
                                accountTotalTransfers += transaction.TransactionAmount;
                                break;
                            case "Bank Fee":
                                accountTotalFees += transaction.TransactionAmount;
                                break;
                            case "Bank Refund":
                                accountTotalRefunds += transaction.TransactionAmount;
                                break;
                            default:
                                break;
                        }

                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }

            // report the totals
            Console.WriteLine($"\n{reportDate.ToString("MMMM")} {reportDate.Year} activity for {account.AccountType} account number: {account.AccountNumber}");
            Console.WriteLine($"Total Deposits: {accountTotalDeposits:C}");
            Console.WriteLine($"Total Withdrawals: {accountTotalWithdrawals:C}");
            Console.WriteLine($"Total Transfers: {accountTotalTransfers:C}");
            Console.WriteLine($"Total Fees: {accountTotalFees:C}");
            Console.WriteLine($"Total Refunds: {accountTotalRefunds:C}");
            Console.WriteLine($"Total Transactions for {account.AccountType} account number {account.AccountNumber}: {accountTotalTransactions}");

            customerDeposits += accountTotalDeposits;
            customerWithdrawals += accountTotalWithdrawals;
            customerFees += accountTotalFees;
            customerRefunds += accountTotalRefunds;
        }

        Console.WriteLine($"\nTotal Transactions for customer {_customer.ReturnFullName()}: {customerTransactions}");

    }

    public void GenerateCurrentMonthToDateReport(BankCustomer bankCustomer, int accountNumber, DateOnly reportDate)
    {
        Console.WriteLine($"\nGenerating current month-to-date report for customer: {_customer.ReturnFullName()}");
        // Logic for generating current month-to-date report based on transaction history
    }

    public void GeneratePrevious30DayReport(BankCustomer bankCustomer, int accountNumber, DateOnly reportDate)
    {
        Console.WriteLine($"Generating previous month report for customer: {_customer.ReturnFullName()}");
        // Logic for generating previous month report based on transaction history
    }

    public void GenerateQuarterlyReport(BankCustomer bankCustomer, int accountNumber, DateOnly reportDate)
    {
        Console.WriteLine($"Generating quarterly report for customer: {_customer.ReturnFullName()}");
        // Logic for generating quarterly report based on transaction history
    }

    public void GeneratePreviousYearReport(BankCustomer bankCustomer, int accountNumber, DateOnly reportDate)
    {
        Console.WriteLine($"Generating previous year report for customer: {_customer.ReturnFullName()}");
        // Logic for generating previous year report based on transaction history
    }

    public void GenerateCurrentYearToDateReport(BankCustomer bankCustomer, int accountNumber, DateOnly reportDate)
    {
        Console.WriteLine($"Generating current year-to-date report for customer: {_customer.ReturnFullName()}");
        // Logic for generating current year-to-date report based on transaction history
    }

    public void GenerateLast365DaysReport(BankCustomer bankCustomer, int accountNumber, DateOnly reportDate)
    {
        Console.WriteLine($"Generating last 365 days report for customer: {_customer.ReturnFullName()}");
        // Logic for generating last 365 days report based on transaction history
    }
}
