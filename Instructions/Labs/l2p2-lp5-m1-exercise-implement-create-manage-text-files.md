---
lab:
    title: 'Exercise - Create and manage text files'
    description: 'Learn how to create and enumerate directories and files by using the Directory and Path classes, how to read, write, and manage text files by using the File class, how to read and write comma-separated value files by using StreamReader, StreamWriter, and FileStream classes, and how to read and write binary data files by using BinaryReader and BinaryWriter classes.'
---

# Create and manage text files

File input and output operations are essential for apps that store data, retrieve data, or share data files with other apps. The .NET framework provides a rich set of classes in the `System.IO` namespace to facilitate these operations.

The `Directory`, `Path`, and `File` classes in C# provide a rich set of methods for managing file and directory operations. The `StreamReader`, `StreamWriter`, and `FileStream` classes provide methods for reading and writing text files. In addition, the `BinaryReader` and `BinaryWriter` classes provide methods for reading and writing binary files. These classes are essential for performing file input and output operations in C# applications.

In this exercise, you update an existing app to demonstrate file I/O operations using classes from the `System.IO` namespace.

This exercise takes approximately **30** minutes to complete.

## Before you start

Before you can start this exercise, you need to:

1. Ensure that you have the latest short term support (STS) version of the .NET SDK installed on your computer. You can download the latest versions of the .NET SDK using the following URL: <a href="https://dotnet.microsoft.com/download/" target="_blank">Download .NET</a>

1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code using the following URL: <a href="https://code.visualstudio.com/download/" target="_blank">Download Visual Studio Code</a>

1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For additional help configuring the Visual Studio Code environment, see <a href="https://learn.microsoft.com/training/modules/install-configure-visual-studio-code/" target="_blank">Install and configure Visual Studio Code for C# development</a>

## Exercise scenario

Suppose you've agreed to help a non-profit company with a software project. Before the project kicks off, you decide to update your object-oriented programming skills by developing a banking app. The current version of your app supports basic operations such as creating accounts, depositing and withdrawing money, and transferring funds between accounts. To practice file I/O operation, you're going implement file I/O operations in the app's Program.cs file. You plan to work you way through some basic directory and file management tasks and then finish up with more advanced tasks like storing and retrieving bank transactions.

This exercise includes the following tasks:

1. Review the current version of your banking app.

1. Use the `Path`, `Directory`, and `File` classes to create and enumerate directories and files.

1. Use the `File` class to perform file input/output operations.

1. Use the `File` class to perform file management operations.

1. Use the `StreamWriter` amd `StreamReader` classes to read and write CSV files.

1. Use the `FileStream` class to perform low-level file I/O operations.

1. Use the `BinaryWriter` and `BinaryReader` classes to create and read binary files.

## Review the current version of your banking app

In this task, you download the existing version of your banking app and review the code.

Use the following steps to complete this section of the exercise:

1. Download the starter code from the following URL: [Access local files asynchronously - exercise code projects](https://github.com/MicrosoftLearning/mslearn-develop-oop-csharp/raw/refs/heads/main/DownloadableCodeProjects/Downloads/LP5SampleApps.zip)

1. Extract the contents of the LP5SampleApps.zip file to a folder location on your computer.

    For example, if your running Windows, you can extract the file contents to your Desktop folder.

1. Expand the LP5SampleApps folder, and then open the `Files_M1` folder.

    The Files_M1 folder contains the following code project folders:

    - Solution
    - Starter

    The **Starter** folder contains the starter project files for this exercise.

1. Use Visual Studio Code to open the **Starter** folder.

1. In the EXPLORER view, collapse the **STARTER** folder, select **SOLUTION EXPLORER**, and expand the **Files_M1** project folders.

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

    - `BankCustomer.cs`: This file defines the BankCustomer partial class, which implements the IBankCustomer interface and includes properties and constructors for customer operations.

    - `BankCustomerMethods.cs`: This file defines the BankCustomerMethods partial class, which implements the IBankCustomer interface and contains methods for the BankCustomer class.

    - `CheckingAccount.cs`: This file defines the CheckingAccount class, which inherits from the BankAccount class and includes properties and methods specific to checking accounts.

    - `MoneyMarketAccount.cs`: This file defines the MoneyMarketAccount class, which inherits from the BankAccount class and includes properties and methods specific to money market accounts.

    - `SavingsAccount.cs`: This file defines the SavingsAccount class, which inherits from the BankAccount class and includes properties and methods specific to savings accounts.

    - `Transaction.cs`: This file defines the Transaction class, which includes properties and methods for managing transactions.

    - `Program.cs`: This file includes the main entry point for the app and uses BankCustomer and BankAccount objects implement deposit, withdrawal, and transfer operations.

    Notice that a bank object includes a collection of bank customer objects, and that each customer object includes a collection of bank accounts owned by that customer. The account objects include a collection of transactions, which provide a record of the deposits, withdrawals, and transfers associated with the account. The app can simulate customer account activity by generating transactions for each account. The app can also generates customer and account reports.

1. Run the app and review the output in the terminal window.

    To run your app, right-click the **Files_M1** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    Your app should produce output that's similar to the following example:

    ```plaintext

    Creating Bank, BankCustomer, and BankAccount objects...
    
    Bank object created...
    Bank customer Tim Shao created and added to the Bank object's customer collection...
    Checking and Savings account objects created and added to Tim Shao's account collection...
    
    Is Tim Shao a premium customer: False
    Account details:
      - Account Number: 11325295, Type: Checking, Balance: $5,000.00, Interest Rate: 0.00%, Customer ID: 0012661604, Overdraft Limit: 500
      - Account Number: 11325296, Type: Savings, Balance: $20,000.00, Interest Rate: 2.00%, Customer ID: 0012661604, Withdrawal Limit: 6, Withdrawals This Month: 0

    Open a MoneyMarket account for Tim Shao with a $90,000.00 balance and check premium status...
    Is Tim Shao a premium customer: True
    Account details:
      - Account Number: 11325295, Type: Checking, Balance: $5,000.00, Interest Rate: 0.00%, Customer ID: 0012661604, Overdraft Limit: 500
      - Account Number: 11325296, Type: Savings, Balance: $20,000.00, Interest Rate: 2.00%, Customer ID: 0012661604, Withdrawal Limit: 6, Withdrawals This Month: 0
      - Account Number: 11325297, Type: Money Market, Balance: $90,000.00, Interest Rate: 4.00%, Customer ID: 0012661604, Minimum Balance: 1000, Interest Rate: 4%, Minimum Opening Balance: 2000
    
    Generating two years of prior transactions based on current date...
    
    Generating reports for Tim Shao's Checking account...
    
    Generating the February 2025 report for Checking account: 11325295
    Account Number: 11325295
    Account Type: Checking
    Starting Balance on 2/1/2025: $4,046.35
    
    Starting Balance on 2/1/2025: $1,011.45
    
    Transaction ID: 3a426ad7-86b9-400f-a59c-751bfc36dda9, Type: Withdraw, Date: 2/1/2025, Time: 12:00 PM, Prior Balance: $4,046.35 Amount: $3,034.90, Source Account: 11325295, Target Account: 11325295, Description: Rent payment
    Transaction ID: f7c6b71c-8617-47bb-be5f-7b4e0771bfd2, Type: Withdraw, Date: 2/1/2025, Time: 9:00 PM, Prior Balance: $1,011.45 Amount: $209.00, Source Account: 11325295, Target Account: 11325295, Description: Debit card purchase
    Transaction ID: 79b99513-2699-4099-982b-a580c7da18c6, Type: Withdraw, Date: 2/3/2025, Time: 8:00 AM, Prior Balance: $802.45 Amount: $400.00, Source Account: 11325295, Target Account: 11325295, Description: Withdraw for expenses
    Transaction ID: 7a6195bb-7447-4da5-8c7c-16aaf403f36e, Type: Bank Fee, Date: 2/3/2025, Time: 12:00 PM, Prior Balance: $402.45 Amount: $50.00, Source Account: 11325295, Target Account: 11325295, Description: -(BANK FEE)
    Transaction ID: f495320c-a594-45aa-83ec-7acf0cd680cd, Type: Bank Refund, Date: 2/5/2025, Time: 12:00 PM, Prior Balance: $352.45 Amount: $100.00, Source Account: 11325295, Target Account: 11325295, Description: Refund for overcharge -(BANK REFUND)
    Transaction ID: 70480656-58ef-40b7-81a6-2fe416d8a01a, Type: Withdraw, Date: 2/8/2025, Time: 9:00 PM, Prior Balance: $452.45 Amount: $167.00, Source Account: 11325295, Target Account: 11325295, Description: Debit card purchase
    Transaction ID: 17f01ba0-9c22-4e38-a937-2e1a9b73dc67, Type: Withdraw, Date: 2/10/2025, Time: 8:00 AM, Prior Balance: $285.45 Amount: $400.00, Source Account: 11325295, Target Account: 11325295, Description: Withdraw for expenses
    Transaction ID: a17d60ae-cc44-472c-8e7b-9ec2ae574be0, Type: Transfer, Date: 2/10/2025, Time: 8:00 AM, Prior Balance: ($114.55) Amount: $1,400.00, Source Account: 11325295, Target Account: 11325295, Description: free overdraft protection-(TRANSFER)-(TRANSFER)
    Transaction ID: 89f34a91-2345-4095-b50a-11f4db03d9be, Type: Bank Fee, Date: 2/10/2025, Time: 12:00 PM, Prior Balance: $1,285.45 Amount: $50.00, Source Account: 11325295, Target Account: 11325295, Description: -(BANK FEE)
    Transaction ID: 744146cb-f024-4b1e-ba7a-04be442c79df, Type: Deposit, Date: 2/14/2025, Time: 12:00 PM, Prior Balance: $1,235.45 Amount: $3,703.00, Source Account: 11325295, Target Account: 11325295, Description: Bi-monthly salary deposit
    Transaction ID: ddd503c9-bba7-4aa5-b980-e7ed7a876514, Type: Withdraw, Date: 2/15/2025, Time: 9:00 PM, Prior Balance: $4,938.45 Amount: $179.00, Source Account: 11325295, Target Account: 11325295, Description: Debit card purchase
    Transaction ID: 49f0388c-608f-4243-b62c-7ef730fb8f36, Type: Withdraw, Date: 2/17/2025, Time: 8:00 AM, Prior Balance: $4,759.45 Amount: $400.00, Source Account: 11325295, Target Account: 11325295, Description: Withdraw for expenses
    Transaction ID: 66a60483-17c9-4c93-a761-7add3ca865dd, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $4,359.45 Amount: $124.00, Source Account: 11325295, Target Account: 11325295, Description: Auto-pay gas and electric bill
    Transaction ID: 78a38927-1020-4306-9007-bf8943e8bfdf, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $4,235.45 Amount: $147.00, Source Account: 11325295, Target Account: 11325295, Description: Auto-pay health club membership
    Transaction ID: 3be8b6c8-2f13-49dc-aa2f-bac00116c4a5, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $4,088.45 Amount: $87.00, Source Account: 11325295, Target Account: 11325295, Description: Auto-pay water and sewer bill
    Transaction ID: e67e4f8b-b9fc-4217-bb05-5b7b04041d66, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $4,001.45 Amount: $63.00, Source Account: 11325295, Target Account: 11325295, Description: Auto-pay waste management bill
    Transaction ID: 5eeddd9f-2f16-4872-8b0b-2a3419e3954a, Type: Withdraw, Date: 2/22/2025, Time: 9:00 PM, Prior Balance: $3,938.45 Amount: $152.00, Source Account: 11325295, Target Account: 11325295, Description: Debit card purchase
    Transaction ID: cd3c242e-f764-412a-a3dc-cda467484df7, Type: Withdraw, Date: 2/24/2025, Time: 8:00 AM, Prior Balance: $3,786.45 Amount: $400.00, Source Account: 11325295, Target Account: 11325295, Description: Withdraw for expenses
    Transaction ID: 17f5d504-6bc8-43ea-8854-9fe850e95159, Type: Withdraw, Date: 2/28/2025, Time: 12:00 PM, Prior Balance: $3,386.45 Amount: $1,548.75, Source Account: 11325295, Target Account: 11325295, Description: Auto-pay credit card bill
    Transaction ID: 597b2e9e-fbd1-46db-b122-20784379312a, Type: Deposit, Date: 2/28/2025, Time: 12:00 PM, Prior Balance: $1,837.70 Amount: $3,703.00, Source Account: 11325295, Target Account: 11325295, Description: Bi-monthly salary deposit
    
    Generating current month-to-date report for account: 11325295
    Generating previous 30 days report for account: 11325295
    Generating quarterly report for account: 11325295
    Generating previous year report for account: 11325295
    Generating current year-to-date report for account: 11325295
    Generating last 365 days report for account: 11325295
    
    Generating reports for a BankCustomer object...
    
    Generating the February 2025 report for customer: Tim Shao
    Customer Name: Tim Shao
    Customer ID: 0012661604
    
    Information for account number: 11325295
    Account Type: Checking
    Account Balance: $4,219.50
    
    February 2025 activity for Checking account number: 11325295
    Total Deposits: $7,406.00
    Total Withdrawals: $7,311.65
    Total Transfers: $1,400.00
    Total Fees: $100.00
    Total Refunds: $100.00
    Total Transactions for Checking account number 11325295: 20
    
    Information for account number: 11325296
    Account Type: Savings
    Account Balance: $14,296.00
    
    February 2025 activity for Savings account number: 11325296
    Total Deposits: $0.00
    Total Withdrawals: $0.00
    Total Transfers: $1,400.00
    Total Fees: $0.00
    Total Refunds: $0.00
    Total Transactions for Savings account number 11325296: 1
    
    Information for account number: 11325297
    Account Type: Money Market
    Account Balance: $90,000.00
    
    February 2025 activity for Money Market account number: 11325297
    Total Deposits: $0.00
    Total Withdrawals: $0.00
    Total Transfers: $0.00
    Total Fees: $0.00
    Total Refunds: $0.00
    Total Transactions for Money Market account number 11325297: 0
    
    Total Transactions for customer Tim Shao: 21
    
    Generating current month-to-date report for customer: Tim Shao
    Generating previous month report for customer: Tim Shao
    Generating quarterly report for customer: Tim Shao
    Generating previous year report for customer: Tim Shao
    Generating current year-to-date report for customer: Tim Shao
    Generating last 365 days report for customer: Tim Shao
    
    ```

    The customer IDs, account numbers, and transaction amounts in your output will be different from the example output.

## Use the Path, Directory, and File classes to create and enumerate directories and files

The `Path` and `Directory` classes in .NET provide methods for creating, deleting, moving, and enumerating directories. The `File` class provides methods for performing various file operations such as reading, writing, copying, and deleting files.

In this task, you implement the following directory and file operations:

- Construct file and directory paths by using the `Path` class.
- Create directories and files by using the `Directory` and `File` classes.
- Enumerate directories and files by using the `Directory` class.

Use the following steps to complete this section of the exercise:

1. Open the **Program.cs** file.

    You'll be using the Program.cs file to implement directory and file operations.

1. Replace the contents of the **Program.cs** file with the following code:

    ```csharp

    using Files_M1;

    using System;
    using System.IO;
    using System.Text;

    class Program
    {
        static void Main()
        {
            string directoryPath = @"C:\TempDir\SampleDirectory";

        }
    }

    ```

    This code includes the `using` directives for the `System.IO` and `System.Text` namespaces, which provide classes for file and directory operations. The `Files_M1` namespace contains the classes and methods for your banking app. The `Main` method includes a `directoryPath` variable that contains the path to a directory named **SampleDirectory** in the **C:\TempDir** folder.

    The `@"C:\TempDir\SampleDirectory"` is an example of a *verbatim string literal*, which is denoted by the `@` symbol before the opening quotation mark. Verbatim string literals in C# are particularly useful for paths and other strings where escape sequences (like `\t`) might otherwise be interpreted. In a regular string literal, the backslash (`\`) is treated as an escape character, so you would need to write the path as `"C:\\TempDir\\SampleDirectory"` to avoid errors. However, by using the `@` symbol, the backslashes are treated as literal characters, making the string easier to read and write, especially when dealing with file paths.

    In the following steps, you'll use the `directoryPath` variable to create a directory and perform file operations.

1. To define two subdirectory paths using the `Path.Combine` method, add the following code to the **Main** method:

    ```csharp

    string subDirectoryPath1 = Path.Combine(directoryPath, "SubDirectory1");
    string subDirectoryPath2 = Path.Combine(directoryPath, "SubDirectory2");

    ```

    The `Path.Combine` method combines the specified directory path with the subdirectory names to create the full paths for **SubDirectory1** and **SubDirectory2**.

1. To create four file paths using `Path.Combine`, add the following code to the **Main** method:

    ```csharp

    string filePath = Path.Combine(directoryPath, "sample.txt");
    string appendFilePath = Path.Combine(directoryPath, "append.txt");
    string copyFilePath = Path.Combine(directoryPath, "copy.txt");
    string moveFilePath = Path.Combine(directoryPath, "moved.txt");

    ```

    The `Path.Combine` method combines the specified directory path with the file names to create the full paths for **sample.txt**, **append.txt**, **copy.txt**, and **moved.txt** files.

    You don't have to create directory paths separately from file paths. The `Path.Combine` method can be used to combine a root directory with one or more subdirectories and a file name. For example:

    ```csharp

    string filePath2 = Path.Combine(directoryPath, "SubDirectory3", "file2.txt");

    ```

1. To display the path strings, add the following code to the **Main** method:

    ```csharp

    Console.WriteLine($"Directory path: {directoryPath}");
    Console.WriteLine($"Text file paths ... Sample file path: {filePath}, Append file path: {appendFilePath}, Copy file path: {copyFilePath}, Move file path: {moveFilePath}");

    ```

1. Run the app in the debugger and verify that the following output is displayed.

    Your output should look similar to the following example:

    ```plaintext

    Directory path: C:\TempDir\SampleDirectory
    Text file paths ... Sample file path: C:\TempDir\SampleDirectory\sample.txt, Append file path: C:\TempDir\SampleDirectory\append.txt, Copy file path: C:\TempDir\SampleDirectory\copy.txt, Move file path: C:\TempDir\SampleDirectory\moved.txt

    ```

1. To check whether the "C:\TempDir\SampleDirectory" directory already exists, add the following code to the **Main** method:

    ```csharp

    if (!Directory.Exists(directoryPath))
    {

    }

    ```

    The `!Directory.Exists(directoryPath)` expression checks whether the directory specified by the `directoryPath` variable exists in your file system. If it doesn't exist, the code inside the `if` block will be executed.

1. To create the `directoryPath` directory, add the following code inside the `if` block:

    ```csharp

    Directory.CreateDirectory(directoryPath);
    Console.WriteLine($"Created directory: {directoryPath}");

    ```

    The `Directory.CreateDirectory(directoryPath)` method creates the `C:\TempDir\SampleDirectory` directory in the local file system.

    If the specified directory already exists, the `CreateDirectory` method does nothing and it doesn't throw an exception. This behavior implies that checking for the directory's existence is unnecessary before creating a directory. However, it's good practice to check whether a directory exists before creating it. Checking for an existing directory avoids redundant operations and potential conflicts, clarifies the intended behavior, and provides an opportunity to throw an exception or handle errors.

1. To create the **SubDirectory1** and **SubDirectory2** directories, add the following code to the **Main** method:

    ```csharp

    if (!Directory.Exists(subDirectoryPath1))
    {
        Directory.CreateDirectory(subDirectoryPath1);
        Console.WriteLine($"Created subdirectory: {subDirectoryPath1}");
    }

    if (!Directory.Exists(subDirectoryPath2))
    {
        Directory.CreateDirectory(subDirectoryPath2);
        Console.WriteLine($"Created subdirectory: {subDirectoryPath2}");
    }

    ```

1. Run the app in the debugger and verify that the following output is displayed.

    ```plaintext

    Directory path: C:\TempDir\SampleDirectory
    Text file paths ... Sample file path: C:\TempDir\SampleDirectory\sample.txt, Append file path: C:\TempDir\SampleDirectory\append.txt, Copy file path: C:\TempDir\SampleDirectory\copy.txt, Move file path: C:\TempDir\SampleDirectory\moved.txt
    Created directory: C:\TempDir\SampleDirectory
    Created subdirectory: C:\TempDir\SampleDirectory\SubDirectory1
    Created subdirectory: C:\TempDir\SampleDirectory\SubDirectory2

    ```

1. To create text files in specified directories, add the following code to the **Main** method:

    ```csharp

    // Use the File class to create a sample file in the root directory
    File.WriteAllText(filePath, "This is a sample file.");

    // Use the File class to create sample files in the subdirectories
    File.WriteAllText(Path.Combine(subDirectoryPath1, "file1.txt"), "Content of file1 in SubDirectory1");
    File.WriteAllText(Path.Combine(subDirectoryPath2, "file2.txt"), "Content of file2 in SubDirectory2");

    ```

    The `File.WriteAllText` method creates the specified text files in the subdirectories and writes the specified content to the files. If the file already exists, this method overwrites the file with the new content. The `Path.Combine` method combines the subdirectory paths with the file names to create the full paths for **file1.txt** and **file2.txt** files.

1. To enumerate the directories and files in the **SampleDirectory** directory, add the following code to the **Main** method:

    ```csharp

    Console.WriteLine("\nEnumerating directories and files ...\n");

    // Enumerate the files within a specified root directory
    foreach (var file in Directory.GetFiles(directoryPath))
    {
        Console.WriteLine($"File: {file}");
    }

    // Enumerate the directories within a specified root directory
    foreach (var dir in Directory.GetDirectories(directoryPath))
    {
        Console.WriteLine($"Directory: {dir}");
    }

    // Enumerate the files within each subdirectory of the specified root directory
    foreach (var subDir in Directory.GetDirectories(directoryPath))
    {
        foreach (var file in Directory.GetFiles(subDir))
        {
            Console.WriteLine($"File: {file}");
        }
    }

    // foreach (var entry in Directory.EnumerateFileSystemEntries(directoryPath, "*", SearchOption.AllDirectories))
    // {
    //     Console.WriteLine($"Entry: {entry}");
    // }

    ```

    The `Directory.GetDirectories(directoryPath)` method retrieves an array of directory paths in the specified directory. The `foreach` loop is used to iterate through the array and prints each directory path to the console.

    The `Directory.GetFiles(directoryPath)` method retrieves an array of file paths in the specified directory. The `foreach` loop is used to iterate through the array and prints each file path to the console.

    The nested `foreach` loop is used to iterate through the subdirectories and files, and display the files found within each subdirectory.

    You could consolidate the three `foreach` loops into a single loop by using the `Directory.EnumerateFileSystemEntries` method, which retrieves both files and directories in a single call. However, this method doesn't provide a way to distinguish between files and directories. If you need to differentiate between files and directories, use the `Directory.GetDirectories` and `Directory.GetFiles` methods.

1. Run the app in the debugger and verify that the following output is displayed.

    ```plaintext

    Directory path: C:\TempDir\SampleDirectory
    Text file paths ... Sample file path: C:\TempDir\SampleDirectory\sample.txt, Append file path: C:\TempDir\SampleDirectory\append.txt, Copy file path: C:\TempDir\SampleDirectory\copy.txt, Move file path: C:\TempDir\SampleDirectory\moved.txt
    
    Enumerating directories and files ...
    
    File: C:\TempDir\SampleDirectory\sample.txt
    Directory: C:\TempDir\SampleDirectory\SubDirectory1
    Directory: C:\TempDir\SampleDirectory\SubDirectory2
    File: C:\TempDir\SampleDirectory\SubDirectory1\file1.txt
    File: C:\TempDir\SampleDirectory\SubDirectory2\file2.txt

    ```

## Use the File class to perform file input/output operations

The `File` class provides methods for reading and writing text files, such as `File.ReadAllText`, `File.WriteAllText`, and `File.AppendText`. These methods allow you to read the entire contents of a text file into a string, write a string to a text file, and append a string to an existing text file.

The string can contain any characters, including letters, numbers, symbols, and whitespace, and can be formatted to support specific file formats. For example, the string can be formatted as comma-separated values (CSV), JavaScript object notation (JSON), or extensible markup language (XML). In addition, the string can be encoded in a specific format, such as UTF-8 or ASCII, when reading or writing text files. By default, the `File` class uses UTF-8 encoding.

In this task, you use the `File` class to complete the following operations:

- Write to a text file using CSV formatted strings.
- Read a CSV formatted text string from a file.
- Append a CSV formatted text string to the end of an existing text file.

Use the following steps to complete this section of the exercise:

1. Ensure that you have the Program.cs file open in the **Files_M1** project.

1. To build a CSV formatted string using an array of numeric values, add the following code to the end of the **Main** method:

    ```csharp

    Console.WriteLine("\nUse the File class to write and read CSV-formatted text files.");

    string label = "deposits";
    double[,] depositValues =
    {
        { 100.50, 200.75, 300.25 },
        { 150.00, 250.50, 350.75 },
        { 175.25, 275.00, 375.50 }
    };

    StringBuilder sb = new StringBuilder();

    for (int i = 0; i < depositValues.GetLength(0); i++)
    {
        sb.AppendLine($"{label}: {depositValues[i, 0]}, {depositValues[i, 1]}, {depositValues[i, 2]}");
    }

    ```

    This code creates a two-dimensional array of double values named `depositValues` and a `StringBuilder` object named `sb` that's used to build a CSV formatted string inside a `for` loop. In this case, CSV formatted strings are constructed using the `label` value followed by a colon (`:`) character and a list of comma delimited values from the `depositValues` array. The strings are appended to the `StringBuilder` object using the `AppendLine` method, which appends a string followed by a line terminator to the `StringBuilder` object.

    When the app exits the `for` loop, `sb` contains the following string value: "deposits: 100.5, 200.75, 300.25\r\ndeposits: 150, 250.5, 350.75\r\ndeposits: 175.25, 275, 375.5\r\n"

    > **NOTE**: The `StringBuilder` class is more efficient than using string concatenation, especially when building large strings or when the number of concatenations is unknown. The `StringBuilder` class provides methods for appending, inserting, and removing characters from a string.

1. To split the CSV formatted string into a string array and display the string values, add the following code to the **Main** method:

    ```csharp

    // Split the string representation of the StringBuilder object into an array of strings 
    //  based on the environment's newline character, removing any empty entries.
    string csvString = sb.ToString();
    string[] csvLines = csvString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

    Console.WriteLine("\nCSV formatted string array:");
    foreach (var line in csvLines)
    {
        Console.WriteLine(line);
    }

    ```

    The `sb.ToString()` method converts the `StringBuilder` object to a string. The `Split` method splits the string into an array of strings using the specified delimiter, which in this case is the newline character. The `StringSplitOptions.RemoveEmptyEntries` option removes any empty entries from the resulting array.

    The `csvLines` array should contain the following string values:
    - "deposits: 100.5, 200.75, 300.25"
    - "deposits: 150, 250.5, 350.75"
    - "deposits: 175.25, 275, 375.5"

1. To write the CSV formatted string array to a text file, add the following code to the **Main** method:

    ```csharp

    // Write the CSV formatted string array to a text file. The file is created if it doesn't exist, or overwritten if it does. 
    File.WriteAllText(filePath, csvString);

    ```

    The `File.WriteAllText` method writes the contents of the `csvString` variable to the specified text file. In this case, `filePath` contains `C:\TempDir\SampleDirectory\sample.txt`. This text file already exists, so the file contents are overwritten.

1. To read the contents of the text file into a string array and display the file contents, add the following code to the **Main** method:

    ```csharp

    // Read the contents of the text file into a string array and display the file contents
    string[] readLines = File.ReadAllLines(filePath);
    Console.WriteLine($"\nContent read from the {filePath} file:");
    foreach (var line in readLines)
    {
        Console.WriteLine(line);
    }

    ```

1. Run the app in the debugger and verify that the following output is displayed.

    ```plaintext

    Directory path: C:\TempDir\SampleDirectory
    Text file paths ... Sample file path: C:\TempDir\SampleDirectory\sample.txt, Append file path: C:\TempDir\SampleDirectory\append.txt, Copy file path: C:\TempDir\SampleDirectory\copy.txt, Move file path: C:\TempDir\SampleDirectory\moved.txt
    
    Enumerating directories and files ...
    
    File: C:\TempDir\SampleDirectory\sample.txt
    Directory: C:\TempDir\SampleDirectory\SubDirectory1
    Directory: C:\TempDir\SampleDirectory\SubDirectory2
    File: C:\TempDir\SampleDirectory\SubDirectory1\file1.txt
    File: C:\TempDir\SampleDirectory\SubDirectory2\file2.txt
    
    Use the File class to write and read CSV-formatted text files.
    
    CSV formatted string array:
    deposits: 100.5, 200.75, 300.25
    deposits: 150, 250.5, 350.75
    deposits: 175.25, 275, 375.5
    
    Content read from the C:\TempDir\SampleDirectory\sample.txt file:
    deposits: 100.5, 200.75, 300.25
    deposits: 150, 250.5, 350.75
    deposits: 175.25, 275, 375.5

    ```

1. To append a CSV string to the end of the `sample.txt` text file and display the updated file contents, add the following code to the **Main** method:

    ```csharp

    // Append a new line to the text file
    File.AppendAllText(filePath, "deposits: 215.25, 417, 111.5\r\n");

    // Read and display the updated file contents
    string[] readUpdatedLines = File.ReadAllLines(filePath);
    Console.WriteLine($"\nContent read from updated the {filePath} file:");
    foreach (var line in readUpdatedLines)
    {
        Console.WriteLine(line);
    }

    ```

    The `File.AppendAllText` method appends the specified string to the end of the specified text file. In this case, `appendFilePath` contains `C:\TempDir\SampleDirectory\append.txt`. If the file doesn't exist, it will be created.

1. To read the file and extract the label and value components from the CSV formatted file contents, add the following code to the **Main** method:

    ```csharp

    // Extract the label and value components from the CSV formatted string
    string readLabel = readUpdatedLines[0].Split(':')[0];
    double[,] readDepositValues = new double[readUpdatedLines.Length, 3];
    for (int i = 0; i < readUpdatedLines.Length; i++)
    {
        string[] parts = readUpdatedLines[i].Split(':');
        string[] values = parts[1].Split(',');
        for (int j = 0; j < values.Length; j++)
        {
            readDepositValues[i, j] = double.Parse(values[j]);
        }
    }

    ```

    This code creates a two-dimensional array of `double` values named `readDepositValues` and populates it with the values from the CSV formatted strings.

    The `Split` method is used to separate the label and value components of `readUpdatedLines` strings into `parts[0]` and `parts[1]`, where the first part contains the label and the second part contains the values. The `Split` method is used again to separate the the comma delimited values. The `double.Parse` method is used to convert the string values to double values.

    When the iteration loop is complete, the `readLabel` variable contains "deposits" and the `readDepositValues` array contains the deposit values stored as `double` types.

1. To display the extracted label and numeric values, add the following code to the **Main** method:

    ```csharp

    Console.WriteLine($"\nLabel: {readLabel}");
    Console.WriteLine("Deposit values:");
    for (int i = 0; i < readDepositValues.GetLength(0); i++)
    {
        Console.WriteLine($"{readDepositValues[i, 0]:C}, {readDepositValues[i, 1]:C}, {readDepositValues[i, 2]:C}");
    }

    ```

    Notice that the `:C` format specifier is used to format the numeric values as currency. The `:C` format specifier formats the value as a currency string, using the current culture's currency symbol and formatting conventions. For example, in the en-US culture, the value 100.5 would be formatted as "$100.50".

1. Run the app in the debugger and verify that the following output is displayed.

    ```plaintext

    Directory path: C:\TempDir\SampleDirectory
    Text file paths ... Sample file path: C:\TempDir\SampleDirectory\sample.txt, Append file path: C:\TempDir\SampleDirectory\append.txt, Copy file path: C:\TempDir\SampleDirectory\copy.txt, Move file path: C:\TempDir\SampleDirectory\moved.txt
    
    Enumerating directories and files ...
    
    File: C:\TempDir\SampleDirectory\sample.txt
    Directory: C:\TempDir\SampleDirectory\SubDirectory1
    Directory: C:\TempDir\SampleDirectory\SubDirectory2
    File: C:\TempDir\SampleDirectory\SubDirectory1\file1.txt
    File: C:\TempDir\SampleDirectory\SubDirectory2\file2.txt
    
    Use the File class to write and read CSV-formatted text files.
    
    CSV formatted string array:
    deposits: 100.5, 200.75, 300.25
    deposits: 150, 250.5, 350.75
    deposits: 175.25, 275, 375.5
    
    Content read from the C:\TempDir\SampleDirectory\sample.txt file:
    deposits: 100.5, 200.75, 300.25
    deposits: 150, 250.5, 350.75
    deposits: 175.25, 275, 375.5
    
    Content read from updated the C:\TempDir\SampleDirectory\sample.txt file:
    deposits: 100.5, 200.75, 300.25
    deposits: 150, 250.5, 350.75
    deposits: 175.25, 275, 375.5
    deposits: 215.25, 417, 111.5
    
    Label: deposits
    Deposit values:
    $100.50, $200.75, $300.25
    $150.00, $250.50, $350.75
    $175.25, $275.00, $375.50
    $215.25, $417.00, $111.50

    ```

## Use the File class to perform file management operations

In addition to reading and writing file contents, the `File` class provides methods for performing file management operations such as copying, moving, and deleting files. The `File` class also provides methods for checking whether a file exists and for creating a new file.

In this task, you use the `File` class to complete the following operations:

- Check whether a file exists.
- Copy, move, and delete files.

Use the following steps to complete this section of the exercise:

1. Ensure that you have the Program.cs file open in the **Files_M1** project.

1. To check whether the **sample.txt** file exists, add the following code to the end of the **Main** method:

    ```csharp

    Console.WriteLine("\nUse the File class to perform file management operations.\n");

    // Check whether the append.txt file exists
    if (File.Exists(appendFilePath))
    {
        Console.WriteLine($"The {appendFilePath} file exists.");
    }
    else
    {
        Console.WriteLine($"The {appendFilePath} file does not exist.");
    }

    ```

1. To copy the **sample.txt** file to the `appendFilePath` file location, add the following code to the **Main** method:

    ```csharp

    // Copy the sample.txt file to the file location defined by the copyFilePath variable
    File.Copy(filePath, copyFilePath, true);
    Console.WriteLine($"Copied {filePath} to {copyFilePath}.");

    ```

    The `File.Copy` method takes either two or three parameters. The first two parameters specify the source file path and the destination file path. The third parameter is a `bool` value that specifies whether to overwrite the destination file if it already exists. If the third parameter is `true`, the destination file will be overwritten. If it's `false`, an exception will be thrown if the destination file already exists. The default value is `false`, which means that if third parameter isn't supplied and the destination file already exists, an exception will be thrown.

1. To move the **copy.txt** file to the `moveFilePath` file location, add the following code to the **Main** method:

    ```csharp

    // Move the copy.txt file to the file location defined by the moveFilePath variable
    File.Move(copyFilePath, moveFilePath, true);
    Console.WriteLine($"Moved {copyFilePath} to {moveFilePath}");

    ```

    The `File.Move` method takes the same three parameters as the `File.Copy` method and the parameters are used in the same way. The `File.Move` method moves the source file to the destination file location. If the destination file already exists, it will be overwritten.

1. To delete the **append.txt** file, add the following code to the **Main** method:

    ```csharp

    // Delete the move.txt file
    if (File.Exists(moveFilePath))
    {
        File.Delete(moveFilePath);
        Console.WriteLine($"Deleted file: {moveFilePath}");
    }

    ```

    The `File.Delete` method deletes the specified file. If the file doesn't exist, an exception will be thrown.

1. Run the app in the debugger and verify that the following output is displayed.

    ```plaintext

    Directory path: C:\TempDir\SampleDirectory
    Text file paths ... Sample file path: C:\TempDir\SampleDirectory\sample.txt, Append file path: C:\TempDir\SampleDirectory\append.txt, Copy file path: C:\TempDir\SampleDirectory\copy.txt, Move file path: C:\TempDir\SampleDirectory\moved.txt
    
    Enumerating directories and files ...
    
    File: C:\TempDir\SampleDirectory\sample.txt
    Directory: C:\TempDir\SampleDirectory\SubDirectory1
    Directory: C:\TempDir\SampleDirectory\SubDirectory2
    File: C:\TempDir\SampleDirectory\SubDirectory1\file1.txt
    File: C:\TempDir\SampleDirectory\SubDirectory2\file2.txt
    
    Use the File class to write and read CSV-formatted text files.
    
    CSV formatted string array:
    deposits: 100.5, 200.75, 300.25
    deposits: 150, 250.5, 350.75
    deposits: 175.25, 275, 375.5
    
    Content read from the C:\TempDir\SampleDirectory\sample.txt file:
    deposits: 100.5, 200.75, 300.25
    deposits: 150, 250.5, 350.75
    deposits: 175.25, 275, 375.5
    
    Content read from updated the C:\TempDir\SampleDirectory\sample.txt file:
    deposits: 100.5, 200.75, 300.25
    deposits: 150, 250.5, 350.75
    deposits: 175.25, 275, 375.5
    deposits: 215.25, 417, 111.5
    
    Label: deposits
    Deposit values:
    $100.50, $200.75, $300.25
    $150.00, $250.50, $350.75
    $175.25, $275.00, $375.50
    $215.25, $417.00, $111.50
    
    Use the File class to perform file management operations.
    
    The C:\TempDir\SampleDirectory\append.txt file does not exist.
    Copied C:\TempDir\SampleDirectory\sample.txt to C:\TempDir\SampleDirectory\copy.txt.
    Moved file to: C:\TempDir\SampleDirectory\moved.txt
    Deleted file: C:\TempDir\SampleDirectory\moved.txt

    ```

    Your file management code determines that the **append.txt** doesn't exist, makes a copy of the **sample.txt** file named **copy.txt**, moves **copy.txt** to **moved.txt** in the same directory (essentially renaming the file), and then deletes the **moved.txt** file. The original **sample.txt** file remains unchanged and is the only file remaining in the **C:\TempDir\SampleDirectory** directory.

## Use the StreamWriter amd StreamReader classes to read and write CSV files

The `StreamWriter` and `StreamReader` classes provide methods for writing and reading text files. These classes are useful for working with large files or when you need to read or write data in a specific format.

The `StreamWriter` class provides methods for writing text to a file, including `Write`, `WriteLine`, and `Flush`. The `Write` method writes a string to the file without appending a newline character, while the `WriteLine` method writes a string to the file and appends a newline character. The `Flush` method clears the buffer and writes any buffered data to the file.

The `StreamReader` class provides methods for reading text from a file, including `Read`, `ReadLine`, and `ReadToEnd`. The `Read` method reads a single character from the file, while the `ReadLine` method reads a line of text from the file. The `ReadToEnd` method reads all the text from the file until the end of the file is reached.

In this task, you use the `StreamWriter` and `StreamReader` classes to complete the following operations:

- Use the `StreamWriter` class to write lines of bank transaction data to a CSV file.
- Use the `StreamReader` class to read bank transaction lines from a CSV file.

Use the following steps to complete this section of the exercise:

1. Ensure that you have the Program.cs file open in the **Files_M1** project.

1. Select the code inside the **Main** method and then use a block comment to comment out the existing code.

    ```csharp

    using Files_M1;
    
    using System;
    using System.IO;
    using System.Text;
    
    class Program
    {
        static void Main()
        {
            /*

            // Your existing code here

            */

        }
    }

    ```

    Retaining the code asa block comment enables you to review your code later without having to see the displayed output every time you run the app.

1. To create a directory named **TransactionLogs** in the current directory of the executable program, add the following code to the end of the **Main** method.

    ```csharp

    Console.WriteLine("\nUse the StreamWriter and StreamReader classes.\n");

    // Get the current directory of the executable program
    string currentDirectory = Directory.GetCurrentDirectory();
    Console.WriteLine($"Current directory: {currentDirectory}");

    // Use currentDirectory to create a directory path named TransactionLogs
    string transactionsDirectoryPath = Path.Combine(currentDirectory, "TransactionLogs");
    if (!Directory.Exists(transactionsDirectoryPath))
    {
        Directory.CreateDirectory(transactionsDirectoryPath);
        Console.WriteLine($"Created directory: {transactionsDirectoryPath}");
    }

    ```

    This code creates a directory named **TransactionLogs** in the current directory of the executable program. The `Directory.GetCurrentDirectory` method retrieves directory of the executable program, and the `Path.Combine` method combines the current directory with the **TransactionLogs** directory name to create the full path.

    If you're using .NET 9.0 and you're running the app in the debug environment, the current directory of the executable program will be the **bin\Debug\net9.0** folder of the **Files_M1** project.

1. To create a filepath in the **TransactionLogs** directory for a file name **transactions.csv**, add the following code to the **Main** method:

    ```csharp

    // Create a filepath in the TransactionLogs directory for a file named transactions.csv
    string csvFilePath = Path.Combine(transactionsDirectoryPath, "transactions.csv");

    ```

1. To generate a month of transactions for a bank customer, add the following code to the **Main** method:

    ```csharp

    // Simulate one month of transactions for customer Niki Demetriou
    string firstName = "Niki";
    string lastName = "Demetriou";
    BankCustomer customer = new BankCustomer(firstName, lastName);

    // Add CheckingAccount, SavingsAccount, and MoneyMarketAccount to the customer object using the customer.CustomerId
    customer.AddAccount(new CheckingAccount(customer, customer.CustomerId, 5000));
    customer.AddAccount(new SavingsAccount(customer, customer.CustomerId, 15000));
    customer.AddAccount(new MoneyMarketAccount(customer, customer.CustomerId, 90000));

    DateOnly startDate = new DateOnly(2025, 3, 1);
    DateOnly endDate = new DateOnly(2025, 3, 31);
    customer = SimulateDepositsWithdrawalsTransfers.SimulateActivityDateRange(startDate, endDate, customer);

    ```

    This code creates a `BankCustomer` object named `customer` and adds three bank accounts to the customer object.

    The `SimulateDepositsWithdrawalsTransfers.SimulateActivityDateRange` method simulates a month of transactions for the customer. The `startDate` and `endDate` variables specify the date range for the transactions. The `SimulateActivityDateRange` method generates random transactions using the customer's checking and savings accounts. The method returns the `BankCustomer` object with bank accounts that include the generated transactions.

1. To create a `StreamWriter` object and write the transaction data to the **transactions.csv** file, add the following code to the **Main** method:

    ```csharp

    using (StreamWriter sw = new StreamWriter(csvFilePath))
    {
        sw.WriteLine("TransactionId,TransactionType,TransactionDate,TransactionTime,PriorBalance,TransactionAmount,SourceAccountNumber,TargetAccountNumber,Description");

        Console.WriteLine("\nSimulated transactions:\n");
        foreach (var account in customer.Accounts)
        {
            foreach (var transaction in account.Transactions)
            {
                Console.WriteLine($"{transaction.TransactionId},{transaction.TransactionType},{transaction.TransactionDate},{transaction.TransactionTime},{transaction.PriorBalance:F2},{transaction.TransactionAmount:F2},{transaction.SourceAccountNumber},{transaction.TargetAccountNumber},{transaction.Description}");
                sw.WriteLine($"{transaction.TransactionId},{transaction.TransactionType},{transaction.TransactionDate},{transaction.TransactionTime},{transaction.PriorBalance:F2},{transaction.TransactionAmount:F2},{transaction.SourceAccountNumber},{transaction.TargetAccountNumber},{transaction.Description}");
            }
        }
    }

    ```

    This code creates a `StreamWriter` object named `sw` that writes to the **transactions.csv** file. The `using` statement ensures that the `StreamWriter` object is disposed of properly when it's no longer needed.

    The first `StreamWriter.WriteLine` method writes a header line to the CSV file, and the `foreach` loop iterates through the transactions in each account and writes each transaction to the CSV file. The `F2` format specifier is used to format the numeric values with two decimal places.

1. Run the app in the debugger and verify that the following output is displayed.

    You should see directory and file paths as well as simulated transaction that look similar to the following:

    ```plaintext

    Use the StreamWriter and StreamReader classes.
    
    Current directory: C:\Users\username\Desktop\LP5SampleApps-Instructions\Files_M1\Starter\bin\Debug\net9.0
    Created directory: C:\Users\username\Desktop\LP5SampleApps-Instructions\Files_M1\Starter\bin\Debug\net9.0\TransactionLogs
    
    Simulated transactions:
    
    60ac10f3-560e-4d03-acea-89ddb77d2b69,Withdraw,3/1/2025,12:00 PM,5000.00,2977.30,14255617,14255617,Rent payment
    53a611d6-013d-46a4-af8c-959f818307ac,Withdraw,3/1/2025,9:00 PM,2022.70,170.00,14255617,14255617,Debit card purchase
    0e42c2cc-d1f3-4e26-8c4e-476fa9a8c236,Withdraw,3/3/2025,8:00 AM,1852.70,400.00,14255617,14255617,Withdraw for expenses
    918724e2-4ba5-46a7-9ae6-2ead6ab939ad,Bank Fee,3/3/2025,12:00 PM,1452.70,50.00,14255617,14255617,-(BANK FEE)
    4fbd463a-33e3-42e6-9352-a161c19d1fb3,Bank Refund,3/5/2025,12:00 PM,1402.70,100.00,14255617,14255617,Refund for overcharge -(BANK REFUND)
    59c91abf-fff7-4516-914c-db48f1132555,Withdraw,3/8/2025,9:00 PM,1502.70,161.00,14255617,14255617,Debit card purchase
    a834926d-0579-4dfa-a39e-e439d7eda9c3,Withdraw,3/10/2025,8:00 AM,1341.70,400.00,14255617,14255617,Withdraw for expenses
    6b3b66a4-b3d6-4de0-8a31-c5a08721bb7a,Bank Fee,3/10/2025,12:00 PM,941.70,50.00,14255617,14255617,-(BANK FEE)
    da3ae401-ed2c-45f8-b572-ec6e31093bc4,Deposit,3/14/2025,12:00 PM,891.70,3351.00,14255617,14255617,Bi-monthly salary deposit
    469a9b7f-ae3d-48f3-9651-e9cacfe09154,Withdraw,3/15/2025,9:00 PM,4242.70,200.00,14255617,14255617,Debit card purchase
    a890f47e-e611-4568-8eba-d27fd1c36ec3,Withdraw,3/17/2025,8:00 AM,4042.70,400.00,14255617,14255617,Withdraw for expenses
    0138a45b-d03d-4b80-9feb-5aab2628e44c,Withdraw,3/20/2025,12:00 PM,3642.70,68.00,14255617,14255617,Auto-pay waste management bill
    cd63d44c-8105-499e-80a0-4c75c48c530e,Withdraw,3/20/2025,12:00 PM,3574.70,82.00,14255617,14255617,Auto-pay water and sewer bill
    4333791e-c961-4fab-b486-349fa4b7f860,Withdraw,3/20/2025,12:00 PM,3492.70,132.00,14255617,14255617,Auto-pay gas and electric bill
    6419578b-3234-4e36-b1f3-fb429b64b57a,Withdraw,3/20/2025,12:00 PM,3360.70,130.00,14255617,14255617,Auto-pay health club membership
    648e525f-42ff-4080-af6e-ef8e16e4c028,Withdraw,3/22/2025,9:00 PM,3230.70,178.00,14255617,14255617,Debit card purchase
    a979965b-c76e-4d63-b33c-6cd4041cdcae,Withdraw,3/24/2025,8:00 AM,3052.70,400.00,14255617,14255617,Withdraw for expenses
    d765db7d-7b99-48e5-a46c-7468f34abfe2,Withdraw,3/31/2025,12:00 PM,2652.70,1379.75,14255617,14255617,Auto-pay credit card bill
    68526aa1-9d13-4c56-992d-5a2ebd3edbd2,Deposit,3/31/2025,12:00 PM,1272.95,3351.00,14255617,14255617,Bi-monthly salary deposit
    fd629440-6378-465c-ad1a-68c1a15e9ad5,Transfer,3/31/2025,12:00 PM,4623.95,800.00,14255617,14255617,Transfer from checking to savings account-(TRANSFER)
    19ff7e4b-030d-420d-b7ea-f58807bc69b3,Transfer,3/31/2025,12:00 PM,15000.00,800.00,14255618,14255618,Transfer from checking to savings account-(TRANSFER)

    ```

1. To create a `StreamReader` object and read the transaction data from the **transactions.csv** file, add the following code to the **Main** method:

    ```csharp

    // Read the transaction data from the transactions.csv file
    using (StreamReader sr = new StreamReader(csvFilePath))
    {
        string headerLine = sr.ReadLine(); // Read the header line
        Console.WriteLine("\nTransaction data read from the CSV file:\n");
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }

    ```

    This code creates a `StreamReader` object named `sr` that reads from the **transactions.csv** file. The `using` statement ensures that the `StreamReader` object is disposed of properly when it's no longer needed.

    The first `StreamReader.ReadLine` method reads the header line from the CSV file, and the `while` loop reads each subsequent line of transaction data until the end of the file is reached. The `ReadLine` method returns `null` when there are no more lines to read.

1. Run the app in the debugger and verify that the following output is displayed.

    ```plaintext

    Use the StreamWriter and StreamReader classes.
    
    Current directory: C:\Users\username\Desktop\LP5SampleApps-Instructions\Files_M1\Starter\bin\Debug\net9.0
    
    Simulated transactions:
    
    e98bdfb0-eb02-4441-9551-195bfd319f73,Withdraw,3/1/2025,12:00 PM,5000.00,2804.50,15754227,15754227,Rent payment
    c181745e-db55-4ba6-a527-4568fc9fd2ef,Withdraw,3/1/2025,9:00 PM,2195.50,212.00,15754227,15754227,Debit card purchase
    b4b2b399-5d54-4bed-b49b-f179944cfc8b,Withdraw,3/3/2025,8:00 AM,1983.50,400.00,15754227,15754227,Withdraw for expenses
    b63c6a5f-058b-4724-8617-953d7a13c4f6,Bank Fee,3/3/2025,12:00 PM,1583.50,50.00,15754227,15754227,-(BANK FEE)
    8c6db542-c5a0-48d1-b01d-7106253d2805,Bank Refund,3/5/2025,12:00 PM,1533.50,100.00,15754227,15754227,Refund for overcharge -(BANK REFUND)
    e88309b6-2324-4b87-ba06-3f1111c2615d,Withdraw,3/8/2025,9:00 PM,1633.50,203.00,15754227,15754227,Debit card purchase
    1e3d49f9-9b09-43c4-b84c-bfbb80363d5b,Withdraw,3/10/2025,8:00 AM,1430.50,400.00,15754227,15754227,Withdraw for expenses
    a98c8ef8-5198-486d-be2f-8da49c31e765,Bank Fee,3/10/2025,12:00 PM,1030.50,50.00,15754227,15754227,-(BANK FEE)
    f677634e-f0ee-4653-8135-cf30d8087aad,Deposit,3/14/2025,12:00 PM,980.50,3325.00,15754227,15754227,Bi-monthly salary deposit
    272e4f1d-71d2-4984-ac8e-bf96caaedbaa,Withdraw,3/15/2025,9:00 PM,4305.50,218.00,15754227,15754227,Debit card purchase
    620a5a08-29c9-428a-8100-7730db834daa,Withdraw,3/17/2025,8:00 AM,4087.50,400.00,15754227,15754227,Withdraw for expenses
    5ae0061b-9746-4ae2-ae32-8918dce828e6,Withdraw,3/20/2025,12:00 PM,3687.50,68.00,15754227,15754227,Auto-pay waste management bill
    6f8e1883-b3ae-47c2-8ccb-6ec4ed7c79bd,Withdraw,3/20/2025,12:00 PM,3619.50,84.00,15754227,15754227,Auto-pay water and sewer bill
    43ec783f-abb2-4d35-961d-452c264b76fc,Withdraw,3/20/2025,12:00 PM,3535.50,134.00,15754227,15754227,Auto-pay gas and electric bill
    886cb420-9783-4c9e-a4c8-cbfb88210010,Withdraw,3/20/2025,12:00 PM,3401.50,142.00,15754227,15754227,Auto-pay health club membership
    938a441c-9d86-4bdb-852e-d5b214b3ffa4,Withdraw,3/22/2025,9:00 PM,3259.50,179.00,15754227,15754227,Debit card purchase
    74c02cb3-8da2-4959-a580-c549d94c6525,Withdraw,3/24/2025,8:00 AM,3080.50,400.00,15754227,15754227,Withdraw for expenses
    04d632ff-a696-495e-ad3b-a93412581abf,Withdraw,3/31/2025,12:00 PM,2680.50,1599.25,15754227,15754227,Auto-pay credit card bill
    73ab2a30-1958-4afa-9843-83917ede4d31,Deposit,3/31/2025,12:00 PM,1081.25,3325.00,15754227,15754227,Bi-monthly salary deposit
    1e401c03-8df6-49e2-9798-d07d1012bfe2,Transfer,3/31/2025,12:00 PM,4406.25,800.00,15754227,15754227,Transfer from checking to savings account-(TRANSFER)
    bddbcb40-7517-4fe4-b191-8efca660d6b1,Transfer,3/31/2025,12:00 PM,15000.00,800.00,15754228,15754228,Transfer from checking to savings account-(TRANSFER)
    
    Transaction data read from the CSV file:
    
    e98bdfb0-eb02-4441-9551-195bfd319f73,Withdraw,3/1/2025,12:00 PM,5000.00,2804.50,15754227,15754227,Rent payment
    c181745e-db55-4ba6-a527-4568fc9fd2ef,Withdraw,3/1/2025,9:00 PM,2195.50,212.00,15754227,15754227,Debit card purchase
    b4b2b399-5d54-4bed-b49b-f179944cfc8b,Withdraw,3/3/2025,8:00 AM,1983.50,400.00,15754227,15754227,Withdraw for expenses
    b63c6a5f-058b-4724-8617-953d7a13c4f6,Bank Fee,3/3/2025,12:00 PM,1583.50,50.00,15754227,15754227,-(BANK FEE)
    8c6db542-c5a0-48d1-b01d-7106253d2805,Bank Refund,3/5/2025,12:00 PM,1533.50,100.00,15754227,15754227,Refund for overcharge -(BANK REFUND)
    e88309b6-2324-4b87-ba06-3f1111c2615d,Withdraw,3/8/2025,9:00 PM,1633.50,203.00,15754227,15754227,Debit card purchase
    1e3d49f9-9b09-43c4-b84c-bfbb80363d5b,Withdraw,3/10/2025,8:00 AM,1430.50,400.00,15754227,15754227,Withdraw for expenses
    a98c8ef8-5198-486d-be2f-8da49c31e765,Bank Fee,3/10/2025,12:00 PM,1030.50,50.00,15754227,15754227,-(BANK FEE)
    f677634e-f0ee-4653-8135-cf30d8087aad,Deposit,3/14/2025,12:00 PM,980.50,3325.00,15754227,15754227,Bi-monthly salary deposit
    272e4f1d-71d2-4984-ac8e-bf96caaedbaa,Withdraw,3/15/2025,9:00 PM,4305.50,218.00,15754227,15754227,Debit card purchase
    620a5a08-29c9-428a-8100-7730db834daa,Withdraw,3/17/2025,8:00 AM,4087.50,400.00,15754227,15754227,Withdraw for expenses
    5ae0061b-9746-4ae2-ae32-8918dce828e6,Withdraw,3/20/2025,12:00 PM,3687.50,68.00,15754227,15754227,Auto-pay waste management bill
    6f8e1883-b3ae-47c2-8ccb-6ec4ed7c79bd,Withdraw,3/20/2025,12:00 PM,3619.50,84.00,15754227,15754227,Auto-pay water and sewer bill
    43ec783f-abb2-4d35-961d-452c264b76fc,Withdraw,3/20/2025,12:00 PM,3535.50,134.00,15754227,15754227,Auto-pay gas and electric bill
    886cb420-9783-4c9e-a4c8-cbfb88210010,Withdraw,3/20/2025,12:00 PM,3401.50,142.00,15754227,15754227,Auto-pay health club membership
    938a441c-9d86-4bdb-852e-d5b214b3ffa4,Withdraw,3/22/2025,9:00 PM,3259.50,179.00,15754227,15754227,Debit card purchase
    74c02cb3-8da2-4959-a580-c549d94c6525,Withdraw,3/24/2025,8:00 AM,3080.50,400.00,15754227,15754227,Withdraw for expenses
    04d632ff-a696-495e-ad3b-a93412581abf,Withdraw,3/31/2025,12:00 PM,2680.50,1599.25,15754227,15754227,Auto-pay credit card bill
    73ab2a30-1958-4afa-9843-83917ede4d31,Deposit,3/31/2025,12:00 PM,1081.25,3325.00,15754227,15754227,Bi-monthly salary deposit
    1e401c03-8df6-49e2-9798-d07d1012bfe2,Transfer,3/31/2025,12:00 PM,4406.25,800.00,15754227,15754227,Transfer from checking to savings account-(TRANSFER)
    bddbcb40-7517-4fe4-b191-8efca660d6b1,Transfer,3/31/2025,12:00 PM,15000.00,800.00,15754228,15754228,Transfer from checking to savings account-(TRANSFER)

    ```

## Use the FileStream class to perform low-level file I/O operations

The `FileStream` class is a subclass of the `Stream` class, which provides methods for reading and writing data to a stream. The `FileStream` class provides methods for reading and writing bytes, seeking a specific position in the file, and flushing the stream. The `FileStream` class is useful for reading and writing either text or binary data files. The `FileStream` class can be used to perform low-level file I/O operations, such as reading and writing bytes, seeking a specific position in the file, and flushing the stream.

In this task, you use the `FileStream` class to complete the following operations:

- Use the `FileStream` class to read and write text files.
- Use the `FileStream` class to perform low-level file I/O operations.

Use the following steps to complete this section of the exercise:

1. Ensure that you have the Program.cs file open in the **Files_M1** project.

1. To create a filepath for a **filestream.txt** file and prepare stream data, add the following code to the **Main** method:

    ```csharp

    // Use the FileStream class to perform low-level file I/O operations

    // Create a filepath for the filestream.txt file
    string fileStreamPath = Path.Combine(currentDirectory, "filestream.txt");

    // Prepare transaction data from customer accounts
    StringBuilder sb = new StringBuilder();
    sb.AppendLine("TransactionId,TransactionType,TransactionDate,TransactionTime,PriorBalance,TransactionAmount,SourceAccountNumber,TargetAccountNumber,Description");

    foreach (var account in customer.Accounts)
    {
        foreach (var transaction in account.Transactions)
        {
            // Append transaction data to the StringBuilder object
            sb.AppendLine($"{transaction.TransactionId},{transaction.TransactionType},{transaction.TransactionDate},{transaction.TransactionTime},{transaction.PriorBalance:F2},{transaction.TransactionAmount:F2},{transaction.SourceAccountNumber},{transaction.TargetAccountNumber},{transaction.Description}");
        }
    }

    Console.WriteLine($"\n\nUse the FileStream class to perform file I/O operations.");

    ```

    This code creates a filepath for a file named **filestream.txt** in the current directory of the executable program. The `StringBuilder` object is used to prepare the transaction data from the customer accounts. The `StringBuilder` object is used to build a CSV-formatted string that contains the transaction data. The `AppendLine` method is used to append each line of transaction data to the `StringBuilder` object.

1. To write all of the transaction data to the **filestream.txt** file using the `FileStream` class, add the following code to the **Main** method:

    ```csharp

    // Write transaction data to file using FileStream
    using (FileStream fileStream = new FileStream(fileStreamPath, FileMode.Create, FileAccess.Write))
    {
        // Convert the StringBuilder object to a byte array and write the byte array to the file
        byte[] transactionDataBytes = new UTF8Encoding(true).GetBytes(sb.ToString());
        
        // Use the Write method to write the byte array to the file
        fileStream.Write(transactionDataBytes, 0, transactionDataBytes.Length);
        Console.WriteLine($"\nFile length after write: {fileStream.Length} bytes");
        
        // Use the Flush method to ensure all data is written to the file
        fileStream.Flush(); 
    }

    Console.WriteLine($"\nTransaction data written using FileStream. File: {fileStreamPath}");

    ```

    This code creates a `FileStream` object and writes the transaction data to the **filestream.txt** file.

    The `using` statement is used to ensure that the `FileStream` object is disposed of properly after use. The `FileStream` constructor takes three parameters: the file path, the file mode, and the file access. The `fileStreamPath` variable contains the path to the **filestream.txt** file. The `FileMode.Create` option creates a new file or overwrites an existing file. The `FileAccess.Write` option specifies that the file is opened for writing.

    The `UTF8Encoding` class is used to convert the contents of the `StringBuilder` object to a byte array named `transactionDataBytes`. The `GetBytes` method converts the string to a byte array using UTF-8 encoding.

    The `fileStream.Write` method is used to write the byte array to the file, and the `Flush` method is used to ensure that all data is written to the file.

1. To read all of the transaction data from the **filestream.txt** file using the `FileStream` class, add the following code to the **Main** method:

    ```csharp

    // Read transaction data from file using FileStream
    using (FileStream fileStream = new FileStream(fileStreamPath, FileMode.Open, FileAccess.Read))
    {
        byte[] readBuffer = new byte[1024];
        UTF8Encoding utf8Decoder = new UTF8Encoding(true);
        int bytesRead;

        Console.WriteLine("\nUsing FileStream to read/display transaction data.\n");

        while ((bytesRead = fileStream.Read(readBuffer, 0, readBuffer.Length)) > 0)
        {
            Console.WriteLine($"bytes read: {utf8Decoder.GetString(readBuffer, 0, bytesRead)}\n");
        }


    }

    ```

    This code creates a `FileStream` object and reads the transaction data from the **filestream.txt** file. The `FileMode.Open` option opens an existing file, and the `FileAccess.Read` option specifies that the file is opened for reading.

    The `byte[] readBuffer = new byte[1024];` line creates a byte array of size 1024 bytes that's used as a buffer for file data as it's being read from the file. The buffer size can be larger or smaller to accommodate file information. The `UTF8Encoding utf8Decoder = new UTF8Encoding(true);` line creates a `UTF8Encoding` object that's used to convert the byte array to a string. The `int bytesRead;` line declares an integer variable to store the number of bytes read from the file.

    The `while` loop is used to read data from the file (in 1024 byte chunks) until the end of the file is reached. The `fileStream.Read(readBuffer, 0, readBuffer.Length)` method reads data from the file into the byte array `readBuffer`, and the number of bytes read is assigned to the `bytesRead` variable. When the `Read` method returns 0 bytes (when `bytesRead` is 0), the end of the file has been reached.

    The `Console.WriteLine` method inside the `while` loop displays the buffer contents as the file is being read. The `utf8Decoder.GetString(readBuffer, 0, bytesRead)` method converts the byte array to a string using UTF-8 encoding.

1. To demonstrate some of the `FileStream` class's low-level file I/O capabilities, add the following code to the end of the `using` code block:

    The following code should be placed inside the `using` code block that creates the `FileStream` object for reading the file:

    ```csharp

    Console.WriteLine($"File length: {fileStream.Length} bytes");
    Console.WriteLine($"Current position: {fileStream.Position} bytes");

    // Use the Seek method to move to the beginning of the file
    fileStream.Seek(0, SeekOrigin.Begin);
    Console.WriteLine($"Position after seek: {fileStream.Position} bytes");

    // Use the FileStream.Read method to read the first 100 bytes
    bytesRead = fileStream.Read(readBuffer, 0, 100);
    Console.WriteLine($"Read first 100 bytes: {utf8Decoder.GetString(readBuffer, 0, bytesRead)}");

    ```

    The `Console.WriteLine` method is used to display the file length and the current position within the file. The `fileStream.Length` property returns the length of the file in bytes, and the `fileStream.Position` property returns the current position in the file in bytes.

    The `fileStream.Seek(0, SeekOrigin.Begin)` method moves the file pointer to the beginning of the file. The `SeekOrigin.Begin` option specifies that the position is relative to the beginning of the file. The `Console.WriteLine` method is used to display the position after using the `Seek` method to reposition the pointer.

    The `fileStream.Read(readBuffer, 0, 100)` method reads the first 100 bytes from the file into the `readBuffer` byte array. The number of bytes read is assigned to the `bytesRead` variable. The `utf8Decoder.GetString(readBuffer, 0, bytesRead)` method converts the byte array to a string using UTF-8 encoding.

    The `Console.WriteLine` method is used to display the file length, current position, position after seeking, and the first 100 bytes read from the file.

1. Run the app in the debugger and verify that the following information appears at the bottom of the displayed output.

    ```plaintext

    Use the FileStream class to perform file I/O operations.
    
    File length after write: 2761 bytes
    
    Transaction data written using FileStream. File: C:\Users\username\Desktop\LP5SampleApps-Instructions\Files_M1\Starter\bin\Debug\net9.0\filestream.txt
    
    Using FileStream to read/display transaction data.
    
    bytes read: TransactionId,TransactionType,TransactionDate,TransactionTime,PriorBalance,TransactionAmount,SourceAccountNumber,TargetAccountNumber,Description
    74c4866d-ae85-49d0-b595-b3d9a0b6f243,Withdraw,3/1/2025,12:00 PM,5000.00,3005.00,15546896,15546896,Rent payment
    0dbfc27e-26ed-4405-ac5f-116bcb97e77b,Withdraw,3/1/2025,9:00 PM,1995.00,212.00,15546896,15546896,Debit card purchase
    8bca1376-85ca-479f-93a9-6f4b59368a69,Withdraw,3/3/2025,8:00 AM,1783.00,400.00,15546896,15546896,Withdraw for expenses
    f19ae246-4cf8-4d8a-91fd-efb1407806c5,Bank Fee,3/3/2025,12:00 PM,1383.00,50.00,15546896,15546896,-(BANK FEE)
    0b2ccfe5-8466-469b-833b-2ff3bdae24a8,Bank Refund,3/5/2025,12:00 PM,1333.00,100.00,15546896,15546896,Refund for overcharge -(BANK REFUND)
    cffaffa8-1e77-43df-8090-4e6676c10db7,Withdraw,3/8/2025,9:00 PM,1433.00,193.00,15546896,15546896,Debit card purchase
    941c53e9-a134-4b49-98ef-e42f93a4b750,Withdraw,3/10/2025,8:00 AM,1240.00,400.00,15546896,15546896,Withdraw for expenses
    b76c2f42-8cbb-43e0-bf01-d90c435805c8,Bank Fee,
    
    bytes read: 3/10/2025,12:00 PM,840.00,50.00,15546896,15546896,-(BANK FEE)
    305b5e8a-d12a-49da-bea7-c49c5523858e,Deposit,3/14/2025,12:00 PM,790.00,3520.00,15546896,15546896,Bi-monthly salary deposit
    4bcb93fb-2a99-4f65-a7bb-bc6493a7f846,Withdraw,3/15/2025,9:00 PM,4310.00,210.00,15546896,15546896,Debit card purchase
    0d42e69d-e205-455d-96b7-c98db1e30281,Withdraw,3/17/2025,8:00 AM,4100.00,400.00,15546896,15546896,Withdraw for expenses
    533aa889-de47-4cc4-bf08-4daddd381376,Withdraw,3/20/2025,12:00 PM,3700.00,64.00,15546896,15546896,Auto-pay waste management bill
    619c404c-d9af-44f8-a935-2f2a8eca7a0b,Withdraw,3/20/2025,12:00 PM,3636.00,81.00,15546896,15546896,Auto-pay water and sewer bill
    bdb65c3e-b12e-4e13-930f-76d5c97119e0,Withdraw,3/20/2025,12:00 PM,3555.00,103.00,15546896,15546896,Auto-pay gas and electric bill
    c4983b0a-dc34-4675-8c83-c2aacf5cd37f,Withdraw,3/20/2025,12:00 PM,3452.00,152.00,15546896,15546896,Auto-pay health club membership
    baffa571-d966-40c6-91c5-bad1007add85,Withdraw,3/22/2025,9:00 PM,3300.00,160.00,15
    
    bytes read: 546896,15546896,Debit card purchase
    4d9522bc-8b45-40e2-9572-483a8b7933de,Withdraw,3/24/2025,8:00 AM,3140.00,400.00,15546896,15546896,Withdraw for expenses
    f873b9ad-89d6-47e6-98cf-f36e904b170e,Withdraw,3/31/2025,12:00 PM,2740.00,1617.00,15546896,15546896,Auto-pay credit card bill
    9a04594f-5e83-44dc-b59a-8064bac8054c,Deposit,3/31/2025,12:00 PM,1123.00,3520.00,15546896,15546896,Bi-monthly salary deposit
    07ee2d54-341b-4546-a2a9-ed0fe0cd1f6e,Transfer,3/31/2025,12:00 PM,4643.00,800.00,15546896,15546896,Transfer from checking to savings account-(TRANSFER)
    b0fe1256-5ea5-484b-884e-2ab64e097a84,Transfer,3/31/2025,12:00 PM,15000.00,800.00,15546897,15546897,Transfer from checking to savings account-(TRANSFER)
    
    
    File length: 2761 bytes
    Current position: 2761 bytes
    Position after seek: 0 bytes
    Read first 100 bytes: TransactionId,TransactionType,TransactionDate,TransactionTime,PriorBalance,TransactionAmount,SourceA

    ```

    > **NOTE**: The transaction data is simulated using randomly generated data, which means your "File length" and "Current position" values may differ from the example output.

## Use the BinaryWriter and BinaryReader classes to create and read binary files

Binary files are files that contain data in a format that is not human-readable. Binary files are often used to store data that is not easily represented as text, such as images, audio, and video. The `BinaryWriter` and `BinaryReader` classes provide methods for writing and reading binary data to and from a file.

In this task, you use the `BinaryWriter` and `BinaryReader` classes to complete the following operations:

- Use the `BinaryWriter` class to write binary data to a file.
- Use the `BinaryReader` class to read binary data from a file.

Use the following steps to complete this section of the exercise:

1. Ensure that you have the Program.cs file open in the **Files_M1** project.

1. To write binary data to a file named **binary.dat** using `BinaryWriter`, add the following code to the **Main** method:

    ```csharp

    // Create a filepath for a binary file named binary.dat
    string binaryFilePath = Path.Combine(currentDirectory, "binary.dat");

    // Create a BinaryWriter object and write binary data to the binary.dat file
    using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(binaryFilePath, FileMode.Create)))
    {
        binaryWriter.Write(1.25);
        binaryWriter.Write("Hello");
        binaryWriter.Write(true);
    }

    Console.WriteLine($"\n\nBinary data written to: {binaryFilePath}");

    ```

    This code creates a `BinaryWriter` object and writes binary data to a file named **binary.dat** in the code execution directory. The `File.Open` method opens the file for writing, and the `FileMode.Create` option creates a new file or overwrites an existing file.

    The `BinaryWriter` class provides methods for writing binary data to a file, including a `Write` method that can be used for writing different data types such as `double`, `string`, and `bool`. The `using` statement ensures that the `BinaryWriter` object is disposed of properly after use.

1. To read binary data from the **binary.dat** file using `BinaryReader`, add the following code to the **Main** method:

    ```csharp

    // Create a BinaryReader object and read binary data from the binary.dat file
    using (BinaryReader binaryReader = new BinaryReader(File.Open(binaryFilePath, FileMode.Open)))
    {
            double a = binaryReader.ReadDouble();
            string b = binaryReader.ReadString();
            bool c = binaryReader.ReadBoolean();
            Console.WriteLine($"Binary data read from {binaryFilePath}: {a}, {b}, {c}");
    }

    ```

    This code creates a `BinaryReader` object and reads binary data from the **binary.dat** file. The `File.Open` method opens the file for reading, and the `FileMode.Open` option opens an existing file.

    The `BinaryReader` class provides methods for reading binary data from a file. Notice that specialized read methods are used for reading specific data types such as `ReadDouble`, `ReadString`, and `ReadBoolean`. Binary files don't inherently support headers or metadata that describe the data types they contain. You must know the order and type of data in the file to read it correctly. In this case, the order of the data is `double`, `string`, and `bool`, which matches the order in which the data was written to the file.

    Once again, the `using` statement ensures that the `BinaryReader` object is disposed of properly after use.

1. Run the app in the debugger and verify that the following output is displayed at the end of the displayed output.

    ```plaintext

    Binary data written to: C:\Users\username\Desktop\LP5SampleApps-Instructions\Files_M1\Starter\bin\Debug\net9.0\binary.dat
    Binary data read from C:\Users\username\Desktop\LP5SampleApps-Instructions\Files_M1\Starter\bin\Debug\net9.0\binary.dat: 1.25, Hello, True

    ```

In this exercise, you used the `System.IO` namespace to perform file input and output operations in C#. You learned how to use the `Directory`, `Path`, `File` `StreamWriter`, `StreamReader`, `FileStream`, `BinaryWriter`, and `BinaryReader` classes to create, read, and write text and binary files.

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Also, building up a portfolio of projects can be a great way to demonstrate your skills to potential employers.
