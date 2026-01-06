using System;

namespace Data_M1;

public class CustomerReportGenerator //: IMonthlyReportGenerator, IQuarterlyReportGenerator, IYearlyReportGenerator
{
    private readonly IBankCustomer _customer;

    public CustomerReportGenerator(IBankCustomer customer)
    {
        _customer = customer;
    }

    public void GenerateMonthlyReport(BankAccount account1, Transaction[] transactions1, DateOnly reportDate, BankAccount account2)
    {
        Console.WriteLine($"\nGenerating the {reportDate.ToString("MMMM")} {reportDate.Year} report for customer: {_customer.ReturnFullName()}");

        // Display customer information
        Console.WriteLine($"Customer Name: {_customer.ReturnFullName()}");
        Console.WriteLine($"Customer ID: {_customer.CustomerId}");

        // Display the properties of the account object
        Console.WriteLine($"Information for account number: {account1.AccountNumber}");
        Console.WriteLine($"Account Type: {account1.AccountType}");
        Console.WriteLine($"Account Balance: {account1.Balance}");

        // Calculate the total deposits, withdrawals, fees, and refunds for accounts
        double account1TotalDeposits = 0;
        double account1TotalWithdrawals = 0;
        double account1TotalFees = 0;
        double account1TotalRefunds = 0;
        int account1TotalTransactions = 0;

        double account2TotalDeposits = 0;
        double account2TotalWithdrawals = 0;
        double account2TotalFees = 0;
        double account2TotalRefunds = 0;
        int account2TotalTransactions = 0;

        int customerTransactionCount = 0;

        foreach (var transaction in transactions1)
        {
            try
            {
                // check transaction for correct date range
                if (transaction.TransactionDate.Month == reportDate.Month && transaction.TransactionDate.Year == reportDate.Year)
                {
                    // check for SourceAccountNumber == TargetAccountNumber AND SourceAccountNumber == account1.AccountNumber
                    if (transaction.SourceAccountNumber == transaction.TargetAccountNumber && transaction.SourceAccountNumber == account1.AccountNumber)
                    {
                        account1TotalTransactions++;
                        customerTransactionCount++;
                        switch (transaction.TransactionType)
                        {
                            case "Deposit":
                                account1TotalDeposits += transaction.TransactionAmount;
                                break;
                            case "Withdraw":
                                account1TotalWithdrawals += transaction.TransactionAmount;
                                break;
                            case "Bank Fee":
                                account1TotalFees += transaction.TransactionAmount;
                                break;
                            case "Bank Refund":
                                account1TotalRefunds += transaction.TransactionAmount;
                                break;
                            default:
                                break;
                        }
                    }
                    // check for SourceAccountNumber == TargetAccountNumber AND SourceAccountNumber == account2.AccountNumber
                    else if (transaction.SourceAccountNumber == transaction.TargetAccountNumber && transaction.SourceAccountNumber == account2.AccountNumber)
                    {
                        account2TotalTransactions++;
                        customerTransactionCount++;
                        switch (transaction.TransactionType)
                        {
                            case "Deposit":
                                account2TotalDeposits += transaction.TransactionAmount;
                                break;
                            case "Withdraw":
                                account2TotalWithdrawals += transaction.TransactionAmount;
                                break;
                            case "Bank Fee":
                                account2TotalFees += transaction.TransactionAmount;
                                break;
                            case "Bank Refund":
                                account2TotalRefunds += transaction.TransactionAmount;
                                break;
                            default:
                                break;
                        }
                    }
                    // check for SourceAccountNumber == account1.AccountNumber AND TargetAccountNumber == account2.AccountNumber
                    else if (transaction.SourceAccountNumber == account1.AccountNumber && transaction.TargetAccountNumber == account2.AccountNumber)
                    {
                        account1TotalTransactions++;
                        account2TotalTransactions++;
                        customerTransactionCount++;
                        switch (transaction.TransactionType)
                        {
                            case "Transfer":
                                account1TotalWithdrawals += transaction.TransactionAmount;
                                account2TotalDeposits += transaction.TransactionAmount;
                                break;
                            default:
                                break;
                        }
                    }
                    // check for SourceAccountNumber == account2.AccountNumber AND TargetAccountNumber == account1.AccountNumber
                    else if (transaction.SourceAccountNumber == account2.AccountNumber && transaction.TargetAccountNumber == account1.AccountNumber)
                    {
                        account1TotalTransactions++;
                        account2TotalTransactions++;
                        customerTransactionCount++;
                        switch (transaction.TransactionType)
                        {
                            case "Transfer":
                                account2TotalWithdrawals += transaction.TransactionAmount;
                                account1TotalDeposits += transaction.TransactionAmount;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // report the totals
        Console.WriteLine($"\nActivity for {account1.AccountType} account number: {account1.AccountNumber}");
        Console.WriteLine($"Total Deposits: {account1TotalDeposits:C}");
        Console.WriteLine($"Total Withdrawals: {account1TotalWithdrawals:C}");
        Console.WriteLine($"Total Fees: {account1TotalFees:C}");
        Console.WriteLine($"Total Refunds: {account1TotalRefunds:C}");

        Console.WriteLine($"\nActivity for {account2.AccountType} account number: {account2.AccountNumber}");
        Console.WriteLine($"Total Deposits: {account2TotalDeposits:C}");
        Console.WriteLine($"Total Withdrawals: {account2TotalWithdrawals:C}");
        Console.WriteLine($"Total Fees: {account2TotalFees:C}");
        Console.WriteLine($"Total Refunds: {account2TotalRefunds:C}");

        Console.WriteLine($"\nTotal Transactions for {account1.AccountType} account number {account1.AccountNumber}: {account1TotalTransactions}");
        Console.WriteLine($"Total Transactions for {account2.AccountType} account number {account2.AccountNumber}: {account2TotalTransactions}");

        Console.WriteLine($"\nTotal Transactions for customer {_customer.ReturnFullName()}: {customerTransactionCount}");
    }

    public void GenerateCurrentMonthToDateReport()
    {
        Console.WriteLine($"\nGenerating current month-to-date report for customer: {_customer.ReturnFullName()}");
        // Logic for generating current month-to-date report based on transaction history
    }

    public void GeneratePrevious30DayReport()
    {
        Console.WriteLine($"\nGenerating previous month report for customer: {_customer.ReturnFullName()}");
        // Logic for generating previous month report based on transaction history
    }

    public void GenerateQuarterlyReport()
    {
        Console.WriteLine($"\nGenerating quarterly report for customer: {_customer.ReturnFullName()}");
        // Logic for generating quarterly report based on transaction history
    }

    public void GeneratePreviousYearReport()
    {
        Console.WriteLine($"\nGenerating previous year report for customer: {_customer.ReturnFullName()}");
        // Logic for generating previous year report based on transaction history
    }

    public void GenerateCurrentYearToDateReport()
    {
        Console.WriteLine($"\nGenerating current year-to-date report for customer: {_customer.ReturnFullName()}");
        // Logic for generating current year-to-date report based on transaction history
    }

    public void GenerateLast365DaysReport()
    {
        Console.WriteLine($"\nGenerating last 365 days report for customer: {_customer.ReturnFullName()}");
        // Logic for generating last 365 days report based on transaction history
    }
}
/*

SourceAccountNumber

*/