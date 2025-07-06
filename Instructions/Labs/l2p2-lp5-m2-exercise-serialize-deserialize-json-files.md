---
lab:
    title: 'Exercise - Serialize and deserialize JSON files'
    description: 'Learn how serialize and deserialize JSON using JsonSerializer methods, how to use JsonSerializerOptions to customize serialization and deserialization, and how to use Data Transfer Objects to implement serialization and deserialization when objects cannot be serialized directly.'
---

# Serialize and deserialize JSON files

In this exercise, you learn how to transform simple C# objects into JSON strings using `JsonSerializer.Serialize`, how to convert JSON strings into simple C# objects object using `JsonSerializer.Deserialize`, and how to use `JsonSerializerOptions` objects to customize serialization and deserialization for more complex objects. When C# objects can't be serialized directly due to design constraints, you learn how to create Data Transfer Objects (DTOs) and use the DTOs to implement serialization and deserialization without violating the encapsulation designed into the original C# objects.

This exercise takes approximately **30** minutes to complete.

## Before you start

Before you can start this exercise, you need to:

1. Ensure that you have the latest short term support (STS) version of the .NET SDK installed on your computer. You can download the latest versions of the .NET SDK using the following URL: <a href="https://dotnet.microsoft.com/download/" target="_blank">Download .NET</a>

1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code using the following URL: <a href="https://code.visualstudio.com/download/" target="_blank">Download Visual Studio Code</a>

1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For additional help configuring the Visual Studio Code environment, see <a href="https://learn.microsoft.com/training/modules/install-configure-visual-studio-code/" target="_blank">Install and configure Visual Studio Code for C# development</a>

## Exercise scenario

Suppose you've agreed to help a non-profit company with a software project. Before the project kicks off, you decide to update your object-oriented programming skills by developing a banking app. The current version of your app supports basic operations such as creating accounts, depositing and withdrawing money, and transferring funds between accounts. To practice JSON serialization and deserialization skills, you're going implement JSON file I/O in the app's Program.cs file and helper classes. You plan to work you way through some basic serialization and deserialization tasks and then finish up with more advanced tasks like storing and retrieving bank accounts.

This exercise includes the following tasks:

1. Review the current version of your banking app.

1. Use `JsonSerializer` to serialize and deserialize a `Transaction` object.

1. Use `JsonSerializer` to serialize and deserialize the transactions collection of a `BankAccount` object.

1. Use `JsonSerializer` with `JsonSerializerOptions` to serialize and deserialize a `BankAccount` object.

1. Use Data Transfer Objects and `JsonSerializer` with `JsonSerializerOptions` to serialize and deserialize a bank accounts.

1. Use service classes and Data Transfer Objects to back up and recover bank customer information.

## Review the current version of your banking app

In this task, you download the existing version of your banking app and review the code.

Use the following steps to complete this section of the exercise:

1. Download the starter code from the following URL: [Access local files asynchronously - exercise code projects](https://github.com/MicrosoftLearning/mslearn-develop-oop-csharp/raw/refs/heads/main/DownloadableCodeProjects/Downloads/LP5SampleApps.zip)

1. Extract the contents of the LP5SampleApps.zip file to a folder location on your computer.

    For example, if your running Windows, you can extract the file contents to your Desktop folder.

1. Expand the LP5SampleApps folder, and then open the `Files_M2` folder.

    The Files_M2 folder contains the following code project folders:

    - Solution
    - Starter

    The **Starter** folder contains the starter project files for this exercise.

1. Use Visual Studio Code to open the **Starter** folder.

1. In the EXPLORER view, collapse the **STARTER** folder, select **SOLUTION EXPLORER**, and expand the **Files_M2** project folders.

    You should see the following project folders and files:

    - Interfaces
        - IBankAccount.cs
        - IBankCustomer.cs
        - IMonthlyReportable.cs
        - IQuarterlyReportable.cs
        - IYearlyReportable.cs
    - Models
        - Bank.cs
        - BankAccount.cs
        - BankCustomer.cs
        - BankCustomerMethods.cs
        - CheckingAccount.cs
        - MoneyMarketAccount.cs
        - SavingsAccount.cs
        - Transaction.cs
    - Services
        - AccountCalculations.cs
        - AccountReportGenerator.cs
        - CustomerReportGenerator.cs
        - Extensions.cs
        - SimulateCustomerAccountActivity.cs
        - SimulateDepositsWithdrawalsTransfers.cs
        - SimulateTransactions.cs
    - Program.cs

1. Take a few minutes to open and review each of the following files:

    - `Bank.cs`: This file defines the Bank class, which implements a collection of bank customers and provides methods that manage customers and retrieve bank information.

    - `BankAccount.cs`: This file defines the BankAccount class, which implements the IBankAccount interface and includes properties, constructors, and methods for account operations.

    - `BankCustomer.cs`: This file defines the BankCustomer partial class, which implements the IBankCustomer interface and includes properties and constructors for customer constructor.

    - `BankCustomerMethods.cs`: This file defines the BankCustomerMethods partial class, which implements the IBankCustomer interface and contains methods for the BankCustomer class.

    - `CheckingAccount.cs`: This file defines the CheckingAccount class, which inherits from the BankAccount class and includes properties and methods specific to checking accounts.

    - `MoneyMarketAccount.cs`: This file defines the MoneyMarketAccount class, which inherits from the BankAccount class and includes properties and methods specific to money market accounts.

    - `SavingsAccount.cs`: This file defines the SavingsAccount class, which inherits from the BankAccount class and includes properties and methods specific to savings accounts.

    - `Transaction.cs`: This file defines the Transaction class, which includes properties and methods for managing transactions.

    - `Program.cs`: This file includes the main entry point for the app and uses BankCustomer and BankAccount objects implement deposit, withdrawal, and transfer operations.

    Notice that a bank object includes a collection of bank customer objects, and that each customer object includes a collection of bank accounts owned by that customer. The account objects include a collection of transactions, which provide a record of the deposits, withdrawals, and transfers associated with the account. The app can simulate customer account activity by generating transactions for each account. The app can also generates customer and account reports.

1. Run the app and review the output in the terminal window.

    To run your app, right-click the **Files_M2** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    Your app should produce output that's similar to the following example:

    ```plaintext

    Use the StreamWriter and StreamReader classes.
    
    Current directory: C:\Users\username\Desktop\LP5SampleApps-M2-Instructions\Files_M2\Starter\bin\Debug\net9.0
    Created directory: C:\Users\username\Desktop\LP5SampleApps-M2-Instructions\Files_M2\Starter\bin\Debug\net9.0\TransactionLogs
    
    Simulated transactions:
    
    d2dd1ce9-99b7-4c96-a17b-3e33da7a46f7,Withdraw,3/1/2025,12:00 PM,5000.00,2806.80,10226554,10226554,Rent payment
    f291241b-3407-4132-b0eb-b984f9cb52b7,Withdraw,3/1/2025,9:00 PM,2193.20,166.00,10226554,10226554,Debit card purchase
    4a4cd141-947e-4e8f-84f0-04b17c4fd4d6,Withdraw,3/3/2025,8:00 AM,2027.20,400.00,10226554,10226554,Withdraw for expenses
    5d719efa-6594-45b3-8f1c-dcc825482f6f,Bank Fee,3/3/2025,12:00 PM,1627.20,50.00,10226554,10226554,-(BANK FEE)
    8f23d246-81df-4bb5-96e1-513d4b76d613,Bank Refund,3/5/2025,12:00 PM,1577.20,100.00,10226554,10226554,Refund for overcharge -(BANK REFUND)
    93cff11c-b434-4b8d-be4b-f0245e48fe33,Withdraw,3/8/2025,9:00 PM,1677.20,207.00,10226554,10226554,Debit card purchase
    8508664c-2fd8-4c52-8837-a069905614a3,Withdraw,3/10/2025,8:00 AM,1470.20,400.00,10226554,10226554,Withdraw for expenses
    c08021f2-e859-43a3-b184-77fb37d3eb08,Bank Fee,3/10/2025,12:00 PM,1070.20,50.00,10226554,10226554,-(BANK FEE)
    b4c38cb5-89d0-45fc-b8ba-2686a14f6bab,Deposit,3/14/2025,12:00 PM,1020.20,3326.00,10226554,10226554,Bi-monthly salary deposit
    ecd7aed0-6590-42ac-8aad-c4e2f3510450,Withdraw,3/15/2025,9:00 PM,4346.20,215.00,10226554,10226554,Debit card purchase
    1457bd06-0aee-4b02-b28f-b03ad8cbb0e2,Withdraw,3/17/2025,8:00 AM,4131.20,400.00,10226554,10226554,Withdraw for expenses
    c9cb1078-4d53-4328-9b7e-0c92a5f257b3,Withdraw,3/20/2025,12:00 PM,3731.20,68.00,10226554,10226554,Auto-pay waste management bill
    18a523df-25a9-41f9-ac9d-78584bbf97fe,Withdraw,3/20/2025,12:00 PM,3663.20,87.00,10226554,10226554,Auto-pay water and sewer bill
    cdcf11d3-0b4a-4090-b9c8-5774605fe43b,Withdraw,3/20/2025,12:00 PM,3576.20,100.00,10226554,10226554,Auto-pay gas and electric bill
    e1d41a58-2387-467f-a762-78e25dde8dcf,Withdraw,3/20/2025,12:00 PM,3476.20,129.00,10226554,10226554,Auto-pay health club membership
    467a200e-129d-479a-937e-f1dbc284758c,Withdraw,3/22/2025,9:00 PM,3347.20,155.00,10226554,10226554,Debit card purchase
    c84262a1-2d0a-49c2-be8d-19f8117c9c59,Withdraw,3/24/2025,8:00 AM,3192.20,400.00,10226554,10226554,Withdraw for expenses
    d384b4df-32cc-4408-a3b9-1b893893e8bc,Withdraw,3/31/2025,12:00 PM,2792.20,1622.50,10226554,10226554,Auto-pay credit card bill
    9ffee615-e045-4fff-b053-722d8810cee8,Deposit,3/31/2025,12:00 PM,1169.70,3326.00,10226554,10226554,Bi-monthly salary deposit
    edc8beaa-c4a6-4bfb-9a9b-4736df72a8ab,Transfer,3/31/2025,12:00 PM,4495.70,800.00,10226554,10226554,Transfer from checking to savings account-(TRANSFER)
    40f1e6a9-c560-4363-91d6-680bd9edc213,Transfer,3/31/2025,12:00 PM,15000.00,800.00,10226555,10226555,Transfer from checking to savings account-(TRANSFER)
    
    Transaction data read from the CSV file:
    
    d2dd1ce9-99b7-4c96-a17b-3e33da7a46f7,Withdraw,3/1/2025,12:00 PM,5000.00,2806.80,10226554,10226554,Rent payment
    f291241b-3407-4132-b0eb-b984f9cb52b7,Withdraw,3/1/2025,9:00 PM,2193.20,166.00,10226554,10226554,Debit card purchase
    4a4cd141-947e-4e8f-84f0-04b17c4fd4d6,Withdraw,3/3/2025,8:00 AM,2027.20,400.00,10226554,10226554,Withdraw for expenses
    5d719efa-6594-45b3-8f1c-dcc825482f6f,Bank Fee,3/3/2025,12:00 PM,1627.20,50.00,10226554,10226554,-(BANK FEE)
    8f23d246-81df-4bb5-96e1-513d4b76d613,Bank Refund,3/5/2025,12:00 PM,1577.20,100.00,10226554,10226554,Refund for overcharge -(BANK REFUND)
    93cff11c-b434-4b8d-be4b-f0245e48fe33,Withdraw,3/8/2025,9:00 PM,1677.20,207.00,10226554,10226554,Debit card purchase
    8508664c-2fd8-4c52-8837-a069905614a3,Withdraw,3/10/2025,8:00 AM,1470.20,400.00,10226554,10226554,Withdraw for expenses
    c08021f2-e859-43a3-b184-77fb37d3eb08,Bank Fee,3/10/2025,12:00 PM,1070.20,50.00,10226554,10226554,-(BANK FEE)
    b4c38cb5-89d0-45fc-b8ba-2686a14f6bab,Deposit,3/14/2025,12:00 PM,1020.20,3326.00,10226554,10226554,Bi-monthly salary deposit
    ecd7aed0-6590-42ac-8aad-c4e2f3510450,Withdraw,3/15/2025,9:00 PM,4346.20,215.00,10226554,10226554,Debit card purchase
    1457bd06-0aee-4b02-b28f-b03ad8cbb0e2,Withdraw,3/17/2025,8:00 AM,4131.20,400.00,10226554,10226554,Withdraw for expenses
    c9cb1078-4d53-4328-9b7e-0c92a5f257b3,Withdraw,3/20/2025,12:00 PM,3731.20,68.00,10226554,10226554,Auto-pay waste management bill
    18a523df-25a9-41f9-ac9d-78584bbf97fe,Withdraw,3/20/2025,12:00 PM,3663.20,87.00,10226554,10226554,Auto-pay water and sewer bill
    cdcf11d3-0b4a-4090-b9c8-5774605fe43b,Withdraw,3/20/2025,12:00 PM,3576.20,100.00,10226554,10226554,Auto-pay gas and electric bill
    e1d41a58-2387-467f-a762-78e25dde8dcf,Withdraw,3/20/2025,12:00 PM,3476.20,129.00,10226554,10226554,Auto-pay health club membership
    467a200e-129d-479a-937e-f1dbc284758c,Withdraw,3/22/2025,9:00 PM,3347.20,155.00,10226554,10226554,Debit card purchase
    c84262a1-2d0a-49c2-be8d-19f8117c9c59,Withdraw,3/24/2025,8:00 AM,3192.20,400.00,10226554,10226554,Withdraw for expenses
    d384b4df-32cc-4408-a3b9-1b893893e8bc,Withdraw,3/31/2025,12:00 PM,2792.20,1622.50,10226554,10226554,Auto-pay credit card bill
    9ffee615-e045-4fff-b053-722d8810cee8,Deposit,3/31/2025,12:00 PM,1169.70,3326.00,10226554,10226554,Bi-monthly salary deposit
    edc8beaa-c4a6-4bfb-9a9b-4736df72a8ab,Transfer,3/31/2025,12:00 PM,4495.70,800.00,10226554,10226554,Transfer from checking to savings account-(TRANSFER)
    40f1e6a9-c560-4363-91d6-680bd9edc213,Transfer,3/31/2025,12:00 PM,15000.00,800.00,10226555,10226555,Transfer from checking to savings account-(TRANSFER)
    
    Use the FileStream class to perform file I/O operations.
    
    File length after write: 2763 bytes
    
    Transaction data written using FileStream. File: C:\Users\username\Desktop\LP5SampleApps-M2-Instructions\Files_M2\Starter\bin\Debug\net9.0\filestream.txt
    
    Using FileStream to read/display transaction data.
    
    bytes read: TransactionId,TransactionType,TransactionDate,TransactionTime,PriorBalance,TransactionAmount,SourceAccountNumber,TargetAccountNumber,Description
    d2dd1ce9-99b7-4c96-a17b-3e33da7a46f7,Withdraw,3/1/2025,12:00 PM,5000.00,2806.80,10226554,10226554,Rent payment
    f291241b-3407-4132-b0eb-b984f9cb52b7,Withdraw,3/1/2025,9:00 PM,2193.20,166.00,10226554,10226554,Debit card purchase
    4a4cd141-947e-4e8f-84f0-04b17c4fd4d6,Withdraw,3/3/2025,8:00 AM,2027.20,400.00,10226554,10226554,Withdraw for expenses
    5d719efa-6594-45b3-8f1c-dcc825482f6f,Bank Fee,3/3/2025,12:00 PM,1627.20,50.00,10226554,10226554,-(BANK FEE)
    8f23d246-81df-4bb5-96e1-513d4b76d613,Bank Refund,3/5/2025,12:00 PM,1577.20,100.00,10226554,10226554,Refund for overcharge -(BANK REFUND)
    93cff11c-b434-4b8d-be4b-f0245e48fe33,Withdraw,3/8/2025,9:00 PM,1677.20,207.00,10226554,10226554,Debit card purchase
    8508664c-2fd8-4c52-8837-a069905614a3,Withdraw,3/10/2025,8:00 AM,1470.20,400.00,10226554,10226554,Withdraw for expenses
    c08021f2-e859-43a3-b184-77fb37d3eb08,Bank Fee,
    
    bytes read: 3/10/2025,12:00 PM,1070.20,50.00,10226554,10226554,-(BANK FEE)
    b4c38cb5-89d0-45fc-b8ba-2686a14f6bab,Deposit,3/14/2025,12:00 PM,1020.20,3326.00,10226554,10226554,Bi-monthly salary deposit
    ecd7aed0-6590-42ac-8aad-c4e2f3510450,Withdraw,3/15/2025,9:00 PM,4346.20,215.00,10226554,10226554,Debit card purchase
    1457bd06-0aee-4b02-b28f-b03ad8cbb0e2,Withdraw,3/17/2025,8:00 AM,4131.20,400.00,10226554,10226554,Withdraw for expenses
    c9cb1078-4d53-4328-9b7e-0c92a5f257b3,Withdraw,3/20/2025,12:00 PM,3731.20,68.00,10226554,10226554,Auto-pay waste management bill
    18a523df-25a9-41f9-ac9d-78584bbf97fe,Withdraw,3/20/2025,12:00 PM,3663.20,87.00,10226554,10226554,Auto-pay water and sewer bill
    cdcf11d3-0b4a-4090-b9c8-5774605fe43b,Withdraw,3/20/2025,12:00 PM,3576.20,100.00,10226554,10226554,Auto-pay gas and electric bill
    e1d41a58-2387-467f-a762-78e25dde8dcf,Withdraw,3/20/2025,12:00 PM,3476.20,129.00,10226554,10226554,Auto-pay health club membership
    467a200e-129d-479a-937e-f1dbc284758c,Withdraw,3/22/2025,9:00 PM,3347.20,155.00,
    
    bytes read: 10226554,10226554,Debit card purchase
    c84262a1-2d0a-49c2-be8d-19f8117c9c59,Withdraw,3/24/2025,8:00 AM,3192.20,400.00,10226554,10226554,Withdraw for expenses
    d384b4df-32cc-4408-a3b9-1b893893e8bc,Withdraw,3/31/2025,12:00 PM,2792.20,1622.50,10226554,10226554,Auto-pay credit card bill
    9ffee615-e045-4fff-b053-722d8810cee8,Deposit,3/31/2025,12:00 PM,1169.70,3326.00,10226554,10226554,Bi-monthly salary deposit
    edc8beaa-c4a6-4bfb-9a9b-4736df72a8ab,Transfer,3/31/2025,12:00 PM,4495.70,800.00,10226554,10226554,Transfer from checking to savings account-(TRANSFER)
    40f1e6a9-c560-4363-91d6-680bd9edc213,Transfer,3/31/2025,12:00 PM,15000.00,800.00,10226555,10226555,Transfer from checking to savings account-(TRANSFER)
    
    
    File length: 2763 bytes
    Current position: 2763 bytes
    Position after seek: 0 bytes
    Read first 100 bytes: TransactionId,TransactionType,TransactionDate,TransactionTime,PriorBalance,TransactionAmount,SourceA
    
    Binary data written to: C:\Users\username\Desktop\LP5SampleApps-M2-Instructions\Files_M2\Starter\bin\Debug\net9.0\binary.dat
    Binary data read from C:\Users\username\Desktop\LP5SampleApps-M2-Instructions\Files_M2\Starter\bin\Debug\net9.0\binary.dat: 1.25, Hello, True
    
    ```

    The customer IDs, account numbers, and transaction amounts in your output will be different from the example output.

## Use JsonSerializer to serialize and deserialize a transaction object

The `JsonSerializer` class in the `System.Text.Json` namespace provides functionality for converting C# objects to JSON and vice versa.

The `JsonSerializer.Serialize` method takes an object as input and transforms it into a JSON-formatted string. This allows the JSON representation of the object to be stored, manipulated, or transmitted as needed.

The `JsonSerializer.Deserialize<T>` method is a generic method where the type parameter `<T>` specifies the type of object you expect the JSON string to represent. The result is stored in a string variable, which can be nullable to account for the possibility that deserialization might fail and return null.

Deserialization is useful when receiving JSON data, such as from an API response or a file, and when you need to work with the data as a strongly-typed object in your application. For example, if `transactionJson` contains JSON data representing a financial transaction, the `Transaction` object allows you to access its properties directly in a type-safe manner.

When deserializing to a strongly-typed object, it's important to ensure that the structure of the JSON string matches the class definition of the object. If there are mismatches (e.g., missing or extra fields, incorrect data types), deserialization may fail or produce unexpected results. Additionally, the `System.Text.Json` library uses default options unless configured otherwise, so features like case-insensitive property matching or handling of null values may need to be explicitly enabled if required.

In this task, you use JsonSerializer to complete the following actions:

- Use the JsonSerializer.Serialize method to serialize a transaction object and display the JSON string.
- Use the JsonSerializer.Deserialize method to deserialize a JSON string into a `Transaction` object and then access the transaction members.

Use the following steps to complete this section of the exercise:

1. Open the **Program.cs** file.

1. Replace the existing **Main** method with the following code:

    ```csharp

    static void Main()
    {
        Console.WriteLine("Demonstrate JSON file storage and retrieval using BankCustomer, BankAccount, and Transaction classes");

        // Create a Bank object
        Bank bank = new Bank();

        // Create a bank customer named Niki Demetriou
        string firstName = "Niki";
        string lastName = "Demetriou";
        BankCustomer bankCustomer = new BankCustomer(firstName, lastName);

        // Add Checking, Savings, and MoneyMarket accounts to bankCustomer
        bankCustomer.AddAccount(new CheckingAccount(bankCustomer, bankCustomer.CustomerId, 5000));
        bankCustomer.AddAccount(new SavingsAccount(bankCustomer, bankCustomer.CustomerId, 15000));
        bankCustomer.AddAccount(new MoneyMarketAccount(bankCustomer, bankCustomer.CustomerId, 90000));

        // Add the bank customer to the bank object
        bank.AddCustomer(bankCustomer);

        // Simulate one month of transactions for customer Niki Demetriou
        DateOnly startDate = new DateOnly(2025, 2, 1);
        DateOnly endDate = new DateOnly(2025, 2, 28);
        bankCustomer = SimulateDepositsWithdrawalsTransfers.SimulateActivityDateRange(startDate, endDate, bankCustomer);

        // Get the current directory of the executable program
        string currentDirectory = Directory.GetCurrentDirectory();

        // Use currentDirectory to create a directory path named BankLogs
        string bankLogsDirectoryPath = Path.Combine(currentDirectory, "BankLogs");
        if (!Directory.Exists(bankLogsDirectoryPath))
        {
            Directory.CreateDirectory(bankLogsDirectoryPath);
            //Console.WriteLine($"Created directory: {bankLogsDirectoryPath}");
        }

    }

    ```

    This code creates a Bank object, a BankCustomer object, and Checking, Savings, and MoneyMarket accounts for the customer. The code then simulates one month of transactions for the customer and creates a directory named BankLogs in the current directory (the directory where the executable program is located).

1. Add the following `using` directive to the **Program.cs** file:

    ```csharp

    using System.Text.Json;

    ```

    The `System.Text.Json` namespace provides access to the `JsonSerializer` class.

1. To convert a transaction object into a JSON string and display the JSON string, add the following code to the **Main** method:

    ```csharp

    // Get the first transaction from the first account of the bank customer
    Transaction singleTransaction = bankCustomer.Accounts[0].Transactions.ElementAt(0);

    // Serialize the transaction object using JsonSerializer.Serialize
    string transactionJson = JsonSerializer.Serialize(singleTransaction);

    // Display the JSON string
    Console.WriteLine($"\nJSON string: {transactionJson}");

    ```

    This code retrieves the first transaction from the first account of the bank customer, serializes the transaction object using JsonSerializer, and displays the JSON string in the console.

1. Run the app and review the output in the terminal window.

    To run your app, right-click the **Files_M2** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    Your output should look similar to the following example:

    ```plaintext

    Demonstrate JSON file storage and retrieval using BankCustomer, BankAccount, and Transaction classes
    
    JSON string: {"TransactionId":"d096fb2a-33f1-4401-b488-2e4945d264ad","TransactionType":"Withdraw","TransactionDate":"2025-02-01","TransactionTime":"12:00:00","PriorBalance":5000,"TransactionAmount":2842,"SourceAccountNumber":15528165,"TargetAccountNumber":15528165,"Description":"Rent payment"}

    ```

    The transaction ID, transaction amount, and account numbers in your output are generated randomly and will be different from the example output.

1. To convert the JSON string into a `Transaction` object using `JsonSerializer.Deserialize`, add the following code to the **Main** method:

    ```csharp

    // Convert the JSON string into a Transaction objects using JsonSerializer.Deserialize
    Transaction? deserializedTransaction = JsonSerializer.Deserialize<Transaction>(transactionJson);

    if (deserializedTransaction == null)
    {
        Console.WriteLine("Deserialization failed. Check the Transaction class for public setters and a parameterless constructor.");
    }
    else
    {
        // Use the Transaction.ReturnTransaction method to display transaction information
        Console.WriteLine($"\nDeserialized transaction object: {deserializedTransaction.ReturnTransaction()}");
    }

    ```

    This code converts the JSON string into a `Transaction` object using `JsonSerializer.Deserialize` and stores the result in a nullable `Transaction` variable. If the deserialization fails, the code displays a message indicating that the deserialization failed. If the deserialization is successful, the code uses the `Transaction.ReturnTransaction` method to display the transaction data.

1. Run the app and examine the error message that's generated.

    When you run the app, you see the following error message:

    ```plaintext

    An unhandled exception of type 'System.InvalidOperationException' occurred in System.Text.Json.dll: 'Each parameter in the deserialization constructor on type 'Files_M2.Transaction' must bind to an object property or field on deserialization. Each parameter name must match with a property or field on the object. Fields are only considered when 'JsonSerializerOptions.IncludeFields' is enabled. The match can be case-insensitive.'

    ```

    Deserialization fails for the following reasons:

    1. The `Transaction` class does not have a parameterless constructor.
    1. The `Transaction` class does not have public setters for its properties.

    You have several options for resolving the issue:

    1. Modify the `Transaction` class to include a parameterless constructor and public setters for its properties.
    1. Create a custom `JsonConverter` for the `Transaction` class that allows you to control how the object is deserialized, including the use of an existing constructor.
    1. Consider whether you can refactor the `Transaction` class as a `record` type rather than using a `class` type. Records are immutable by default and support deserialization with non-default constructors.
    1. Create a separate data transfer object (DTO) class with public setters and a parameterless constructor. Deserialize the JSON string into the DTO class and then use the DTO class to create a new `Transaction` object.
    1. If you cannot add a parameterless constructor but can modify the existing constructor, use the `[JsonConstructor]` attribute to specify which constructor should be used during deserialization.

    In this case, you'll modify the `Transaction` class to include public property setters and a parameterless constructor.

1. Stop the debugger.

1. Open the **Transaction.cs** file.

1. Take a minute to review the `Transaction` class.

    Notice that the `Transaction` class defines readonly fields and properties and that the parameterized constructor is used to initialize the backing fields. Also notice that the Transaction methods use the backing fields to access property values. For deserialization to work properly, you have two options:

    1. Remove the `readonly` accessor from the backing fields, add public setters to the properties, and add a parameterless constructor to the `Transaction` class.
    1. Replace the existing property declarations with auto-implemented properties, delete the backing fields, update the Transaction methods to use the properties directly, and add a parameterless constructor to the `Transaction` class.

    In this case, you'll implement the first option - update the `Transaction` class to use read-write backing fields, add public setters to the property definitions, and add a parameterless constructor.

1. To remove the readonly accessor from the backing field declarations, replace the existing field declarations with the following code:

    ```csharp

    private Guid transactionId;
    private string transactionType;
    private DateOnly transactionDate;
    private TimeOnly transactionTime;
    private double priorBalance;
    private double transactionAmount;
    private int sourceAccountNumber;
    private int targetAccountNumber;
    private string description;

    ```

1. To update the properties with explicit property setters, replace the existing property declarations with the following code:

    ```csharp

    // Gets the unique identifier for the transaction.
    public Guid TransactionId
    {
        get => transactionId;
        set => transactionId = value;
    }

    // Gets or sets the type of the transaction (e.g., Withdraw, Deposit, Transfer, Bank Fee, Bank Refund).
    public string TransactionType
    {
        get => transactionType;
        set => transactionType = value;
    }

    // Gets or sets the date of the transaction.
    public DateOnly TransactionDate
    {
        get => transactionDate;
        set => transactionDate = value;
    }

    // Gets or sets the time of the transaction.
    public TimeOnly TransactionTime
    {
        get => transactionTime;
        set => transactionTime = value;
    }

    // Gets the prior balance of the account before the transaction.
    public double PriorBalance
    {
        get => priorBalance;
        set => priorBalance = value;
    }

    // Gets or sets the amount of the transaction.
    public double TransactionAmount
    {
        get => transactionAmount;
        set => transactionAmount = value;
    }

    // Gets or sets the source bank account number for the transaction.
    public int SourceAccountNumber
    {
        get => sourceAccountNumber;
        set => sourceAccountNumber = value;
    }

    // Gets or sets the target bank account number for the transaction.
    public int TargetAccountNumber
    {
        get => targetAccountNumber;
        set => targetAccountNumber = value;
    }

    // Gets or sets the description of the transaction.
    public string Description
    {
        get => description;
        set => description = value;
    }

    ```

    This code updates the property declarations to include public setters for each property. Deserialization will use these setters to assign property values.

1. To create a parameterless constructor, add the following code to the `Transaction` class:

    ```csharp

    // Parameterless constructor for deserialization
    public Transaction()
    { 
        transactionType = "";
        description = "";
    }

    ```

    This constructor is used during deserialization to create a new `Transaction` object.

    The `transactionType` and `description` fields are strings, which are non-nullable types by default and must be initialized with a value. The other option would be to make these fields nullable by adding a `?` after the type declaration (e.g., `string? transactionType;`).  

1. Save your changes to the **Transaction.cs** file, and then rerun the app and review the output in the terminal window.

    When you run the app, you should see the following output:

    ```plaintext

    Demonstrate JSON file storage and retrieval using BankCustomer, BankAccount, and Transaction classes
    
    JSON string: {"TransactionId":"87f0da9c-4de1-43ca-b8e6-63d860ffcbb6","TransactionType":"Withdraw","TransactionDate":"2025-02-01","TransactionTime":"12:00:00","PriorBalance":5000,"TransactionAmount":2897.5,"SourceAccountNumber":18547716,"TargetAccountNumber":18547716,"Description":"Rent payment"}
    
    Deserialized transaction object: Transaction ID: 87f0da9c-4de1-43ca-b8e6-63d860ffcbb6, Type: Withdraw, Date: 2/1/2025, Time: 12:00 PM, Prior Balance: $5,000.00 Amount: $2,897.50, Source Account: 18547716, Target Account: 18547716, Description: Rent payment

    ```

    Notice that the JSON string is successfully deserialized into a `Transaction` object named `deserializedTransaction` and that the `deserializedTransaction.ReturnTransaction` method is used to display transaction information to the console.

## Use JsonSerializer to serialize and deserialize the transactions collection of a BankAccount object

JSON strings can be used to serialize and store collections of objects, such as the transactions collection of a `BankAccount` object. Storing the JSON representation of an object enables you to persist application data rather than keeping everything in the computer's limited memory. When you need to work with the objects again, you can deserialize the JSON string back into the collection of objects.

In this task, you'll use `JsonSerializer` to complete the following actions:

- Serialize and store the transactions collection of a `BankAccount` object.
- Read the transactions JSON file, convert the JSON strings into a collection of transaction objects, and display transaction data from within a loop.

Use the following steps to complete this section of the exercise:

1. Open the **Program.cs** file.

1. To serialize and store the transactions collection of a `BankAccount` object, add the following code to the end of the **Main** method:

    ```csharp

    // Serialize account transactions using JsonSerializer.Serialize
    string transactionsJson = JsonSerializer.Serialize(bankCustomer.Accounts[0].Transactions);
    Console.WriteLine($"\nbankCustomer.Accounts[0].Transactions serialized to JSON: \n{transactionsJson}");

    // Construct a file path where the serialized transactions (JSON string) can be stored
    string transactionsJsonFilePath = Path.Combine(bankLogsDirectoryPath, "Transactions", bankCustomer.Accounts[0].AccountNumber.ToString() + "-transactions" + ".json");

    // Create the parent directory for the serialized transactions file
    var directoryPath = Path.GetDirectoryName(transactionsJsonFilePath);
    if (directoryPath != null && !Directory.Exists(directoryPath))
    {
        Directory.CreateDirectory(directoryPath);
    }

    // Store the serialized JSON string to a file
    File.WriteAllText(transactionsJsonFilePath, transactionsJson);
    Console.WriteLine($"\nSerialized transactions saved to: {transactionsJsonFilePath}");

    ```

    This code retrieves the transactions collection from the first account of the bank customer, serializes the collection using `JsonSerializer.Serialize`, and writes the JSON string to a file named **transactions.json** in a **BankLogs** directory.

1. Run the app and review the output in the terminal window.

    When you run the app, you should see the following information at the end of the output:

    ```plaintext
    
    bankCustomer.Accounts[0].Transactions serialized to JSON: 
    [{"TransactionId":"a47a834f-5998-44be-b77a-03e9b3518238","TransactionType":"Withdraw","TransactionDate":"2025-02-01","TransactionTime":"12:00:00","PriorBalance":5000,"TransactionAmount":2860,"SourceAccountNumber":13270675,"TargetAccountNumber":13270675,"Description":"Rent payment"},{"TransactionId":"6b0fd4c4-775d-4dfa-b373-cc9f8c64952b","TransactionType":"Withdraw","TransactionDate":"2025-02-01","TransactionTime":"21:00:00","PriorBalance":2140,"TransactionAmount":219,"SourceAccountNumber":13270675,"TargetAccountNumber":13270675,"Description":"Debit card purchase"},{"TransactionId":"88d08739-4730-4655-924d-5232e9bc0393","TransactionType":"Withdraw","TransactionDate":"2025-02-03","TransactionTime":"08:00:00","PriorBalance":1921,"TransactionAmount":400,"SourceAccountNumber":13270675,"TargetAccountNumber":13270675,"Description":"Withdraw for expenses"},{"TransactionId":"fcf89f87-0e2b-4caa-9dbd-5330cc0a7f6b","TransactionType":"Bank Fee","TransactionDate":"2025-02-03","TransactionTime":"12:00:00","PriorBalance":1521,"TransactionAmount":50,"SourceAccountNumber":13270675,"TargetAccountNumber":13270675,"Description":"-(BANK FEE)"},{"TransactionId":"e1746851-6e21-4f8b-8de2-37167092bacc","TransactionType":"Bank Refund","TransactionDate":"2025-02-05","TransactionTime":"12:00:00","PriorBalance":1471,"TransactionAmount":100,"SourceAccountNumber":13270675,"TargetAccountNumber":13270675,"Description":"Refund for overcharge -(BANK REFUND)"},{"TransactionId":"171cab77-ff15-4310-93d5-faf752189e50","TransactionType":"Withdraw","TransactionDate":"2025-02-08","TransactionTime":"21:00:00","PriorBalance":1571,"TransactionAmount":170,"SourceAccountNumber":13270675,"TargetAccountNumber":13270675,"Description":"Debit card purchase"},{"TransactionId":"063e7830-77e6-4651-a205-92d6c26ba3f3","TransactionType":"Withdraw","TransactionDate":"2025-02-10","TransactionTime":"08:00:00","PriorBalance":1401,"TransactionAmount":400,"SourceAccountNumber":13270675,"TargetAccountNumber":13270675,"Description":"Withdraw for expenses"},{"TransactionId":"ae4d2fdc-f232-4764-9bab-16f019e55aec","TransactionType":"Bank Fee","TransactionDate":"2025-02-10","TransactionTime":"12:00:00","PriorBalance":1001,"TransactionAmount":50,"SourceAccountNumber":13270675,"TargetAccountNumber":13270675,"Description":"-(BANK FEE)"},{"TransactionId":"6c4ff9a3-9187-48a1-990a-ae819e014729","TransactionType":"Deposit","TransactionDate":"2025-02-14","TransactionTime":"12:00:00","PriorBalance":951,"TransactionAmount":3220,"SourceAccountNumber":13270675,"TargetAccountNumber":13270675,"Description":"Bi-monthly salary deposit"},{"TransactionId":"85fe6ea3-5e66-4e92-9715-e9d0e734e266","TransactionType":"Withdraw","TransactionDate":"2025-02-15","TransactionTime":"21:00:00","PriorBalance":4171,"TransactionAmount":193,"SourceAccountNumber":13270675,"TargetAccountNumber":13270675,"Description":"Debit card purchase"},{"TransactionId":"26897716-3550-45dc-9130-e944a8b514b2","TransactionType":"Withdraw","TransactionDate":"2025-02-17","TransactionTime":"08:00:00","PriorBalance":3978,"TransactionAmount":400,"SourceAccountNumber":13270675,"TargetAccountNumber":13270675,"Description":"Withdraw for expenses"},{"TransactionId":"08044d28-68e9-4abe-b32c-f06364f2fe56","TransactionType":"Withdraw","TransactionDate":"2025-02-20","TransactionTime":"12:00:00","PriorBalance":3578,"TransactionAmount":68,"SourceAccountNumber":13270675,"TargetAccountNumber":13270675,"Description":"Auto-pay waste management bill"},{"TransactionId":"152a674b-51f8-4cfa-98f1-f392f2e6748f","TransactionType":"Withdraw","TransactionDate":"2025-02-20","TransactionTime":"12:00:00","PriorBalance":3510,"TransactionAmount":89,"SourceAccountNumber":13270675,"TargetAccountNumber":13270675,"Description":"Auto-pay water and sewer bill"},{"TransactionId":"f8c81fca-f80f-4617-b24c-38a908d2f873","TransactionType":"Withdraw","TransactionDate":"2025-02-20","TransactionTime":"12:00:00","PriorBalance":3421,"TransactionAmount":118,"SourceAccountNumber":13270675,"TargetAccountNumber":13270675,"Description":"Auto-pay gas and electric bill"},{"TransactionId":"fc0aa477-d2b8-4f50-8d87-71d704d5ef90","TransactionType":"Withdraw","TransactionDate":"2025-02-20","TransactionTime":"12:00:00","PriorBalance":3303,"TransactionAmount":136,"SourceAccountNumber":13270675,"TargetAccountNumber":13270675,"Description":"Auto-pay health club membership"},{"TransactionId":"7cb401c1-1a1a-47f0-8c61-9cf389795387","TransactionType":"Withdraw","TransactionDate":"2025-02-22","TransactionTime":"21:00:00","PriorBalance":3167,"TransactionAmount":219,"SourceAccountNumber":13270675,"TargetAccountNumber":13270675,"Description":"Debit card purchase"},{"TransactionId":"310ed926-e3ef-4083-9458-6de564a6b7eb","TransactionType":"Withdraw","TransactionDate":"2025-02-24","TransactionTime":"08:00:00","PriorBalance":2948,"TransactionAmount":400,"SourceAccountNumber":13270675,"TargetAccountNumber":13270675,"Description":"Withdraw for expenses"},{"TransactionId":"d477a0be-521f-4eef-bbba-75ce8d28e416","TransactionType":"Withdraw","TransactionDate":"2025-02-28","TransactionTime":"12:00:00","PriorBalance":2548,"TransactionAmount":1480,"SourceAccountNumber":13270675,"TargetAccountNumber":13270675,"Description":"Auto-pay credit card bill"},{"TransactionId":"2a37caa9-b8e2-4f34-9671-ad629715cf5f","TransactionType":"Deposit","TransactionDate":"2025-02-28","TransactionTime":"12:00:00","PriorBalance":1068,"TransactionAmount":3220,"SourceAccountNumber":13270675,"TargetAccountNumber":13270675,"Description":"Bi-monthly salary deposit"},{"TransactionId":"451ab5b0-5bf2-457d-9257-fae17050a38a","TransactionType":"Transfer","TransactionDate":"2025-02-28","TransactionTime":"12:00:00","PriorBalance":4288,"TransactionAmount":800,"SourceAccountNumber":13270675,"TargetAccountNumber":13270675,"Description":"Transfer from checking to savings account-(TRANSFER)"}]
    
    Serialized transactions saved to: C:\Users\username\Desktop\LP5SampleApps-M2-Instructions\Files_M2\Starter\bin\Debug\net9.0\BankLogs\Transactions\13270675-transactions.json

    ```

    Notice how the transactions collection is represented within the JSON string. The JSON syntax uses square brackets `[]` to define the array and curly braces `{}` to enclose each object. The objects are separated by a comma within the array.

    Also notice that the file is named using the account number, and stored in a **Transactions** directory within the **BankLogs** directory.

1. To read the transactions JSON file, convert the JSON strings into a collection of transaction objects, and display transaction data from within a loop, add the following code to the end of the **Main** method:

    ```csharp

    // Use File.ReadAllText to read the JSON file and assign the text contents to a string.
    string transactionsJsonFromFile = File.ReadAllText(transactionsJsonFilePath);

    // Deserialize the JSON string using JsonSerializer.Deserialize
    var transactionsJsonDeserialized = JsonSerializer.Deserialize<IEnumerable<Transaction>>(transactionsJsonFromFile);

    // Loop through the deserialized transactions and display each transaction
    if (transactionsJsonDeserialized == null)
    {
        Console.WriteLine("Deserialization failed. Check the Transaction class for public setters and a parameterless constructor.");
    }
    else
    {
        Console.WriteLine("\nDeserialized transactions:");
        foreach (var transaction in transactionsJsonDeserialized)
        {
            Console.WriteLine(transaction.ReturnTransaction());
        }
    }

    ```

1. Run the app and review the output in the terminal window.

    When you run the app, you should see the following information at the end of the output:

    ```plaintext

    Deserialized transactions:
    Transaction ID: bbb86ac7-e06e-4c97-be15-d1fe61b06169, Type: Withdraw, Date: 2/1/2025, Time: 12:00 PM, Prior Balance: $5,000.00 Amount: $2,871.80, Source Account: 17352395, Target Account: 17352395, Description: Rent payment
    Transaction ID: 2adad6af-1e1e-45d5-8ee4-a208b97d538c, Type: Withdraw, Date: 2/1/2025, Time: 9:00 PM, Prior Balance: $2,128.20 Amount: $201.00, Source Account: 17352395, Target Account: 17352395, Description: Debit card purchase
    Transaction ID: 41d4308c-c594-4570-8075-1263662b2656, Type: Withdraw, Date: 2/3/2025, Time: 8:00 AM, Prior Balance: $1,927.20 Amount: $400.00, Source Account: 17352395, Target Account: 17352395, Description: Withdraw for expenses
    Transaction ID: 0255372b-74c7-476d-a102-45a317ff518a, Type: Bank Fee, Date: 2/3/2025, Time: 12:00 PM, Prior Balance: $1,527.20 Amount: $50.00, Source Account: 17352395, Target Account: 17352395, Description: -(BANK FEE)
    Transaction ID: 9249b7df-1246-4fb5-b1e4-d4de2758a79e, Type: Bank Refund, Date: 2/5/2025, Time: 12:00 PM, Prior Balance: $1,477.20 Amount: $100.00, Source Account: 17352395, Target Account: 17352395, Description: Refund for overcharge -(BANK REFUND)
    Transaction ID: 4a82b2f8-d3a2-4c9c-8100-266e6b619c7c, Type: Withdraw, Date: 2/8/2025, Time: 9:00 PM, Prior Balance: $1,577.20 Amount: $178.00, Source Account: 17352395, Target Account: 17352395, Description: Debit card purchase
    Transaction ID: 709f4695-f4b6-46b8-bcad-44f26526337d, Type: Withdraw, Date: 2/10/2025, Time: 8:00 AM, Prior Balance: $1,399.20 Amount: $400.00, Source Account: 17352395, Target Account: 17352395, Description: Withdraw for expenses
    Transaction ID: 5167ba2a-178b-4982-bbbf-96efcb0c6f0f, Type: Bank Fee, Date: 2/10/2025, Time: 12:00 PM, Prior Balance: $999.20 Amount: $50.00, Source Account: 17352395, Target Account: 17352395, Description: -(BANK FEE)
    Transaction ID: ed3f29b6-ab98-41d8-8c53-982aa198a89d, Type: Deposit, Date: 2/14/2025, Time: 12:00 PM, Prior Balance: $949.20 Amount: $3,256.00, Source Account: 17352395, Target Account: 17352395, Description: Bi-monthly salary deposit
    Transaction ID: 70807404-8a79-42ab-bf84-ef37742c6c73, Type: Withdraw, Date: 2/15/2025, Time: 9:00 PM, Prior Balance: $4,205.20 Amount: $194.00, Source Account: 17352395, Target Account: 17352395, Description: Debit card purchase
    Transaction ID: 19a13d19-8cd8-4dd9-931d-96fcb47d69be, Type: Withdraw, Date: 2/17/2025, Time: 8:00 AM, Prior Balance: $4,011.20 Amount: $400.00, Source Account: 17352395, Target Account: 17352395, Description: Withdraw for expenses
    Transaction ID: 068a5b77-ca45-42f7-82d6-7e6958cb742e, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $3,611.20 Amount: $64.00, Source Account: 17352395, Target Account: 17352395, Description: Auto-pay waste management bill
    Transaction ID: 2c6e0328-d5da-4cc4-abcd-96a8a5092472, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $3,547.20 Amount: $86.00, Source Account: 17352395, Target Account: 17352395, Description: Auto-pay water and sewer bill
    Transaction ID: f166cdbf-4ae6-487b-934e-25659d64f870, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $3,461.20 Amount: $146.00, Source Account: 17352395, Target Account: 17352395, Description: Auto-pay gas and electric bill
    Transaction ID: b7936a26-4af6-46cd-99db-003f5a339970, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $3,315.20 Amount: $159.00, Source Account: 17352395, Target Account: 17352395, Description: Auto-pay health club membership
    Transaction ID: fcfe3ad1-f83e-4709-ac7f-78dd8beeb07f, Type: Withdraw, Date: 2/22/2025, Time: 9:00 PM, Prior Balance: $3,156.20 Amount: $166.00, Source Account: 17352395, Target Account: 17352395, Description: Debit card purchase
    Transaction ID: c28bd8a9-1caf-40f5-8dc6-3bd95f27a6d3, Type: Withdraw, Date: 2/24/2025, Time: 8:00 AM, Prior Balance: $2,990.20 Amount: $400.00, Source Account: 17352395, Target Account: 17352395, Description: Withdraw for expenses
    Transaction ID: ac384c84-ed2a-46fa-b205-adf607304724, Type: Withdraw, Date: 2/28/2025, Time: 12:00 PM, Prior Balance: $2,590.20 Amount: $1,406.00, Source Account: 17352395, Target Account: 17352395, Description: Auto-pay credit card bill
    Transaction ID: 48e66452-f3a6-43a2-9560-524a949f2029, Type: Deposit, Date: 2/28/2025, Time: 12:00 PM, Prior Balance: $1,184.20 Amount: $3,256.00, Source Account: 17352395, Target Account: 17352395, Description: Bi-monthly salary deposit
    Transaction ID: d67fb35f-f119-4fe2-b735-24a9522b9722, Type: Transfer, Date: 2/28/2025, Time: 12:00 PM, Prior Balance: $4,440.20 Amount: $800.00, Source Account: 17352395, Target Account: 17352395, Description: Transfer from checking to savings account-(TRANSFER)

    ```

## Use JsonSerializer with JsonSerializerOptions to serialize and deserialize a BankAccount object

Large and complex objects can present challenges during serialization or deserialization. The `JsonSerializerOptions` class provides additional control over the serialization and deserialization process, allowing you to customize the behavior of the `JsonSerializer` class.

In this task, you'll use `JsonSerializer` with `JsonSerializerOptions` to complete the following actions:

- Serialize and store a `BankAccount` object using `JsonSerializer` with `JsonSerializerOptions`.
- Read the serialized account file, deserialize into a `BankAccount` object, and then access `BankAccount` members.

Use the following steps to complete this section of the exercise:

1. Open the **Program.cs** file.

1. To serialize and store a `BankAccount` object using `JsonSerializer`, add the following code to the end of the **Main** method:

    ```csharp

    //Serialize the CheckingAccount object using JsonSerializer.Serialize
    string accountJson = JsonSerializer.Serialize(bankCustomer.Accounts[0]);
    Console.WriteLine(accountJson);

    // Create a file path for the CheckingAccount object
    string accountFilePath = Path.Combine(bankLogsDirectoryPath, "Account", bankCustomer.Accounts[0].AccountNumber + ".json");

    // Create the parent directory for the serialized account file
    var accountDirectoryPath = Path.GetDirectoryName(accountFilePath);
    if (accountDirectoryPath != null && !Directory.Exists(accountDirectoryPath))
    {
        Directory.CreateDirectory(accountDirectoryPath);
    }

    // Save the JSON to a file
    File.WriteAllText(accountFilePath, accountJson);
    Console.WriteLine($"Serialized account saved to: {accountFilePath}");

    ```

    This code attempts to serialize the first account of the bank customer using `JsonSerializer.Serialize` and writes the JSON string to a file named **account.json** in an **Account** directory within the **BankLogs** directory.

1. Run the app and review the error message that's generated.

    When you run the app, you see the following error message:

    ```plaintext

    An unhandled exception of type 'System.Text.Json.JsonException' occurred in System.Text.Json.dll: 'A possible object cycle was detected. This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 64. Consider using ReferenceHandler.Preserve on JsonSerializerOptions to support cycles.'

    ```

    The error message indicates that a possible object cycle was detected. An object cycle occurs when two or more objects reference each other in a circular manner. In this case, the `BankAccount` object references the `BankCustomer` object, and the `BankCustomer` object references the `BankAccount` object.

    To resolve the cycle issue, you can use the `ReferenceHandler.Preserve` option in the `JsonSerializerOptions` class to support object cycles.

1. Stop the debugger.

1. Locate the code line used to serialize the `BankAccount` object:

    ```csharp

    string accountJson = JsonSerializer.Serialize(bankCustomer.Accounts[0]);

    ```

1. To create a `JsonSerializerOptions` object with the `ReferenceHandler.Preserve` option, insert the following code above the code that serializes the `BankAccount` object:

    ```csharp

        // Configure JsonSerializerOptions
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve // Handle circular references
        };

    ```

    This code creates a `JsonSerializerOptions` object with the `ReferenceHandler.Preserve` option.

1. To serialize the `BankAccount` object using `JsonSerializer` with `JsonSerializerOptions`, update the serialization code as follows:

    ```csharp

    string accountJson = JsonSerializer.Serialize(bankCustomer.Accounts[0], options);

    ```

    This code serializes the first account of the bank customer using `JsonSerializer.Serialize` with the `JsonSerializerOptions` object.

1. Run the app and review the output in the terminal window.

    When you run the app, you should see a long list of serialized account data concluding with a message indicating where the JSON file is stored.

    ```plaintext

    Serialized account saved to: C:\Users\username\Desktop\LP5SampleApps-M2-Instructions\Files_M2\Starter\bin\Debug\net9.0\BankLogs\Account\19951509.json

    ```

1. Use Visual Studio Code's EXPLORER view to open the JSON file that was created in the `BankLogs\Account` folder.

    To locate the file, collapse SOLUTION EXPLORER and then expand the  `STARTER\bin\Debug\net9.0\BankLogs\Account` folder structure and select the JSON file named with an account number.

1. To deserialize the JSON file into a `BankAccount` object and access the `BankAccount` members, add the following code to the end of the **Main** method:

    ```csharp

    string accountJsonFromFile = File.ReadAllText(accountFilePath);

    // Deserialize the JSON string using JsonSerializer.Deserialize with options
    try
    {
        BankAccount? deserializedAccount = JsonSerializer.Deserialize<BankAccount>(accountJsonFromFile, options);

        // Demonstrate the deserialized BankAccount object
        if (deserializedAccount == null)
        {
            Console.WriteLine("Deserialization failed. Check the BankAccount class for public setters and a parameterless constructor.");
        }
        else
        {
            Console.WriteLine($"\nDeserialized BankAccount object: {deserializedAccount.DisplayAccountInfo()}");
            Console.WriteLine($"Transactions for Account Number: {deserializedAccount.AccountNumber}");

            foreach (var transaction in deserializedAccount.Transactions)
            {
                Console.WriteLine(transaction.ReturnTransaction());
            }
        }
    }
    catch (Exception ex)
    {
        string displayMessage = "Exception has occurred: " + ex.Message.Split('.')[0] + ".";
        displayMessage += "\n\nConsider using Data Transfer Objects (DTOs) for serializing and deserializing complex and nested objects.";
        Console.WriteLine(displayMessage);
    }

    ```

    This code reads the JSON file into a string, then attempts to deserializes the JSON string into a `BankAccount` object using `JsonSerializer.Deserialize` with the `JsonSerializerOptions` object. If deserialization is successful, the code displays the account information and transactions to the console.

1. Run the app and review the error message that's generated.

    When you run the app, you see the following error message:

    ```plaintext

    Exception has occurred: Deserialization of types without a parameterless constructor, a singular parameterized constructor, or a parameterized constructor annotated with 'JsonConstructorAttribute' is not supported.

    ```

    The BankAccount class is designed with restricted access policies for properties and fields. It also uses constructors that require specific parameters, so a parameterless constructor may be an option.

    Direct serialization and deserialization of a BankAccount object isn't the best option. This is when Data Transfer Objects (DTOs) are needed.

## Use Data Transfer Objects and JsonSerializer with JsonSerializerOptions to serialize and deserialize a BankAccount object

When the complexity and design restrictions associated with a class make it difficult to serialize and deserialize objects directly, you can create Data Transfer Objects (DTOs) that make it easier to serialize and deserialize objects without violating the encapsulation of the original object. DTOs are simple objects that have public properties and a parameterless constructor. You can map the properties from the original object to the DTO object and serialize the DTO object instead.

In this task, you'll complete the following actions:

- Create a `BankAccountDTO` class that includes `BankAccount` properties and a parameterless constructor.
- Use a `BankAccountDTO` object to store serialized bank account properties to one JSON file and account transactions to a second JSON file.
- Read the JSON files and use a `BankAccountDTO` object to construct a `BankAccount` that includes the associated transactions.

1. Create a new class file named `BankAccountDTO` in the **Services** folder.

    To create the `BankAccountDTO` class:

    1. Open the SOLUTION EXPLORER view
    1. Right-click **Services**
    1. Select **New File** and then select **Class**
    1. Type **BankAccountDTO** and then press Enter.

1. Replace the contents of the **BankAccountDTO.cs** file with the following code:

    ```csharp

    using System;
    
    namespace Files_M2;
    
    public class BankAccountDTO
    {
        public int AccountNumber { get; set; }
        public string CustomerId { get; set; } = "";
        public double Balance { get; set; }
        public string AccountType { get; set; } = "";
        public double InterestRate { get; set; }
    
        public static BankAccountDTO MapToDTO(BankAccount bankAccount)
        {
            return new BankAccountDTO
            {
                AccountNumber = bankAccount.AccountNumber,
                CustomerId = bankAccount.CustomerId,
                Balance = bankAccount.Balance,
                AccountType = bankAccount.AccountType,
                InterestRate = bankAccount.InterestRate
            };
        }
    }

    ```

    This code defines a `BankAccountDTO` class with properties that match the `BankAccount` class properties. The `MapToDTO` method maps the properties from a `BankAccount` object to a `BankAccountDTO` object.

    This DTO class will be used to store account information in a format that can be serialized and deserialized without violating the encapsulation of the `BankAccount` class.

1. Open the **Program.cs** file.

1. To prepare file storage paths and a bank account object, add the following code to the end of the **Main** method:

    ```csharp

    // Create directory paths for Account and Transaction files
    string accountsDirectoryPath = Path.Combine(bankLogsDirectoryPath, "Accounts");
    Directory.CreateDirectory(accountsDirectoryPath);

    string transactionsDirectory = Path.Combine(bankLogsDirectoryPath, "Transactions");
    Directory.CreateDirectory(transactionsDirectory);

    BankAccount customerAccount1 = (BankAccount)bankCustomer.Accounts[0];

    // Create a jsonAccountDTOFilePath for the BankAccount object
    string jsonAccountDTOFilePath = Path.Combine(accountsDirectoryPath, customerAccount1.AccountNumber.ToString() + ".json");

    ```

    This code creates directories for storing account and transaction files, and then retrieves the first account of the bank customer.

1. To create a BankAccountDTO object and serialize the account properties to a JSON file, add the following code to the end of the **Main** method:

    ```csharp

    // Create a bankAccountDTO object from the BankAccount object and serialize it as JSON
    BankAccountDTO bankAccountDTO = BankAccountDTO.MapToDTO((BankAccount)customerAccount1);
    string jsonAccountDTO = JsonSerializer.Serialize(bankAccountDTO, options);

    // Save the serialized jsonAccountDTO to a file in the Accounts directory using the AccountNumber value as the filename  (.json)
    File.WriteAllText(jsonAccountDTOFilePath, jsonAccountDTO);
    Console.WriteLine($"\nSerialized account saved to: {jsonAccountDTOFilePath}");

    ```

    This code creates a `BankAccountDTO` object from the `BankAccount` object and serializes the DTO object to a JSON string. The JSON string is then written to a file in the **Accounts** directory.

1. To serialize the transactions collection of the BankAccount object to a JSON file, add the following code to the end of the **Main** method:

    ```csharp

    //Serialize the Transactions collection
    string jsonTransactions = JsonSerializer.Serialize(customerAccount1.Transactions);

    // Create a jsonTransactionsFilePath for the Transactions collection using the account number and a "T" suffix as the filename  (.json)
    string jsonTransactionsFilePath = Path.Combine(transactionsDirectory, customerAccount1.AccountNumber.ToString() + "T" + ".json");

    // Save the serialized transaction to a file in the Transactions directory 
    File.WriteAllText(jsonTransactionsFilePath, jsonTransactions);
    Console.WriteLine($"Serialized account transactions saved to: {jsonTransactionsFilePath}");

    ```

    This code serializes the transactions collection of the `BankAccount` object and writes the JSON string to a file in the **Transactions** directory.

1. Run the app and review the output in the terminal window.

    When you run the app, you should see the following information at the end of the output:

    ```plaintext

    Serialized account saved to: C:\Users\username\Desktop\LP5SampleApps-M2-Instructions\Files_M2\Starter\bin\Debug\net9.0\BankLogs\Accounts\17051140.json
    Serialized account transactions saved to: C:\Users\username\Desktop\LP5SampleApps-M2-Instructions\Files_M2\Starter\bin\Debug\net9.0\BankLogs\Transactions\17051140T.json

    ```

1. To read the JSON files and use a `BankAccountDTO` object to construct a `BankAccount` object, add the following code to the end of the **Main** method:

    ```csharp

    // Load the BankAccountDTO info from the JSON file
    jsonAccountDTO = File.ReadAllText(jsonAccountDTOFilePath);

    // Deserialize the JSON string into a BankAccountDTO object using JsonSerializer.Deserialize
    var accountDTO = JsonSerializer.Deserialize<BankAccountDTO>(jsonAccountDTO, options);

    if (accountDTO == null)
    {
        Console.WriteLine("Deserialization failed. Check the BankAccountDTO class for public setters and a parameterless constructor.");
    }
    else
    {
        // create a bank account using the recovered data
        var recoveredBankAccount = new BankAccount(bankCustomer, bankCustomer.CustomerId, accountDTO.Balance, accountDTO.AccountType);

        // load the transactions file into a JSON formatted string
        jsonTransactions = File.ReadAllText(jsonTransactionsFilePath);

        // deserialize the JSON string into a collection of Transaction objects
        var transactions = JsonSerializer.Deserialize<IEnumerable<Transaction>>(jsonTransactions, options);

        if (transactions == null)
        {
            Console.WriteLine("Deserialization failed. Check the Transaction class for public setters and a parameterless constructor.");
        }
        else
        {
            // add the transactions to the recovered account
            foreach (var transaction in transactions)
            {
                recoveredBankAccount.AddTransaction(transaction);
            }

            // display the recovered account information
            Console.WriteLine($"\nRecovered BankAccount object: {recoveredBankAccount.DisplayAccountInfo()}");
            Console.WriteLine($"Transactions for Account Number: {recoveredBankAccount.AccountNumber}\n");

            foreach (var transaction in recoveredBankAccount.Transactions)
            {
                Console.WriteLine(transaction.ReturnTransaction());
            }
        }
    }


    ```

    This code reads the JSON files into strings, deserializes the strings into `BankAccountDTO` and `Transaction` objects, and then constructs a `BankAccount` object using the recovered data.

1. Run the app and review the output in the terminal window.

    When you run the app, you should see the following information at the end of the output:

    ```plaintext

    Recovered BankAccount object: Account Number: 18497035, Type: Checking, Balance: $3,797.45, Interest Rate: 0.00%, Customer ID: 0012498991
    Transactions for Account Number: 18497035
    
    Transaction ID: e663891c-ad09-4117-a80d-dc17b24f7add, Type: Withdraw, Date: 2/1/2025, Time: 12:00 PM, Prior Balance: $5,000.00 Amount: $2,819.30, Source Account: 18497032, Target Account: 18497032, Description: Rent payment
    Transaction ID: 2e524686-2474-4c8c-9f88-9fb782a0c549, Type: Withdraw, Date: 2/1/2025, Time: 9:00 PM, Prior Balance: $2,180.70 Amount: $164.00, Source Account: 18497032, Target Account: 18497032, Description: Debit card purchase
    Transaction ID: 6c2a0d0a-baf8-41f8-a55f-ed71cf4378e4, Type: Withdraw, Date: 2/3/2025, Time: 8:00 AM, Prior Balance: $2,016.70 Amount: $400.00, Source Account: 18497032, Target Account: 18497032, Description: Withdraw for expenses
    Transaction ID: 42198a30-bd4f-4fec-8f01-6fef83f5a9a0, Type: Bank Fee, Date: 2/3/2025, Time: 12:00 PM, Prior Balance: $1,616.70 Amount: $50.00, Source Account: 18497032, Target Account: 18497032, Description: -(BANK FEE)
    Transaction ID: f2c078d2-028e-4888-92ca-e3089e2aab75, Type: Bank Refund, Date: 2/5/2025, Time: 12:00 PM, Prior Balance: $1,566.70 Amount: $100.00, Source Account: 18497032, Target Account: 18497032, Description: Refund for overcharge -(BANK REFUND)
    Transaction ID: 285bee55-1c65-416e-b9f3-f210f09ce919, Type: Withdraw, Date: 2/8/2025, Time: 9:00 PM, Prior Balance: $1,666.70 Amount: $183.00, Source Account: 18497032, Target Account: 18497032, Description: Debit card purchase
    Transaction ID: c22f5535-3c72-4701-ac24-87148620a51f, Type: Withdraw, Date: 2/10/2025, Time: 8:00 AM, Prior Balance: $1,483.70 Amount: $400.00, Source Account: 18497032, Target Account: 18497032, Description: Withdraw for expenses
    Transaction ID: d30d13ef-7dcb-411d-8c80-548f1da9708a, Type: Bank Fee, Date: 2/10/2025, Time: 12:00 PM, Prior Balance: $1,083.70 Amount: $50.00, Source Account: 18497032, Target Account: 18497032, Description: -(BANK FEE)
    Transaction ID: 82dbb467-66b9-4ef7-929e-d4cbff645b12, Type: Deposit, Date: 2/14/2025, Time: 12:00 PM, Prior Balance: $1,033.70 Amount: $3,321.00, Source Account: 18497032, Target Account: 18497032, Description: Bi-monthly salary deposit
    Transaction ID: a8bb9b60-5414-4527-b0d5-a5bed3910aa7, Type: Withdraw, Date: 2/15/2025, Time: 9:00 PM, Prior Balance: $4,354.70 Amount: $156.00, Source Account: 18497032, Target Account: 18497032, Description: Debit card purchase
    Transaction ID: 93de76d6-f60f-4a8c-a9c3-230137f06e9a, Type: Withdraw, Date: 2/17/2025, Time: 8:00 AM, Prior Balance: $4,198.70 Amount: $400.00, Source Account: 18497032, Target Account: 18497032, Description: Withdraw for expenses
    Transaction ID: f0a85243-c5e6-4640-b611-b0dbdc44a374, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $3,798.70 Amount: $66.00, Source Account: 18497032, Target Account: 18497032, Description: Auto-pay waste management bill
    Transaction ID: f7206aa2-4dc6-41db-8980-1d0e58acd919, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $3,732.70 Amount: $80.00, Source Account: 18497032, Target Account: 18497032, Description: Auto-pay water and sewer bill
    Transaction ID: d100e6b1-9c5c-406f-b178-8c1a836f8495, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $3,652.70 Amount: $111.00, Source Account: 18497032, Target Account: 18497032, Description: Auto-pay gas and electric bill
    Transaction ID: df08f37d-c121-424f-bf90-43f4b2961531, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $3,541.70 Amount: $146.00, Source Account: 18497032, Target Account: 18497032, Description: Auto-pay health club membership
    Transaction ID: ca043738-7e08-479e-b2a0-57ba4f2e9dea, Type: Withdraw, Date: 2/22/2025, Time: 9:00 PM, Prior Balance: $3,395.70 Amount: $176.00, Source Account: 18497032, Target Account: 18497032, Description: Debit card purchase
    Transaction ID: a938e2f6-b13e-448d-8e73-7e15546c6dd1, Type: Withdraw, Date: 2/24/2025, Time: 8:00 AM, Prior Balance: $3,219.70 Amount: $400.00, Source Account: 18497032, Target Account: 18497032, Description: Withdraw for expenses
    Transaction ID: be74bbca-3920-4963-8166-67626fe49255, Type: Withdraw, Date: 2/28/2025, Time: 12:00 PM, Prior Balance: $2,819.70 Amount: $1,543.25, Source Account: 18497032, Target Account: 18497032, Description: Auto-pay credit card bill
    Transaction ID: e2ccabf2-1583-48ef-8453-755005f0b945, Type: Deposit, Date: 2/28/2025, Time: 12:00 PM, Prior Balance: $1,276.45 Amount: $3,321.00, Source Account: 18497032, Target Account: 18497032, Description: Bi-monthly salary deposit
    Transaction ID: 4589839b-fca7-4bb2-a735-157918212cdc, Type: Transfer, Date: 2/28/2025, Time: 12:00 PM, Prior Balance: $4,597.45 Amount: $800.00, Source Account: 18497032, Target Account: 18497032, Description: Transfer from checking to savings account-(TRANSFER)

    ```

## Use service classes and Data Transfer Objects to back up and restore a BankCustomer object

Storing and retrieving application data is an essential aspect of many applications, and is often part of a larger backup and recovery process. Service classes are often used to help manage file or data input and output.

In this task, you'll complete the following actions:

- Create service classes named `JsonStorage` and `JsonRetrieval` that can be used to read and write JSON files.
- Add methods to the `JsonStorage` and `JsonRetrieval` classes that can be used to backup and recover `BankAccount` objects.
- Create a `BankCustomerDTO` class that can be used to serialize and deserialize `BankCustomer` properties.
- Add methods to the `JsonStorage` and `JsonRetrieval` classes that can be used to backup and recover `BankCustomer` objects.

Use the following steps to complete this section of the exercise:

1. Create a new class file named `JsonStorage` in the **Services** folder.

1. Create a new class file named `JsonRetrieval` in the **Services** folder.

1. Open the **JsonStorage.cs** file.

1. Replace the contents of the **JsonStorage.cs** file with the following code:

    ```csharp

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;
    
    namespace Files_M2;
    
    public static class JsonStorage
    {
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
        };
        
        public static void SaveBankAccount(BankAccount account, string directoryPath)
        {
            var accountDTO = new BankAccountDTO
            {
                AccountNumber = account.AccountNumber,
                CustomerId = account.CustomerId,
                Balance = account.Balance,
                AccountType = account.AccountType,
                InterestRate = account.InterestRate
            };
    
            string accountFilePath = Path.Combine(directoryPath, "Accounts", $"{account.AccountNumber}.json");
    
            var accountDirectoryPath = Path.GetDirectoryName(accountFilePath);
            if (accountDirectoryPath != null && !Directory.Exists(accountDirectoryPath))
            {
                Directory.CreateDirectory(accountDirectoryPath);
            }
    
            string json = JsonSerializer.Serialize(accountDTO, _options);
            File.WriteAllText(accountFilePath, json);
    
            SaveAllTransactions(account.Transactions, directoryPath, account.AccountNumber);
        }
    
        public static void SaveAllTransactions(IEnumerable<Transaction> transactions, string directoryPath, int accountNumber)
        {
            string transactionsFilePath = Path.Combine(directoryPath, "Transactions", $"{accountNumber}-transactions.json");
    
            var transactionsDirectoryPath = Path.GetDirectoryName(transactionsFilePath);
            if (transactionsDirectoryPath != null && !Directory.Exists(transactionsDirectoryPath))
            {
                Directory.CreateDirectory(transactionsDirectoryPath);
            }
    
            string json = JsonSerializer.Serialize(transactions, _options);
            File.WriteAllText(transactionsFilePath, json);
        }
    }

    ```

    This code defines a `JsonStorage` class with methods that can be used to save `BankAccount` and `Transaction` objects to JSON files.

1. Open the **JsonRetrieval.cs** file.

1. Replace the contents of the **JsonRetrieval.cs** file with the following code:

    ```csharp

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;
    
    namespace Files_M2;
    
    public static class JsonRetrieval
    {
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
        };
    
        public static BankAccountDTO LoadBankAccountDTO(string filePath)
        {
            string json = File.ReadAllText(filePath);
    
            if (string.IsNullOrEmpty(json))
            {
                throw new Exception("No account found.");
            }
            else
            {
                var accountDTO = JsonSerializer.Deserialize<BankAccountDTO>(json, _options);
                if (accountDTO == null)
                {
                    throw new Exception("Account could not be deserialized.");
                }
                return accountDTO;
            }
        }
    }

    ```

    This code is based on the code you added to the Program.cs file in a previous task.

    The `JsonSerializerOptions` object is configured with a `ReferenceHandler` value of `ReferenceHandler.Preserve`.

    The `LoadBankAccountDTO` method accepts a parameter that specifies the file path of the JSON file to load. The method reads the JSON file, deserializes the JSON string into a `BankAccountDTO` object, and returns the object.

1. To update the `JsonRetrieval` class with a method that loads transaction information from JSON files, add the following code to the end of the **JsonRetrieval.cs** file:

    ```csharp

    public static IEnumerable<Transaction> LoadAllTransactions(string filePath)
    {
        string jsonTransaction = File.ReadAllText(filePath);

        if (string.IsNullOrEmpty(jsonTransaction))
        {
            throw new Exception("No transactions loaded.");
        }
        else
        {
            var transactions = JsonSerializer.Deserialize<IEnumerable<Transaction>>(jsonTransaction, _options);
            if (transactions == null)
            {
                throw new Exception("Transactions could not be deserialized.");
            }

            return transactions;
        }
    }

    ```

    This code is based on the code you added to the Program.cs file in a previous task.

    The `LoadAllTransactions` method accepts a parameter that specifies the file path of the JSON file to load. The method reads the JSON file, deserializes the JSON string into a collection of `Transaction` objects, and returns the collection.

1. To update the `JsonRetrieval` class with a method that recovers account information from JSON files, add the following code to the end of the **JsonRetrieval.cs** file:

    ```csharp

    public static BankAccount LoadBankAccount(string accountFilePath, string transactionsDirectoryPath, BankCustomer customer)
    {
        // get the customer's existing accounts
        IEnumerable<IBankAccount> existingCustomerAccounts = customer.GetAllAccounts();

        // Prepare a transactions file path and a collection for recovered transactions
        string transactionsFilePath = "";
        IEnumerable<Transaction> recoveredTransactions = new List<Transaction>();

        // Load account data from a file using the provided file path (filename = AccountNumber.json)
        var accountDTO = LoadBankAccountDTO(accountFilePath); // accountDTO: AccountNumber, CustomerId, Balance, AccountType, InterestRate

        // Check if the account already exists in the customer's accounts

        bool accountExists = false;

        IBankAccount? returnAccount = null;

        foreach (var existingAccount in existingCustomerAccounts)
        {
            if (existingAccount.AccountNumber == accountDTO.AccountNumber)
            {
                returnAccount = existingAccount;
                accountExists = true;
                break;
            }
        }

        if (accountExists)
        {
            // Before returning the existing account, ensure that it contains the current transaction history
            transactionsFilePath = Path.Combine(transactionsDirectoryPath, $"{accountDTO.AccountNumber}-transactions.json");

            if (File.Exists(transactionsFilePath))
            {
                recoveredTransactions = LoadAllTransactions(transactionsFilePath);
            }

            // Compare the latest transaction date
            int finalExistingAccountTransaction = returnAccount.Transactions.Count() - 1;
            int finalRecoveredTransaction = recoveredTransactions.Count() - 1;

            if (returnAccount.Transactions.ElementAt(finalExistingAccountTransaction).TransactionDate < recoveredTransactions.ElementAt(finalRecoveredTransaction).TransactionDate)
            {
                foreach (var transaction in recoveredTransactions)
                {
                    // Add any missing transactions to the account's transaction history
                    if (!returnAccount.Transactions.Contains(transaction))
                    {
                        returnAccount.AddTransaction(transaction);
                    }
                }
            }

            return (BankAccount)returnAccount;
        }
        else
        {
            // If an existing account wasn't returned, create a new bank account using the recovered data
            var recoveredBankAccount = new BankAccount(customer, customer.CustomerId, accountDTO.Balance, accountDTO.AccountType);

            // Before returning the recovered account, ensure that it contains the current transaction history
            transactionsFilePath = Path.Combine(transactionsDirectoryPath, $"{accountDTO.AccountNumber}-transactions.json");

            recoveredTransactions = LoadAllTransactions(transactionsFilePath);
    
            foreach (var transaction in recoveredTransactions)
            {
                recoveredBankAccount.AddTransaction(transaction);
            }

            return recoveredBankAccount;
        }
    }

    ```

    This code is based on the code you added to the Program.cs file in a previous task.

    The `LoadBankAccount` method accepts parameters that specify the file path of the account JSON file, the directory path for transaction JSON files, and the `BankCustomer` object. The method uses the `BankCustomer` object to retrieve existing accounts and transactions. It then loads account data from the `AccountDTO` file and checks whether the stored account information is present in the active `BankCustomer` object.

    If the recovered account is already represented in the active `BankCustomer` object, the code checks for existing transactions and adds any missing transactions to the account's transaction history. The existing account is returned.

    If the recovered account isn't represented in the active `BankAccount` object, the code creates a new bank account using the recovered data. Transactions are then recovered and added to the account. The new account is returned.

1. To update the `JsonRetrieval` class with a method that returns the file path for a specified account number, add the following code to the end of the **JsonRetrieval.cs** file:

    ```csharp

    public static string ReturnAccountFilePath(string directoryPath, int accountNumber)
    {
        string? accountFilePath = null;

        // search the directoryPath directory for a file named with the accountNumber
        foreach (var filePath in Directory.GetFiles(Path.Combine(directoryPath, "Accounts"), "*.json"))
        {
            if (Path.GetFileNameWithoutExtension(filePath) == accountNumber.ToString())
            {
                accountFilePath = filePath;
            }
        }

        if (accountFilePath == null)
        {
            throw new Exception("Account file not found.");
        }

        return accountFilePath;
    }

    ```

    This code returns the file path of a JSON file based on the specified directory path and account number. If the file isn't found, an exception is thrown.

1. Open the **Program.cs** file.

1. To back up a `BankAccount` object as JSON files using the `JsonStorage.SaveBankAccount` method, add the following code to the end of the **Main** method:

    ```csharp

    // Get the customer's checking account
    BankAccount checkingAccount = (CheckingAccount)bankCustomer.Accounts[0];

    // Use the JsonStorage.SaveBankAccount method to save account info to JSON files (an account file using BankAccountDTO and a separate transactions file)
    JsonStorage.SaveBankAccount(checkingAccount, bankLogsDirectoryPath);

    ```

    This code uses the `JsonStorage` class to save the bank account information to JSON files.

1. To recover a `BankAccount` object using the `JsonRetrieval.LoadBankAccount` method, add the following code to the end of the **Main** method:

    ```csharp

    // Construct the file path for the checking account
    string retrieveAccountFilePath = JsonRetrieval.ReturnAccountFilePath(bankLogsDirectoryPath, checkingAccount.AccountNumber);

    // Use the JsonStorage.LoadBankAccount method to load account info from JSON files (an account file using BankAccountDTO and a separate transactions file)
    BankAccount retrievedAccount = JsonRetrieval.LoadBankAccount(retrieveAccountFilePath, transactionsDirectory, bankCustomer);

    // Display the retrieved account information
    Console.WriteLine($"The owner of the retrieved account is: {retrievedAccount.Owner.ReturnFullName()}");
    Console.WriteLine($"{retrievedAccount.Owner.ReturnFullName()} has the following {retrievedAccount.Owner.Accounts.Count} accounts:");
    foreach (var account in retrievedAccount.Owner.Accounts)
    {
        Console.WriteLine($"Account number: {account.AccountNumber} is a {account.AccountType} account.");
    }

    Console.WriteLine($"\nRetrieved {retrievedAccount.AccountType} account info: {retrievedAccount.DisplayAccountInfo()}");

    Console.WriteLine($"The following transactions were retrieved for {retrievedAccount.Owner.ReturnFullName()}'s {retrievedAccount.AccountType} account: \n");

    foreach (var transaction in retrievedAccount.Transactions)
    {
        Console.WriteLine(transaction.ReturnTransaction());
    }

    ```

    This code uses the `JsonRetrieval` class to recover a `BankAccount` object that's been backed up using JSON files. The recovered account information is displayed along with and account transactions.

1. Run the app and review the output in the terminal window.

    When you run the app, you should see the following information at the end of the output:

    ```plaintext

    Retrieved Checking account info: Account Number: 13237535, Type: Checking, Balance: $3,530.20, Interest Rate: 0.00%, Customer ID: 0011680926, Overdraft Limit: 500
    The following transactions were retrieved for Niki Demetriou's Checking account: 
    
    Transaction ID: 4ece62cb-c3b7-4d6f-baf3-aec70bb08bd8, Type: Withdraw, Date: 2/1/2025, Time: 12:00 PM, Prior Balance: $5,000.00 Amount: $2,927.80, Source Account: 13237535, Target Account: 13237535, Description: Rent payment
    Transaction ID: 53b4c16c-374a-488a-9667-f88b05cd220b, Type: Withdraw, Date: 2/1/2025, Time: 9:00 PM, Prior Balance: $2,072.20 Amount: $150.00, Source Account: 13237535, Target Account: 13237535, Description: Debit card purchase
    Transaction ID: 5172a596-bd73-4a64-b5fd-74bc68b96c0f, Type: Withdraw, Date: 2/3/2025, Time: 8:00 AM, Prior Balance: $1,922.20 Amount: $400.00, Source Account: 13237535, Target Account: 13237535, Description: Withdraw for expenses
    Transaction ID: cfe1e39a-d6e5-4133-9c0d-03c8ada42538, Type: Bank Fee, Date: 2/3/2025, Time: 12:00 PM, Prior Balance: $1,522.20 Amount: $50.00, Source Account: 13237535, Target Account: 13237535, Description: -(BANK FEE)
    Transaction ID: 57c4552a-7e41-49ef-95a5-aabb84e29c52, Type: Bank Refund, Date: 2/5/2025, Time: 12:00 PM, Prior Balance: $1,472.20 Amount: $100.00, Source Account: 13237535, Target Account: 13237535, Description: Refund for overcharge -(BANK REFUND)
    Transaction ID: 2c881cfa-8ed2-4e05-bccb-05ddc340e6c2, Type: Withdraw, Date: 2/8/2025, Time: 9:00 PM, Prior Balance: $1,572.20 Amount: $150.00, Source Account: 13237535, Target Account: 13237535, Description: Debit card purchase
    Transaction ID: cdb85f26-4c99-44e0-8358-f8771a82da9a, Type: Withdraw, Date: 2/10/2025, Time: 8:00 AM, Prior Balance: $1,422.20 Amount: $400.00, Source Account: 13237535, Target Account: 13237535, Description: Withdraw for expenses
    Transaction ID: e0747f8d-8cb5-4b90-ad2f-268242f271ce, Type: Bank Fee, Date: 2/10/2025, Time: 12:00 PM, Prior Balance: $1,022.20 Amount: $50.00, Source Account: 13237535, Target Account: 13237535, Description: -(BANK FEE)
    Transaction ID: ba6405ff-7001-4610-8bd8-f36a68ef6edb, Type: Deposit, Date: 2/14/2025, Time: 12:00 PM, Prior Balance: $972.20 Amount: $3,236.00, Source Account: 13237535, Target Account: 13237535, Description: Bi-monthly salary deposit
    Transaction ID: 79515034-a7d7-4537-8db6-f132ae51f03a, Type: Withdraw, Date: 2/15/2025, Time: 9:00 PM, Prior Balance: $4,208.20 Amount: $158.00, Source Account: 13237535, Target Account: 13237535, Description: Debit card purchase
    Transaction ID: 59d7838c-b279-4fba-ba57-405a3cc595b5, Type: Withdraw, Date: 2/17/2025, Time: 8:00 AM, Prior Balance: $4,050.20 Amount: $400.00, Source Account: 13237535, Target Account: 13237535, Description: Withdraw for expenses
    Transaction ID: eb9f6c5e-5b7c-48d7-af7d-b860d20bf6d8, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $3,650.20 Amount: $64.00, Source Account: 13237535, Target Account: 13237535, Description: Auto-pay waste management bill
    Transaction ID: 77efab20-7bca-4a4f-92ed-c7a2a3c101bd, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $3,586.20 Amount: $80.00, Source Account: 13237535, Target Account: 13237535, Description: Auto-pay water and sewer bill
    Transaction ID: e68414ed-3cab-4d9b-9431-50a38046db4c, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $3,506.20 Amount: $145.00, Source Account: 13237535, Target Account: 13237535, Description: Auto-pay gas and electric bill
    Transaction ID: 98386710-d12a-469c-b661-a4899b4bceb8, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $3,361.20 Amount: $150.00, Source Account: 13237535, Target Account: 13237535, Description: Auto-pay health club membership
    Transaction ID: 506efec0-3c26-42bd-b02e-badb3c051d67, Type: Withdraw, Date: 2/22/2025, Time: 9:00 PM, Prior Balance: $3,211.20 Amount: $179.00, Source Account: 13237535, Target Account: 13237535, Description: Debit card purchase
    Transaction ID: 10d210e4-ac63-4f27-b0a5-0d5f6b93f906, Type: Withdraw, Date: 2/24/2025, Time: 8:00 AM, Prior Balance: $3,032.20 Amount: $400.00, Source Account: 13237535, Target Account: 13237535, Description: Withdraw for expenses
    Transaction ID: 5da9983f-331e-4451-b7e0-ba794f4714af, Type: Withdraw, Date: 2/28/2025, Time: 12:00 PM, Prior Balance: $2,632.20 Amount: $1,538.00, Source Account: 13237535, Target Account: 13237535, Description: Auto-pay credit card bill
    Transaction ID: 1bc3b598-4ec0-4d35-9a92-349c7266a844, Type: Deposit, Date: 2/28/2025, Time: 12:00 PM, Prior Balance: $1,094.20 Amount: $3,236.00, Source Account: 13237535, Target Account: 13237535, Description: Bi-monthly salary deposit
    Transaction ID: 129f61e3-b7bd-41f9-a689-4af4ce6ca901, Type: Transfer, Date: 2/28/2025, Time: 12:00 PM, Prior Balance: $4,330.20 Amount: $800.00, Source Account: 13237535, Target Account: 13237535, Description: Transfer from checking to savings account-(TRANSFER)

    ```

1. Create a new class named `BankCustomerDTO` in the **Services** folder.

    This class will be used as a Data Transfer Object (DTO) to store customer information in a format that can be serialized and deserialized without violating the encapsulation of the `BankCustomer` class.

1. Replace the contents of the **BankCustomerDTO.cs** file with the following code:

    ```csharp

    using System;
    
    namespace Files_M2;
    
    public class BankCustomerDTO
    {
        public string CustomerId { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public List<int> AccountNumbers { get; set; } = new List<int>();
    
        public static BankCustomerDTO MapToDTO(BankCustomer bankCustomer)
        {
            return new BankCustomerDTO
            {
                CustomerId = bankCustomer.CustomerId,
                FirstName = bankCustomer.FirstName,
                LastName = bankCustomer.LastName,
                AccountNumbers = bankCustomer.Accounts.Select(a => a.AccountNumber).ToList()
            };
        }
    }

    ```

    This code defines a `BankCustomerDTO` class with properties that can be used to store customer information. The `MapToDTO` method is used to map the properties of a `BankCustomer` object to a `BankCustomerDTO` object.

1. To update the `BankCustomer` class with a constructor that accepts `CustomerId` and `Bank` object parameters, add the following code to the end of the **BankCustomer.cs** file:

    ```csharp

    // Constructor used to recover and restore an existing customer from back up
    public BankCustomer(string firstName, string lastName, string customerId, Bank bank)
    {
        // Verify that the CustomerId isn't already in use
        if (bank.GetCustomerById(customerId) == null)
        {
            FirstName = firstName;
            LastName = lastName;
            this.CustomerId = customerId;
            _accounts = new List<IBankAccount>();
        }
        else
        {
            throw new ArgumentException("Customer ID already in use");
        }
    }

    ```

    This constructor is used to recover and restore an existing customer from back up. The constructor verifies that the `customerId` isn't already a member of the `bank` object by calling the `GetCustomerById` method of the `Bank` class. If the `customerId` is already in use, an exception is thrown. If the `customerId` isn't in use, the constructor initializes the `FirstName`, `LastName`, and `CustomerId` properties and creates a new list of accounts. The customer and account details will be recovered separately.

1. To update the `JsonStorage` class with methods that can be used to back up `BankCustomer` objects to JSON files, add the following code to the end of the **JsonStorage.cs** file:

    ```csharp

        public static void SaveAllAccounts(IEnumerable<IBankAccount> accounts, string directoryPath)
        {
            foreach (var account in accounts)
            {
                SaveBankAccount((BankAccount)account, directoryPath);
            }
        }
    
        public static void SaveBankCustomer(BankCustomer customer, string directoryPath)
        {
            var customerDTO = new BankCustomerDTO
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                AccountNumbers = new List<int>()
            };
    
            foreach (var account in customer.Accounts)
            {
                customerDTO.AccountNumbers.Add(account.AccountNumber);
            }
    
            string customerFilePath = Path.Combine(directoryPath, "Customers", $"{customer.CustomerId}.json");
    
            var customerDirectoryPath = Path.GetDirectoryName(customerFilePath);
            if (customerDirectoryPath != null && !Directory.Exists(customerDirectoryPath))
            {
                Directory.CreateDirectory(customerDirectoryPath);
            }
    
            string json = JsonSerializer.Serialize(customerDTO, _options);
            File.WriteAllText(customerFilePath, json);
    
            SaveAllAccounts(customer.Accounts, directoryPath);
        }
    
        public static void SaveAllCustomers(IEnumerable<BankCustomer> customers, string directoryPath)
        {
            foreach (var customer in customers)
            {
                SaveBankCustomer(customer, directoryPath);
            }
        }

    ```

    This code defines methods that can be used to save `BankCustomer` objects to JSON files. The `SaveBankCustomer` method saves the customer information and calls the `SaveAllAccounts` method to save the associated accounts. A separate method, `SaveAllCustomers`, is also defined to save all customers in a collection.

1. To update the `JsonRetrieval` class with methods that can be used to recover `BankCustomer` information, add the following code to the end of the **JsonRetrieval.cs** file:

    ```csharp

    public static IEnumerable<BankAccount> LoadAllAccounts(string directoryPath, string transactionsDirectoryPath, BankCustomer customer)
    {
        List<BankAccount> accounts = new List<BankAccount>();
        foreach (var filePath in Directory.GetFiles(Path.Combine(directoryPath, "Accounts"), "*.json"))
        {
            accounts.Add(LoadBankAccount(filePath, transactionsDirectoryPath, customer));
        }
        return accounts;
    }

    public static BankCustomerDTO LoadBankCustomerDTO(string filePath)
    {
        string json = File.ReadAllText(filePath);

        if (string.IsNullOrEmpty(json))
        {
            throw new Exception("No customer found.");
        }
        else
        {
            var customerDTO = JsonSerializer.Deserialize<BankCustomerDTO>(json, _options);
            if (customerDTO == null)
            {
                throw new Exception("Customer could not be deserialized.");
            }
            return customerDTO;
        }
    }

    public static BankCustomer LoadBankCustomer(Bank bank, string filePath, string accountsDirectoryPath, string transactionsDirectoryPath)
    {
        // Load customer data from a file using the provided file path (filename = CustomerId.json)
        var customerDTO = LoadBankCustomerDTO(filePath); // customerDTO: CustomerId, FirstName, LastName, AccountNumbers (list)

        // Use the recovered CustomerId to find the matching customer in Bank.Customers
        var bankCustomer = bank.GetCustomerById(customerDTO.CustomerId);

        // If the customer is not found, create a new bank customer using the recovered data
        if (bankCustomer == null)
        {
            bankCustomer = new BankCustomer(customerDTO.FirstName, customerDTO.LastName, customerDTO.CustomerId, bank);
            bank.AddCustomer(bankCustomer);
        }

        // Ensure the customer object includes all of the customer's accounts that have been backed up to file
        foreach (var accountNumber in customerDTO.AccountNumbers)
        {
            // Check if the account already exists in the customer's accounts
            var existingAccount = bankCustomer.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);

            if (existingAccount == null)
            {
                var accountFilePath = Path.Combine(accountsDirectoryPath, $"{accountNumber}.json");
                var recoveredAccount = LoadBankAccount(accountFilePath, transactionsDirectoryPath, bankCustomer);

                if (recoveredAccount != null)
                {
                    bankCustomer.AddAccount(recoveredAccount);
                }
            }
            else
            {
                bankCustomer.AddAccount(existingAccount);
            }
        }

        return bankCustomer;
    }

    public static IEnumerable<BankCustomer> LoadAllCustomers(Bank bank, string directoryPath, string accountsDirectoryPath, string transactionsDirectoryPath)
    {
        List<BankCustomer> customers = new List<BankCustomer>();
        foreach (var filePath in Directory.GetFiles(Path.Combine(directoryPath, "Customers"), "*.json"))
        {
            customers.Add(LoadBankCustomer(bank, filePath, accountsDirectoryPath, transactionsDirectoryPath));
        }
        return customers;
    }

    ```

    This code defines methods that can be used to recover `BankCustomer` objects using information that's been backed up to JSON files. The `LoadBankCustomer` method loads customer information and calls the `LoadAllAccounts` method to load the associated accounts. A separate method, `LoadAllCustomers`, is also defined to load all customers in a collection.

1. Open the Program.cs file.

1. To back up a `BankCustomer` object as JSON files using the `JsonStorage.SaveBankCustomer` method, add the following code to the end of the **Main** method:

    ```csharp

    string customersDirectoryPath = Path.Combine(bankLogsDirectoryPath, "Customers");
    Directory.CreateDirectory(customersDirectoryPath);

    JsonStorage.SaveBankCustomer(bankCustomer, bankLogsDirectoryPath);
    Console.WriteLine($"\nBank customer information for {bankCustomer.ReturnFullName()} backed up to JSON files.");

    ```

    This code uses the `JsonStorage` class to back up the bank customer information to JSON files.

1. To recover a `BankCustomer` object using the `JsonRetrieval.LoadBankCustomer` method, add the following code to the end of the **Main** method:

    ```csharp

    // Delete the customer and then start the recovery process
    bank.RemoveCustomer(bankCustomer);

    string customerFilePath = Path.Combine(customersDirectoryPath, bankCustomer.CustomerId + ".json");

    BankCustomer retrievedCustomer = JsonRetrieval.LoadBankCustomer(bank, customerFilePath, accountsDirectoryPath, transactionsDirectory);

    Console.WriteLine($"\nRetrieved customer information for {retrievedCustomer.ReturnFullName()}:");
    Console.WriteLine($"Customer ID: {retrievedCustomer.CustomerId}");
    Console.WriteLine($"First Name: {retrievedCustomer.FirstName}");
    Console.WriteLine($"Last Name: {retrievedCustomer.LastName}");
    Console.WriteLine($"Number of accounts: {retrievedCustomer.Accounts.Count}");

    foreach (var account in retrievedCustomer.Accounts)
    {
        Console.WriteLine($"\nAccount number: {account.AccountNumber} is a {account.AccountType} account.");
        Console.WriteLine($" - Balance: {account.Balance}");
        Console.WriteLine($" - Interest Rate: {account.InterestRate}");
        Console.WriteLine($" - Transactions:");
        foreach (var transaction in account.Transactions)
        {
            Console.WriteLine($"    {transaction.ReturnTransaction()}");
        }
    }

    ```

    This code uses the `JsonRetrieval` class to recover a `BankCustomer` object that's been backed up using JSON files. The recovered customer information is displayed along with account information and transactions.

1. To update the `IBankAccount` interface with an `InterestRate` property, add the following code to the list of properties in the **IBankAccount.cs** file:

    ```csharp

    double InterestRate { get; }

    ```

1. Run the app and review the output in the terminal window.

    When you run the app, you should see the following information at the end of the output:

    ```plaintext

    Bank customer information for Niki Demetriou backed up to JSON files.
    
    Retrieved customer information for Niki Demetriou:
    Customer ID: 0014353441
    First Name: Niki
    Last Name: Demetriou
    Number of accounts: 3
    
    Account number: 10730633 is a Checking account.
     - Balance: 4426.5
     - Interest Rate: 0
     - Transactions:
        Transaction ID: 39638dcf-01ff-4318-9682-b793ef4b10e9, Type: Withdraw, Date: 2/1/2025, Time: 12:00 PM, Prior Balance: $5,000.00 Amount: $3,121.00, Source Account: 10730629, Target Account: 10730629, Description: Rent payment
        Transaction ID: 147940be-c842-4ca9-ba6e-34554f65b4f3, Type: Withdraw, Date: 2/1/2025, Time: 9:00 PM, Prior Balance: $1,879.00 Amount: $196.00, Source Account: 10730629, Target Account: 10730629, Description: Debit card purchase
        Transaction ID: 89bdc6a5-e81d-4570-9cb8-7fe458f18836, Type: Withdraw, Date: 2/3/2025, Time: 8:00 AM, Prior Balance: $1,683.00 Amount: $400.00, Source Account: 10730629, Target Account: 10730629, Description: Withdraw for expenses
        Transaction ID: bd06a41d-3f82-4e72-aa4b-a00d8759271f, Type: Bank Fee, Date: 2/3/2025, Time: 12:00 PM, Prior Balance: $1,283.00 Amount: $50.00, Source Account: 10730629, Target Account: 10730629, Description: -(BANK FEE)
        Transaction ID: 0d140c1f-7770-4e44-9e2c-5945ef7de435, Type: Bank Refund, Date: 2/5/2025, Time: 12:00 PM, Prior Balance: $1,233.00 Amount: $100.00, Source Account: 10730629, Target Account: 10730629, Description: Refund for overcharge -(BANK REFUND)
        Transaction ID: 931f60f8-1670-427e-bd4d-03ebbd3a1120, Type: Withdraw, Date: 2/8/2025, Time: 9:00 PM, Prior Balance: $1,333.00 Amount: $211.00, Source Account: 10730629, Target Account: 10730629, Description: Debit card purchase
        Transaction ID: 15ca149e-86d3-4681-854d-98b9c2c512ab, Type: Withdraw, Date: 2/10/2025, Time: 8:00 AM, Prior Balance: $1,122.00 Amount: $400.00, Source Account: 10730629, Target Account: 10730629, Description: Withdraw for expenses
        Transaction ID: 3471df0b-5016-4f5e-9b5a-465b60fa1c69, Type: Bank Fee, Date: 2/10/2025, Time: 12:00 PM, Prior Balance: $722.00 Amount: $50.00, Source Account: 10730629, Target Account: 10730629, Description: -(BANK FEE)
        Transaction ID: 935ffeb5-6544-4771-8b32-867067928065, Type: Deposit, Date: 2/14/2025, Time: 12:00 PM, Prior Balance: $672.00 Amount: $3,970.00, Source Account: 10730629, Target Account: 10730629, Description: Bi-monthly salary deposit
        Transaction ID: 46ff29d9-b77b-45e4-b8e7-f65c53c86b82, Type: Withdraw, Date: 2/15/2025, Time: 9:00 PM, Prior Balance: $4,642.00 Amount: $179.00, Source Account: 10730629, Target Account: 10730629, Description: Debit card purchase
        Transaction ID: 0ff69532-5333-48b3-a4c0-993f7fd386c7, Type: Withdraw, Date: 2/17/2025, Time: 8:00 AM, Prior Balance: $4,463.00 Amount: $400.00, Source Account: 10730629, Target Account: 10730629, Description: Withdraw for expenses
        Transaction ID: ece77249-4f8d-4e2f-bcf6-a2740039b531, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $4,063.00 Amount: $63.00, Source Account: 10730629, Target Account: 10730629, Description: Auto-pay waste management bill
        Transaction ID: de9d8024-de6f-4a85-ae03-9e5238399914, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $4,000.00 Amount: $84.00, Source Account: 10730629, Target Account: 10730629, Description: Auto-pay water and sewer bill
        Transaction ID: 639d97bb-5380-4e02-a278-8485b7206533, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $3,916.00 Amount: $135.00, Source Account: 10730629, Target Account: 10730629, Description: Auto-pay gas and electric bill
        Transaction ID: bcf70998-441f-4fb0-b4b6-df47586a8189, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $3,781.00 Amount: $129.00, Source Account: 10730629, Target Account: 10730629, Description: Auto-pay health club membership
        Transaction ID: 4c92fc1a-bfaf-47e9-afd1-8cbbb9bea2a6, Type: Withdraw, Date: 2/22/2025, Time: 9:00 PM, Prior Balance: $3,652.00 Amount: $161.00, Source Account: 10730629, Target Account: 10730629, Description: Debit card purchase
        Transaction ID: 5b5c8b39-5934-4442-a82b-8ee1bef0f302, Type: Withdraw, Date: 2/24/2025, Time: 8:00 AM, Prior Balance: $3,491.00 Amount: $400.00, Source Account: 10730629, Target Account: 10730629, Description: Withdraw for expenses
        Transaction ID: e329cb8c-e6d7-46d4-bfdd-40532afc3743, Type: Withdraw, Date: 2/28/2025, Time: 12:00 PM, Prior Balance: $3,091.00 Amount: $1,734.50, Source Account: 10730629, Target Account: 10730629, Description: Auto-pay credit card bill
        Transaction ID: 9ded0eb5-39f8-4642-bf8c-1e468f79b019, Type: Deposit, Date: 2/28/2025, Time: 12:00 PM, Prior Balance: $1,356.50 Amount: $3,970.00, Source Account: 10730629, Target Account: 10730629, Description: Bi-monthly salary deposit
        Transaction ID: 55c570d1-1c08-4193-9811-3e6cde6e34a4, Type: Transfer, Date: 2/28/2025, Time: 12:00 PM, Prior Balance: $5,326.50 Amount: $900.00, Source Account: 10730629, Target Account: 10730629, Description: Transfer from checking to savings account-(TRANSFER)
    
    Account number: 10730634 is a Savings account.
     - Balance: 15900
     - Interest Rate: 0
     - Transactions:
        Transaction ID: e47b768b-0809-439d-ae23-c61f82f237c2, Type: Transfer, Date: 2/28/2025, Time: 12:00 PM, Prior Balance: $15,000.00 Amount: $900.00, Source Account: 10730630, Target Account: 10730630, Description: Transfer from checking to savings account-(TRANSFER)
    
    Account number: 10730635 is a Money Market account.
     - Balance: 90000
     - Interest Rate: 0
     - Transactions:

    ```

In this exercise, you used the `JsonSerializer` class serialize and deserialize JSON, beginning with simple conversions and progressing to a more complex data backup and restore implementation.

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Also, building up a portfolio of projects can be a great way to demonstrate your skills to potential employers.
