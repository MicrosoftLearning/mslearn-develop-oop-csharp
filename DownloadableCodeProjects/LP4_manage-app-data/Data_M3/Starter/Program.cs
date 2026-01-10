using System;

namespace BankApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Bank App!");

        // TASK 4: Display basic bank account information

        // TASK 4: Step 1 - Create the AccountHolderDetails and BankAccountNumber for a new bank account.


        // TASK 4: Step 2 - Create a Checking account with $500 using accountHolderDetails and accountNumber.


        // TASK 4: Step 3 - Display the account type description and account details.


        // TASK 5: Demonstrate successful transactions
        // TASK 5: Step 1 - Use the AddTransaction method for deposits and withdrawals.


        // TASK 5: Step 2 - Display Account Info and Transactions


        // TASK 6: Demonstrate record comparison and the immutability of readonly structs
        // TASK 6: Step 1 - Create a second AccountHolderDetails object with identical properties.


        // TASK 6: Step 2 - Compare the two Customer objects using the == operator.


        // TASK 6: Step 3 - create an instance of the readonly struct BankAccountNumber.


        // TASK 6: Step 4 - Attempt to change the Value property of the BankAccountNumber struct.
        // accountNumber2.Value = "000987654321"; // Uncommenting this line will cause an error

    }
}