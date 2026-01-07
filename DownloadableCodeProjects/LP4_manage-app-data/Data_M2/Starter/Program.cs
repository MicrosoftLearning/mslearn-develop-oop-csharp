using Data_M2;
using System.Globalization;
using System.Collections.Generic; // TASK 7: Step 1 - Add System.Collections.Generic namespace

class Program
{
    static void Main()
    {
        // TASK 1: Create and Manage Bank, Customers, and Accounts
        // This task will set up the initial structure for the bank system.

        // TASK 1: Step 1 - Create a Bank object
        // The Bank class requires a name to be passed to its constructor.
        // Placeholder for creating a Bank object 
        // Example: Bank myBank = new Bank("MyBank");

        // TASK 1: Step 2 - Create BankCustomer and BankAccount objects
        // Placeholder for creating customers and their accounts
        // Example: BankCustomer customer1 = new BankCustomer("Alice", "Smith");

        // TASK 1: Step 3 - Add accounts to customers and customers to the bank
        // Placeholder for adding accounts to customers and customers to the bank
        // Example: myBank.AddCustomer(customer1);

        // TASK 1: Step 4 - Simulate deposits, withdrawals, and transfers
        // Placeholder for simulating transactions
        // Example: SimulateDepositWithdrawTransfer simulator = new SimulateDepositWithdrawTransfer();

        // TASK 1: Step 5 - Use a HashSet to ensure unique transactions
        // Placeholder for ensuring unique transactions
        // Example: HashSet<Transaction> uniqueTransactions = new HashSet<Transaction>();

        // TASK 1: Step 6 - Generate a report of transactions within a date range
        // Placeholder for generating a transaction report
        // Example: Console.WriteLine("\nTransaction Report:");

        // TASK 1: Step 7 - Display bank and customer information
        // Purpose: Test the program by displaying all customers and their accounts.
        // Placeholder for displaying bank and customer information with foreach loop

        // TASK 7: Use HashSet in Program.cs
        // Purpose: Ensure unique transactions in reports.

        // TASK 7: Step 2 - Identify where List<Transaction> is used for reporting
        // Placeholder for identifying and replacing any List<Transaction> used for reporting

        // TASK 7: Step 3 - Replace List<Transaction> with HashSet<Transaction> and generate a
        // report of unique transactions
        // This step ensures:
        //   - Transactions are stored in a HashSet<Transaction> to avoid duplicates.
        //   - Logic is updated to work with HashSet<Transaction> instead of List<Transaction>.
        //   - A report of unique transactions is generated and displayed.

        // TASK 8: Generate Reports in Program.cs
        // Purpose: Loop through customers, accounts, and transactions to generate date-range reports.

        // TASK 8: Step 1 - Define a date range for the report
        DateOnly startDate = new DateOnly(2025, 1, 1); // Example start date
        DateOnly endDate = new DateOnly(2025, 12, 31); // Example end date


        // TASK 8: Step 2 - Loop through customers, accounts, and filter transactions by date range
        // This step performs the following:
        //   - Loops through each customer and their accounts.
        //   - Filters transactions within the specified date range.
        //   - Displays the transaction details for each filtered transaction.

        // Test code to ensure the program runs
        // Example: Create a BankCustomer and display their information

        // TASK 9: Handle Transfer Duplication
        // Purpose: Avoid counting the same transfer twice in reports.
        // This step ensures:
        //   - Transfers between accounts are only counted once.
        //   - A HashSet<Transaction> is used to track unique transfer transactions.
        //   - The Transaction class does not include SourceAccount or TargetAccount properties,
        //   - so only basic transfer details are displayed.

        // TASK 9: Step 1 - Create a HashSet to store unique transfer transactions
        // Placeholder for creating a HashSet<Transaction> for unique transfers

        // TASK 9: Step 2 - Loop through customers and their accounts
        // Placeholder for looping through customers and accounts

        // TASK 9: Step 3 - Filter transfer transactions and add them to the HashSet
        // Placeholder for filtering transfer transactions and adding them to the HashSet

        // TASK 9: Step 4 - Display the unique transfer transactions
        // Placeholder for displaying unique transfer transactions

        // TASK 10: Add Dictionary for Reports
        // Purpose: Manage transaction data for reports in the Bank class.

        // TASK 10: Step 1 - Populate the dictionary with transaction data
        // Placeholder for populating the dictionary with transaction data

        // TASK 10: Step 2 - Retrieve and display transactions from the dictionary
        // Placeholder for retrieving and displaying transactions from the dictionary

        BankCustomer exampleCustomer = new BankCustomer("Isabel", "Robledo");
        Console.WriteLine($"Example Customer Created: {exampleCustomer.FirstName} {exampleCustomer.LastName}");

        // Example: Use a method from the BankCustomer class
        exampleCustomer.AddAccount(new BankAccount("Savings", 1000.00));
        Console.WriteLine($"Account added for {exampleCustomer.FirstName} with balance: {exampleCustomer.Accounts[0].Balance}");
    }
}