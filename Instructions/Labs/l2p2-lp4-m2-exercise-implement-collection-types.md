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
- `Bank.cs`: This file defines the Bank class and will be used to manage customer collections for bank locations.
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

1. Review the prototype banking application.
1. Implement the Bank class.
1. Update the BankCustomer class.
1. Update the BankAccount class.
1. Update the SimulateDepositWithdrawTransfer class.
1. Manage customer, account, and transaction collections using bank objects.
1. Use a HashSet to ensure unique transactions.
1. Generate transaction reports using a Dictionary.

## Task 1: Review the prototype banking application

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

    Notice that the IBankCustomer interface needs to be updated. The current app has no way to create a collection of account objects for a customer.

1. Take a couple minutes to review the contents of the Models folder.

    - `Models`: The Models folder contains the concrete domain types and behaviors that implement the banking contracts and drive the app’s logic: the bank and customers in Bank.cs and BankCustomer.cs, the account base and variants in BankAccount.cs, CheckingAccount.cs, SavingsAccount.cs, MoneyMarketAccount.cs, and CertificateOfDepositAccount.cs, plus transactional primitives and helpers in Transaction.cs and BankCustomerMethods.cs. It also includes a lightweight workflow harness in SimulateDepositWithdrawTransfer.cs for exercising core operations. Together, these classes realize the IBankAccount/IBankCustomer contracts from Interfaces and supply the state and business rules consumed by Services for calculations and reporting.

    Notice the following:

    - The Bank class needs to be updated. The current app has no way to create a collection of customer objects for a bank.
    - The BankCustomer class needs to be updated. The current app has no way to create a collection of account objects for a customer.
    - The BankCustomerMethods class needs to be updated. The current app has no way to add accounts to a customer.
    - The BankAccount class needs to be updated. The current app has no way to create a collection of transaction objects for an account.

1. Take a couple minutes to review the contents of the Services folder.

    - `Services`: The Services folder encapsulates application-level logic built on the domain models and interface contracts: AccountCalculations.cs centralizes balance/interest/fee computations; AccountReportGenerator.cs and CustomerReportGenerator.cs generate monthly/quarterly/yearly outputs aligning with the reporting interfaces; Extensions.cs provides helper extension methods; and SimulateTransactions.cs orchestrates example deposit/withdraw/transfer flows. These services consume model implementations of IBankAccount and IBankCustomer and are invoked by Program.cs and simulators, keeping business rules centralized, reusable, and decoupled from UI or storage concerns.

    Notice that the SimulateDepositWithdrawTransfer class needs to be updated. The current app has no way to simulate transactions between accounts.

1. Take a minute to review the Program.cs file.

    - `Program.cs`: Program.cs serves as the application entry point and orchestrator, wiring together Interfaces, Models, and Services to evaluate banking scenarios. It can be used to construct the core domain objects (bank, customers, and accounts), invoke service routines for calculations and report generation, and drive transaction simulations to demonstrate behavior end-to-end.

1. Run the app and review the output in the terminal window.

    To run your app, right-click the **Data_M2** project under SOLUTION EXPLORER, select **Debug**, and then select **Start New Instance**.

## Task 2: Implement the Bank class

Bank objects must be able to store a collection of customers. This capability is essential for managing the bank's clientele effectively.

In this task, you implement the fields, properties, constructors, and methods required to begin managing a collection of bank customers.

Use the following steps to complete this task:

1. Open the Bank.cs file, and then locate the code comment that begins with `// Task 2: Step 1`.

1. To declare the bank's unique identifier and customers listAdd the following code below the comment:

   ```csharp
    // Fields
    private readonly Guid _bankId;
    private readonly List<BankCustomer> _customers;

    // Properties
    public Guid BankId => _bankId;
    public IReadOnlyList<BankCustomer> Customers => _customers.AsReadOnly();

   ```

   This code adds a private field to store the bank's unique identifier and a private list to store the bank's customers. It also adds public properties to access the bank's ID and a read-only list of customers.

1. Locate the code comment that begins with `// Task 2: Step 2`.

1. To create a constructor for the Bank class that initializes the bank's properties, add the following code:

    ```csharp
    // Constructors
    public Bank()
    {
        _bankId = Guid.NewGuid();
        _customers = new List<BankCustomer>();
    }
    ```

1. Locate the code comment that begins with `// Task 2: Step 3`.

1. To create a method for adding customers to a bank object, add the following code:

    ```csharp
    //Methods
    internal void AddCustomer(BankCustomer customer)
    {
        _customers.Add(customer);
    }
    ```

1. Save the Bank.cs file.

1. Build and run the application.

    Ensure that the project builds successfully without errors. If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

    The functionality implemented in this task doesn't change the output but will be used in subsequent tasks.

## Task 3: Update the BankCustomer class

BankCustomer objects must be able to store a collection of accounts. This capability is essential for managing the customer's financial assets effectively.

In this task, you update the IBankCustomer interface and BankCustomer class to support managing a collection of customer accounts.

Use the following steps to complete this task:

1. Open the IBankCustomer.cs file.

    The IBankCustomer.cs file is located in the Interfaces folder.

1. Locate the code comment that begins with `// Task 3: Step 1`.

1. To expose a property for accessing the customer's accounts, add the following code below the comment:

   ```csharp
   IReadOnlyList<IBankAccount> Accounts { get; }
   ```

1. Locate the code comment that begins with `// Task 3: Step 2`.

1. To add a method for adding accounts to a customer, add the following code below the comment:

   ```csharp
   void AddAccount(IBankAccount account);
   ```

1. Save the IBankCustomer.cs file.

1. Open the BankCustomer.cs file, and then locate the code comment that begins with `// Task 3: Step 3`.

    The BankCustomer.cs file is located in the Models folder.

1. To create a private field to store the customer's accounts, add the following code below the comment:

   ```csharp
   private readonly List<IBankAccount> _accounts;
   ```

1. Locate the code comment that begins with `// Task 3: Step 4`.

1. To create a public property that exposes the accounts list as a read-only collection, add the following code below the comment:

    ```csharp  
    public IReadOnlyList<IBankAccount> Accounts => _accounts.AsReadOnly();
    ```

1. Locate the code comment that begins with `// Task 3: Step 5`.

1. To update the first constructor to initialize the accounts list, add the following code inside the constructor:

   ```csharp
   _accounts = new List<IBankAccount>();
   ```

1. Locate the code comment that begins with `// Task 3: Step 6`.

1. To update the second constructor to initialize the accounts list, add the following code inside the constructor:

   ```csharp
   _accounts = new List<IBankAccount>(existingCustomer._accounts);
   ```

1. Save the BankCustomer.cs file.

1. Open the BankCustomerMethods.cs file, and then locate the code comment that begins with `// Task 3: Step 7`.

1. To create a method that adds accounts to the customer's accounts list, add the following code below the comment:  

    ```csharp
    public void AddAccount(IBankAccount account)
    {
        _accounts.Add(account);
    }
    ```

1. Save the BankCustomerMethods.cs file.

1. Build and run the application.

    Ensure that the project builds successfully without errors. If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

    The functionality implemented in this task doesn't change the output but will be used in subsequent tasks.

## Task 4: Update the BankAccount class

BankAccount objects must be able to store a collection of account transactions. This capability is essential for generating reports and for audits.

In this task, you update the `IBankAccount` interface and `BankAccount` class to manage the transactions associated with each account.

Use the following steps to complete this task:

1. Open the IBankAccount.cs file.

    The IBankAccount.cs file is located in the Interfaces folder.

1. Locate the code comment that begins with `// Task 4: Step 1`.`

1. To expose properties for accessing the account owner and transactions, add the following code below the comment:

    ```csharp
    BankCustomer Owner { get; } // This is the BankCustomer object that owns the account
    IReadOnlyList<Transaction> Transactions { get; } // List of transactions for the account
    ```

1. Locate the code comment that begins with `// Task 4: Step 2`.`

1. To define methods for logging and retrieving transactions, add the following code below the comment:

    ```csharp
    void AddTransaction(Transaction transaction);
    List<Transaction> GetAllTransactions();
    ```

1. Save the IBankAccount.cs file.

1. Open the `BankAccount.cs` file, and then locate the `// Task 4: Step 3` comment.

1. To define a private readonly list to store transactions, add the following code below the comment:

    ```csharp
    private readonly List<Transaction> _transactions;
    ```

1. Locate the code comment that begins with `// Task 4: Step 4`.

1. To provide access to the collections of transactions, add the following code below the comment:

    ```csharp
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    ```

   > **NOTE**: This property stores the transactions associated with the bank account.

1. Locate the code comment that begins with `// Task 4: Step 5a`.

1. To initialize the transactions list in the first constructor, add the following code inside the constructor:

    ```csharp
    _transactions = new List<Transaction>();
    ```

1. Locate the code comment that begins with `// Task 4: Step 5b`.

1. To initialize the transactions list in the copy constructor, add the following code inside the constructor:

    ```csharp
    _transactions = new List<Transaction>(existingAccount._transactions);
    ```

1. Locate the code comment that begins with `// Task 4: Step 6`.

1. To add the AddTransaction and GetAllTransactions methods, add the following code below the comment:

    ```csharp
    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
    }

    // Method to return all transactions for the account
    public List<Transaction> GetAllTransactions()
    {
        return _transactions;
    }
    ```

   > **NOTE**: The interface provides both `Transactions (IReadOnlyList<Transaction>)` for safe enumeration and `GetAllTransactions()` for a concrete, potentially mutable list (useful for operations that require a `List<T>`). Use `Transactions` when you don’t need to modify the collection.

1. Locate the code comment that begins with `// Task 4: Step 7a`.

1. To add logic that logs the deposit transaction, add the following code below the comment:

    ```csharp
    AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, amount, AccountNumber, AccountNumber, transactionType, description));

    ```

1. Locate the code comment that begins with `// Task 4: Step 7b`.

1. To add logic that logs the withdrawal transaction, add the following code below the comment:

    ```csharp
    AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, amount, AccountNumber, AccountNumber, transactionType, description));

    ```

1. Locate the code comment that begins with `// Task 4: Step 7c`.

1. To add logic that logs the interest transaction, add the following code below the comment:

    ```csharp
    AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, interest, AccountNumber, AccountNumber, AccountType, "Interest"));

    ```

1. Locate the code comment that begins with `// Task 4: Step 7d`.

1. To add logic that logs the refund transaction, add the following code below the comment:

    ```csharp
    AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, refund, AccountNumber, AccountNumber, AccountType, "Refund"));

    ```

1. Locate the code comment that begins with `// Task 4: Step 7e`.

1. To add logic that logs the deposit transaction, add the following code below the comment:

    ```csharp
    AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, amount, AccountNumber, AccountNumber, AccountType, "Cashier's Check"));
    AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, fee, AccountNumber, AccountNumber, AccountType, "Transaction Fee"));

    ```

1. Save the BankAccount.cs file.

1. Build and run the application.

    Ensure that the project builds successfully without errors. If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

    The functionality implemented in this task doesn't change the output but will be used in subsequent tasks.

## Task 5: Update the SimulateDepositWithdrawTransfer class

The SimulateDepositWithdrawTransfer class must be able to simulate deposits, withdrawals, and transfers between accounts. This capability is essential for testing account operations.

In this task, you update the SimulateDepositWithdrawTransfer class to support simulating deposits, withdrawals, and transfers between accounts.

Use the following steps to complete this task:

1. Open the SimulateDepositWithdrawTransfer.cs file, and then locate the `// Task 6: Step 1` comment.

1. To reset the withdrawal limits for savings accounts at the start of the month, add the following code below the comment:

    ```csharp
    foreach (BankAccount account in bankCustomer.Accounts)
    {
        if (account.AccountType == "Savings")
        {
            SavingsAccount savingsAccount = (SavingsAccount)account;
            savingsAccount.ResetWithdrawalLimit();
        }
    }
    ```

1. Locate the `// Task 6: Step 2` comment.

1. To check the account balance and perform transfers between checking and savings accounts, add the following code below the comment:

    ```csharp
    DateOnly dateFinalDayOfMonth = new DateOnly(endDate.Year, endDate.Month, DateTime.DaysInMonth(endDate.Year, endDate.Month));
    if (startDate <= dateFinalDayOfMonth && dateFinalDayOfMonth <= endDate)
    {
        if (bankCustomer.Accounts[0].Balance <= minCheckingBalance)
        {
            transactions.Add(new TransactionInfo { Date = dateFinalDayOfMonth, Time = new TimeOnly(12, 00), Amount = transferToChecking, Description = "Transfer from savings to checking account", TransactionType = "Transfer" });
        }
        else if (bankCustomer.Accounts[0].Balance >= maxCheckingBalance)
        {
            transactions.Add(new TransactionInfo { Date = dateFinalDayOfMonth, Time = new TimeOnly(12, 00), Amount = transferToSavings, Description = "Transfer from checking to savings account", TransactionType = "Transfer" });
        }
    }
    ```

1. Locate the `// Task 6: Step 3` comment.

1. To Update accounts for each transaction based on its type, add the following code below the comment:

    ```csharp
    if (transaction.TransactionType == "Deposit")
    {
        bankCustomer.Accounts[0].Deposit(transaction.Amount, transaction.Date, transaction.Time, transaction.Description);
    }
    else if (transaction.TransactionType == "Withdraw")
    {
        bankCustomer.Accounts[0].Withdraw(transaction.Amount, transaction.Date, transaction.Time, transaction.Description);
    }
    else if (transaction.TransactionType == "Transfer")
    {
        if (transaction.Description.Contains("savings to checking"))
        {
            bankCustomer.Accounts[1].Transfer(bankCustomer.Accounts[0], transaction.Amount, transaction.Date, transaction.Time, transaction.Description);
        }
        else if (transaction.Description.Contains("checking to savings"))
        {
            bankCustomer.Accounts[0].Transfer(bankCustomer.Accounts[1], transaction.Amount, transaction.Date, transaction.Time, transaction.Description);
        }
    }
    ```

1. Locate the `// Task 6: Step 4` comment.

1. To add a method to simulate deposits, add the following code below the comment:

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

1. Locate the `// Task 6: Step 4` comment.

1. To add a method to simulate withdrawals, add the following code below the comment:

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

1. Locate the `// Task 6: Step 4` comment.

1. To add a method to simulate transfers, add the following code below the comment:

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

1. Save the SimulateDepositWithdrawTransfer.cs file.

1. Build and run the application.

    Ensure that the project builds successfully without errors. If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

    The functionality implemented in this task doesn't change the output but will be used in subsequent tasks.

## Task 6: Manage customer, account, and transaction collections using bank objects

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
