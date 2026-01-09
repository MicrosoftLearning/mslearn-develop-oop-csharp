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
1. Update the Bank class for a customers collection.
1. Update IBankCustomer and BankCustomer for an accounts collection.
1. Update IBankAccount, BankAccount, and CheckingAccount for account transactions.
1. Update the SimulateDepositWithdrawTransfer class.
1. Manage customer, account, and transaction collections using bank objects.
1. Create a monthly statement using a HashSet and Dictionary.

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

    Your app should produce output similar to the following:

    ```plaintext
    Bank Application - demonstrate the use of Collections, HashSets, and Dictionaries.
    ```

    To run your app, right-click the **Data_M2** project under SOLUTION EXPLORER, select **Debug**, and then select **Start New Instance**.

## Task 2: Update the Bank class for a customers collection

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

## Task 3: Update IBankCustomer and BankCustomer for an accounts collection

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

## Task 4: Update IBankAccount, BankAccount, and CheckingAccount for account transactions

BankAccount objects must be able to store a collection of account transactions. This capability is essential for generating reports and for audits.

In this task, you update the `IBankAccount` interface, `BankAccount` class, and `CheckingAccount` class to manage the transactions associated with each account.

Use the following steps to complete this task:

1. Open the IBankAccount.cs file.

    The IBankAccount.cs file is located in the Interfaces folder.

1. Locate the code comment that begins with `// Task 4: Step 1`.`

1. To expose properties for accessing the account owner and transactions, add the following code below the comment:

    ```csharp
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

1. To provide readonly access to the transactions collection, add the following code below the comment:

    ```csharp
    public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();
    ```

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

   > **NOTE**: The application provides `Transactions (IReadOnlyList<Transaction>)` for safe enumeration and `GetAllTransactions()` for a concrete, potentially mutable list (useful for operations that require a `List<T>`).

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

1. Open the CheckingAccount.cs file, and then locate the `// Task 4: Step 8a` comment.

1. To add logic that logs the withdrawal transaction, add the following code below the comment:

    ```csharp
    AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, amount, AccountNumber, AccountNumber, transactionType, description));
    ```

1. Locate the `// Task 4: Step 8b` comment.

1. To add logic that logs the overdraft fee transaction, add the following code below the comment:

    ```csharp
    AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, overdraftFee, AccountNumber, AccountNumber, transactionType, overdraftDescription));
    ```

1. Save the CheckingAccount.cs file.

1. Build and run the application.

    Ensure that the project builds successfully without errors. If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

    The functionality implemented in this task doesn't change the output but will be used in subsequent tasks.

## Task 5: Update the SimulateDepositWithdrawTransfer class

The SimulateDepositWithdrawTransfer class must be able to simulate deposits, withdrawals, and transfers between accounts. Each of these actions will be logged as a transaction and added to the corresponding account's transaction history. The ability to simulate these actions is essential for testing account operations.

In this task, you update the SimulateDepositWithdrawTransfer class to support simulating deposits, withdrawals, and transfers between accounts.

Use the following steps to complete this task:

1. Open the SimulateDepositWithdrawTransfer.cs file, and then locate the `// Task 5: Step 1` comment.

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

1. Locate the `// Task 5: Step 2` comment.

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

1. Locate the `// Task 5: Step 3` comment.

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

1. Save the SimulateDepositWithdrawTransfer.cs file.

1. Build and run the application.

    Ensure that the project builds successfully without errors. If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

    The functionality implemented in this task doesn't change the output but will be used in subsequent tasks.

## Task 6: Manage customer, account, and transaction collections using bank objects

Bank objects can be used to build and manage collections of customer objects. These customer objects associated with a bank location can be used to manage the customer accounts. The customer account objects can be used to log the transaction history for each of the customer's accounts. These capabilities are essential for simulating real-world banking operations.

In this task, you use the Bank, BankCustomer, and BankAccount classes to create and manage collections of customers, accounts, and transactions.

Use the following steps to complete this task:

1. Open the Program.cs file, and then locate the `// Task 6: Step 1` comment.

1. To create a Bank object, add the following code below the comment:

    ```csharp
    Bank myBank = new Bank();
    Console.WriteLine($"\nBank object created...");
    ```

1. Locate the `// Task 6: Step 2` comment.

1. To create a BankCustomer and BankAccount using the myBank object, add the following code below the comment:

    ```csharp
    Console.WriteLine($"\nUse myBank object to add a customer and an account...");
    myBank.AddCustomer(new BankCustomer("Remy", "Morris"));
    myBank.Customers[0].AddAccount(new BankAccount(myBank.Customers[0], myBank.Customers[0].CustomerId, 1500.00, "Checking"));
    Console.WriteLine($"{myBank.Customers[0].Accounts[0].AccountType} account object created and added to {myBank.Customers[0].ReturnFullName()}'s account collection.");

    ```

1. Locate the `// Task 6: Step 3` comment.

1. To create BankCustomer and BankAccount objects and then add them to collections, add the following code below the comment:

    ```csharp
    Console.WriteLine($"\nAdd new customer and account objects to the bank...");
    BankCustomer customer1 = new BankCustomer("Ni", "Kang");
    BankAccount account1 = new BankAccount(customer1, customer1.CustomerId, 1000.00, "Checking");
    
    customer1.AddAccount(account1);
    myBank.AddCustomer(customer1);
    
    foreach (BankCustomer bankCustomer in myBank.Customers)
    {
        Console.WriteLine($"{bankCustomer.ReturnFullName()} has {bankCustomer.Accounts.Count} accounts.");
    
    }
    ```

1. Locate the `// Task 6: Step 4` comment.

1. To use the myBank.Customers collection to add accounts to all customers, add the following code below the comment:

    ```csharp
    Console.WriteLine($"\nUse the Customers collection to add SavingsAccount and MoneyMarketAccount to all customers...");
    foreach (BankCustomer bankCustomer in myBank.Customers)
    {
        bankCustomer.AddAccount(new SavingsAccount(bankCustomer, bankCustomer.CustomerId, 3000.00, 6));
        bankCustomer.AddAccount(new MoneyMarketAccount(bankCustomer, bankCustomer.CustomerId, 15000.00, 1000.00));
        Console.WriteLine($"{bankCustomer.ReturnFullName()} has {bankCustomer.Accounts.Count} accounts.");
    
    }
    ```

1. Locate the `// Task 6: Step 5` comment.

1. To generate two months of transactions for customer Ni Kang, add the following code below the comment:

   ```csharp
        Console.WriteLine($"\nGenerate two months of transactions for customer \"Ni Kang\"...");
        foreach (BankCustomer bankCustomer in myBank.Customers)
        {
            if (bankCustomer.ReturnFullName() == "Ni Kang")
            {
                DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);

                DateOnly startDate = currentDate.AddMonths(-2);
                DateOnly endDate = currentDate;
                BankCustomer customer = bankCustomer;

                customer = SimulateDepositsWithdrawalsTransfers.SimulateActivityDateRange(startDate, endDate, customer);
                
                int totalTransactions = 0;
                foreach (BankAccount account in bankCustomer.Accounts)
                {
                    totalTransactions += account.Transactions.Count;
                }
                Console.WriteLine($"{bankCustomer.ReturnFullName()} had {totalTransactions} transactions in the past two months.");
            }
        }
   ```

1. Locate the `// Task 6: Step 6` comment.

1. To display all transactions for all accounts, add the following code below the comment:

    ```csharp
    Console.WriteLine($"\nDisplay all transactions for all accounts...");
    foreach (BankCustomer bankCustomer in myBank.Customers)
    {
        Console.WriteLine($"\nTransactions for {bankCustomer.ReturnFullName()}:");
    
        foreach (BankAccount account in bankCustomer.Accounts)
        {
            Console.WriteLine($"\nAccount Type: {account.AccountType}, Account Number: {account.AccountNumber}");
            foreach (Transaction transaction in account.Transactions)
            {
                Console.WriteLine(transaction.ReturnTransaction());
            }
        }
    }
    ```

1. Save the Program.cs file.

1. Build and run the application.

    Ensure that the project builds successfully without errors. If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

1. Review the output in the terminal window.

    Your app should produce output similar to the following:

    ```plaintext
    Bank Application - demonstrate the use of Collections, HashSets, and Dictionaries.
    
    Bank object created...
    
    Use myBank object to add a customer and an account...
    Checking account object created and added to Remy Morris's account collection.
    
    Add new customer and account objects to the bank...
    Remy Morris has 1 accounts.
    Ni Kang has 1 accounts.
    
    Use the Customers collection to add SavingsAccount and MoneyMarketAccount to all customers...
    Remy Morris has 3 accounts.
    Ni Kang has 3 accounts.
    
    Generate two months of transactions for customer "Ni Kang"...
    Ni Kang had 42 transactions in the past two months.
    
    Display all transactions for all accounts...
    
    Transactions for Remy Morris:
    
    Account Type: Checking, Account Number: 11906837
    
    Account Type: Savings, Account Number: 11906839
    
    Account Type: Money Market, Account Number: 11906840
    
    Transactions for Ni Kang:
    
    Account Type: Checking, Account Number: 11906838
    Transaction ID: 2081a1ce-1f11-4d4f-b0fa-37cd43c58b00, Type: Withdraw, Date: 11/8/2025, Time: 9:00 PM, Prior Balance: $1,000.00 Amount: $177.00, Source Account: 11906838, Target Account: 11906838, Description: Debit card purchase
    Transaction ID: ed508f94-9b5f-477e-9524-4d8d38d3fdcc, Type: Withdraw, Date: 11/10/2025, Time: 8:00 AM, Prior Balance: $823.00 Amount: $400.00, Source Account: 11906838, Target Account: 11906838, Description: Withdraw for expenses
    Transaction ID: 8a02081d-6990-4382-9706-ddcc99f1c191, Type: Bank Fee, Date: 11/10/2025, Time: 12:00 PM, Prior Balance: $423.00 Amount: $50.00, Source Account: 11906838, Target Account: 11906838, Description: -(BANK FEE)
    Transaction ID: 1e050949-7910-4484-96dc-808bba93dd18, Type: Deposit, Date: 11/14/2025, Time: 12:00 PM, Prior Balance: $373.00 Amount: $3,224.00, Source Account: 11906838, Target Account: 11906838, Description: Bi-monthly salary deposit
    Transaction ID: cf039ed7-3223-43f1-a66d-b45e8cce31dd, Type: Withdraw, Date: 11/15/2025, Time: 9:00 PM, Prior Balance: $3,597.00 Amount: $219.00, Source Account: 11906838, Target Account: 11906838, Description: Debit card purchase
    Transaction ID: 4694e7eb-365a-45f0-a935-9cb49b9a5c5c, Type: Withdraw, Date: 11/17/2025, Time: 8:00 AM, Prior Balance: $3,378.00 Amount: $400.00, Source Account: 11906838, Target Account: 11906838, Description: Withdraw for expenses
    Transaction ID: 9b9f4221-e6d2-409c-b8ed-f82b39994454, Type: Withdraw, Date: 11/20/2025, Time: 12:00 PM, Prior Balance: $2,978.00 Amount: $136.00, Source Account: 11906838, Target Account: 11906838, Description: Auto-pay gas and electric bill
    Transaction ID: 6631120d-b624-43ea-8d7a-6f02e165e05a, Type: Withdraw, Date: 11/20/2025, Time: 12:00 PM, Prior Balance: $2,842.00 Amount: $86.00, Source Account: 11906838, Target Account: 11906838, Description: Auto-pay water and sewer bill
    Transaction ID: 6453603e-c01b-487f-99e3-cacfeb54663e, Type: Withdraw, Date: 11/20/2025, Time: 12:00 PM, Prior Balance: $2,756.00 Amount: $68.00, Source Account: 11906838, Target Account: 11906838, Description: Auto-pay waste management bill
    Transaction ID: bd9ef088-69ac-4563-98d7-c05447b47e92, Type: Withdraw, Date: 11/20/2025, Time: 12:00 PM, Prior Balance: $2,688.00 Amount: $137.00, Source Account: 11906838, Target Account: 11906838, Description: Auto-pay health club membership
    Transaction ID: c6684c8b-f6d4-4758-b6a2-76d8915fc023, Type: Withdraw, Date: 11/22/2025, Time: 9:00 PM, Prior Balance: $2,551.00 Amount: $166.00, Source Account: 11906838, Target Account: 11906838, Description: Debit card purchase
    Transaction ID: 0ef6b90b-c881-4c23-a7b2-511946591353, Type: Withdraw, Date: 11/24/2025, Time: 8:00 AM, Prior Balance: $2,385.00 Amount: $400.00, Source Account: 11906838, Target Account: 11906838, Description: Withdraw for expenses
    Transaction ID: d23500e3-96d9-48dc-83a3-765cd7bd9d7f, Type: Deposit, Date: 11/28/2025, Time: 12:00 PM, Prior Balance: $1,985.00 Amount: $3,224.00, Source Account: 11906838, Target Account: 11906838, Description: Bi-monthly salary deposit
    Transaction ID: da465aa4-6a64-4c33-8b0c-d70c9035a632, Type: Withdraw, Date: 11/28/2025, Time: 12:00 PM, Prior Balance: $5,209.00 Amount: $1,539.00, Source Account: 11906838, Target Account: 11906838, Description: Auto-pay credit card bill
    Transaction ID: be0e4c26-7a08-4d7c-b48f-f0db9d3ac223, Type: Transfer, Date: 11/30/2025, Time: 12:00 PM, Prior Balance: $3,670.00 Amount: $2,000.00, Source Account: 11906838, Target Account: 11906838, Description: Transfer from savings to checking account-(TRANSFER)
    Transaction ID: 6a5b09d7-314f-4eb5-865c-c1bf791bdebf, Type: Withdraw, Date: 12/1/2025, Time: 8:00 AM, Prior Balance: $5,670.00 Amount: $400.00, Source Account: 11906838, Target Account: 11906838, Description: Withdraw for expenses
    Transaction ID: 6a687598-dc2d-41b3-8a07-6b71cd703e86, Type: Withdraw, Date: 12/1/2025, Time: 12:00 PM, Prior Balance: $5,270.00 Amount: $2,945.50, Source Account: 11906838, Target Account: 11906838, Description: Rent payment
    Transaction ID: eaa4d1fb-65aa-46bb-8e3b-81fac9b58967, Type: Bank Fee, Date: 12/3/2025, Time: 12:00 PM, Prior Balance: $2,324.50 Amount: $50.00, Source Account: 11906838, Target Account: 11906838, Description: -(BANK FEE)
    Transaction ID: 363ccb20-f4a6-4b3d-9c26-5be2fff5c033, Type: Bank Refund, Date: 12/5/2025, Time: 12:00 PM, Prior Balance: $2,274.50 Amount: $100.00, Source Account: 11906838, Target Account: 11906838, Description: Refund for overcharge -(BANK REFUND)
    Transaction ID: 8abec699-81d3-41d2-b819-5b30b024795e, Type: Withdraw, Date: 12/6/2025, Time: 9:00 PM, Prior Balance: $2,374.50 Amount: $188.00, Source Account: 11906838, Target Account: 11906838, Description: Debit card purchase
    Transaction ID: e9c4822a-a4b2-4938-b1ff-ccac2bf2561f, Type: Withdraw, Date: 12/8/2025, Time: 8:00 AM, Prior Balance: $2,186.50 Amount: $400.00, Source Account: 11906838, Target Account: 11906838, Description: Withdraw for expenses
    Transaction ID: d1b2e8e4-7db2-42c0-ac5c-01d3d1e28b6c, Type: Bank Fee, Date: 12/10/2025, Time: 12:00 PM, Prior Balance: $1,786.50 Amount: $50.00, Source Account: 11906838, Target Account: 11906838, Description: -(BANK FEE)
    Transaction ID: 46fe844b-6f9f-4744-bfc2-bf85bcdb5bc4, Type: Withdraw, Date: 12/13/2025, Time: 9:00 PM, Prior Balance: $1,736.50 Amount: $201.00, Source Account: 11906838, Target Account: 11906838, Description: Debit card purchase
    Transaction ID: 21e8785e-5805-43ca-ba58-5ab3143a0406, Type: Withdraw, Date: 12/15/2025, Time: 8:00 AM, Prior Balance: $1,535.50 Amount: $400.00, Source Account: 11906838, Target Account: 11906838, Description: Withdraw for expenses
    Transaction ID: 3afbc7ee-9b2d-49cc-b72e-30eb55374ce0, Type: Deposit, Date: 12/15/2025, Time: 12:00 PM, Prior Balance: $1,135.50 Amount: $3,755.00, Source Account: 11906838, Target Account: 11906838, Description: Bi-monthly salary deposit
    Transaction ID: 985b9857-ff80-4bb1-a8f4-385ea8837125, Type: Withdraw, Date: 12/20/2025, Time: 12:00 PM, Prior Balance: $4,890.50 Amount: $64.00, Source Account: 11906838, Target Account: 11906838, Description: Auto-pay waste management bill
    Transaction ID: cb289a5d-dab6-477f-82a8-ae3cf4671745, Type: Withdraw, Date: 12/20/2025, Time: 12:00 PM, Prior Balance: $4,826.50 Amount: $84.00, Source Account: 11906838, Target Account: 11906838, Description: Auto-pay water and sewer bill
    Transaction ID: c1e14c14-3af1-4c4b-9255-3ca7c8e69dfb, Type: Withdraw, Date: 12/20/2025, Time: 12:00 PM, Prior Balance: $4,742.50 Amount: $101.00, Source Account: 11906838, Target Account: 11906838, Description: Auto-pay gas and electric bill
    Transaction ID: 3677c3ef-54d3-4326-b463-c443df826fe1, Type: Withdraw, Date: 12/20/2025, Time: 12:00 PM, Prior Balance: $4,641.50 Amount: $120.00, Source Account: 11906838, Target Account: 11906838, Description: Auto-pay health club membership
    Transaction ID: 2cca578d-490f-4876-84eb-f6c63e46fc4a, Type: Withdraw, Date: 12/20/2025, Time: 9:00 PM, Prior Balance: $4,521.50 Amount: $192.00, Source Account: 11906838, Target Account: 11906838, Description: Debit card purchase
    Transaction ID: 7b86bf35-8121-431c-b923-e58db7199853, Type: Withdraw, Date: 12/22/2025, Time: 8:00 AM, Prior Balance: $4,329.50 Amount: $400.00, Source Account: 11906838, Target Account: 11906838, Description: Withdraw for expenses
    Transaction ID: e9651f3d-50a1-4b67-9602-907fe0c115cc, Type: Withdraw, Date: 12/27/2025, Time: 9:00 PM, Prior Balance: $3,929.50 Amount: $171.00, Source Account: 11906838, Target Account: 11906838, Description: Debit card purchase
    Transaction ID: 62486675-b5a8-448b-985b-8efab9083379, Type: Withdraw, Date: 12/31/2025, Time: 12:00 PM, Prior Balance: $3,758.50 Amount: $1,460.75, Source Account: 11906838, Target Account: 11906838, Description: Auto-pay credit card bill
    Transaction ID: cad2736e-9725-409a-87d0-de7894bcb599, Type: Deposit, Date: 12/31/2025, Time: 12:00 PM, Prior Balance: $2,297.75 Amount: $3,755.00, Source Account: 11906838, Target Account: 11906838, Description: Bi-monthly salary deposit
    Transaction ID: f38b73a2-a9a3-44e9-b658-d3dd8e0be72e, Type: Transfer, Date: 12/31/2025, Time: 12:00 PM, Prior Balance: $6,052.75 Amount: $900.00, Source Account: 11906838, Target Account: 11906838, Description: Transfer from checking to savings account-(TRANSFER)
    Transaction ID: 6075f724-198c-4afa-9767-800e750f49cf, Type: Withdraw, Date: 1/1/2026, Time: 12:00 PM, Prior Balance: $5,152.75 Amount: $2,950.40, Source Account: 11906838, Target Account: 11906838, Description: Rent payment
    Transaction ID: 19b208bf-ad09-456b-a5fd-768e2122d865, Type: Bank Fee, Date: 1/3/2026, Time: 12:00 PM, Prior Balance: $2,202.35 Amount: $50.00, Source Account: 11906838, Target Account: 11906838, Description: -(BANK FEE)
    Transaction ID: 821d33e7-2cb5-4711-8ad8-ac0b919a632c, Type: Withdraw, Date: 1/3/2026, Time: 9:00 PM, Prior Balance: $2,152.35 Amount: $198.00, Source Account: 11906838, Target Account: 11906838, Description: Debit card purchase
    Transaction ID: 3bd100e4-dd88-4302-87e0-b8563e0069ea, Type: Withdraw, Date: 1/5/2026, Time: 8:00 AM, Prior Balance: $1,954.35 Amount: $400.00, Source Account: 11906838, Target Account: 11906838, Description: Withdraw for expenses
    Transaction ID: c530ebec-7359-4378-b8a1-3d3c189c7f06, Type: Bank Refund, Date: 1/5/2026, Time: 12:00 PM, Prior Balance: $1,554.35 Amount: $100.00, Source Account: 11906838, Target Account: 11906838, Description: Refund for overcharge -(BANK REFUND)
    
    Account Type: Savings, Account Number: 11906841
    Transaction ID: 42014e15-2afc-4891-adb0-dc0a22164a52, Type: Transfer, Date: 11/30/2025, Time: 12:00 PM, Prior Balance: $3,000.00 Amount: $2,000.00, Source Account: 11906841, Target Account: 11906841, Description: Transfer from savings to checking account-(TRANSFER)
    Transaction ID: 2e9ca986-c92f-49d3-948f-c0a8946b1cf3, Type: Transfer, Date: 12/31/2025, Time: 12:00 PM, Prior Balance: $1,000.00 Amount: $900.00, Source Account: 11906841, Target Account: 11906841, Description: Transfer from checking to savings account-(TRANSFER)
    
    Account Type: Money Market, Account Number: 11906842
    ```

1. Notice that transfers between accounts are logged as transactions in both the source and target accounts.

    For example, when transferring money from a savings account to a checking account, the transaction is recorded in both accounts' transaction histories. This behavior is essential for accurate record-keeping and auditing purposes. However, customers may prefer to see transfers between accounts reported separately in there monthly statements.

## Task 7: Create a monthly statement using a HashSet and Dictionary

A HashSet can be used to store unique transactions, while a Dictionary can be used to generate transaction reports. These data structures are useful for managing and organizing transaction data efficiently.

In this task, you create a monthly statement using a `HashSet` to store unique transactions and a `Dictionary` to generate transaction reports.

Use the following steps to complete this task:

1. Open the Program.cs file, and then locate the `// Task 7: Step 1` comment.

1. To locate customer Ni Kang using the Customers collection, add the following code below the comment:

    ```csharp
    Console.WriteLine("\nMonthly statement showing Transfers, Deposits, and Withdrawals...");

    BankCustomer? reportCustomer = null;
    foreach (BankCustomer bc in myBank.Customers)
    {
        if (bc.ReturnFullName() == "Ni Kang")
        {
            reportCustomer = bc;
            break;
        }
    }
    ```

1. Locate the `// Task 7: Step 2` comment.

1. To set the reporting date range to the previous month, add the following code below the comment:

    ```csharp
    DateOnly today = DateOnly.FromDateTime(DateTime.Now);
    DateOnly reportStart = new DateOnly(today.Year, today.Month, 1).AddMonths(-1);
    DateOnly reportEnd = new DateOnly(reportStart.Year, reportStart.Month, DateTime.DaysInMonth(reportStart.Year, reportStart.Month));
    ```

1. Locate the `// Task 7: Step 3` comment.

1. To create a HashSet and Dictionary, add the following code below the comment:

    ```csharp
    // HashSet to track unique transfer signatures across accounts
    HashSet<string> uniqueTransferKeys = new HashSet<string>();

    // Dictionary to organize monthly activity by transaction type
    Dictionary<string, List<string>> monthlyActivity = new Dictionary<string, List<string>>
    {
        { "Deposits", new List<string>() },
        { "Withdrawals", new List<string>() },
        { "Transfers", new List<string>() }
    };
    ```

1. Locate the `// Task 7: Step 4` comment.

1. To populate the HashSet and Dictionary with transactions, add the following code below the comment:

    ```csharp
    if (reportCustomer != null)
    {
        foreach (BankAccount acct in reportCustomer.Accounts)
        {
            foreach (Transaction txn in acct.Transactions)
            {
                if (txn.TransactionDate < reportStart || txn.TransactionDate > reportEnd)
                    continue;

                string dateStr = txn.TransactionDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                string timeStr = txn.TransactionTime.ToString("HH:mm", CultureInfo.InvariantCulture);
                string desc = txn.Description.Replace("-(TRANSFER)", string.Empty).Trim();

                if (txn.TransactionType == "Transfer")
                {
                    // Build a signature that uniquely identifies a single transfer across accounts
                    string signature = $"{dateStr}|{timeStr}|{txn.TransactionAmount:F2}|{desc}";
                    if (uniqueTransferKeys.Add(signature))
                    {
                        monthlyActivity["Transfers"].Add($"{txn.TransactionDate} {timeStr} - Transfer {txn.TransactionAmount:C} - {desc}");
                    }
                    // else: duplicate entry for the paired account; skip
                }
                else if (txn.TransactionType == "Deposit")
                {
                    monthlyActivity["Deposits"].Add($"{txn.TransactionDate} {timeStr} - Deposit {txn.TransactionAmount:C} ({acct.AccountType})");
                }
                else if (txn.TransactionType == "Withdraw")
                {
                    monthlyActivity["Withdrawals"].Add($"{txn.TransactionDate} {timeStr} - Withdrawal {txn.TransactionAmount:C} ({acct.AccountType})");
                }
            }
        }

        Console.WriteLine($"\nMonthly Statement for {reportCustomer.ReturnFullName()} - {reportStart.ToString("MMMM yyyy", CultureInfo.InvariantCulture)}");
        Console.WriteLine($"Date Range: {reportStart} to {reportEnd}");
        Console.WriteLine($"Summary: Deposits={monthlyActivity["Deposits"].Count}, Withdrawals={monthlyActivity["Withdrawals"].Count}, Transfers (unique)={monthlyActivity["Transfers"].Count}");

        Console.WriteLine("\nTransfers (unique):");
        foreach (var line in monthlyActivity["Transfers"]) Console.WriteLine(line);

        Console.WriteLine("\nDeposits:");
        foreach (var line in monthlyActivity["Deposits"]) Console.WriteLine(line);

        Console.WriteLine("\nWithdrawals:");
        foreach (var line in monthlyActivity["Withdrawals"]) Console.WriteLine(line);
    }
    else
    {
        Console.WriteLine("Customer for monthly statement not found.");
    }
    ```

1. Save the Program.cs file.

1. Build and run the application.

    Ensure that the project builds successfully without errors. If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

1. Review the output in the terminal window.

    Your app should produce a monthly statement similar to the following:

    ```plaintext
    Monthly statement showing Transfers, Deposits, and Withdrawals...
    
    Monthly Statement for Ni Kang - December 2025
    Date Range: 12/1/2025 to 12/31/2025
    Summary: Deposits=2, Withdrawals=14, Transfers (unique)=1
    
    Transfers (unique):
    12/31/2025 12:00 - Transfer $900.00 - Transfer from checking to savings account
    
    Deposits:
    12/15/2025 12:00 - Deposit $3,780.00 (Checking)
    12/31/2025 12:00 - Deposit $3,780.00 (Checking)
    
    Withdrawals:
    12/1/2025 08:00 - Withdrawal $400.00 (Checking)
    12/1/2025 12:00 - Withdrawal $3,050.00 (Checking)
    12/6/2025 21:00 - Withdrawal $171.00 (Checking)
    12/8/2025 08:00 - Withdrawal $400.00 (Checking)
    12/13/2025 21:00 - Withdrawal $173.00 (Checking)
    12/15/2025 08:00 - Withdrawal $400.00 (Checking)
    12/20/2025 12:00 - Withdrawal $61.00 (Checking)
    12/20/2025 12:00 - Withdrawal $80.00 (Checking)
    12/20/2025 12:00 - Withdrawal $138.00 (Checking)
    12/20/2025 12:00 - Withdrawal $132.00 (Checking)
    12/20/2025 21:00 - Withdrawal $174.00 (Checking)
    12/22/2025 08:00 - Withdrawal $400.00 (Checking)
    12/27/2025 21:00 - Withdrawal $164.00 (Checking)
    12/31/2025 12:00 - Withdrawal $1,673.00 (Checking)
    ```

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Additionally, building a portfolio of projects can be a great way to demonstrate your skills to potential employers.
