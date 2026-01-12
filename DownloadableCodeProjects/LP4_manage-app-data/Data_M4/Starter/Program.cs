using System;
using System.Linq;

namespace BankApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Bank App!");

        // TODO: Task 3: Step 3 - Update Program to create a Bank and open 2–3 accounts.

        AccountHolderDetails accountHolderDetails = new("Tim Shao", "123456789", "123 Elm Street");
        BankAccountNumber accountNumber = new BankAccountNumber("000012345678");

        BankAccount bankAccount = new(accountNumber, BankAccountType.Checking, accountHolderDetails, 500m);

        Console.WriteLine($"Account type description: {bankAccount.AccountType.GetDescription()}");
        Console.WriteLine(bankAccount.DisplayAccountInfo());

        bankAccount.AddTransaction(200m, "Deposit");
        bankAccount.AddTransaction(-50m, "ATM Withdrawal");

        // TODO: Task 5: Step 3 - Add an anonymous-type transaction report (Select(...) into new { ... }).

        // TODO: Task 5: Step 5 - Add an anonymous-type daily totals report (GroupBy(...) + Select(...)).

        // TODO: Task 5: Step 7 - Add an anonymous-type "top debits" report (Where/OrderBy/Take).

        // TODO: Task 6: Step 5 - Update Program to call bankAccount.GetDailyTotals() (named record) for API-friendly reporting.

        Console.WriteLine(bankAccount.DisplayAccountInfo());
        bankAccount.DisplayTransactions();

        AccountHolderDetails customer2 = new("Tim Shao", "123456789", "123 Elm Street");

        Console.WriteLine($"Are customers equal? {accountHolderDetails == customer2}");

        BankAccountNumber accountNumber2 = new BankAccountNumber("000123456789");
        Console.WriteLine($"Original Account Number: {accountNumber2}");

    }
}