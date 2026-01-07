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

Suppose you're a software developer at a tech company working on a banking application. Your team needs to implement collection types to manage customers, accounts, and transactions efficiently. To ensure consistent behavior, you decide to create and implement these operations in a simple console application.

You've developed an initial version of the app that includes the following files:

- `Program.cs`: This file contains the main entry point of the application, demonstrating the creation and manipulation of collection types.
- `Bank.cs`: This file defines the `Bank` class, which includes methods for managing customers and transaction reports.
- `BankCustomer.cs`: This file defines the `BankCustomer` class, which includes properties and methods for managing customer accounts.
- `BankAccount.cs`: This file defines the `BankAccount` class, which includes properties and methods for managing transactions.
- `Transaction.cs`: This file defines the `Transaction` class, which includes properties for transaction details such as account ID, amount, description, and date.
- `SimulateDepositWithdrawTransfer.cs`: This file contains methods for simulating deposits, withdrawals, and transfers.

This exercise includes the following tasks:

1. Review the code.
1. Implement the `Bank` class.
1. Update the `BankCustomer` class.
1. Update the `BankAccount` class.
1. Create the `Transaction` class.
1. Create the `SimulateDepositWithdrawTransfer` class.
1. Use a `HashSet` to ensure unique transactions.
1. Generate transaction reports using a `Dictionary`.

---

## Review the current version of your project

In this task, you download the existing version of your project and review the code.

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

    - Program.cs

1. Take a few minutes to open and review the Program.cs file.

    - `Program.cs`: This file contains the main entry point of the application, demonstrating the creation and manipulation of date and time values.

1. Run the app and review the output in the terminal window.

    To run your app, right-click the **Data_M2** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    > **TIP**: If you encounter any issues while completing this exercise, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code. If you're still having trouble, you can review the solution code in the sample apps that you downloaded at the beginning of this exercise. To view the Data_M2 solution, navigate to the LP4SampleApps/Data_M2/Solution folder and open the Solution project in Visual Studio Code.

---

## Task 1: Create and manage objects in `Program.cs`

You will implement functionality to create `Bank`, `BankCustomer`, and `BankAccount` objects, add accounts to customers and customers to the bank, simulate transactions, ensure unique transactions using a `HashSet`, and generate a report of transactions within a date range. Each step aligns with a `// Task 1` comment in the `Program.cs` file to help you locate where to add the code.

### Task 1 Steps

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

---

### Check Task 1 work

After completing this task, save your work and run debug with **F5**, your app should produce output similar to the following:

```plaintext
Transaction Report:
Transaction ID: 1, Type: Deposit, Amount: $500.00, Date: 3/14/2025
Transaction ID: 2, Type: Withdrawal, Amount: $300.00, Date: 3/14/2025
```

If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

---

## Task 2: Implement the `Bank` class

You will implement functionality to manage customers and transaction reports in the `Bank` class. Each step aligns with a `// Task 2` comment in the `Bank.cs` file to help you locate where to add the code.

### Task 2 Steps

1. **Add properties for the bank name and customers**  
   Open the `Bank.cs` file and locate the `// Task 2` comment. Add the following code below it:

   ```csharp
   public string Name { get; set; }
   public List<BankCustomer> Customers { get; set; } = new List<BankCustomer>();
   ```

   > **NOTE**: This code adds a property for the bank's name and a list to store its customers.

1. **Add a method to add customers**  
   Below the properties, add the following method:

   ```csharp
   public void AddCustomer(BankCustomer customer)
   {
       Customers.Add(customer);
   }
   ```

   > **NOTE**: This method allows you to add a customer to the bank.

1. **Add a dictionary for transaction reports**  
   Add the following property to store transaction reports:

   ```csharp
   public Dictionary<string, List<Transaction>> TransactionReports { get; set; } = new Dictionary<string, List<Transaction>>();
   ```

   > **NOTE**: This dictionary will be used to generate transaction reports.

---

### Check Task 2 work

After completing this task, save your work. You do not need to build and debug yet, as the functionality implemented in this task will be used in subsequent tasks.

> **NOTE**: The output remains the same as the previous step. Ensure the application builds successfully and no errors are introduced.

---

## Task 3: Update the `BankCustomer` class

You will update the `BankCustomer` class to manage customer accounts. Each step aligns with a `// Task 3` comment in the `BankCustomer.cs` file to help you locate where to add the code.

### Task 3 Steps

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

---

### Check Task 3 work

After completing this task, save your work and run debug with **F5**. While this task does not produce visible output, ensure that the project builds successfully without errors. The functionality implemented in this task will be used in subsequent tasks.

If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

---

## Task 4: Update the `BankAccount` class

You will update the `BankAccount` class to manage transactions. Each step aligns with a `// Task 4` comment in the `BankAccount.cs` file to help you locate where to add the code.

### Task 4 Steps

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

---

### Check Task 4 work

After completing this task, save your work. You do not need to build and debug yet, as the functionality implemented in this task will be used in subsequent tasks.

> **NOTE**: The output remains the same as the previous step. Ensure the application builds successfully and no errors are introduced.

---

## Task 5: Create the `Transaction` class

You will create the `Transaction` class to represent deposits, withdrawals, and transfers. Each step aligns with a `// Task 5` comment in the `Transaction.cs` file to help you locate where to add the code.

### Task 5 Steps

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

---

### Check Task 5 work

After completing this task, save your work and run debug with **F5**. While this task does not produce visible output, ensure that the project builds successfully without errors. The functionality implemented in this task will be used in subsequent tasks.

If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

---

## Task 6: Create the `SimulateDepositWithdrawTransfer` class

You will create the `SimulateDepositWithdrawTransfer` class to simulate deposits, withdrawals, and transfers. Each step aligns with a `// Task 6` comment in the `SimulateDepositWithdrawTransfer.cs` file to help you locate where to add the code.

### Task 6 Steps

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

---

### Check Task 6 work

After completing this task, save your work and run debug with **F5**. While this task does not produce visible output, ensure that the project builds successfully without errors.

> **NOTE**: The output remains the same as the previous step. Ensure the application builds successfully and no errors are introduced.

---

## Task 7: Use a `HashSet` to ensure unique transactions

You will use a `HashSet` to ensure that transactions are unique. Each step aligns with a `// Task 7` comment in the `Program.cs` file to help you locate where to add the code.

### Task 7 Steps

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

---

### Check Task 7 work

After completing this task, save your work and run debug with **F5**. Your app should produce output similar to the following:

```plaintext
Unique Transactions:
Transaction ID: 1, Type: Deposit, Amount: $500.00, Date: 3/14/2025
Transaction ID: 2, Type: Withdrawal, Amount: $300.00, Date: 3/14/2025
```

If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

---

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

---

### Check Task 8 work

After completing this task, save your work and run debug with **F5**. Your app should produce output similar to the following:

```plaintext
Transaction Report for Account 12345:
Transaction ID: 1, Type: Deposit, Amount: $500.00, Date: 3/14/2025
Transaction ID: 2, Type: Withdrawal, Amount: $300.00, Date: 3/14/2025
```

If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

---

## Task 9: Generate a report of transactions within a date range

You will generate a report of transactions within a specific date range. Each step aligns with a `// Task 9` comment in the `Program.cs` file to help you locate where to add the code.

### Task 9 Steps

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

---

### Check Task 9 work

After completing this task, save your work and run debug with **F5**. Your app should prompt you to enter a date range and produce output similar to the following:

```plaintext
Enter the start date (MM/DD/YYYY):
3/14/2025
Enter the end date (MM/DD/YYYY):
3/15/2025

Transactions within the specified date range:
Transaction ID: 1, Type: Deposit, Amount: $500.00, Date: 3/14/2025
Transaction ID: 2, Type: Withdrawal, Amount: $300.00, Date: 3/14/2025
```

If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

---

## Task 10: Generate a summary report of all transactions

You will generate a summary report of all transactions across all accounts. Each step aligns with a `// Task 10` comment in the `Program.cs` file to help you locate where to add the code.

### Task 10 Steps

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

---

### Check Task 10 work

After completing this task, save your work and run debug with **F5**. Your app should produce output similar to the following:

```plaintext
Summary Report:
Total Transactions: 2
Total Amount: $800.00
```

If you encounter any issues, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code.

---

## Check your work

After completing all tasks, save your work and run the application to verify that all functionality is implemented correctly. Ensure that the application builds successfully and produces the expected output for each task.

---

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Additionally, building a portfolio of projects can be a great way to demonstrate your skills to potential employers.

---
