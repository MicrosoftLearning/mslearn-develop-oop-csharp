using System;
using System.Linq;

namespace BankApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Bank App!");

        // Task 3: Step 2 - Update Program to create a Bank and open 2 accounts.
        var bank = new Bank();

        var accountHolderDetails = new AccountHolderDetails("Tim Shao", "123456789", "123 Elm Street");
        var accountNumber = new BankAccountNumber("000012345678");
        var checking = new BankAccount(accountNumber, BankAccountType.Checking, accountHolderDetails, 500m);

        var accountHolderDetails3 = new AccountHolderDetails("Ni Kang", "987654321", "456 Oak Avenue");
        var accountNumber3 = new BankAccountNumber("000123456789");
        var savings = new BankAccount(accountNumber3, BankAccountType.Savings, accountHolderDetails3, 1200m);

        bank.OpenAccount(checking);
        bank.OpenAccount(savings);

        // Keep a reference named `bankAccount` for the reporting tasks later in this lab.
        var bankAccount = checking;

        // Task 3: Step 3 - Retrieve account and perform transactions.
        var selected = bank.GetAccount(accountNumber);
        selected.AddTransaction(200m, "Deposit");
        selected.AddTransaction(-50m, "ATM Withdrawal");
        Console.WriteLine(selected.DisplayAccountInfo());

        Console.WriteLine($"Account type description: {bankAccount.AccountType.GetDescription()}");
        Console.WriteLine(bankAccount.DisplayAccountInfo());

        bankAccount.AddTransaction(200m, "Deposit");
        bankAccount.AddTransaction(-50m, "ATM Withdrawal");

        // Task 4: Step 8 - Add Fee transactions to the account.
        var feeLedger = new Ledger<Fee>();
        feeLedger.Add(new Fee(-2.50m, DateTime.Now, "Monthly service fee"));
        Console.WriteLine($"Fee ledger total: {feeLedger.Total():C}");

        // Task 5: Step 1 - Add an anonymous-type transaction report (Select(...) into new { ... }).
        var rows = bankAccount.Transactions
            .Select(t => new
            {
                t.Date,
                t.Description,
                t.Amount,
                Kind = t.Amount >= 0 ? "Credit" : "Debit"
            });

        Console.WriteLine("Transaction report:");
        foreach (var row in rows)
        {
            Console.WriteLine($"{row.Date:d} | {row.Kind,-6} | {row.Amount,10:C} | {row.Description}");
        }


        // Task 6: Step 3 - Update Program to call bankAccount.GetDailyTotals() (named record) for API-friendly reporting.
        Console.WriteLine("Daily totals:");
        foreach (var day in bankAccount.GetDailyTotals())
        {
            Console.WriteLine($"{day.Day}: {day.Total:C} ({day.Count} tx)");
        }

        // Task 5: Step 3 - Add an anonymous-type "top debits" report (Where/OrderBy/Take).
        var topDebits = bankAccount.Transactions
            .Where(t => t.Amount < 0)
            .OrderBy(t => t.Amount)
            .Take(3)
            .Select(t => new { t.Date, t.Description, t.Amount });

        Console.WriteLine("Top debits:");
        foreach (var d in topDebits)
        {
            Console.WriteLine($"{d.Date:d} | {d.Amount,10:C} | {d.Description}");
        }


        Console.WriteLine(bankAccount.DisplayAccountInfo());
        bankAccount.DisplayTransactions();

        AccountHolderDetails accountHolderDetails2 = new("Tim Shao", "123456789", "123 Elm Street");

        Console.WriteLine($"Are customers equal? {accountHolderDetails == accountHolderDetails2}");

        BankAccountNumber accountNumber2 = new BankAccountNumber("000123456789");
        Console.WriteLine($"Original Account Number: {accountNumber2}");

    }
}