---
lab:
    title: 'Exercise - Implement Collection Types'
    description: 'Learn how to implement and use collection types in C#. Explore using List, Dictionary, HashSet, and other collection types to manage data effectively.'
---

# Implement Collection Types

Collections are essential in software development for managing and organizing data. In this exercise, you will implement and use various collection types in a C# console application. You will explore using `List`, `Dictionary`, `HashSet`, and other collection types to manage customers, accounts, and transactions in a banking application.

This exercise takes approximately **30** minutes to complete.

## Before you start

Before you can start this exercise, you need to:

1. Ensure that you have the latest short term support (STS) version of the .NET SDK installed on your computer. You can download the latest versions of the .NET SDK using the following URL: <a href="https://dotnet.microsoft.com/download/" target="_blank">Download .NET</a>

1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code using the following URL: <a href="https://code.visualstudio.com/download/" target="_blank">Download Visual Studio Code</a>

1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For additional help configuring the Visual Studio Code environment, see <a href="https://learn.microsoft.com/training/modules/install-configure-visual-studio-code/" target="_blank">Install and configure Visual Studio Code for C# development</a>

## Exercise scenario

Suppose you're a software developer at a tech company working on a banking application. Your team needs to implement collection types to manage customers, accounts, and transactions for bank locations. You create a console application to prototype app features.

Your prototype app includes the following files:

- `Program.cs`: This file provides the main entry point to the application and is used to evaluate new app features or functionality.
- `Bank.cs`: This file defines the Bank class and will be used to manage customer and transaction collections for bank locations.
- `BankAccount.cs`: This file defines the BankAccount class, which implements the IBankAccount interface and includes properties, constructors, and methods for account operations.
- `BankCustomer.cs`: This file defines the BankCustomer partial class, which implements the IBankCustomer interface and includes properties and constructors for customer operations.
- `BankCustomerMethods.cs`: This file defines the BankCustomerMethods partial class, which implements the IBankCustomer interface and contains methods for the BankCustomer class.
- `CheckingAccount.cs`: This file defines the CheckingAccount class, which inherits from the BankAccount class and includes properties and methods specific to checking accounts.
- `MoneyMarketAccount.cs`: This file defines the MoneyMarketAccount class, which inherits from the BankAccount class and includes properties and methods specific to money market accounts.
- `SavingsAccount.cs`: This file defines the SavingsAccount class, which inherits from the BankAccount class and includes properties and methods specific to savings accounts.
- `Transaction.cs`: This file defines the Transaction class, which includes properties and methods for managing transactions.
- `SimulateDepositWithdrawTransfer.cs`: This file contains methods for simulating deposits, withdrawals, and transfers.
- `SimulateTransactions.cs`: This file contains methods for simulating various banking transactions.

This exercise includes the following tasks:

1. Review the banking application project.
1. Implement the Bank class.
1. Update the BankCustomer class.
1. Update the BankAccount class.
1. Update the SimulateDepositWithdrawTransfer class.
1. Create and manage bank objects with customers and accounts.
1. Use a HashSet to ensure unique transactions.
1. Generate transaction reports using a Dictionary.

## Review the banking application project

In this task, you download the existing version of your banking project and review the code.

Use the following steps to complete this section of the exercise:

1. Download the starter code from the following URL: [Implement collection types - exercise code projects](https://github.com/MicrosoftLearning/mslearn-develop-oop-csharp/raw/refs/heads/main/DownloadableCodeProjects/Downloads/LP4SampleApps.zip)

1. Extract the contents of the LP4SampleApps.zip file to a folder location on your computer.

1. Expand the LP4SampleApps folder, and then open the `Data_M2` folder.

    The Data_M2 folder contains the following code project folders:

    - Solution
    - Starter

    The **Starter** folder contains the starter project files for this exercise.

1. Use Visual Studio Code to open the **Starter** folder.

1. In the EXPLORER view, collapse the **STARTER** folder, select **SOLUTION EXPLORER**, and expand the **Data_M2** project.

    You should see the following project files:

    - Interfaces (folder)
    - Models (folder)
    - Services (folder)
    - Program.cs

1. Take a couple minutes to review the contents of the Interfaces folder.

    - `Interfaces`: The interface files define the core contracts for the banking domain: account behavior and state in IBankAccount.cs, customer interactions in IBankCustomer.cs, and reporting abstractions in IMonthlyReportGenerator.cs, IQuarterlyReportGenerator.cs, and IYearlyReportGenerator.cs. These interfaces decouple the codebase by allowing concrete implementations in Models (various account and customer types) and Services (calculations and report generation) to be swapped or extended without changing consumers like Program.cs or transaction simulators, promoting testability and clear separation of concerns.

1. Take a couple minutes to review the contents of the Models folder.

    - `Models`: The Models folder contains the concrete domain types and behaviors that implement the banking contracts and drive the app’s logic: the bank and customers in Bank.cs and BankCustomer.cs, the account base and variants in BankAccount.cs, CheckingAccount.cs, SavingsAccount.cs, MoneyMarketAccount.cs, and CertificateOfDepositAccount.cs, plus transactional primitives and helpers in Transaction.cs and BankCustomerMethods.cs. It also includes a lightweight workflow harness in SimulateDepositWithdrawTransfer.cs for exercising core operations. Together, these classes realize the IBankAccount/IBankCustomer contracts from Interfaces and supply the state and business rules consumed by Services for calculations and reporting.

1. Take a couple minutes to review the contents of the Services folder.

    - `Services`: The Services folder encapsulates application-level logic built on the domain models and interface contracts: AccountCalculations.cs centralizes balance/interest/fee computations; AccountReportGenerator.cs and CustomerReportGenerator.cs generate monthly/quarterly/yearly outputs aligning with the reporting interfaces; Extensions.cs provides helper extension methods; and SimulateTransactions.cs orchestrates example deposit/withdraw/transfer flows. These services consume model implementations of IBankAccount and IBankCustomer and are invoked by Program.cs and simulators, keeping business rules centralized, reusable, and decoupled from UI or storage concerns.

1. Take a minute to review the Program.cs file.

    - `Program.cs`: Program.cs serves as the application entry point and orchestrator, wiring together Interfaces, Models, and Services to run the sample banking workflow. It constructs the core domain objects (bank, customers, and accounts), invokes service routines for calculations and report generation, and drives transaction simulations to demonstrate behavior end-to-end. In short, it coordinates execution and output, exercising the concrete implementations behind the interface contracts to showcase the system’s business logic.

1. Run the app and review the output in the terminal window.

    To run your app, right-click the **Data_M2** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    > **TIP**: If you encounter any issues while completing this exercise, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code. If you're still having trouble, you can review the solution code in the sample apps that you downloaded at the beginning of this exercise. To view the Data_M2 solution, navigate to the LP4SampleApps/Data_M2/Solution folder and open the Solution project in Visual Studio Code.

## Task 2: Implement the Bank class

You will implement functionality to manage customers and transaction reports in the `Bank` class. Each step aligns with a `// Task 2` comment in the `Bank.cs` file to help you locate where to add the code.

1. Open the `Bank.cs` file and locate the `// Task 2` comment.

1. Add the following code below the comment:

   ```csharp
   public string Name { get; set; }
   public List<BankCustomer> Customers { get; set; } = new List<BankCustomer>();
   ```

   > **NOTE**: This code adds a property for the bank's name and a list to store its customers.

1. To create a method for adding customers to a bank object, add the following code:

   ```csharp
   public void AddCustomer(BankCustomer customer)
   {
       Customers.Add(customer);
   }
   ```

   > **NOTE**: This method allows you to add a customer to the bank.

1. To create a dictionary that stores transaction reports, add the following code:

   ```csharp
   public Dictionary<string, List<Transaction>> TransactionReports { get; set; } = new Dictionary<string, List<Transaction>>();
   ```

   > **NOTE**: This dictionary will be used to generate transaction reports.

1. Save the Bank.cs file.

1. Build and run the application.

    Ensure that the project builds successfully without errors. If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

    The functionality implemented in this task will be used in subsequent tasks.

## Task 3: Update the BankCustomer class

You will update the `BankCustomer` class to manage customer accounts. Each step aligns with a `// Task 3` comment in the `BankCustomer.cs` file to help you locate where to add the code.

1. **Add a list of accounts**  
   Open the `BankCustomer.cs` file and locate the `// Task 3` comment. Add the following code below it:

   ```csharp
   public List<BankAccount> Accounts { get; set; } = new List<BankAccount>();
   ```

   > **NOTE**: This property stores the accounts associated with the customer.

1. **Add a method to add accounts**  
   Below the property, add the following method:

   ```csharp
   public void AddAccount(BankAccount account)
   {
       Accounts.Add(account);
   }
   ```

   > **NOTE**: This method allows you to add an account to the customer.

1. Save the BankCustomer.cs file.

1. Build and run the application.

    Ensure that the project builds successfully without errors. If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

    The functionality implemented in this task will be used in subsequent tasks.

## Task 4: Update the BankAccount class

You will update the `BankAccount` class to manage transactions. Each step aligns with a `// Task 4` comment in the `BankAccount.cs` file to help you locate where to add the code.

1. **Add a list of transactions**  
   Open the `BankAccount.cs` file and locate the `// Task 4` comment. Add the following code below it:

   ```csharp
   public List<Transaction> Transactions { get; set; } = new List<Transaction>();
   ```

   > **NOTE**: This property stores the transactions associated with the bank account.

1. **Add a method to add transactions**  
   Below the property, add the following method:

   ```csharp
   public void AddTransaction(Transaction transaction)
   {
       Transactions.Add(transaction);
   }
   ```

   > **NOTE**: This method allows you to add a transaction to the account.

1. Save the BankAccount.cs file.

1. Build and run the application.

    Ensure that the project builds successfully without errors. If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

    The functionality implemented in this task will be used in subsequent tasks.

## Task 5: Create the Transaction class

You will create the `Transaction` class to represent deposits, withdrawals, and transfers. Each step aligns with a `// Task 5` comment in the `Transaction.cs` file to help you locate where to add the code.

1. **Add properties for transaction details**  
   Open the `Transaction.cs` file and locate the `// Task 5` comment. Add the following code below it:

   ```csharp
   public string TransactionId { get; set; }
   public DateTime Date { get; set; }
   public string Type { get; set; }
   public double Amount { get; set; }
   ```

   > **NOTE**: These properties represent the details of a transaction, including its ID, date, type, and amount.

1. **Add a constructor to initialize transaction details**  
   Below the properties, add the following constructor:

   ```csharp
   public Transaction(string transactionId, DateTime date, string type, double amount)
   {
       TransactionId = transactionId;
       Date = date;
       Type = type;
       Amount = amount;
   }
   ```

   > **NOTE**: This constructor initializes a transaction with the provided details.

1. Save the Transaction.cs file.

1. Build and run the application.

    Ensure that the project builds successfully without errors. If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

    The functionality implemented in this task will be used in subsequent tasks.

## Task 6: Create the SimulateDepositWithdrawTransfer class

You will create the `SimulateDepositWithdrawTransfer` class to simulate deposits, withdrawals, and transfers. Each step aligns with a `// Task 6` comment in the `SimulateDepositWithdrawTransfer.cs` file to help you locate where to add the code.

1. **Add a method to simulate deposits**  
   Open the `SimulateDepositWithdrawTransfer.cs` file and locate the `// Task 6` comment. Add the following code below it:

   ```csharp
   public void SimulateDeposit(BankAccount account, double amount)
   {
       var transaction = new Transaction(
           Guid.NewGuid().ToString(),
           DateTime.Now,
           "Deposit",
           amount
       );
       account.AddTransaction(transaction);
   }
   ```

   > **NOTE**: This method creates a deposit transaction and adds it to the specified account.

1. **Add a method to simulate withdrawals**  
   Below the deposit method, add the following code:

   ```csharp
   public void SimulateWithdrawal(BankAccount account, double amount)
   {
       var transaction = new Transaction(
           Guid.NewGuid().ToString(),
           DateTime.Now,
           "Withdrawal",
           amount
       );
       account.AddTransaction(transaction);
   }
   ```

   > **NOTE**: This method creates a withdrawal transaction and adds it to the specified account.

1. **Add a method to simulate transfers**  
   Below the withdrawal method, add the following code:

   ```csharp
   public void SimulateTransfer(BankAccount fromAccount, BankAccount toAccount, double amount)
   {
       var withdrawal = new Transaction(
           Guid.NewGuid().ToString(),
           DateTime.Now,
           "Transfer Out",
           amount
       );
       fromAccount.AddTransaction(withdrawal);

       var deposit = new Transaction(
           Guid.NewGuid().ToString(),
           DateTime.Now,
           "Transfer In",
           amount
       );
       toAccount.AddTransaction(deposit);
   }
   ```

   > **NOTE**: This method creates a transfer transaction, withdrawing from one account and depositing into another.

1. Save the SimulateDepositWithdrawTransfer.cs file.

1. Build and run the application.

    Ensure that the project builds successfully without errors. If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

    The functionality implemented in this task will be used in subsequent tasks.

## Create and manage bank objects with customers and accounts

You will implement functionality to create `Bank`, `BankCustomer`, and `BankAccount` objects, add accounts to customers and customers to the bank, simulate transactions, ensure unique transactions using a `HashSet`, and generate a report of transactions within a date range. Each step aligns with a `// Task 1` comment in the `Program.cs` file to help you locate where to add the code.

1. **Create a `Bank` object**  
   Open the `Program.cs` file and locate the `// Task 1` comment. Add the following code below it:

   ```csharp
   // Task 1: Create a Bank object
   Bank myBank = new Bank("MyBank");
   ```

   > **NOTE**: This creates a bank named "MyBank" that will hold customers and their accounts.

1. **Create `BankCustomer` and `BankAccount` objects**  
   Add the following code below the previous step:

   ```csharp
   // Task 1: Create BankCustomer and BankAccount objects
   BankCustomer customer1 = new BankCustomer("Alice", "Smith");
   BankAccount account1 = new CheckingAccount(customer1.CustomerId, 1000);
   ```

   > **NOTE**: This creates a customer named Alice Smith and a checking account with a $1,000 balance.

1. **Add accounts to customers and customers to the bank**  
   Add the following code below the previous step:

   ```csharp
   // Task 1: Add accounts to customers and customers to the bank
   customer1.AddAccount(account1);
   myBank.AddCustomer(customer1);
   ```

   > **NOTE**: This links the account to the customer and the customer to the bank.

1. **Simulate deposits, withdrawals, and transfers**  
   Add the following code below the previous step:

   ```csharp
   // Task 1: Simulate deposits, withdrawals, and transfers
   SimulateDepositWithdrawTransfer simulator = new SimulateDepositWithdrawTransfer();
   simulator.SimulateDeposit(account1, 500);
   simulator.SimulateWithdrawal(account1, 300);
   ```

   > **NOTE**: This adds $500 to the account and then removes $300.

1. **Use a `HashSet` to ensure unique transactions**  
   Add the following code below the previous step:

   ```csharp
   // Task 1: Use a HashSet to ensure unique transactions
   HashSet<Transaction> uniqueTransactions = new HashSet<Transaction>(account1.Transactions);
   ```

   > **NOTE**: This ensures that duplicate transactions are not added to the list.

1. **Generate a report of transactions within a date range**  
   Add the following code below the previous step:

   ```csharp
   // Task 1: Generate a report of transactions within a date range
   Console.WriteLine("\nTransaction Report:");
   foreach (var transaction in uniqueTransactions)
   {
       Console.WriteLine($"Transaction ID: {transaction.TransactionId}, Type: {transaction.Type}, Amount: {transaction.Amount:C}, Date: {transaction.Date}");
   }
   ```

   > **NOTE**: This displays all unique transactions for the account.

1. Save the Program.cs file.

1. Build and run the application.

    Ensure that the project builds successfully without errors. If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

1. Review the output in the terminal window.

    Your app should produce output similar to the following:

    ```plaintext
    Transaction Report:
    Transaction ID: 1, Type: Deposit, Amount: $500.00, Date: 3/14/2025
    Transaction ID: 2, Type: Withdrawal, Amount: $300.00, Date: 3/14/2025
    ```

## Task 7: Use a HashSet to ensure unique transactions

You will use a `HashSet` to ensure that transactions are unique. Each step aligns with a `// Task 7` comment in the `Program.cs` file to help you locate where to add the code.

1. **Create a `HashSet` for unique transactions**  
   Open the `Program.cs` file and locate the `// Task 7` comment. Add the following code below it:

   ```csharp
   HashSet<Transaction> uniqueTransactions = new HashSet<Transaction>(account1.Transactions);
   ```

   > **NOTE**: This creates a `HashSet` from the transactions in `account1`, ensuring that duplicate transactions are not added.

1. **Display unique transactions**  
   Below the `HashSet` creation, add the following code:

   ```csharp
   Console.WriteLine("\nUnique Transactions:");
   foreach (var transaction in uniqueTransactions)
   {
       Console.WriteLine($"Transaction ID: {transaction.TransactionId}, Type: {transaction.Type}, Amount: {transaction.Amount:C}, Date: {transaction.Date}");
   }
   ```

   > **NOTE**: This displays all unique transactions in the `HashSet`.

1. Save the Program.cs file.

1. Build and run the application.

    Ensure that the project builds successfully without errors. If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

1. Review the output in the terminal window.

    Your app should produce output similar to the following:

    ```plaintext
    Unique Transactions:
    Transaction ID: 1, Type: Deposit, Amount: $500.00, Date: 3/14/2025
    Transaction ID: 2, Type: Withdrawal, Amount: $300.00, Date: 3/14/2025
    ```

## Task 8: Generate transaction reports using a `Dictionary`

You will generate transaction reports using a `Dictionary` to group transactions by account. Each step aligns with a `// Task 8` comment in the `Program.cs` file to help you locate where to add the code.

### Task 8 Steps

1. **Create a `Dictionary` to group transactions by account**  
   Open the `Program.cs` file and locate the `// Task 8` comment. Add the following code below it:

   ```csharp
   Dictionary<string, List<Transaction>> transactionReports = new Dictionary<string, List<Transaction>>();
   ```

   > **NOTE**: This dictionary will group transactions by account number.

1. **Populate the `Dictionary` with transactions**  
   Below the dictionary creation, add the following code:

   ```csharp
   foreach (var customer in myBank.Customers)
   {
       foreach (var account in customer.Accounts)
       {
           transactionReports[account.AccountNumber.ToString()] = account.Transactions;
       }
   }
   ```

   > **NOTE**: This loops through all customers and their accounts, adding transactions to the dictionary.

1. **Generate a report for a specific account**  
   Below the dictionary population, add the following code:

   ```csharp
   Console.WriteLine("\nTransaction Report for Account 12345:");
   if (transactionReports.ContainsKey("12345"))
   {
       foreach (var transaction in transactionReports["12345"])
       {
           Console.WriteLine($"Transaction ID: {transaction.TransactionId}, Type: {transaction.Type}, Amount: {transaction.Amount:C}, Date: {transaction.Date}");
       }
   }
   else
   {
       Console.WriteLine("No transactions found for Account 12345.");
   }
   ```

   > **NOTE**: This generates a report for a specific account (e.g., account number `12345`).

1. Save the Program.cs file.

1. Build and run the application.

    Ensure that the project builds successfully without errors. If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

1. Review the output in the terminal window.

    Your app should produce output similar to the following:

    ```plaintext
    Transaction Report for Account 12345:
    Transaction ID: 1, Type: Deposit, Amount: $500.00, Date: 3/14/2025
    Transaction ID: 2, Type: Withdrawal, Amount: $300.00, Date: 3/14/2025
    ```

## Task 9: Generate a report of transactions within a date range

You will generate a report of transactions within a specific date range. Each step aligns with a `// Task 9` comment in the `Program.cs` file to help you locate where to add the code.

1. **Prompt the user for a date range**  
   Open the `Program.cs` file and locate the `// Task 9` comment. Add the following code below it:

   ```csharp
   Console.WriteLine("\nEnter the start date (MM/DD/YYYY):");
   DateTime startDate = DateTime.Parse(Console.ReadLine());

   Console.WriteLine("Enter the end date (MM/DD/YYYY):");
   DateTime endDate = DateTime.Parse(Console.ReadLine());
   ```

   > **NOTE**: This prompts the user to enter a start and end date for the transaction report.

1. **Filter transactions by date range**  
   Below the user input, add the following code:

   ```csharp
   Console.WriteLine("\nTransactions within the specified date range:");
   foreach (var customer in myBank.Customers)
   {
       foreach (var account in customer.Accounts)
       {
           foreach (var transaction in account.Transactions)
           {
               if (transaction.Date >= startDate && transaction.Date <= endDate)
               {
                   Console.WriteLine($"Transaction ID: {transaction.TransactionId}, Type: {transaction.Type}, Amount: {transaction.Amount:C}, Date: {transaction.Date}");
               }
           }
       }
   }
   ```

   > **NOTE**: This filters and displays transactions that fall within the specified date range.

1. Save the Program.cs file.

1. Build and run the application.

    Ensure that the project builds successfully without errors. If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

1. Review the output in the terminal window.

    Your app should produce output similar to the following:

    ```plaintext
    Enter the start date (MM/DD/YYYY):
    3/14/2025
    Enter the end date (MM/DD/YYYY):
    3/15/2025
    
    Transactions within the specified date range:
    Transaction ID: 1, Type: Deposit, Amount: $500.00, Date: 3/14/2025
    Transaction ID: 2, Type: Withdrawal, Amount: $300.00, Date: 3/14/2025
    ```

## Task 10: Generate a summary report of all transactions

You will generate a summary report of all transactions across all accounts. Each step aligns with a `// Task 10` comment in the `Program.cs` file to help you locate where to add the code.

1. **Calculate the total number of transactions and total amount**  
   Open the `Program.cs` file and locate the `// Task 10` comment. Add the following code below it:

   ```csharp
   int totalTransactions = 0;
   double totalAmount = 0;

   foreach (var customer in myBank.Customers)
   {
       foreach (var account in customer.Accounts)
       {
           totalTransactions += account.Transactions.Count;
           totalAmount += account.Transactions.Sum(t => t.Amount);
       }
   }
   ```

   > **NOTE**: This calculates the total number of transactions and the total amount across all accounts.

1. **Display the summary report**  
   Below the calculations, add the following code:

   ```csharp
   Console.WriteLine("\nSummary Report:");
   Console.WriteLine($"Total Transactions: {totalTransactions}");
   Console.WriteLine($"Total Amount: {totalAmount:C}");
   ```

   > **NOTE**: This displays the total number of transactions and the total amount in a summary report.

1. Save the Program.cs file.

1. Build and run the application.

    Ensure that the project builds successfully without errors. If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

1. Review the output in the terminal window.

    Your app should produce output similar to the following:

    ```plaintext
    Summary Report:
    Total Transactions: 2
    Total Amount: $800.00
    ```

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Additionally, building a portfolio of projects can be a great way to demonstrate your skills to potential employers.
