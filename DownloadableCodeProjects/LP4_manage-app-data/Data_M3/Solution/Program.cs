using System;

namespace BankApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Bank App!");

        // TASK 4: Display basic bank account information

        // TASK 4: Step 1 - Create the AccountHolderDetails and BankAccountNumber for a new bank account.
        AccountHolderDetails accountHolderDetails = new("Tim Shao", "123456789", "123 Elm Street");
        BankAccountNumber accountNumber = new BankAccountNumber("000012345678");

        // TASK 4: Step 2 - Create a Checking account with $500 using accountHolderDetails and accountNumber.
        BankAccount bankAccount = new(accountNumber, BankAccountType.Checking, accountHolderDetails, 500m);

        // TASK 4: Step 3 - Display the account type description and account details.
        Console.WriteLine("\nTASK 4: Display basic bank account information");
        Console.WriteLine($"Account type description: {bankAccount.AccountType.GetDescription()}");
        Console.WriteLine(bankAccount.DisplayAccountInfo());

        // TASK 5: Demonstrate successful transactions
        // TASK 5: Step 1 - Use the AddTransaction method for deposits and withdrawals.
        bankAccount.AddTransaction(200m, "Deposit");
        bankAccount.AddTransaction(-50m, "ATM Withdrawal");

        // TASK 5: Step 2 - Display Account Info and Transactions
        Console.WriteLine("\nTASK 5: Demonstrate using the Transaction record");
        Console.WriteLine(bankAccount.DisplayAccountInfo());
        bankAccount.DisplayTransactions();

        // TASK 6: Demonstrate record comparison and the immutability of readonly structs
        // TASK 6: Step 1 - Create a second AccountHolderDetails object with identical properties.
        AccountHolderDetails customer2 = new("Tim Shao", "123456789", "123 Elm Street");


        // TASK 6: Step 2 - Compare the two Customer objects using the == operator.
        Console.WriteLine("\nTASK 6: Demonstrate record comparison and struct immutability");
        Console.WriteLine($"Are customers equal? {accountHolderDetails == customer2}");

        // TASK 6: Step 3 - create an instance of the readonly struct BankAccountNumber.
        BankAccountNumber accountNumber2 = new BankAccountNumber("000123456789");
        Console.WriteLine($"Original Account Number: {accountNumber2}");

        // TASK 6: Step 4 - Attempt to change the Value property of the BankAccountNumber struct.
        // accountNumber2.Value = "000987654321"; // Uncommenting this line will cause an error

    }
}