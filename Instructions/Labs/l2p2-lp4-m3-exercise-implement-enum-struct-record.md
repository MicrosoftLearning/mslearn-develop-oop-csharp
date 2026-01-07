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

Suppose you're a software developer at a tech company working on a new project. Your team needs to implement a banking application that uses enums, structs, and records to manage account types, transactions, and customer details. To ensure consistent behavior, you decide to create and implement these features in a simple console application.

You've developed an initial version of the app that includes the following files:

- `Program.cs`: This file contains the main entry point of the application, demonstrating how to use enums, structs, and records in a banking application.
- `Bank.cs`: This file defines the `AccountType` enum, `Transaction` struct, `Customer` record, and `BankAccount` class.

This exercise includes the following tasks:

1. Define the `AccountType` enum.
1. Define the `Transaction` struct.
1. Define the `Customer` record.
1. Implement the `BankAccount` class.
1. Display basic bank account information.
1. Perform transactions.
1. Display transaction history.
1. Demonstrate record comparison.
1. Demonstrate immutability of structs.

## Review the current version of your project

In this task, you download the existing version of your project and review the code.

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

1. Take a few minutes to open and review the Program.cs and Bank.cs files.

    - `Program.cs`: This file contains the main entry point of the application, demonstrating how to use enums, structs, and records in a banking application.
    - `Bank.cs`: This file defines the `AccountType` enum, `Transaction` struct, `Customer` record, and `BankAccount` class.

1. Run the app and review the output in the terminal window.

    To run your app, right-click the **Data_M3** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    > **TIP**: If you encounter any issues while completing this exercise, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code. If you're still having trouble, you can review the solution code in the sample apps that you downloaded at the beginning of this exercise. To view the Data_M3 solution, navigate to the LP4SampleApps/Data_M3/Solution folder and open the Solution project in Visual Studio Code.

## Task 1: Define the `AccountType` enum

In this task, you'll define an enum named `AccountType` to represent different types of bank accounts. Enums are a great way to define a set of named constants, making your code more readable and maintainable.

Use the following steps to complete this task:

1. Open the `Bank.cs` file in the **Starter** folder.

1. Locate the placeholder comment for **Task 1**.

1. Define an enum named `AccountType` with the following values:
    - `Checking`
    - `Savings`
    - `Business`

    Your `AccountType` enum should look like this:

    ```csharp
    public enum AccountType
    {
        Checking,
        Savings,
        Business
    }
    ```

1. Save your changes.

### What you should see

The `AccountType` enum defines a set of named constants (`Checking`, `Savings`, `Business`) that represent different types of bank accounts. This makes the code more readable and ensures consistent account type values throughout the application.

---

## Task 2: Define the `Transaction` struct

In this task, you'll define a struct named `Transaction` to represent individual transactions in the banking application. Structs are value types in C# that are ideal for representing small, immutable objects.

Use the following steps to complete this task:

1. Open the `Bank.cs` file in the **Starter** folder.

1. Locate the placeholder comment for **Task 2**.

1. Define a struct named `Transaction` with the following properties:
    - `Amount` (type: `double`)
    - `Date` (type: `DateTime`)
    - `Description` (type: `string`)

1. Add a constructor to initialize the properties of the `Transaction` struct.

1. Override the `ToString` method to return a formatted string that includes the date, description, and amount of the transaction.

    Your `Transaction` struct should look like this:

    ```csharp
    public readonly struct Transaction
    {
        public double Amount { get; }
        public DateTime Date { get; }
        public string Description { get; }

        public Transaction(double amount, DateTime date, string description)
        {
            Amount = amount;
            Date = date;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()}: {Description} - {Amount:C}";
        }
    }
    ```

1. Save your changes.

### What you should see

The `Transaction` struct represents individual transactions with properties for the amount, date, and description. It uses a constructor for initialization and overrides the `ToString` method to format transaction details for display.

---

## Task 3: Define the `Customer` record

In this task, you'll define a record named `Customer` to represent customer details in the banking application. Records are immutable reference types in C# that are ideal for representing data with value-based equality.

Use the following steps to complete this task:

1. Open the `Bank.cs` file in the **Starter** folder.

1. Locate the placeholder comment for **Task 3**.

1. Define a record named `Customer` with the following properties:
    - `Name` (type: `string`)
    - `CustomerId` (type: `string`)
    - `Address` (type: `string`)

    Your `Customer` record should look like this:

    ```csharp
    public record Customer(string Name, string CustomerId, string Address);
    ```

1. Save your changes.

### What you should see

The `Customer` record is an immutable data type that represents customer details, such as name, ID, and address. Records in C# provide value-based equality, making them ideal for representing data objects.

---

## Task 4: Implement the `BankAccount` class

In this task, you'll implement the `BankAccount` class to manage bank accounts in the application. This class will include properties, a constructor, and methods to handle account operations such as deposits, withdrawals, and displaying account information.

Use the following steps to complete this task:

1. Open the `Bank.cs` file in the **Starter** folder.

1. Locate the placeholder comment for **Task 4**.

1. Add the following properties to the `BankAccount` class:
    - `AccountNumber` (type: `int`, read-only)
    - `Type` (type: `AccountType`, read-only)
    - `AccountHolder` (type: `Customer`, read-only)
    - `Balance` (type: `double`, private set)

1. Add a constructor to initialize the properties of the `BankAccount` class. The constructor should accept the following parameters:
    - `accountNumber` (type: `int`)
    - `type` (type: `AccountType`)
    - `accountHolder` (type: `Customer`)
    - `initialBalance` (type: `double`, optional, default value: `0`)

    Your constructor should look like this:

    ```csharp
    public BankAccount(int accountNumber, AccountType type, Customer accountHolder, double initialBalance = 0)
    {
        AccountNumber = accountNumber;
        Type = type;
        AccountHolder = accountHolder;
        Balance = initialBalance;
    }
    ```

1. Add a method named `AddTransaction` to deposit money into the account. This method should:
    - Accept two parameters: `amount` (type: `double`) and `description` (type: `string`).
    - Update the `Balance` property by adding the `amount`.
    - Add a new `Transaction` to a private list of transactions.

1. Add a method named `DisplayAccountInfo` to return a formatted string with the account holder's name, account number, account type, and balance.

    Your `DisplayAccountInfo` method should look like this:

    ```csharp
    public string DisplayAccountInfo()
    {
        return $"Account Holder: {AccountHolder.Name}, Account Number: {AccountNumber}, Type: {Type}, Balance: {Balance:C}";
    }
    ```

1. Add a private list of transactions to the class:
    ```csharp
    private List<Transaction> Transactions { get; } = new();
    ```

1. Add a method named `DisplayTransactions` to iterate through the list of transactions and print each transaction to the console.

    Your `DisplayTransactions` method should look like this:

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

### What you should see

The `BankAccount` class ties together the `AccountType` enum, `Transaction` struct, and `Customer` record to manage bank accounts. It includes properties, a constructor, and methods for handling deposits, withdrawals, and displaying account information.

---

## Task 5: Display Basic Bank Account Information

In this task, you'll use the `BankAccount` class to display basic account information, including the account holder's name, account number, account type, and balance.

Use the following steps to complete this task:

1. Open the `Program.cs` file in the **Starter** folder.

1. Locate the placeholder comment for **Task 5**.

1. Create a `Customer` object to represent the account holder. Use the following values:
    - `Name`: `"Tim Shao"`
    - `CustomerId`: `"C123456789"`
    - `Address`: `"123 Elm Street"`

    Your `Customer` object should look like this:

    ```csharp
    Customer customer1 = new("Tim Shao", "C123456789", "123 Elm Street");
    ```

1. Create a `BankAccount` object to represent the account. Use the following values:
    - `AccountNumber`: `12345678`
    - `Type`: `AccountType.Checking`
    - `AccountHolder`: `customer1`
    - `InitialBalance`: `500`

    Your `BankAccount` object should look like this:

    ```csharp
    BankAccount account = new(12345678, AccountType.Checking, customer1, 500);
    ```

1. Call the `DisplayAccountInfo` method on the `BankAccount` object and print the result to the console.

    Your code should look like this:

    ```csharp
    Console.WriteLine(account.DisplayAccountInfo());
    ```

1. Save your changes.

### What you should see

The `DisplayAccountInfo` method outputs the account holder's name, account number, account type, and balance. This demonstrates how the `BankAccount` class integrates with the `Customer` record and `AccountType` enum.

### Run the project

Save your changes and run the project to verify the output. You should see the following in the terminal:

```console
Account Holder: Tim Shao, Account Number: 12345678, Type: Checking, Balance: $500.00
```

---

## Task 6: Perform Transactions

In this task, you'll use the `BankAccount` class to perform transactions, including deposits and withdrawals. You'll also display the updated account information after each transaction.

Use the following steps to complete this task:

1. Open the `Program.cs` file in the **Starter** folder.

1. Locate the placeholder comment for **Task 6**.

1. Call the `AddTransaction` method on the `BankAccount` object to perform a deposit. Use the following values:
    - `Amount`: `200`
    - `Description`: `"Deposit"`

    Your code should look like this:

    ```csharp
    account.AddTransaction(200, "Deposit");
    ```

1. Print the updated account information to the console by calling the `DisplayAccountInfo` method.

    Your code should look like this:

    ```csharp
    Console.WriteLine("After deposit:");
    Console.WriteLine(account.DisplayAccountInfo());
    ```

1. Call the `AddTransaction` method on the `BankAccount` object to perform a withdrawal. Use the following values:
    - `Amount`: `-50`
    - `Description`: `"ATM Withdrawal"`

    Your code should look like this:

    ```csharp
    account.AddTransaction(-50, "ATM Withdrawal");
    ```

1. Print the updated account information to the console by calling the `DisplayAccountInfo` method.

    Your code should look like this:

    ```csharp
    Console.WriteLine("After withdrawal:");
    Console.WriteLine(account.DisplayAccountInfo());
    ```

1. Save your changes.

### What you should see

The `AddTransaction` method updates the account balance and records each transaction in a list. This demonstrates how the `Transaction` struct is used to track deposits and withdrawals.



### Run the project

Save your changes and run the project to verify the output. You should see the following in the terminal:

```console
After deposit: Account Holder: Tim Shao, Account Number: 12345678, Type: Checking, Balance: $700.00

After withdrawal: Account Holder: Tim Shao, Account Number: 12345678, Type: Checking, Balance: $650.00
```

---

## Task 7: Display Transaction History

In this task, you'll use the `BankAccount` class to display the transaction history for an account. This will include all deposits and withdrawals made on the account.

Use the following steps to complete this task:

1. Open the `Program.cs` file in the **Starter** folder.

1. Locate the placeholder comment for **Task 7**.

1. Call the `DisplayTransactions` method on the `BankAccount` object to print the transaction history to the console.

    Your code should look like this:

    ```csharp
    account.DisplayTransactions();
    ```

1. Save your changes.

### What you should see

The `DisplayTransactions` method iterates through the list of transactions and prints each one to the console. This demonstrates how the `Transaction` struct and collections work together to manage and display transaction history.

### Run the project

Save your changes and run the project to verify the output. You should see the following in the terminal:

```console
Transactions: 4/1/2025: Deposit - $200.00 4/1/2025: ATM Withdrawal - ($50.00)
```

---

## Task 8: Demonstrate Record Comparison

In this task, you'll demonstrate how C# records support value-based equality by creating and comparing two `Customer` objects with identical properties.

Use the following steps to complete this task:

1. Open the `Program.cs` file in the **Starter** folder.

1. Locate the placeholder comment for **Task 8**.

1. Create two `Customer` objects with identical properties. Use the following values for both objects:
    - `Name`: `"Tim Shao"`
    - `CustomerId`: `"C123456789"`
    - `Address`: `"123 Elm Street"`

    Your code should look like this:

    ```csharp
    Customer customer1 = new("Tim Shao", "C123456789", "123 Elm Street");
    Customer customer2 = new("Tim Shao", "C123456789", "123 Elm Street");
    ```

1. Compare the two `Customer` objects using the `==` operator and print the result to the console.

    Your code should look like this:

    ```csharp
    Console.WriteLine($"Are customers equal? {customer1 == customer2}");
    ```

1. Save your changes.

### What you should see

The comparison of two `Customer` objects demonstrates value-based equality in C# records. Even though the objects are separate instances, they are considered equal because their property values are identical.

### Run the project

Save your changes and run the project to verify the output. You should see the following in the terminal:

```console
Are customers equal? True
```

---

## Task 9: Demonstrate Immutability of Structs

In this task, you'll demonstrate the immutability of structs by creating a `Transaction` object and displaying its details. Structs in C# are value types and are immutable when their properties are read-only.

Use the following steps to complete this task:

1. Open the `Program.cs` file in the **Starter** folder.

1. Locate the placeholder comment for **Task 9**.

1. Create a `Transaction` object to represent a transaction. Use the following values:
    - `Amount`: `100`
    - `Date`: `DateTime.Now`
    - `Description`: `"Test Transaction"`

    Your code should look like this:

    ```csharp
    Transaction transaction = new(100, DateTime.Now, "Test Transaction");
    ```

1. Print the details of the `Transaction` object to the console by calling its `ToString` method.

    Your code should look like this:

    ```csharp
    Console.WriteLine($"Immutable Transaction: {transaction}");
    ```

1. Save your changes.

### What you should see

The `Transaction` struct is immutable because its properties are read-only. Once a `Transaction` object is created, its values cannot be changed, ensuring data integrity.

### Run the project

Save your changes and run the project to verify the output. You should see the following in the terminal:

```console
Immutable Transaction: 4/1/2025: Test Transaction - $100.00
```

---

## Check your work

After completing all tasks, save your work and run the application to verify that all functionality is implemented correctly. Ensure that the application builds successfully and produces the expected output for each task.

### Run the project

1. Open the `Program.cs` file in the **Starter** folder.

1. Run the application by selecting **Debug** > **Start Without Debugging** in Visual Studio Code or by using the terminal command:

    ```bash
    dotnet run
    ```

1. Verify that the application produces the following output in the terminal:

```console
Account Holder: Tim Shao, Account Number: 12345678, Type: Checking, Balance: $500.00

After deposit:
Account Holder: Tim Shao, Account Number: 12345678, Type: Checking, Balance: $700.00

After withdrawal:
Account Holder: Tim Shao, Account Number: 12345678, Type: Checking, Balance: $650.00

Transactions:
4/1/2025: Deposit - $200.00
4/1/2025: ATM Withdrawal - ($50.00)

Are customers equal? True

Immutable Transaction: 4/1/2025: Test Transaction - $100.00
```

---

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Additionally, building a portfolio of projects can be a great way to demonstrate your skills to potential employers.

If you no longer need the project files, you can delete the folder to free up space on your computer. However, it's recommended to keep a copy of the completed project for future reference or as part of your coding portfolio.
