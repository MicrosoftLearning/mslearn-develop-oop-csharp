---
lab:
    title: 'Exercise - Implement Generics and Anonymous Types in a Banking Application'
    description: 'Learn how to implement generics, advanced generics, and anonymous types in C#. Explore their use in a banking application to manage accounts, transactions, and customers.'
---

# Implement Generics and Anonymous Types in a Banking Application

Generics and anonymous types are powerful tools in C# that allow you to create reusable, type-safe, and efficient code. In this exercise, you will explore how generics enable you to work with collections and methods in a type-safe manner, while anonymous types allow you to group related data into temporary objects without defining a full class. You will implement these concepts in a banking application by defining an enum for account types, a struct for transactions, and a record for customer details. Additionally, you will implement a class to manage bank accounts and use anonymous types to summarize transaction details efficiently.

This exercise takes approximately **25** minutes to complete.

## Before you start

Before you can start this exercise, you need to:

1. Ensure that you have the latest short-term support (STS) version of the .NET SDK installed on your computer. You can download the latest versions of the .NET SDK using the following URL: <a href="https://dotnet.microsoft.com/download/" target="_blank">Download .NET</a>

1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code using the following URL: <a href="https://code.visualstudio.com/download/" target="_blank">Download Visual Studio Code</a>

1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For additional help configuring the Visual Studio Code environment, see <a href="https://learn.microsoft.com/training/modules/install-configure-visual-studio-code/" target="_blank">Install and configure Visual Studio Code for C# development</a>

## Exercise scenario

Suppose you're a software developer at a tech company working on a new project. Your team needs to implement a banking application that uses generics and anonymous types to manage account types, transactions, and customer details. To ensure consistent behavior, you decide to create and implement these features in a simple console application.

You've developed an initial version of the app that includes the following files:

- `Program.cs`: This file contains the main entry point of the application, demonstrating how to use generics and anonymous types in a banking application.
- `Bank.cs`: This file defines the `AccountType` enum, `Transaction` struct, `Customer` record, and `BankAccount` class.

This exercise includes the following tasks:

1. Define the `AccountType` enum and `Transaction` struct.
1. Define the `Customer` record.
1. Implement the `BankAccount` class.
1. Use anonymous types to summarize transaction details.
1. Demonstrate record comparison and the immutability of structs.
1. Display basic bank account information.
1. Perform transactions.
1. Display transaction history.

## Review the current version of your project

In this task, you download the existing version of your project and review the code.

Use the following steps to complete this section of the exercise:

1. Download the starter code from the following URL: [Implement Collection Types - exercise code projects](https://github.com/MicrosoftLearning/mslearn-develop-oop-csharp/blob/main/DownloadableCodeProjects/Downloads/LP4SampleApps.zip)
    ![Image of raw file download button for zip on toolbar.](../labs/Media/zip-download-button.png)
1. Extract the contents of the LP4SampleApps.zip file to a folder location on your computer.

1. Expand the LP4SampleApps folder, and then open the `Data_M4` folder.

    The Data_M4 folder contains the following code project folders:

    - Solution
    - Starter

    The **Starter** folder contains the starter project files for this exercise.

1. Use Visual Studio Code to open the **Starter** folder.

1. In the EXPLORER view, collapse the **STARTER** folder, select **SOLUTION EXPLORER**, and expand the **Data_M4** project.

    You should see the following project files:

    - Program.cs
    - Bank.cs

1. Take a few minutes to open and review the Program.cs and Bank.cs files.

    - `Program.cs`: This file contains the main entry point of the application, demonstrating how to use generics and anonymous types in a banking application.
    - `Bank.cs`: This file defines the `AccountType` enum, `Transaction` struct, `Customer` record, and `BankAccount` class.

1. Run the app and review the output in the terminal window.

    To run your app, right-click the **Data_M4** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    > [!TIP]
    > If you encounter any issues while completing this exercise, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code. If you're still having trouble, you can review the solution code in the sample apps that you downloaded at the beginning of this exercise. To view the Data_M4 solution, navigate to the LP4SampleApps/Data_M4/Solution folder and open the Solution project in Visual Studio Code.

## Task 1: Define the `AccountType` Enum and `Transaction` Struct

In this task, you'll define an enum named `AccountType` to represent different types of bank accounts and a struct named `Transaction` to represent individual transactions. These are foundational building blocks for creating reusable and type-safe code in C#. The `Transaction` struct will later be used in a generic collection to manage transactions efficiently.

### Steps

1. Open the `Bank.cs` file in the **Starter** folder.

1. Locate the placeholder comment for **Task 1: Step 1**.

1. Define an enum named `AccountType` with the following values:
    - `Checking`
    - `Savings`
    - `Business`

    ```csharp
    public enum AccountType
    {
        Checking,
        Savings,
        Business
    }
    ```

1. Locate the placeholder comment for **Task 2: Step 1**.

1. Define a struct named `Transaction` with the following:
    - Properties:
        - `Amount` (type: `double`)
        - `Date` (type: `DateTime`)
        - `Description` (type: `string`)
    - A constructor to initialize the properties.
    - An overridden `ToString` method to format transaction details.

    ```csharp
    public struct Transaction
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

---

### What you should see

The `AccountType` enum defines a set of named constants (`Checking`, `Savings`, `Business`) that represent different types of bank accounts. The `Transaction` struct represents individual transactions with properties for the amount, date, and description. It uses a constructor for initialization and overrides the `ToString` method to format transaction details for display.

These definitions will later be used in generic collections to manage transactions in a type-safe way and in methods that summarize transaction details using anonymous types.

---

## Task 2: Define the `Customer` Record

In this task, you'll define a record named `Customer` to represent customer details such as their name, ID, and address. Records in C# are immutable by default, making them ideal for representing data that shouldn't change after it's created. This record will later be used to associate accounts with customers in the `BankAccount` class.

### Steps

1. In Bank.cs, locate the placeholder comment for **Task 3: Step 1**.

1. Define a record named `Customer` with the following properties:
    - `Name` (type: `string`)
    - `CustomerId` (type: `string`)
    - `Address` (type: `string`)

    ```csharp
    public record Customer
    {
        public string Name { get; init; }
        public string CustomerId { get; init; }
        public string Address { get; init; }
    }
    ```

1. Save your changes.

---

### What you should see

The `Customer` record defines an immutable data structure with properties for the customer's name, ID, and address. This record will later be used in the `BankAccount` class to associate accounts with customers and in methods that demonstrate record comparison. Its immutability ensures that customer data remains consistent throughout the application.

---

## Task 3: Implement the `BankAccount` Class

In this task, you'll implement a class named `BankAccount` to manage bank accounts and their associated transactions. The `BankAccount` class will include properties for account details, methods for deposits and withdrawals, and functionality to display account information. It will also use a generic collection (`List<Transaction>`) to store transactions, ensuring type safety and reusability.

### Steps

1. In `Bank.cs`, locate the placeholder comment for **Task 3: Step 1**.

1. Define the `BankAccount` class and add the following properties:
    - `AccountNumber` (type: `int`)
    - `Balance` (type: `double`)
    - `AccountHolder` (type: `Customer`)
    - `Type` (type: `AccountType`)

    ```csharp
    public class BankAccount
    {
        public int AccountNumber { get; }
        public double Balance { get; private set; }
        public Customer AccountHolder { get; }
        public AccountType Type { get; }
    }
    ```

1. Locate the placeholder comment for **Task 3: Step 2**.

1. Add a private list to track transactions.

    ```csharp
    private List<Transaction> _transactions = new();
    ```

1. Locate the placeholder comment for **Task 3: Step 3**.

1. Add a constructor to initialize the properties.

    ```csharp
    public BankAccount(int accountNumber, double initialBalance, Customer accountHolder, AccountType type)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
        AccountHolder = accountHolder;
        Type = type;
    }
    ```

1. Locate the placeholder comment for **Task 3: Step 4**.

1. Add a `Deposit` method to:
    - Add the specified amount to the balance.
    - Create a new `Transaction` object and add it to the `_transactions` list.

    ```csharp
    public void Deposit(double amount, string description)
    {
        if (amount > 0)
        {
            Balance += amount;
            _transactions.Add(new Transaction(amount, DateTime.Now, description));
        }
    }
    ```

1. Locate the placeholder comment for **Task 3: Step 5**.

1. Add a `Withdraw` method to:
    - Subtract the specified amount from the balance if sufficient funds are available.
    - Create a new `Transaction` object and add it to the `_transactions` list.

    ```csharp
    public bool Withdraw(double amount, string description)
    {
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            _transactions.Add(new Transaction(-amount, DateTime.Now, description));
            return true;
        }
        return false;
    }
    ```

1. Locate the placeholder comment for **Task 3: Step 6**.

1. Add a `DisplayAccountInfo` method to return a formatted string with account details.

    ```csharp
    public string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Balance: {Balance:C}, Account Holder: {AccountHolder.Name}, Type: {Type}";
    }
    ```

1. Locate the placeholder comment for **Task 3: Step 7**.

1. Add a `DisplayTransactions` method to iterate through the `_transactions` list and display each transaction using the `ToString` method.

    ```csharp
    public void DisplayTransactions()
    {
        Console.WriteLine("Transaction History:");
        foreach (var transaction in _transactions)
        {
            Console.WriteLine(transaction);
        }
    }
    ```

1. Save your changes.

---

### What you should see

The `BankAccount` class defines a reusable and type-safe structure for managing bank accounts and their transactions. It uses a generic collection (`List<Transaction>`) to store transactions. The methods in this class allow you to perform deposits and withdrawals, display account information, and list all transactions.

---

## Task 4: Implement the `BankAccount` Class

In this task, you'll continue implementing the `BankAccount` class to manage bank accounts and their transactions. You'll add properties, a constructor, and methods for deposits, withdrawals, and displaying account information. This task demonstrates the use of **generic collections** (`List<Transaction>`) to store transactions in a type-safe and reusable way, as well as encapsulation to protect the internal state of the class.

### Steps

1. Open the `Bank.cs` file in the **Starter** folder.

1. Locate the placeholder comment for **Task 4: Step 1**.

1. Add the following properties to the `BankAccount` class:
    - `AccountNumber` (type: `int`, read-only)
    - `Balance` (type: `double`, private set)
    - `AccountHolder` (type: `Customer`, read-only)
    - `Type` (type: `AccountType`, read-only)

    ```csharp
    public int AccountNumber { get; }
    public double Balance { get; private set; }
    public Customer AccountHolder { get; }
    public AccountType Type { get; }
    ```

1. Locate the placeholder comment for **Task 4: Step 2**.

1. Add a constructor to initialize the properties.

    ```csharp
    public BankAccount(int accountNumber, double initialBalance, Customer accountHolder, AccountType type)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
        AccountHolder = accountHolder;
        Type = type;
    }
    ```

1. Locate the placeholder comment for **Task 4: Step 3**.

1. Add a `Deposit` method to:
    - Add the specified amount to the balance.
    - Create a new `Transaction` object and add it to the `_transactions` list.

    ```csharp
    public void Deposit(double amount, string description)
    {
        if (amount > 0)
        {
            Balance += amount;
            _transactions.Add(new Transaction(amount, DateTime.Now, description));
        }
    }
    ```

1. Locate the placeholder comment for **Task 4: Step 4**.

1. Add a `Withdraw` method to:
    - Subtract the specified amount from the balance if sufficient funds are available.
    - Create a new `Transaction` object and add it to the `_transactions` list.

    ```csharp
    public bool Withdraw(double amount, string description)
    {
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            _transactions.Add(new Transaction(-amount, DateTime.Now, description));
            return true;
        }
        return false;
    }
    ```

1. Locate the placeholder comment for **Task 4: Step 5**.

1. Add a `DisplayAccountInfo` method to return a formatted string with account details.

    ```csharp
    public string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Balance: {Balance:C}, Account Holder: {AccountHolder.Name}, Type: {Type}";
    }
    ```

1. Locate the placeholder comment for **Task 4: Step 6**.

1. Add a private list to track transactions.

    ```csharp
    private List<Transaction> _transactions = new();
    ```

1. Locate the placeholder comment for **Task 4: Step 7**.

1. Add a `DisplayTransactions` method to iterate through the `_transactions` list and display each transaction using the `ToString` method.

    ```csharp
    public void DisplayTransactions()
    {
        Console.WriteLine("Transaction History:");
        foreach (var transaction in _transactions)
        {
            Console.WriteLine(transaction);
        }
    }
    ```

1. Save your changes.

---

### What you should see

The `BankAccount` class now includes properties for account details, methods for deposits and withdrawals, and functionality to display account information. It also uses a generic collection (`List<Transaction>`) to store transactions. These additions make the `BankAccount` class a reusable and type-safe structure for managing bank accounts and their transactions.

---

## Task 5: Display Basic Bank Account Information

In this task, you'll create a `BankAccount` object and display its basic information, including the account number, balance, account holder, and account type. This task highlights the use of **records** (e.g., `Customer`) for immutable data structures and demonstrates how to initialize and use the `BankAccount` class effectively.

### Steps

1. Open the `Program.cs` file in the **Starter** folder.

1. Locate the placeholder comment for **Task 5**.

1. Create a `Customer` object to represent the account holder. Use the following properties:
    - `Name`: `"John Doe"`
    - `CustomerId`: `"C12345"`
    - `Address`: `"123 Main St"`

    ```csharp
    Customer customer = new Customer
    {
        Name = "John Doe",
        CustomerId = "C12345",
        Address = "123 Main St"
    };
    ```

1. Create a `BankAccount` object using the following parameters:
    - `AccountNumber`: `12345678`
    - `InitialBalance`: `500`
    - `AccountHolder`: The `Customer` object you just created.
    - `Type`: `AccountType.Checking`

    ```csharp
    BankAccount account = new BankAccount(12345678, 500, customer, AccountType.Checking);
    ```

1. Display the account information by calling the `DisplayAccountInfo` method.

    ```csharp
    Console.WriteLine(account.DisplayAccountInfo());
    ```

1. Save your changes.

---

### What you should see

When you run the application, the console should display the basic information for the bank account, including the account number, balance, account holder's name, and account type. For example:

```
Account Number: 12345678, Balance: $500.00, Account Holder: John Doe, Type: Checking
```

---

## Task 6: Perform Transactions

In this task, you'll enhance the functionality of the `BankAccount` class by performing transactions. Specifically, you'll add a deposit and a withdrawal to the account. Each transaction will update the account balance and be recorded in the `_transactions` list using the `Transaction` struct. This task demonstrates how to use **generic collections** to manage transaction data and encapsulate logic for updating account balances and recording transaction details.

### Steps

1. Open the `Program.cs` file in the **Starter** folder.

1. Locate the placeholder comment for **Task 6**.

1. Add a deposit to the account using the `Deposit` method. Use the following parameters:
    - `Amount`: `200`
    - `Description`: `"Paycheck"`

    ```csharp
    account.Deposit(200, "Paycheck");
    ```

1. Display the updated account information by calling the `DisplayAccountInfo` method.

    ```csharp
    Console.WriteLine("After deposit:");
    Console.WriteLine(account.DisplayAccountInfo());
    ```

1. Add a withdrawal from the account using the `Withdraw` method. Use the following parameters:
    - `Amount`: `100`
    - `Description`: `"Groceries"`

    ```csharp
    bool success = account.Withdraw(100, "Groceries");
    ```

1. Display whether the withdrawal was successful or not.

    ```csharp
    Console.WriteLine(success ? "Withdrawal successful." : "Withdrawal failed.");
    ```

1. Display the updated account information by calling the `DisplayAccountInfo` method again.

    ```csharp
    Console.WriteLine("After withdrawal:");
    Console.WriteLine(account.DisplayAccountInfo());
    ```

1. Save your changes.

---

### What you should see

When you run the application, the console should display the updated account information after the deposit and withdrawal. For example:

```
After deposit:
Account Number: 12345678, Balance: $700.00, Account Holder: John Doe, Type: Checking

Withdrawal successful.
After withdrawal:
Account Number: 12345678, Balance: $600.00, Account Holder: John Doe, Type: Checking
```

---

## Task 7: Display Transaction History

In this task, you'll display the transaction history for a bank account. This task demonstrates how to iterate through a **generic collection** (`List<Transaction>`) and format data for display. It also highlights the importance of designing reusable methods, such as `DisplayTransactions`, to simplify code and improve readability.

### Steps

1. Open the `Program.cs` file in the **Starter** folder.

1. Locate the placeholder comment for **Task 7**.

1. Call the `DisplayTransactions` method on the `BankAccount` object to display the transaction history.

    ```csharp
    account.DisplayTransactions();
    ```

1. Save your changes.

---

### What you should see

When you run the application, the console should display the transaction history for the bank account. For example:

```
Transaction History:
4/2/2025: Paycheck - $200.00
4/2/2025: Groceries - -$100.00
```

This output shows the date, description, and amount for each transaction in the account.

### Check your work

After completing all the tasks, review your code to ensure it matches the provided instructions. Pay close attention to the following:

- The `BankAccount` class includes properties, methods, and a generic collection (`List<Transaction>`) to manage transactions.
- The `Customer` record and `Transaction` struct are implemented correctly and used in the `BankAccount` class.
- The `Program.cs` file demonstrates the creation of a `BankAccount` object, performs transactions, and displays transaction history.

If you encounter any issues, compare your code with the solution files provided in the **Solution** folder. Debugging and troubleshooting your code is an important part of the learning process.

---

### Run the project

To run your project and view the output:

1. Save all your changes.
2. Open the terminal in Visual Studio Code.
3. Run the project by pressing **F5** or using the following command in the terminal:

   ```bash
   dotnet run
   ```

When you run the project, you should see output similar to the following:

```plaintext
Welcome to the Bank App!
Account Number: 12345678, Balance: $500.00, Account Holder: John Doe, Type: Checking
After deposit:
Account Number: 12345678, Balance: $700.00, Account Holder: John Doe, Type: Checking
Withdrawal successful.
After withdrawal:
Account Number: 12345678, Balance: $600.00, Account Holder: John Doe, Type: Checking
Transaction History:
4/2/2025: Paycheck - $200.00
4/2/2025: Groceries - ($100.00)
```

If your output differs, review your code and ensure it matches the instructions provided in the tasks.

---

### Clean up

Now that you've finished the exercise, consider the following steps:

1. Archive your project files for future reference. This will allow you to revisit your work and track your progress over time.
2. Review the solution files provided in the **Solution** folder to compare your implementation with the intended solution.
3. Reflect on what you’ve learned in this exercise, including:
   - Using generics and anonymous types to build reusable and type-safe code.
   - Designing immutable data structures with records and structs.
   - Encapsulating logic in classes to manage state and behavior effectively.

By completing this exercise, you’ve gained valuable experience with generics, anonymous types, and object-oriented programming in C#. Keep practicing these concepts to further strengthen your skills.
