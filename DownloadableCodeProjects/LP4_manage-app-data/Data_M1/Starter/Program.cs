using Data_M1;
using System.Globalization;

class Program
{
    static void Main()
    {
        // TASK 1: Create and Manipulate Date and Time Values
        // This task will display the output for various DateTime operations.

        // TASK 1: Step 1 - Get the current date and time, and extract date and time components
        // Placeholder for getting the current date and time, and extracting date and time components

        // TASK 1: Step 2 - Get the current day of the week and the current month and year
        // Placeholder for getting the current day of the week, and the current month and year

        // TASK 1: Step 3 - Add days to the current date and parse a date string
        // Placeholder for adding days to the current date and parsing a date string

        // TASK 1: Step 4 - Format a date and get the current timezone offset
        // Placeholder for formatting a date and getting the current timezone offset

        // TASK 1: Step 5 - Convert the current time to UTC and display it
        // Placeholder for converting the current time to UTC and displaying it

        // TASK 2: Calculate Date and Time Values for Bank Customer Transactions
        // This task will display the output for customer transactions.

        // New customer and accounts
        string firstName = "Tim";
        string lastName = "Shao";
        BankCustomer customer1 = new StandardCustomer(firstName, lastName);

        BankAccount account1 = new BankAccount(customer1.CustomerId, 10000);
        BankAccount account2 = new CheckingAccount(customer1.CustomerId, 500, 400);
        BankAccount account3 = new SavingsAccount(customer1.CustomerId, 1000);
        BankAccount account4 = new MoneyMarketAccount(customer1.CustomerId, 2000);

        BankAccount[] bankAccounts = new BankAccount[4];
        bankAccounts[0] = account1;
        bankAccounts[1] = account2;
        bankAccounts[2] = account3;
        bankAccounts[3] = account4;

        // TASK 2: Step 1 - Create a List of type Transaction
        // Placeholder for creating a List of type Transaction

        // TASK 2: Step 2 - Create a transaction for the current date and time
        // Placeholder for creating a transaction for the current date and time

        // TASK 2: Step 3 - Create a transaction for yesterday at 1:15PM
        // Placeholder for creating a transaction for yesterday at 1:15PM

        // TASK 2: Step 4 - Create transactions for the first three days of December 2024
        // Placeholder for creating transactions for the first three days of December 2024

        // TASK 2: Step 5 - Display the datedTransactions
        // Placeholder for displaying the datedTransactions

        // TASK 3: Use Date Ranges to Simulate Transactions Programmatically
        // This task will display the output for simulated transactions.

        // TASK 3: Step 1 - Define a date range starting on December 12, 2024, and ending on February 20, 2025
        // Placeholder for defining a date range

        // TASK 3: Step 2 - Generate transactions for the specified date range using the SimulateTransactions class
        // Placeholder for generating transactions for the specified date range

        // TASK 3: Step 3 - Display the simulated transactions
        // Placeholder for displaying the simulated transactions

        // TASK 3: Step 4 - Display the number of transactions processed
        // Placeholder for displaying the number of transactions processed

        // Demonstrate inheritance-based polymorphism
        Console.WriteLine("\nDemonstrating inheritance-based polymorphism:");
        foreach (BankAccount account in bankAccounts)
        {
            Console.WriteLine(account.DisplayAccountInfo());
        }
    }
}