using System;
using System.Linq;

namespace BankApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Bank App!");

        // Task 3: Step 2 - Update Program to create a Bank and open 2 accounts.
        AccountHolderDetails accountHolderDetails = new("Tim Shao", "123456789", "123 Elm Street");
        BankAccountNumber accountNumber = new BankAccountNumber("000012345678");
        BankAccount bankAccount = new(accountNumber, BankAccountType.Checking, accountHolderDetails, 500m);

        // Task 3: Step 3 - Retrieve account and perform transactions.


        Console.WriteLine($"Account type description: {bankAccount.AccountType.GetDescription()}");
        Console.WriteLine(bankAccount.DisplayAccountInfo());

        bankAccount.AddTransaction(200m, "Deposit");
        bankAccount.AddTransaction(-50m, "ATM Withdrawal");

        // Task 5: Step 3 - Add an anonymous-type transaction report (Select(...) into new { ... }).


        // Task 5: Step 5 - Add an anonymous-type daily totals report (GroupBy(...) + Select(...)).


        // Task 5: Step 7 - Add an anonymous-type "top debits" report (Where/OrderBy/Take).


        // Task 6: Step 3 - Update Program to call bankAccount.GetDailyTotals() (named record) for API-friendly reporting.


        Console.WriteLine(bankAccount.DisplayAccountInfo());
        bankAccount.DisplayTransactions();

        // Task 4: Step 8 - Add Fee transactions to the account.


        AccountHolderDetails accountHolderDetails2 = new("Tim Shao", "123456789", "123 Elm Street");

        Console.WriteLine($"Are customers equal? {accountHolderDetails == accountHolderDetails2}");

        BankAccountNumber accountNumber2 = new BankAccountNumber("000123456789");
        Console.WriteLine($"Original Account Number: {accountNumber2}");

    }
}