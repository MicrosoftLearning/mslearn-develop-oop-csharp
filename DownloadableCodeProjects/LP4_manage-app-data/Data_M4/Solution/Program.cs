using System;
using System.Linq;

namespace BankApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Bank App!");

        // TODO: Task 3: Step 3 - Update Program to create a Bank and open 2–3 accounts.

        var bank = new Bank();

        var holder1 = new AccountHolderDetails("Tim Shao", "123456789", "123 Elm Street");
        var number1 = new BankAccountNumber("000012345678");
        var checking = new BankAccount(number1, BankAccountType.Checking, holder1, 500m);
        bank.OpenAccount(checking);

        var holder2 = new AccountHolderDetails("Ava Patel", "987654321", "456 Oak Avenue");
        var number2 = new BankAccountNumber("000123456789");
        var savings = new BankAccount(number2, BankAccountType.Savings, holder2, 1200m);
        bank.OpenAccount(savings);

        // Keep a reference named `bankAccount` for the reporting tasks later in this lab.
        var bankAccount = checking;

        Console.WriteLine("\nTASK 4: Display basic bank account information");
        Console.WriteLine($"Account type description: {bankAccount.AccountType.GetDescription()}");
        Console.WriteLine(bankAccount.DisplayAccountInfo());

        bankAccount.AddTransaction(200m, "Deposit");
        bankAccount.AddTransaction(-50m, "ATM Withdrawal");

        var feeLedger = new Ledger<Fee>();
        feeLedger.Add(new Fee(-2.50m, DateTime.Now, "Monthly service fee"));
        Console.WriteLine($"Fee ledger total: {feeLedger.Total():C}");

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

        Console.WriteLine("Daily totals:");
        foreach (var day in bankAccount.GetDailyTotals())
        {
            Console.WriteLine($"{day.Day}: {day.Total:C} ({day.Count} tx)");
        }

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

        // TODO: Task 5: Step 3 - Add an anonymous-type transaction report (Select(...) into new { ... }).

        // TODO: Task 5: Step 5 - Add an anonymous-type daily totals report (GroupBy(...) + Select(...)).

        // TODO: Task 5: Step 7 - Add an anonymous-type "top debits" report (Where/OrderBy/Take).

        // TODO: Task 6: Step 5 - Update Program to call bankAccount.GetDailyTotals() (named record) for API-friendly reporting.

        Console.WriteLine("\nTASK 5: Demonstrate using the Transaction record");
        Console.WriteLine(bankAccount.DisplayAccountInfo());
        bankAccount.DisplayTransactions();

        AccountHolderDetails customer2 = new("Tim Shao", "123456789", "123 Elm Street");

        Console.WriteLine("\nTASK 6: Demonstrate record comparison and struct immutability");
        Console.WriteLine($"Are customers equal? {holder1 == customer2}");

        BankAccountNumber accountNumber2 = new BankAccountNumber("000123456789");
        Console.WriteLine($"Original Account Number: {accountNumber2}");

    }
}