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
- `Transaction.cs`: This file defines the `Transaction` class, which includes properties for transaction details such as date, time, amount, sourceaccount ID, targetaccount ID, type and description.
- `BankAccount.cs`: This file defines the `BankAccount` class, which includes properties and methods for managing bank account transactions.
- `SimulateTransactions.cs`: This file contains methods for generating and simulating transactions over a specified date range.

This exercise includes the following tasks:

1. Review the current version of your project.
1. Create date and time values.
1. Calculate date and time values for bank customer transactions.
1. Use date ranges to simulate transactions programmatically.

## Review the current version of your project

In this task, you download the existing version of your project and review the code.

Use the following steps to complete this section of the exercise:

1. Download the starter code from the following URL: [Implement Basic Date and Time Operations - exercise code projects](https://github.com/MicrosoftLearning/mslearn-develop-oop-csharp/blob/main/DownloadableCodeProjects/Downloads/LP4SampleApps.zip)

1. Extract the contents of the LP4SampleApps.zip file to a folder location on your computer.

1. Expand the LP4SampleApps folder, and then open the `Data_M1` folder.

    The Data_M1 folder contains the following code project folders:

    - Solution
    - Starter

    The **Starter** folder contains the starter project files for this exercise.

1. Use Visual Studio Code to open the **Starter** folder.

1. In the EXPLORER view, collapse the **STARTER** folder, select **SOLUTION EXPLORER**, and expand the **Data_M1** project.

    You should see the following project files:

    - Program.cs

1. Take a few minutes to open and review the Program.cs file.

    - `Program.cs`: This file contains the main entry point of the application, demonstrating the creation and manipulation of date and time values.

1. Run the app and review the output in the terminal window.

    To run your app, right-click the **Data_M1** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    > [!TIP]
    > If you encounter any issues while completing this exercise, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code. If you're still having trouble, you can review the solution code in the sample apps that you downloaded at the beginning of this exercise. To view the Data_M1 solution, navigate to the LP4SampleApps/Data_M1/Solution folder and open the Solution project in Visual Studio Code.

## Task 1: Create and Manipulate Date and Time Values

In this task, you will use the `DateTime`, `DateOnly`, `TimeOnly`, and `TimeZoneInfo` classes to create and manipulate date and time values.

### Task 1 Steps

1. **Get the current date and time**  
   Add the following code to retrieve and display the current date and time:

   ```csharp
   DateTime currentDateTime = DateTime.Now;
   Console.WriteLine($"Current Date and Time: {currentDateTime}");
   ```

1. **Get the current date only**  
   Add the following code to retrieve and display the current date:

   ```csharp
   DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
   Console.WriteLine($"Current Date: {currentDate}");
   ```

1. **Get the current time only**  
   Add the following code to retrieve and display the current time:

   ```csharp
   TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
   Console.WriteLine($"Current Time: {currentTime}");
   ```

1. **Get the current day of the week**  
   Add the following code to retrieve and display the current day of the week:

   ```csharp
   DayOfWeek currentDayOfWeek = DateTime.Now.DayOfWeek;
   Console.WriteLine($"Current Day of the Week: {currentDayOfWeek}");
   ```

1. **Get the current month and year**  
   Add the following code to retrieve and display the current month and year:

   ```csharp
   int currentMonth = DateTime.Now.Month;
   int currentYear = DateTime.Now.Year;
   Console.WriteLine($"Current Month: {currentMonth}, Current Year: {currentYear}");
   ```

1. **Add days to the current date**  
   Add the following code to add 10 days to the current date and display the result:

   ```csharp
   DateTime datePlusDays = DateTime.Now.AddDays(10);
   Console.WriteLine($"Date Plus 10 Days: {datePlusDays}");
   ```

1. **Parse a date string**  
   Add the following code to parse a date string and display the result:

   ```csharp
   DateTime parsedDate = DateTime.Parse("2025-03-13");
   Console.WriteLine($"Parsed Date: {parsedDate}");
   ```

1. **Format a date using `.ToString()` method and "yyyy-MM-dd" format**  
   Add the following code to format the current date and display it:

   ```csharp
   string formattedDate = DateTime.Now.ToString("yyyy-MM-dd");
   Console.WriteLine($"Formatted Date: {formattedDate}");
   ```

1. **Get the current timezone and offset from UTC**  
   Add the following code to retrieve and display the current timezone and UTC offset:

   ```csharp
   TimeZoneInfo currentTimeZone = TimeZoneInfo.Local;
   TimeSpan offsetFromUtc = currentTimeZone.GetUtcOffset(DateTime.Now);
   Console.WriteLine($"Current Time Zone: {currentTimeZone.DisplayName}, Offset from UTC: {offsetFromUtc}");
   ```

1. **Convert the current time to UTC**  
   Add the following code to convert the current time to UTC and display it:

   ```csharp
   DateTime utcTime = DateTime.UtcNow;
   Console.WriteLine($"UTC Time: {utcTime}");
   ```

### Check Task 1 work

After completing this task, save your work and run debug with **F5**, your app should produce output similar to the following:

```plaintext
Current Date and Time: 3/14/2025 10:00:00 AM
Current Date: 3/14/2025
Current Time: 10:00 AM
Current Day of the Week: Friday
Current Month: 3, Current Year: 2025
Date Plus 10 Days: 3/24/2025 10:00:00 AM
Parsed Date: 3/13/2025 12:00:00 AM
Formatted Date: 2025-03-14
Current Time Zone: Pacific Standard Time, Offset from UTC: -08:00:00
UTC Time: 3/14/2025 6:00:00 PM
```

---

## Task 2: Calculate Date and Time Values for Bank Customer Transactions

In this task, you will create transactions for specific dates and times.

### Task 2 Steps

1. **Create a List of type Transaction**
   ```csharp
   List<Transaction> transactions = new();
   ```

1. **Create a transaction for the current date and time**  
   Add the following code to create a transaction for the current date and time:

   ```csharp
   DateOnly date = new DateOnly.FromDateTime(DateTime.Now);
   TimeOnly time = new TimeOnly.FromDatetime(DateTime.Now);
   Transaction transaction1 = new Transaction(date, time, 100, account1.AccountNumber, account2.AccountNumber, "Deposit", "reimbursement");
   transactions.Add(transaction1);
   ```

1. **Create a transaction for yesterday at 1:15 PM**  
   Add the following code to create a transaction for yesterday at 1:15 PM:

   ```csharp
   DateTime yesterday = DateTime.Now.AddDays(-1).Date.Add(new TimeSpan(13, 15, 0));
   date = new DateOnly.FromDateTime(yesterday);
   time = new DateOnly.FromDateTime(yesterday);
   Transaction transaction2 = new Transaction(date, time, 100, account1.AccountNumber, account2.AccountNumber, "Deposit", "reimbursement");
   transactions.Add(transaction2);
   ```

1. **Create transactions for the first three days of December 2024**  
   Add the following code to create transactions for the first three days of December 2024:

   ```csharp
   for (int day = 1; day <= 3; day++)
   {
       DateTime transactionDate = new DateTime(2024, 12, day, 13, 15, 0);
       date = new DateOnly.FromDateTime(transactionDate);
       time = new DateOnly.FromDateTime(transactionDate);
       Transaction transaction = new Transaction(date, time, 100, account1.AccountNumber, account2.AccountNumber, "Deposit", "reimbursement");
       transactions.Add(transaction);
   }
   ```

1. **Display the transactions**  
   Add the following code to display the transactions:

   ```csharp
   foreach (Transaction transaction in transactions)
   {
       Console.WriteLine(transaction.ReturnTransaction());
   }
   ```

### Check Task 2 work

After completing this task, save your work and run debug with **F5**, your app should display the transactions you created, including their dates and times.

---

## Task 3: Use Date Ranges to Simulate Transactions Programmatically

In this task, you will define a date range and generate transactions for that range.

### Steps

1. **Define a date range**  
   Add the following code to define a date range starting on December 12, 2024, and ending on February 20, 2025:

   ```csharp
   DateTime startDate = new DateTime(2024, 12, 12);
   DateTime endDate = new DateTime(2025, 2, 20);
   ```

1. **Generate transactions for the specified date range**  
   Add the following code to generate transactions for the specified date range using the `SimulateTransactions` class:

   ```csharp
   List<Transaction> transactions = SimulateTransactions.GenerateTransactions(startDate, endDate, account1.AccountNumber, account2.AccountNumber).ToList();
   ```

1. **Display the simulated transactions**  
   Add the following code to display the simulated transactions:

   ```csharp
   foreach (Transaction transaction in transactions)
   {
       Console.WriteLine(transaction.ReturnTransaction());
   }
   ```

1. **Display the number of transactions processed**  
   Add the following code to display the number of transactions processed:

   ```csharp
   Console.WriteLine($"\nNumber of transactions processed: {transactions.Count}");
   ```

### Check Task 3 work

After completing this task, save your work and run debug with **F5**, your app should display all simulated transactions and the total number of transactions processed.

---

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Additionally, building a portfolio of projects can be a great way to demonstrate your skills to potential employers.