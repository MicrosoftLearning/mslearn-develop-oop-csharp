using Data_M1;
using System.Globalization;

class Program
{
    static void Main()
    {
        // Prepare banking objects 
        string firstName = "Tim";
        string lastName = "Shao";
        BankCustomer customer1 = new StandardCustomer(firstName, lastName);

        BankAccount account1 = new BankAccount(customer1.CustomerId, 10000);
        BankAccount account2 = new CheckingAccount(customer1.CustomerId, 500, 400);
        BankAccount account3 = new SavingsAccount(customer1.CustomerId, 1000);

        BankAccount[] bankAccounts = new BankAccount[4];
        bankAccounts[0] = account1;
        bankAccounts[1] = account2;
        bankAccounts[2] = account3;

        Transaction[] datedTransactions = new Transaction[5];

        // Begin date and time operations
        Console.WriteLine("\nDemonstrate date and time operations:");

        // TASK 1: Create and Manipulate Date and Time Values
        // TASK 1: Step 1 - Get the current date and time, and extract date and time components
    

        // TASK 1: Step 2 - Get the current day of the week and the current month and year


        // TASK 1: Step 3 - Add days to the current date and parse a date string


        // TASK 1: Step 4 - Format a date and get the current timezone offset


        // TASK 1: Step 5 - Convert the current time to UTC and display it


        // TASK 2: Calculate Date and Time Values for Bank Customer Transactions
        // This task will display the output for customer transactions.

        // TASK 2: Step 1 - Create a transaction for the current date and time


        // TASK 2: Step 2 - Create a transaction for yesterday at 1:15PM


        // TASK 2: Step 3 - Create transactions for the first three days of December 2025


        // TASK 2: Step 4 - Display the datedTransactions


        // TASK 3: Use Date Ranges to Simulate Transactions Programmatically
        // TASK 3: Step 1 - Define a date range starting on October 12, 2025, and ending on December 20, 2025


        // TASK 3: Step 2 - Generate transactions for the specified date range using the SimulateTransactions class


        // TASK 3: Step 3 - Display the simulated transactions


        // TASK 3: Step 4 - Display the number of transactions processed


    }
}