---
lab:
    title: 'Exercise - Implement Basic Date and Time Operations'
    description: 'Learn how to create and manipulate date and time values in C#. Explore using DateTime, DateOnly, TimeOnly, and TimeZoneInfo classes to perform various date and time operations.'
---

# Implement Basic Date and Time Operations

Date and time manipulation is a fundamental concept in software development that allows you to handle various operations related to scheduling events, logging transactions, session expiration, order processing, and data updates. In this exercise, you will create and manipulate date and time values in a C# console application. You will explore using `DateTime`, `DateOnly`, `TimeOnly`, and `TimeZoneInfo` classes to perform various date and time operations. Additionally, you will calculate date and time values for bank customer transactions and use date ranges to simulate transactions programmatically.

This exercise takes approximately **30** minutes to complete.

## Before you start

Before you can start this exercise, you need to:

1. Ensure that you have the latest short term support (STS) version of the .NET SDK installed on your computer. You can download the latest versions of the .NET SDK using the following URL: <a href="https://dotnet.microsoft.com/download/" target="_blank">Download .NET</a>

1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code using the following URL: <a href="https://code.visualstudio.com/download/" target="_blank">Download Visual Studio Code</a>

1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For additional help configuring the Visual Studio Code environment, see <a href="https://learn.microsoft.com/training/modules/install-configure-visual-studio-code/" target="_blank">Install and configure Visual Studio Code for C# development</a>

## Exercise scenario

Suppose you're a software developer at a tech company working on a new project. Your team needs to implement basic date and time operations in a C# console application. To ensure consistent behavior, you decide to create and implement these operations in a simple console application.

You've developed an initial version of the app that includes the following files:

- `Program.cs`: This file contains the main entry point of the application, demonstrating the creation and manipulation of date and time values.
- `Transaction.cs`: This file defines the `Transaction` class, which includes properties for transaction details such as account ID, amount, description, and date.
- `BankAccount.cs`: This file defines the `BankAccount` class, which includes properties and methods for managing bank account transactions.
- `SimulateTransactions.cs`: This file contains methods for generating and simulating transactions over a specified date range.

This exercise includes the following tasks:

1. Review the current version of your project.
1. Create and manipulate date and time values.
1. Construct date and time values for bank customer transactions.
1. Use date ranges to simulate transactions programmatically.

## Review the current version of your project

In this task, you download the existing version of your project and review the code.

Use the following steps to complete this section of the exercise:

1. Download the starter code from the following URL: [Implement collection types - exercise code projects](https://github.com/MicrosoftLearning/mslearn-develop-oop-csharp/raw/refs/heads/main/DownloadableCodeProjects/Downloads/LP4SampleApps.zip)

1. Extract the contents of the LP4SampleApps.zip file to a folder location on your computer.

1. Expand the LP4SampleApps folder, and then open the `Data_M1` folder.

    The Data_M1 folder contains the following code project folders:

    - Solution
    - Starter

    The **Starter** folder contains the starter project files for this exercise.

1. Use Visual Studio Code to open the **Starter** folder.

1. In the EXPLORER view, collapse the **STARTER** folder, select **SOLUTION EXPLORER**, and expand the **Data_M1** project.

    You should see the following project structure:

    - Interfaces (folder)
    - Models (folder)
    - Services (folder)
    - Program.cs

1. Take a few minutes to open and review the Program.cs file.

    - `Program.cs`: This file contains the main entry point of the application, demonstrating the creation and manipulation of date and time values.

1. Run the app and review the output in the terminal window.

    You should see output that's similar to the following sample:

    ```plaintext
    Demonstrate date and time operations:

    ```

    To run your app from the EXPLORER view, expand SOLUTION EXPLORER, right-click the **Data_M1** project, select **Debug**, and then select **Start New Instance**.

    > **TIP**: If you encounter any issues while completing this exercise, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code. If you're still having trouble, you can review the solution code in the sample apps that you downloaded at the beginning of this exercise. To view the Data_M1 solution, navigate to the LP4SampleApps/Data_M1/Solution folder and open the Solution project in Visual Studio Code.

## Create and manipulate date and time values

In this task, you will use the `DateTime`, `DateOnly`, `TimeOnly`, and `TimeZoneInfo` classes to create and manipulate date and time values.

1. Ensure that you have the Program.cs file open in Visual Studio Code.

1. Locate the following code comment:

    ```csharp
    // TASK 1: Step 1 - Get the current date and time, and extract date and time components
    ```

1. To get and display the current date and time, add the following code below the comment:

   ```csharp
   DateTime currentDateTime = DateTime.Now;
   Console.WriteLine($"Current Date and Time: {currentDateTime}");
   ```

1. Locate the following code comment:

    ```csharp
    // TASK 1: Step 2 - Get the current day of the week and the current month and year
    ```

1. To get and display the date only, add the following code below the comment:

   ```csharp
   DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
   Console.WriteLine($"Current Date: {currentDate}");
   ```

1. To get and display the current time only, add the following code:

   ```csharp
   TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
   Console.WriteLine($"Current Time: {currentTime}");
   ```

1. To get and display the current day of the week, add the following code:

   ```csharp
   DayOfWeek currentDayOfWeek = DateTime.Now.DayOfWeek;
   Console.WriteLine($"Current Day of the Week: {currentDayOfWeek}");
   ```

1. To get and display the current month and year, add the following code:

   ```csharp
   int currentMonth = DateTime.Now.Month;
   int currentYear = DateTime.Now.Year;
   Console.WriteLine($"Current Month: {currentMonth}, Current Year: {currentYear}");
   ```

1. Locate the following code comment:

    ```csharp
    // TASK 1: Step 3 - Add days to the current date and parse a date string
    ```

1. To add 10 days to the current date and display the result, add the following code below the comment:

   ```csharp
   DateTime datePlusDays = DateTime.Now.AddDays(10);
   Console.WriteLine($"Date Plus 10 Days: {datePlusDays}");
   ```

1. To parse a date string and display the result, add the following code:

   ```csharp
   DateTime parsedDate = DateTime.Parse("2025-03-13");
   Console.WriteLine($"Parsed Date: {parsedDate}");
   ```

1. Locate the following code comment:

    ```csharp
    // TASK 1: Step 4 - Format a date and get the current timezone offset
    ```

1. To format a date using the `.ToString()` method and "yyyy-MM-dd" format, add the following code below the comment:  

   ```csharp
   string formattedDate = DateTime.Now.ToString("yyyy-MM-dd");
   Console.WriteLine($"Formatted Date: {formattedDate}");
   ```

1. To get the current timezone and offset from UTC, add the following code:

   ```csharp
   TimeZoneInfo currentTimeZone = TimeZoneInfo.Local;
   TimeSpan offsetFromUtc = currentTimeZone.GetUtcOffset(DateTime.Now);
   Console.WriteLine($"Current Time Zone: {currentTimeZone.DisplayName}, Offset from UTC: {offsetFromUtc}");
   ```

1. Locate the following code comment:

    ```csharp
    // TASK 1: Step 5 - Convert the current time to UTC and display it
    ```

1. To convert the current time to UTC and display it, add the following code below the comment:

   ```csharp
   DateTime utcTime = DateTime.UtcNow;
   Console.WriteLine($"UTC Time: {utcTime}");
   ```

1. Save the Program.cs file.

1. Run your app and review the output.

    You should see output (for the current date) that's similar to the following:

    ```plaintext
    Demonstrate date and time operations:
    Current Date and Time: 1/6/2026 12:16:52 PM
    Current Date: 1/6/2026
    Current Time: 12:16 PM
    Current Day of the Week: Tuesday
    Current Month: 1, Current Year: 2026
    Date Plus 10 Days: 1/16/2026 12:16:52 PM
    Parsed Date: 3/13/2025 12:00:00 AM
    Formatted Date: 2026-01-06
    Current Time Zone: (UTC-08:00) Pacific Time (US & Canada), Offset from UTC: -08:00:00
    UTC Time: 1/6/2026 8:16:52 PM
    ```

## Construct date and time values for bank customer transactions

In this task, you will create bank transactions for specific dates and times.

1. Locate the following code comment in the Program.cs file:

    ```csharp
    // TASK 2: Step 1 - Create a transaction for the current date and time
    ```

1. To create a bank transaction for the current date and time, add the following code below the comment:

    ```csharp

    datedTransactions[0] = new Transaction(currentDate, currentTime, 100, account2.AccountNumber, account2.AccountNumber, "Withdraw", "Groceries");

    ```

1. Locate the following code comment in the Program.cs file:

    ```csharp
    // TASK 2: Step 2 - Create a transaction for yesterday at 1:15PM
    ```

1. To create a bank transaction for yesterday at 1:15 PM, add the following code below the comment:

    ```csharp

    datedTransactions[1] = new Transaction(currentDate.AddDays(-1), new TimeOnly(13, 15), 500, account2.AccountNumber, account2.AccountNumber, "Deposit", "ATM Deposit");

    ```

1. Locate the following code comment in the Program.cs file:

    ```csharp
    // TASK 2: Step 3 - Create transactions for the first three days of December 2025
    ```

1. To create transactions for the first three days of December 2025, add the following code below the comment:

    ```csharp
    
    datedTransactions[2] = new Transaction(new DateOnly(2025, 12, 1), new TimeOnly(10, 0), 200, account2.AccountNumber, account2.AccountNumber, "Deposit", "Salary");
    datedTransactions[3] = new Transaction(new DateOnly(2025, 12, 2), new TimeOnly(14, 30), 150, account2.AccountNumber, account2.AccountNumber, "Withdraw", "Groceries");
    datedTransactions[4] = new Transaction(new DateOnly(2025, 12, 3), new TimeOnly(9, 45), 300, account2.AccountNumber, account2.AccountNumber, "Deposit", "Freelance Work");
    
    ```

1. Locate the following code comment in the Program.cs file:

    ```csharp
    // TASK 2: Step 4 - Display the datedTransactions
    ```

1. To display the transactions, add the following code below the comment:

    ```csharp
    
    Console.WriteLine("\nDated Transactions:");
    foreach (Transaction transaction in datedTransactions)
    {
       Console.WriteLine(transaction.ReturnTransaction());
    }
    ```

1. Save the Program.cs file.

1. Run your app and review the output.

    You should see output (for the current date) that's similar to the following:

    ```plaintext
    Demonstrate date and time operations:
    Current Date and Time: 1/6/2026 12:16:52 PM
    Current Date: 1/6/2026
    Current Time: 12:16 PM
    Current Day of the Week: Tuesday
    Current Month: 1, Current Year: 2026
    Date Plus 10 Days: 1/16/2026 12:16:52 PM
    Parsed Date: 3/13/2025 12:00:00 AM
    Formatted Date: 2026-01-06
    Current Time Zone: (UTC-08:00) Pacific Time (US & Canada), Offset from UTC: -08:00:00
    UTC Time: 1/6/2026 8:16:52 PM
    
    Dated Transactions:
    Transaction ID: a43c2d81-d814-462f-9ed2-115843465482, Type: Withdraw, Date: 1/6/2026, Time: 12:16 PM, Amount: 100, Source Account: 11159445, Target Account: 11159445, Description: Groceries
    Transaction ID: fed4389a-f311-4f28-82f9-a4b2502a7729, Type: Deposit, Date: 1/5/2026, Time: 1:15 PM, Amount: 500, Source Account: 11159445, Target Account: 11159445, Description: ATM Deposit
    Transaction ID: 36e1fc8b-2afe-41f7-af0e-99368a7e3117, Type: Deposit, Date: 12/1/2025, Time: 10:00 AM, Amount: 200, Source Account: 11159445, Target Account: 11159445, Description: Salary
    Transaction ID: f5fce6eb-5148-4198-ba0f-7d9d5b30c495, Type: Withdraw, Date: 12/2/2025, Time: 2:30 PM, Amount: 150, Source Account: 11159445, Target Account: 11159445, Description: Groceries
    Transaction ID: f0368502-cd3e-49ec-846f-2b1e2736ef0c, Type: Deposit, Date: 12/3/2025, Time: 9:45 AM, Amount: 300, Source Account: 11159445, Target Account: 11159445, Description: Freelance Work
    ```

## Use date ranges to simulate transactions programmatically

In this task, you will define a date range and generate transactions for that range.

1. Locate the following code comment in the Program.cs file:

    ```csharp
      // TASK 3: Step 1 - Define a date range starting on October 12, 2025, and ending on December 20, 2025
    ```

1. To define a date range starting on October 12, 2025, and ending on December 20, 2025, add the following code below the comment:

   ```csharp
   DateOnly startDate = new DateOnly(2025, 10, 12);
   DateOnly endDate = new DateOnly(2025, 12, 20);
   ```

1. Locate the following code comment in the Program.cs file:

    ```csharp
      // TASK 3: Step 2 - Generate transactions for the specified date range using the SimulateTransactions class
    ```

1. To generate transactions for the specified date range using the `SimulateTransactions` class, add the following code below the comment:

    ```csharp
    List<Transaction> transactions = new List<Transaction>(SimulateTransactions.SimulateTransactionsDateRange(startDate, endDate, account2, account3));
    ```

1. Locate the following code comment in the Program.cs file:

    ```csharp
      // TASK 3: Step 3 - Display the simulated transactions
    ```

1. To display the simulated transactions, add the following code below the comment:

    ```csharp
    Console.WriteLine("\nSimulated Transactions:");
    foreach (Transaction transaction in transactions)
    {
       if (transaction != null)
       {
             Console.WriteLine(transaction.ReturnTransaction());
       }
    }
    ```

1. Locate the following code comment in the Program.cs file:

    ```csharp
    // TASK 3: Step 4 - Display the number of transactions processed
    ```

1. To display the number of transactions processed, add the following code below the comment:

    ```csharp
    Console.WriteLine($"\nNumber of transactions processed: {transactions.Count}");
    ```

1. Save the Program.cs file.

1. Run your app and review the output.

    You should see output (for the current date) that's similar to the following:

    ```plaintext
    Demonstrate date and time operations:
    Current Date and Time: 1/6/2026 12:16:52 PM
    Current Date: 1/6/2026
    Current Time: 12:16 PM
    Current Day of the Week: Tuesday
    Current Month: 1, Current Year: 2026
    Date Plus 10 Days: 1/16/2026 12:16:52 PM
    Parsed Date: 3/13/2025 12:00:00 AM
    Formatted Date: 2026-01-06
    Current Time Zone: (UTC-08:00) Pacific Time (US & Canada), Offset from UTC: -08:00:00
    UTC Time: 1/6/2026 8:16:52 PM
    
    Dated Transactions:
    Transaction ID: a43c2d81-d814-462f-9ed2-115843465482, Type: Withdraw, Date: 1/6/2026, Time: 12:16 PM, Amount: 100, Source Account: 11159445, Target Account: 11159445, Description: Groceries
    Transaction ID: fed4389a-f311-4f28-82f9-a4b2502a7729, Type: Deposit, Date: 1/5/2026, Time: 1:15 PM, Amount: 500, Source Account: 11159445, Target Account: 11159445, Description: ATM Deposit
    Transaction ID: 36e1fc8b-2afe-41f7-af0e-99368a7e3117, Type: Deposit, Date: 12/1/2025, Time: 10:00 AM, Amount: 200, Source Account: 11159445, Target Account: 11159445, Description: Salary
    Transaction ID: f5fce6eb-5148-4198-ba0f-7d9d5b30c495, Type: Withdraw, Date: 12/2/2025, Time: 2:30 PM, Amount: 150, Source Account: 11159445, Target Account: 11159445, Description: Groceries
    Transaction ID: f0368502-cd3e-49ec-846f-2b1e2736ef0c, Type: Deposit, Date: 12/3/2025, Time: 9:45 AM, Amount: 300, Source Account: 11159445, Target Account: 11159445, Description: Freelance Work
    
    Simulated Transactions:
    Transaction ID: 8a1ffb0d-f1a5-44ff-9e59-245bedaf6a87, Type: Deposit, Date: 10/14/2025, Time: 12:00 PM, Amount: 4853, Source Account: 11159445, Target Account: 11159445, Description: Bi-monthly salary deposit
    Transaction ID: 8c27140d-2280-4b57-9d02-09df59d7b2bd, Type: Deposit, Date: 10/31/2025, Time: 12:00 PM, Amount: 4853, Source Account: 11159445, Target Account: 11159445, Description: Bi-monthly salary deposit
    Transaction ID: addc88cf-4fc1-4f25-a64c-6187f00c4b43, Type: Withdraw, Date: 10/18/2025, Time: 9:00 PM, Amount: 214, Source Account: 11159445, Target Account: 11159445, Description: Debit card purchase
    Transaction ID: 9d44a10f-4558-4961-bca5-62b25ae73d50, Type: Withdraw, Date: 10/25/2025, Time: 9:00 PM, Amount: 189, Source Account: 11159445, Target Account: 11159445, Description: Debit card purchase
    Transaction ID: f9b17938-ea29-45cf-b7be-0da12d0b8f1a, Type: Withdraw, Date: 10/20/2025, Time: 12:00 PM, Amount: 118, Source Account: 11159445, Target Account: 11159445, Description: Auto-pay gas and electric bill
    Transaction ID: d1b29129-8eda-4e86-b020-7849b1eb996f, Type: Withdraw, Date: 10/20/2025, Time: 12:00 PM, Amount: 85, Source Account: 11159445, Target Account: 11159445, Description: Auto-pay water and sewer bill
    Transaction ID: 88f7966f-1779-4ec5-aa97-1b135b321eb3, Type: Withdraw, Date: 10/20/2025, Time: 12:00 PM, Amount: 66, Source Account: 11159445, Target Account: 11159445, Description: Auto-pay waste management bill
    Transaction ID: 6b2ddd2f-309a-4bb5-8ff0-b86538eb3b3f, Type: Withdraw, Date: 10/20/2025, Time: 12:00 PM, Amount: 147, Source Account: 11159445, Target Account: 11159445, Description: Auto-pay health club membership
    Transaction ID: ddddde99-8358-406e-9628-c4408507d849, Type: Withdraw, Date: 10/13/2025, Time: 9:00 AM, Amount: 400, Source Account: 11159445, Target Account: 11159445, Description: Withdraw for expenses
    Transaction ID: 6fa8fbb6-4b06-4378-b164-9b36a78176e8, Type: Withdraw, Date: 10/20/2025, Time: 9:00 AM, Amount: 400, Source Account: 11159445, Target Account: 11159445, Description: Withdraw for expenses
    Transaction ID: 5db30a06-925c-4eb8-9943-cb0fce79458f, Type: Withdraw, Date: 10/27/2025, Time: 9:00 AM, Amount: 400, Source Account: 11159445, Target Account: 11159445, Description: Withdraw for expenses
    Transaction ID: 66d58051-1ecc-4131-8066-a685081b4a6d, Type: Withdraw, Date: 10/31/2025, Time: 12:00 PM, Amount: 3236.2, Source Account: 11159445, Target Account: 11159445, Description: Auto-pay credit card bill
    Transaction ID: 0a14dd83-d347-4e53-b3c3-402dbb2348ba, Type: Deposit, Date: 11/17/2025, Time: 12:00 PM, Amount: 3579, Source Account: 11159445, Target Account: 11159445, Description: Bi-monthly salary deposit
    Transaction ID: 278f44ae-3474-433b-8662-ad6fe595211d, Type: Deposit, Date: 11/28/2025, Time: 12:00 PM, Amount: 3579, Source Account: 11159445, Target Account: 11159445, Description: Bi-monthly salary deposit
    Transaction ID: d13d5151-03f2-4141-a819-949b7ba76073, Type: Transfer, Date: 11/1/2025, Time: 12:00 PM, Amount: 800, Source Account: 11159445, Target Account: 11159446, Description: Transfer checking to savings account
    Transaction ID: 84d996bf-f7d7-49e7-bc30-2ed0b8eb13a0, Type: Withdraw, Date: 11/1/2025, Time: 12:00 PM, Amount: 4437.200000000001, Source Account: 11159445, Target Account: 11159445, Description: Auto-pay rent
    Transaction ID: 5f8c105d-a545-41e1-b1a2-779f885086a6, Type: Withdraw, Date: 11/1/2025, Time: 9:00 PM, Amount: 159, Source Account: 11159445, Target Account: 11159445, Description: Debit card purchase
    Transaction ID: 61f2f853-1f57-4e0a-86c4-69eae8b97285, Type: Withdraw, Date: 11/8/2025, Time: 9:00 PM, Amount: 167, Source Account: 11159445, Target Account: 11159445, Description: Debit card purchase
    Transaction ID: 91130d34-f012-44e8-95a4-ae6450b99140, Type: Withdraw, Date: 11/15/2025, Time: 9:00 PM, Amount: 170, Source Account: 11159445, Target Account: 11159445, Description: Debit card purchase
    Transaction ID: c696fecd-0bb6-40b3-b1d7-b1ac84a96a3b, Type: Withdraw, Date: 11/22/2025, Time: 9:00 PM, Amount: 166, Source Account: 11159445, Target Account: 11159445, Description: Debit card purchase
    Transaction ID: 7d8de552-b9cd-47e8-ae00-154ecd7b84ca, Type: Withdraw, Date: 11/20/2025, Time: 12:00 PM, Amount: 112, Source Account: 11159445, Target Account: 11159445, Description: Auto-pay gas and electric bill
    Transaction ID: 3b92b99c-7a2b-4569-8859-275574180838, Type: Withdraw, Date: 11/20/2025, Time: 12:00 PM, Amount: 88, Source Account: 11159445, Target Account: 11159445, Description: Auto-pay water and sewer bill
    Transaction ID: b037344b-6a26-4197-bb2e-7ce7fe710ce2, Type: Withdraw, Date: 11/20/2025, Time: 12:00 PM, Amount: 69, Source Account: 11159445, Target Account: 11159445, Description: Auto-pay waste management bill
    Transaction ID: 7f163b42-aaba-4af6-9b40-ddcae6d27201, Type: Withdraw, Date: 11/20/2025, Time: 12:00 PM, Amount: 157, Source Account: 11159445, Target Account: 11159445, Description: Auto-pay health club membership
    Transaction ID: 43a3fa8a-a241-4f64-96e5-d13542a333f1, Type: Withdraw, Date: 11/3/2025, Time: 9:00 AM, Amount: 400, Source Account: 11159445, Target Account: 11159445, Description: Withdraw for expenses
    Transaction ID: f107d840-3075-4d68-aa03-6c287b700dcb, Type: Withdraw, Date: 11/10/2025, Time: 9:00 AM, Amount: 400, Source Account: 11159445, Target Account: 11159445, Description: Withdraw for expenses
    Transaction ID: ac88e0ed-c2dc-416a-a800-6c7a8851eda6, Type: Withdraw, Date: 11/17/2025, Time: 9:00 AM, Amount: 400, Source Account: 11159445, Target Account: 11159445, Description: Withdraw for expenses
    Transaction ID: b797d495-c1cc-401b-ae0f-56d8f89811fb, Type: Withdraw, Date: 11/24/2025, Time: 9:00 AM, Amount: 400, Source Account: 11159445, Target Account: 11159445, Description: Withdraw for expenses
    Transaction ID: 124a0e30-1612-4e50-8cd0-73233fd59100, Type: Withdraw, Date: 11/30/2025, Time: 12:00 PM, Amount: 2575.6000000000004, Source Account: 11159445, Target Account: 11159445, Description: Auto-pay credit card bill
    Transaction ID: 95f665d3-e560-4fad-b709-ef538e0f57fc, Type: Refund, Date: 11/5/2025, Time: 12:00 PM, Amount: 100, Source Account: 11159446, Target Account: 11159445, Description: Refund for overcharge
    Transaction ID: e7d89c50-543f-4af7-bde7-1279500b4702, Type: Fee, Date: 11/3/2025, Time: 12:00 PM, Amount: -50, Source Account: 11159445, Target Account: 11159445, Description: Monthly fee
    Transaction ID: aa538bee-0a11-400b-afa2-8278ca850cc2, Type: Fee, Date: 11/10/2025, Time: 12:00 PM, Amount: -50, Source Account: 11159445, Target Account: 11159445, Description: Monthly fee
    Transaction ID: ad1dfd3d-a3f1-42ce-923d-9668980a6330, Type: Deposit, Date: 12/15/2025, Time: 12:00 PM, Amount: 3427, Source Account: 11159445, Target Account: 11159445, Description: Bi-monthly salary deposit
    Transaction ID: 093da892-cd57-468a-8179-3ed8a8e242c0, Type: Deposit, Date: 12/19/2025, Time: 12:00 PM, Amount: 3427, Source Account: 11159445, Target Account: 11159445, Description: Bi-monthly salary deposit
    Transaction ID: b124245b-9fcb-4b85-869a-e3d8181438db, Type: Transfer, Date: 12/1/2025, Time: 12:00 PM, Amount: 800, Source Account: 11159445, Target Account: 11159446, Description: Transfer checking to savings account
    Transaction ID: 62755d8f-b0e8-4080-85ca-5c9b3f93e77b, Type: Withdraw, Date: 12/1/2025, Time: 12:00 PM, Amount: 3613.6000000000004, Source Account: 11159445, Target Account: 11159445, Description: Auto-pay rent
    Transaction ID: 0d9fb04d-a0fc-4989-8297-4a364e294831, Type: Withdraw, Date: 12/6/2025, Time: 9:00 PM, Amount: 175, Source Account: 11159445, Target Account: 11159445, Description: Debit card purchase
    Transaction ID: 05d5b695-67b7-4c9b-89b5-69cfbcc2cfc9, Type: Withdraw, Date: 12/13/2025, Time: 9:00 PM, Amount: 202, Source Account: 11159445, Target Account: 11159445, Description: Debit card purchase
    Transaction ID: 71db5228-ac80-4e27-9df9-bfc020254112, Type: Withdraw, Date: 12/20/2025, Time: 9:00 PM, Amount: 211, Source Account: 11159445, Target Account: 11159445, Description: Debit card purchase
    Transaction ID: 36fbc095-9af2-4481-a5d6-6ef39179eaae, Type: Withdraw, Date: 12/20/2025, Time: 12:00 PM, Amount: 137, Source Account: 11159445, Target Account: 11159445, Description: Auto-pay gas and electric bill
    Transaction ID: 18d4071d-3d0a-450e-84b3-75a576bfc25e, Type: Withdraw, Date: 12/20/2025, Time: 12:00 PM, Amount: 85, Source Account: 11159445, Target Account: 11159445, Description: Auto-pay water and sewer bill
    Transaction ID: e1ac4928-f57a-45a5-9f29-0d3b374f7b66, Type: Withdraw, Date: 12/20/2025, Time: 12:00 PM, Amount: 61, Source Account: 11159445, Target Account: 11159445, Description: Auto-pay waste management bill
    Transaction ID: 6a74a94a-d108-4e2b-bf1f-afe8b4377355, Type: Withdraw, Date: 12/20/2025, Time: 12:00 PM, Amount: 149, Source Account: 11159445, Target Account: 11159445, Description: Auto-pay health club membership
    Transaction ID: 32400719-3f2d-4b32-a380-76eeb8893ba0, Type: Withdraw, Date: 12/1/2025, Time: 9:00 AM, Amount: 400, Source Account: 11159445, Target Account: 11159445, Description: Withdraw for expenses
    Transaction ID: 73de55c5-e07e-462a-8c8c-9349438a5e6c, Type: Withdraw, Date: 12/8/2025, Time: 9:00 AM, Amount: 400, Source Account: 11159445, Target Account: 11159445, Description: Withdraw for expenses
    Transaction ID: f9836adb-5623-457a-817f-bcadd94ecda1, Type: Withdraw, Date: 12/15/2025, Time: 9:00 AM, Amount: 400, Source Account: 11159445, Target Account: 11159445, Description: Withdraw for expenses
    Transaction ID: 3cc54781-2a3a-4e60-a548-e6ddd87aaa9b, Type: Withdraw, Date: 12/19/2025, Time: 12:00 PM, Amount: 2841.8, Source Account: 11159445, Target Account: 11159445, Description: Auto-pay credit card bill
    Transaction ID: 37c5b67a-2945-4318-8d24-b0ad9484f182, Type: Refund, Date: 12/5/2025, Time: 12:00 PM, Amount: 100, Source Account: 11159446, Target Account: 11159445, Description: Refund for overcharge
    Transaction ID: 7a8d2b16-b344-447b-9b6f-c6c9ebae4044, Type: Fee, Date: 12/3/2025, Time: 12:00 PM, Amount: -50, Source Account: 11159445, Target Account: 11159445, Description: Monthly fee
    Transaction ID: da3f1489-7975-49a6-a136-6dcbd0b5057b, Type: Fee, Date: 12/10/2025, Time: 12:00 PM, Amount: -50, Source Account: 11159445, Target Account: 11159445, Description: Monthly fee
    
    Total Simulated Transactions: 70
    ```

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Additionally, building a portfolio of projects can be a great way to demonstrate your skills to potential employers.