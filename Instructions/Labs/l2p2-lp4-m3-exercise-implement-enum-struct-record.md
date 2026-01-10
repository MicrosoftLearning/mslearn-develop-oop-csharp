---
lab:
    title: 'Exercise - Implement Enum, Struct, and Record in a Banking Application'
    description: 'Learn how to define and implement enums, structs, and records in C#. Explore their use in a banking application to manage accounts, transactions, and customers.'
---

# Implement Enum, Struct, and Record in a Banking Application

Enums, structs, and records are fundamental concepts in C# that allow you to define and manage data in a structured and efficient way. In this exercise, you will implement these concepts in a banking application. You will define an enum for account types, a struct for transactions, and a record for customer details. Additionally, you will implement a class to manage bank accounts and demonstrate how these concepts work together in a real-world scenario.

This exercise takes approximately **30** minutes to complete.

## Before you start

Before you can start this exercise, you need to:

1. Ensure that you have the latest short term support (STS) version of the .NET SDK installed on your computer. You can download the latest versions of the .NET SDK using the following URL: <a href="https://dotnet.microsoft.com/download/" target="_blank">Download .NET</a>

1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code using the following URL: <a href="https://code.visualstudio.com/download/" target="_blank">Download Visual Studio Code</a>

1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For additional help configuring the Visual Studio Code environment, see <a href="https://learn.microsoft.com/training/modules/install-configure-visual-studio-code/" target="_blank">Install and configure Visual Studio Code for C# development</a>

## Exercise scenario

Suppose you're a software developer at a tech company working on a new project. Your team needs to implement a banking application that uses enums, structs, and records to manage account types, transactions, and customer details. To ensure consistent behavior, you decide to implement these features in a simple console application.

You've planned an initial version of the console app that includes the Bank.cs and Program.cs placeholder files.

This exercise includes the following tasks:

1. Download and review the starter project.
1. Define Enum, Struct, and Record types.
1. Implement the BankAccount class.
1. Display basic bank account information.
1. Demonstrate using the Transaction record.
1. Demonstrate record comparison and the immutability of readonly structs.

## Task 1: Download and review the starter project

In this task, you download the existing version of your project and review the placeholder files.

Use the following steps to complete this section of the exercise:

1. Download the starter code from the following URL: [Implement collection types - exercise code projects](https://github.com/MicrosoftLearning/mslearn-develop-oop-csharp/raw/refs/heads/main/DownloadableCodeProjects/Downloads/LP4SampleApps.zip)

1. Extract the contents of the LP4SampleApps.zip file to a folder location on your computer.

1. Expand the LP4SampleApps folder, and then open the `Data_M3` folder.

    The Data_M3 folder contains the following code project folders:

    - Solution
    - Starter

    The **Starter** folder contains the starter project files for this exercise.

1. Use Visual Studio Code to open the **Starter** folder.

1. In the EXPLORER view, collapse the **STARTER** folder, select **SOLUTION EXPLORER**, and expand the **Data_M3** project.

    You should see the following project files:

    - Program.cs
    - Bank.cs

1. Take a minute to open and review the Program.cs and Bank.cs files.

1. Run the app and verify that the output matches the sample output listed below.

    The expected output should look similar to the following:

    ```console
    Welcome to the Bank App!
    ```

    This exercise will guide you through implementing the intended functionality.

## Task 2: Define Enum, Struct, and Record types

An Enum is a special "value type" that allows you to define a set of named constants. Enums are a great way to define a set of named constants, making your code more readable and maintainable.

A Struct is a value type that's typically used to encapsulate small groups of related variables.

A Record is a reference type that provides built-in functionality for encapsulating data. Records are ideal for representing data with value-based equality.

In this task, you'll define an enum named `AccountType` to represent different types of bank accounts, a struct named `BankAccountNumber` to represent bank account numbers, and two records named `AccountHolderDetails` and `Transaction` to represent customer details and individual transactions, respectively.

Use the following steps to complete this task:

1. Open the Bank.cs file, and then locate the code comment that begins with **Task 2: Step 1**.

1. To define an enum named BankAccountType with Checking, Savings, and Business values, enter the following code:

    ```csharp
    public enum BankAccountType
    {
        Checking,
        Savings,
        Business
    }
    ```

1. Locate the **Task 2: Step 2** comment.

1. To define an extension method named GetDescription that provides descriptions for each BankAccountType value, enter the following code:

    ```csharp
    public static class BankAccountTypeExtensions
    {
        public static string GetDescription(this BankAccountType accountType)
        {
            return accountType switch
            {
                BankAccountType.Checking => "A standard checking account.",
                BankAccountType.Savings => "A savings account with interest.",
                BankAccountType.Business => "A business account for companies.",
                _ => "Unknown account type."
            };
        }
    }
    ```

1. Locate the **Task 2: Step 3** comment.

1. To define a struct named BankAccountNumber that represents a bank account number, add the following code:

    ```csharp
    public readonly struct BankAccountNumber
    {
        public string Value { get; }
        public BankAccountNumber(string value)
        {
            // Simple format: 12 digits (demo-friendly)
            if (value is null || value.Length != 12 || !value.All(char.IsDigit))
                throw new ArgumentException("Account numbers must be 12 digits.");
            Value = value;
        }
        public override string ToString() => Value;
    }
    ```

1. Locate the **Task 2: Step 4** comment.

1. To define a record named AccountHolderDetails with Name, CustomerId, and Address properties, add the following code:

    ```csharp
    public record AccountHolderDetails(string Name, string CustomerId, string Address);
    ```

1. Locate the **Task 2: Step 5** comment.

1. To define a record named Transaction with Amount, Date, and Description properties, add the following code:

    ```csharp
    public record Transaction(decimal Amount, DateTime Date, string Description)
    {
        public override string ToString()
        {
            return $"{Date.ToShortDateString()}: {Description} - {Amount:C}";
        }
    }
    ```

1. Save your changes.

## Task 3: Implement the BankAccount class

In this task, you'll implement the `BankAccount` class to manage bank accounts in the application. This class will include properties, a constructor, and methods to handle account operations such as deposits, withdrawals, and displaying account information.

Use the following steps to complete this task:

1. Ensure that you have the Bank.cs file open.

1. Locate the **Task 3: Step 1** comment.

1. To add public properties and a private list of transactions to the BankAccount class, enter the following code:

    ```csharp
        public BankAccountNumber AccountNumber { get; }
        public BankAccountType AccountType { get; }
        public decimal Balance { get; private set; }
        public AccountHolderDetails AccountHolder { get; }
        private List<Transaction> Transactions { get; } = new();
    ```

1. Locate the **Task 3: Step 2** comment.

1. To add a constructor that initializes the properties of the `BankAccount` class, enter the following code:

    ```csharp
    public BankAccount(int accountNumber, AccountType type, Customer accountHolder, double initialBalance = 0)
    {
        AccountNumber = accountNumber;
        Type = type;
        AccountHolder = accountHolder;
        Balance = initialBalance;
    }
    ```

1. Locate the **Task 3: Step 3** comment.

1. To add a method for deposits/withdrawals that updates the balance and records the transaction, enter the following code:

    ```csharp
    public void AddTransaction(decimal amount, string description)
    {
        Balance += amount;
        Transactions.Add(new Transaction(amount, DateTime.Now, description));
    }
    ```

1. Locate the **Task 3: Step 4** comment.

1. To add a method that displays account information, enter the following code:

    ```csharp
    public string DisplayAccountInfo()
    {
        return $"Account Holder: {AccountHolder.Name}, Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance:C}";
    }
    ```

1. Locate the **Task 3: Step 5** comment.

1. To add method that displays the list of transactions, enter the following code:

    ```csharp
    public void DisplayTransactions()
    {
        Console.WriteLine("Transactions:");
        foreach (var transaction in Transactions)
        {
            Console.WriteLine(transaction);
        }
    }
    ```

1. Save your changes.

## Task 4: Display basic bank account information

Developers use a record class like AccountHolderDetails when they want rich, immutable data carriers with value-based equality and object semantics. A small readonly struct like BankAccountNumber is used by developers when they need a compact, immutable value type with domain validation and value semantics.

In this task, you use AccountHolderDetails and BankAccountNumber to create a new bank account. Then, you display the account type description and account details.

Use the following steps to complete this task:

1. Open the Program.cs file.

1. Locate the **Task 4: Step 1** comment.

1. To create AccountHolderDetails and BankAccountNumber for a new bank account, enter the following code:

    ```csharp
    AccountHolderDetails accountHolderDetails = new("Tim Shao", "123456789", "123 Elm Street");
    BankAccountNumber accountNumber = new BankAccountNumber("000012345678");
    ```

1. Locate the **Task 4: Step 2** comment.

1. To create a Checking account with $500 using accountHolderDetails and accountNumber, enter the following code:

    ```csharp
    BankAccount bankAccount = new(accountNumber, BankAccountType.Checking, accountHolderDetails, 500m);
    ```

1. Locate the **Task 4: Step 3** comment.

1. To display the account type description and account details, enter the following code:

    ```csharp
    Console.WriteLine("\nTASK 4: Display basic bank account information");
    Console.WriteLine($"Account type description: {bankAccount.AccountType.GetDescription()}");
    Console.WriteLine(bankAccount.DisplayAccountInfo());
    ```

1. Save the Program.cs file.

1. Build and run the application.

    Ensure that the project builds successfully without errors. If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

1. Review the output in the terminal window.

    Your app should produce output similar to the following:

    ```plaintext
    Welcome to the Bank App!
    
    TASK 4: Display basic bank account information
    Account type description: A standard checking account.
    Account Holder: Tim Shao, Account Number: 000012345678, Type: Checking, Balance: $500.00
    ```

## Task 5: Demonstrate using the Transaction record

As a record class, `Transaction` has value-based equality and is naturally immutable, making it well-suited as an append-only ledger entry. Transactions are added to the `BankAccount` class to track deposits and withdrawals.

In this task, you'll use the `AddTransaction` method to perform deposits and withdrawals, and then display the updated account information.

1. Ensure that the Program.cs file is open.

1. Locate the **Task 5: Step 1** comment.

1. To use the AddTransaction method for deposits and withdrawals, enter the following code:

    ```csharp
    bankAccount.AddTransaction(200m, "Deposit");
    bankAccount.AddTransaction(-50m, "ATM Withdrawal");
    ```

1. Locate the **Task 5: Step 2** comment.

1. To display account information and transactions, enter the following code:

    ```csharp
    Console.WriteLine("\nTASK 5: Demonstrate using the Transaction record");
    Console.WriteLine(bankAccount.DisplayAccountInfo());
    bankAccount.DisplayTransactions();
    ```

1. Save the Program.cs file.

1. Build and run the application.

    Ensure that the project builds successfully without errors. If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

1. Review the output in the terminal window.

    Your app should produce output similar to the following:

    ```plaintext
    Welcome to the Bank App!
    
    TASK 4: Display basic bank account information
    Account type description: A standard checking account.
    Account Holder: Tim Shao, Account Number: 000012345678, Type: Checking, Balance: $500.00
    
    TASK 5: Demonstrate using the Transaction record
    Account Holder: Tim Shao, Account Number: 000012345678, Type: Checking, Balance: $650.00
    Transactions:
    1/9/2026: Deposit - $200.00
    1/9/2026: ATM Withdrawal - ($50.00)
    ```

## TASK 6: Demonstrate record comparison and the immutability of readonly structs

Records in C# support value-based equality, meaning that two record instances with identical property values are considered equal. This is particularly useful for data-centric applications where the focus is on the data itself rather than the identity of the object.

Readonly structs in C# are immutable, meaning that once an instance is created, its properties cannot be changed. This immutability ensures data integrity and consistency, especially when dealing with value types.

In this task, you'll demonstrate record comparison by creating two `AccountHolderDetails` objects with identical properties and comparing them. You'll also demonstrate the immutability of the `BankAccountNumber` struct by attempting to change its property.

Use the following steps to complete this task:

1. Ensure that the Program.cs file is open.

1. Locate the **Task 6: Step 1** comment.

1. To create a second AccountHolderDetails object with identical properties, enter the following code:

    ```csharp
    AccountHolderDetails customer2 = new("Tim Shao", "123456789", "123 Elm Street");
    ```

1. Locate the **Task 6: Step 2** comment.

1. To compare the two Customer objects using the == operator, enter the following code:

    ```csharp
    Console.WriteLine("\nTASK 6: Demonstrate record comparison and struct immutability");
    Console.WriteLine($"Are customers equal? {accountHolderDetails == customer2}");
    ```

1. Locate the **Task 6: Step 3** comment.

1. To create an instance of the readonly struct BankAccountNumber, enter the following code:

    ```csharp
    BankAccountNumber accountNumber2 = new BankAccountNumber("000123456789");
    Console.WriteLine($"Original Account Number: {accountNumber2}");
    ```

1. Save the Program.cs file.

1. Build and run the application.

    Ensure that the project builds successfully without errors. If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

1. Review the output in the terminal window.

    Your app should produce output similar to the following:

    ```plaintext
    Welcome to the Bank App!
    
    TASK 4: Display basic bank account information
    Account type description: A standard checking account.
    Account Holder: Tim Shao, Account Number: 000012345678, Type: Checking, Balance: $500.00
    
    TASK 5: Demonstrate using the Transaction record
    Account Holder: Tim Shao, Account Number: 000012345678, Type: Checking, Balance: $650.00
    Transactions:
    1/9/2026: Deposit - $200.00
    1/9/2026: ATM Withdrawal - ($50.00)
    
    TASK 6: Demonstrate record comparison and struct immutability
    Are customers equal? True
    Original Account Number: 000123456789
    ```

1. Locate the **Task 6: Step 4** comment.

1. Attempt to change the Value property of the BankAccountNumber struct by uncommenting the following code:

    ```csharp
    // accountNumber2.Value = "000987654321"; // Uncommenting this line will cause an error
    ```

1. Notice that uncommenting the line will result in a compilation error, demonstrating the immutability of the readonly struct.

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Additionally, building a portfolio of projects can be a great way to demonstrate your skills to potential employers.

If you no longer need the project files, you can delete the folder to free up space on your computer. However, it's recommended to keep a copy of the completed project for future reference or as part of your coding portfolio.
