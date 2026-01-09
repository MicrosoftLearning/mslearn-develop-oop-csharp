using Data_M2;
using System.Globalization;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Bank Application - demonstrate using object collections and dictionaries.");

        // TASK 6: Create and Manage Bank, Customers, and Accounts
        // This task will set up a bank with customers, accounts, and transactions using object collections.

        // TASK 6: Step 1 - Create a Bank object
        Bank myBank = new Bank();
        Console.WriteLine($"\nBank object created...");


        // TASK 6: Step 2 - Create a BankCustomer and BankAccount using the myBank object
        Console.WriteLine($"\nUse myBank object to add a customer and an account...");
        myBank.AddCustomer(new BankCustomer("Remy", "Morris"));
        myBank.Customers[0].AddAccount(new CheckingAccount(myBank.Customers[0], myBank.Customers[0].CustomerId, 1500.00, 500.00));
        Console.WriteLine($"{myBank.Customers[0].Accounts[0].AccountType} account object created and added to {myBank.Customers[0].ReturnFullName()}'s account collection.");


        // TASK 6: Step 3 - Create BankCustomer and BankAccount objects and then add them to collections
        Console.WriteLine($"\nAdd new customer and account objects to the bank...");
        BankCustomer customer1 = new BankCustomer("Ni", "Kang");
        BankAccount account1 = new CheckingAccount(customer1, customer1.CustomerId, 1000.00, 500.00);

        customer1.AddAccount(account1);
        myBank.AddCustomer(customer1);

        foreach (BankCustomer bankCustomer in myBank.Customers)
        {
            Console.WriteLine($"{bankCustomer.ReturnFullName()} has {bankCustomer.Accounts.Count} accounts.");

        }

        // TASK 6: Step 4 - Use the myBank.Customers collection to add a SavingsAccount and MoneyMarketAccount to all customers
        Console.WriteLine($"\nUse the Customers collection to add SavingsAccount and MoneyMarketAccount to all customers...");
        foreach (BankCustomer bankCustomer in myBank.Customers)
        {
            bankCustomer.AddAccount(new SavingsAccount(bankCustomer, bankCustomer.CustomerId, 11000.00, 6));
            bankCustomer.AddAccount(new MoneyMarketAccount(bankCustomer, bankCustomer.CustomerId, 35000.00, 1000.00));
            Console.WriteLine($"{bankCustomer.ReturnFullName()} has {bankCustomer.Accounts.Count} accounts.");

        }


        // TASK 6: Step 5 - Generate two months of transactions for customer "Ni Kang"
        Console.WriteLine($"\nGenerate two months of transactions for customer \"Ni Kang\"...");
        foreach (BankCustomer bankCustomer in myBank.Customers)
        {
            if (bankCustomer.ReturnFullName() == "Ni Kang")
            {
                DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);

                DateOnly startDate = currentDate.AddMonths(-2);
                DateOnly endDate = currentDate;
                BankCustomer customer = bankCustomer;

                customer = SimulateDepositsWithdrawalsTransfers.SimulateActivityDateRange(startDate, endDate, customer);

                int totalTransactions = 0;
                foreach (BankAccount account in bankCustomer.Accounts)
                {
                    totalTransactions += account.Transactions.Count;
                }
                Console.WriteLine($"{bankCustomer.ReturnFullName()} had {totalTransactions} transactions in the past two months.");
            }
        }


        // TASK 6: Step 6 - Display all transactions for all accounts
        Console.WriteLine($"\nDisplay all transactions for all accounts...");
        foreach (BankCustomer bankCustomer in myBank.Customers)
        {
            Console.WriteLine($"\nTransactions for {bankCustomer.ReturnFullName()}:");

            foreach (BankAccount account in bankCustomer.Accounts)
            {
                Console.WriteLine($"\nAccount Type: {account.AccountType}, Account Number: {account.AccountNumber}");
                foreach (Transaction transaction in account.Transactions)
                {
                    Console.WriteLine(transaction.ReturnTransaction());
                }
            }
        }


        // TASK 7: Create a monthly statement using a HashSet and Dictionary
        // This task will create a monthly statement for a specific customer. The statement will use a HashSet
        // to track unique transfers across multiple accounts and a Dictionary to organize the monthly activity 
        // by transaction.


        // Task 7: Step 1 - Use the Customers collection to locate the customer
        Console.WriteLine("\nMonthly statement showing Transfers, Deposits, and Withdrawals...");

        BankCustomer? reportCustomer = null;
        foreach (BankCustomer bc in myBank.Customers)
        {
            if (bc.ReturnFullName() == "Ni Kang")
            {
                reportCustomer = bc;
                break;
            }
        }

        // Task 7: Step 2 - Set the reporting date range (previous month)
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        DateOnly reportStart = new DateOnly(today.Year, today.Month, 1).AddMonths(-1);
        DateOnly reportEnd = new DateOnly(reportStart.Year, reportStart.Month, DateTime.DaysInMonth(reportStart.Year, reportStart.Month));


        // Task 7: Step 3 - Create a HashSet and Dictionary to track unique transfers and organize activity
        // HashSet to track unique transfer signatures across accounts
        HashSet<string> uniqueTransferKeys = new HashSet<string>();

        // Dictionary to organize monthly activity by transaction type
        Dictionary<string, List<string>> monthlyActivity = new Dictionary<string, List<string>>
        {
            { "Deposits", new List<string>() },
            { "Withdrawals", new List<string>() },
            { "Transfers", new List<string>() }
        };


        // Task 7: Step 4 - Populate the HashSet and Dictionary with transactions
        if (reportCustomer != null)
        {
            foreach (BankAccount acct in reportCustomer.Accounts)
            {
                foreach (Transaction txn in acct.Transactions)
                {
                    if (txn.TransactionDate < reportStart || txn.TransactionDate > reportEnd)
                        continue;

                    string dateStr = txn.TransactionDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    string timeStr = txn.TransactionTime.ToString("HH:mm", CultureInfo.InvariantCulture);
                    string desc = txn.Description.Replace("-(TRANSFER)", string.Empty).Trim();

                    if (txn.TransactionType == "Transfer")
                    {
                        // Build a signature that uniquely identifies a single transfer across accounts
                        string signature = $"{dateStr}|{timeStr}|{txn.TransactionAmount:F2}|{desc}";
                        if (uniqueTransferKeys.Add(signature))
                        {
                            monthlyActivity["Transfers"].Add($"{txn.TransactionDate} {timeStr} - Transfer {txn.TransactionAmount:C} - {desc}");
                        }
                        // else: duplicate entry for the paired account; skip
                    }
                    else if (txn.TransactionType == "Deposit")
                    {
                        monthlyActivity["Deposits"].Add($"{txn.TransactionDate} {timeStr} - Deposit {txn.TransactionAmount:C} ({acct.AccountType})");
                    }
                    else if (txn.TransactionType == "Withdraw")
                    {
                        monthlyActivity["Withdrawals"].Add($"{txn.TransactionDate} {timeStr} - Withdrawal {txn.TransactionAmount:C} ({acct.AccountType})");
                    }
                }
            }

            Console.WriteLine($"\nMonthly Statement for {reportCustomer.ReturnFullName()} - {reportStart.ToString("MMMM yyyy", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Date Range: {reportStart} to {reportEnd}");
            Console.WriteLine($"Summary: Deposits={monthlyActivity["Deposits"].Count}, Withdrawals={monthlyActivity["Withdrawals"].Count}, Transfers (unique)={monthlyActivity["Transfers"].Count}");

            Console.WriteLine("\nTransfers (unique):");
            foreach (var line in monthlyActivity["Transfers"]) Console.WriteLine(line);

            Console.WriteLine("\nDeposits:");
            foreach (var line in monthlyActivity["Deposits"]) Console.WriteLine(line);

            Console.WriteLine("\nWithdrawals:");
            foreach (var line in monthlyActivity["Withdrawals"]) Console.WriteLine(line);
        }
        else
        {
            Console.WriteLine("Customer for monthly statement not found.");
        }
    }
}