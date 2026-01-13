---
lab:
    title: 'Exercise - Implement Generics and Anonymous Types in a Banking Application'
    description: 'Learn how to implement generics, advanced generics, and anonymous types in C#. Explore their use in a banking application to manage accounts, transactions, and customers.'
---

# Implement Generics and Anonymous Types in a Banking Application

Generics and anonymous types are powerful tools in C# that allow you to create reusable, type-safe, and efficient code. In this exercise, you will explore how generics enable you to work with collections and methods in a type-safe manner, while anonymous types allow you to group related data into temporary objects without defining a full class.

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

- `Program.cs`: The Program.cs file provides the main entry point of the application. It's used to demonstrate features of the banking application.
- `Bank.cs`: The Bank.cs file includes the following components:

    - enum `BankAccountType`: A closed set of allowed account categories (Checking/Savings/Business).
    - static class `BankAccountTypeExtensions`: An extension method that converts an enum value into a friendly description.
    - readonly struct `BankAccountNumber`: A small value type that wraps and validates a 12-digit account number.
    - record `BankAccountNumber`: An immutable data model for customer identity/address info (value-based equality).
    - record `Transaction`: An immutable data model for a single ledger entry (amount, date, description).
    - class `BankAccount`: The main domain object that holds account state (balance) and behavior (recording/displaying transactions).

This exercise includes the following tasks:

1. Review the current version of your project.
1. Refactor transactions to a read-only generic API.
1. Add a Bank class that manages accounts using generics.
1. Build a reusable generic Ledger\<TEntry\> with constraints.
1. Create reports using anonymous types (LINQ projections).
1. Decide the boundary - anonymous types vs named result types.

## Task 1: Review the current version of your project

In this task, you download the existing version of your project and review the code.

Use the following steps to complete this section of the exercise:

1. Download the starter code from the following URL: [Implement collection types - exercise code projects](https://github.com/MicrosoftLearning/mslearn-develop-oop-csharp/raw/refs/heads/main/DownloadableCodeProjects/Downloads/LP4SampleApps.zip)

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
    - `Bank.cs`: This file defines the `BankAccountType` enum, `BankAccountNumber` struct, `BankAccountNumber` and `Transaction` records, and `BankAccount` class.

1. Run the app and review the output in the terminal window.

    Your output should look similar to the following:

    ```plaintext
    Welcome to the Bank App!
    Account type description: A standard checking account.
    Account Holder: Tim Shao, Account Number: 000012345678, Type: Checking, Balance: $500.00
    Account Holder: Tim Shao, Account Number: 000012345678, Type: Checking, Balance: $650.00
    Transactions:
    1/12/2026: Deposit - $200.00
    1/12/2026: ATM Withdrawal - ($50.00)
    Are customers equal? True
    Original Account Number: 000123456789
    ```

    To run your app, right-click the **Data_M4** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

## Task 2: Refactor transactions to a read-only generic API

Returning mutable collections like `List<T>` exposes internal state that callers can modify, breaking encapsulation. Generic read-only interfaces like `IReadOnlyList<T>` provide a safe way to expose collections without allowing mutation.

In this task, you use generic read-only interfaces to make transactions queryable without exposing mutable internal state.

Use the following steps to complete this task:

1. Open the `Bank.cs` file, and then locate the code comment that begins with **Task 2: Step 1**.

1. Replace the existing private transactions collection with a private backing field.

    Before (current code in `BankAccount`):

    ```csharp
    private List<Transaction> Transactions { get; } = new();
    ```

    After:

    ```csharp
    private readonly List<Transaction> _transactions = new();
    ```

1. Locate the **Task 2: Step 2** comment.

1. To create a public read-only Property that exposes transactions as `IReadOnlyList<Transaction>`, enter the following code:

    ```csharp
    public IReadOnlyList<Transaction> Transactions => _transactions;
    ```

    This code exposes a public read-only view so callers can read transactions without mutating the list.

1. Locate the **Task 2: Step 3** comment.

1. Update the `AddTransaction(...)` method to use `_transactions` instead of `Transactions`.

    Before:

    ```csharp
    Transactions.Add(new Transaction(amount, DateTime.Now, description));
    ```

    After:

    ```csharp
    _transactions.Add(new Transaction(amount, DateTime.Now, description));
    ```

    Notice that the method now adds to the private backing list, not the public property.

1. Locate the **Task 2: Step 4** comment.

1. Update `DisplayTransactions()` to iterate over the public `Transactions` property.

    Before (iterate the backing list directly):

    ```csharp
    foreach (Transaction transaction in Transactions)
    {
        Console.WriteLine(transaction);
    }
    ```

    After (iterate the read-only view):

    ```csharp
    foreach (var transaction in Transactions)
    {
        Console.WriteLine(transaction);
    }
    ```

    Notice the loop now uses the public read-only property, not a private list.

1. Locate the **Task 2: Step 5** comment.

1. Add a method that returns an iterator abstraction instead of a list.

    Add this method to `BankAccount`:

    ```csharp
    public IEnumerable<Transaction> GetTransactions() => Transactions;
    ```

1. Open the `Program.cs` file.

1. Locate the code comment that begins with **Task 2: Step 6**.

1. Take a minute to consider the `DisplayTransactions()` method call.

    You updated the `DisplayTransactions()` method to read transactions using the read-only API, so no changes are needed here. However, if you wanted to print transactions directly from `Program.cs`, you could replace the method call with something similar to the following code:

    ```csharp
    Console.WriteLine("Transactions (from Program):");
    foreach (var tx in bankAccount.Transactions)
    {
        Console.WriteLine(tx);
    }
    ```

1. Run the app, and then review the output to confirm behavior is unchanged.

    Your output should be similar to the following:

    ```plaintext
    Welcome to the Bank App!
    Account type description: A standard checking account.
    Account Holder: Tim Shao, Account Number: 000012345678, Type: Checking, Balance: $500.00
    Account Holder: Tim Shao, Account Number: 000012345678, Type: Checking, Balance: $650.00
    Transactions:
    1/12/2026: Deposit - $200.00
    1/12/2026: ATM Withdrawal - ($50.00)
    Are customers equal? True
    Original Account Number: 000123456789
    ```

## Task 3: Add a Bank class that manages accounts using generics

Generic collections like `Dictionary<TKey, TValue>` provide fast lookups and type safety.

In this task, you use `Dictionary<TKey, TValue>` to manage accounts with fast lookup and type safety.

Use the following steps to complete this task:

1. Open the `Bank.cs` file, and then locate the code comment that begins with **Task 3: Step 1**.

1. To create a new class named `Bank`, enter the following code:

    ```csharp
    public sealed class Bank
    {
        private readonly Dictionary<BankAccountNumber, BankAccount> _accounts = new();
    
        public void OpenAccount(BankAccount account)
        {
            if (account is null) throw new ArgumentNullException(nameof(account));
            _accounts.Add(account.AccountNumber, account);
        }
    
        public BankAccount GetAccount(BankAccountNumber number)
        {
            if (_accounts.TryGetValue(number, out var account))
                return account;
    
            throw new InvalidOperationException($"No account exists with number {number}.");
        }
    
        public bool TryGetAccount(BankAccountNumber number, out BankAccount account)
            => _accounts.TryGetValue(number, out account!);
    
        public bool CloseAccount(BankAccountNumber number)
            => _accounts.Remove(number);
    }
    ```

1. Review the generic field and methods in the `Bank` class.

    Notice the following line of code:

    ```csharp
    private readonly Dictionary<BankAccountNumber, BankAccount> _accounts = new();
    ```

    The 'generics' part of this line is the `Dictionary<BankAccountNumber, BankAccount>`.

    You may recall that `Dictionary<TKey, TValue>` is a generic .NET collection type. It takes two type parameters:
    - TKey = BankAccountNumber (the type you look up by)
    - TValue = BankAccount (the type you get back)

    So `_accounts` is a strongly-typed map: given a BankAccountNumber, you can store and retrieve a BankAccount.

    Why generics matter here:

    - Type safety at compile time: you can’t accidentally add a key/value of the wrong type (e.g., a string key or an int value).
    - No casting when reading: `_accounts[number]` (or TryGetValue) gives you a BankAccount directly—no (BankAccount) casts.
    - Performance: generic collections avoid boxing/unboxing for value types. Here, BankAccountNumber is a readonly struct, so using it as the key stays efficient.

1. Open the `Program.cs` file.

1. Locate the code comment that begins with **Task 3: Step 2**.

1. Update `Program.cs` to create a bank object and a second bank account, and then open the accounts using the bank object.

    Before (existing single-account creation):

    ```csharp
    AccountHolderDetails accountHolderDetails = new("Tim Shao", "123456789", "123 Elm Street");
    BankAccountNumber accountNumber = new BankAccountNumber("000012345678");
    BankAccount bankAccount = new(accountNumber, BankAccountType.Checking, accountHolderDetails, 500m);
    ```

    After (create two accounts and add them to the dictionary):

    ```csharp
    var bank = new Bank();

    var accountHolderDetails = new AccountHolderDetails("Tim Shao", "123456789", "123 Elm Street");
    var accountNumber = new BankAccountNumber("000012345678");
    var checking = new BankAccount(accountNumber, BankAccountType.Checking, accountHolderDetails, 500m);

    var accountHolderDetails3 = new AccountHolderDetails("Ni Kang", "987654321", "456 Oak Avenue");
    var accountNumber3 = new BankAccountNumber("000123456789");
    var savings = new BankAccount(accountNumber3, BankAccountType.Savings, accountHolderDetails3, 1200m);

    bank.OpenAccount(checking);
    bank.OpenAccount(savings);

    // Keep a reference named `bankAccount` for the reporting tasks later in this lab.
    var bankAccount = checking;
    ```

1. Locate the code comment that begins with **Task 3: Step 3**.

1. Add code that retrieves an account by account number and performs transactions.

    Add this below the code above:

    ```csharp
    var selected = bank.GetAccount(accountNumber3);
    selected.AddTransaction(321m, "Deposit");
    selected.AddTransaction(-123m, "ATM Withdrawal");
    Console.WriteLine(selected.DisplayAccountInfo());
    ```

1. Run the app, and then review the output to confirm that you can add/retrieve multiple accounts.

    Your output should be similar to the following:

    ```plaintext
    Welcome to the Bank App!
    Account Holder: Ni Kang, Account Number: 000123456789, Type: Savings, Balance: $1,350.00
    Account type description: A standard checking account.
    Account Holder: Tim Shao, Account Number: 000012345678, Type: Checking, Balance: $500.00
    Account Holder: Tim Shao, Account Number: 000012345678, Type: Checking, Balance: $650.00
    Transactions:
    1/12/2026: Deposit - $200.00
    1/12/2026: ATM Withdrawal - ($50.00)
    Are customers equal? True
    Original Account Number: 000123456789
    ```

## Task 4: Build a reusable generic Ledger\<TEntry\> with constraints

Generic constraints (`where TEntry : ILedgerEntry`) let you write generic code that still has meaningful guarantees.

In this task, you implement a generic class that can store different kinds of “ledger entries” safely.

Use the following steps to complete this task:

1. Open the Bank.cs file, and then locate the code comment that begins with **Task 4: Step 1**.

1. To define an interface named `ILedgerEntry`, enter the following code:

    ```csharp
    public interface ILedgerEntry
    {
        decimal Amount { get; }
        DateTime Date { get; }
        string Description { get; }
    }
    ```

1. Locate the code comment that begins with **Task 4: Step 2**.

1. Update the `Transaction` record to implement `ILedgerEntry`.

    Before:

    ```csharp
    public record Transaction(decimal Amount, DateTime Date, string Description)
    {
        public override string ToString()
        {
            return $"{Date.ToShortDateString()}: {Description} - {Amount:C}";
        }
    }
    ```

    After (no member changes required because the properties already match the interface):

    ```csharp
    public record Transaction(decimal Amount, DateTime Date, string Description) : ILedgerEntry
    {
        public override string ToString()
        {
            return $"{Date.ToShortDateString()}: {Description} - {Amount:C}";
        }
    }
    ```

1. Scroll to the bottom of the file.

1. Locate the code comment that begins with **Task 4: Step 3**.

1. Create a new generic class `Ledger<TEntry>` constrained to `ILedgerEntry`:

    ```csharp
    public sealed class Ledger<TEntry> where TEntry : ILedgerEntry
    {
        private readonly List<TEntry> _entries = new();
    
        public IReadOnlyList<TEntry> Entries => _entries;
    
        public void Add(TEntry entry)
        {
            if (entry is null) throw new ArgumentNullException(nameof(entry));
            _entries.Add(entry);
        }
    
        public decimal Total() => _entries.Sum(e => e.Amount);
    }
    ```

1. Take a minute to consider the class declaration code line that you just created.

    ```csharp
    public sealed class Ledger<TEntry> where TEntry : ILedgerEntry
    ```

    In this generic class declaration, `TEntry` can be any type that implements `ILedgerEntry`, ensuring type safety while allowing flexibility.

1. Scroll back up to locate the code comment that begins with **Task 4: Step 4**.

1. Refactor `BankAccount` to replace its transaction list with `Ledger<Transaction>`.

    Before (fields in `BankAccount`):

    ```csharp
   // Task 2: Step 1 - Replace the transactions collection with a private backing field.
    private readonly List<Transaction> _transactions = new();

    // Task 2: Step 2 - Expose transactions as a read-only generic view (IReadOnlyList<Transaction>).
    public IReadOnlyList<Transaction> Transactions => _transactions;
    ```

    After:

    ```csharp
    private readonly Ledger<Transaction> _ledger = new();
    public IReadOnlyList<Transaction> Transactions => _ledger.Entries;
    ```

1. Locate the code comment that begins with **Task 4: Step 5**.

1. Update `AddTransaction(...)` to call `ledger.Add(...)`.

    Before:

    ```csharp
    Balance += amount;

    // Task 2: Step 3 - Update AddTransaction to add to the backing field.
    _transactions.Add(new Transaction(amount, DateTime.Now, description));
    ```

    After:

    ```csharp
    Balance += amount;
    _ledger.Add(new Transaction(amount, DateTime.Now, description));
    ```

1. Locate the code comment that begins with **Task 4: Step 6**.

1. Take a minute to consider the code that iterates through Transactions.

    ```csharp
    foreach (var transaction in Transactions)
    {
        Console.WriteLine(transaction);
    }
    ```

    This code continues to work because `Transactions` now returns `_ledger.Entries`, which is an `IReadOnlyList<Transaction>`.

1. Locate the code comment that begins with **Task 4: Step 7**.

1. To create a second entry type named `Fee` that implements `ILedgerEntry`, enter the following code:

    ```csharp
    public record Fee(decimal Amount, DateTime Date, string Description) : ILedgerEntry;
    ```

1. Open Program.cs, and then locate the code comment that begins with **Task 4: Step 8**.

1. To demonstrate that `Ledger<Fee>` works without rewriting ledger logic, enter the following code:

    ```csharp
    var feeLedger = new Ledger<Fee>();
    feeLedger.Add(new Fee(-2.50m, DateTime.Now, "Monthly service fee"));
    Console.WriteLine($"Fee ledger total: {feeLedger.Total():C}");
    ```

1. Run the app, and then review the output to confirm the expected behavior.

    Your output should be similar to the following:

    ```plaintext
    Welcome to the Bank App!
    Account Holder: Ni Kang, Account Number: 000123456789, Type: Savings, Balance: $1,350.00
    Account type description: A standard checking account.
    Account Holder: Tim Shao, Account Number: 000012345678, Type: Checking, Balance: $500.00
    Account Holder: Tim Shao, Account Number: 000012345678, Type: Checking, Balance: $650.00
    Transactions:
    1/12/2026: Deposit - $200.00
    1/12/2026: ATM Withdrawal - ($50.00)
    Fee ledger total: ($2.50)
    Are customers equal? True
    Original Account Number: 000123456789
    ```

## Task 5: Create reports using anonymous types (LINQ projections)

Anonymous types are great for short-lived, local transformations (especially in LINQ queries).

In this task, you use anonymous types to produce report “rows” quickly without defining a new class.

Use the following steps to complete this task:

1. Open the `Program.cs` file, and then locate the code comment that begins with **Task 5: Step 1**.

1. To add a basic transaction report using a projection, enter the following code:

    ```csharp
    var rows = bankAccount.Transactions
        .Select(t => new
        {
            t.Date,
            t.Description,
            t.Amount,
            Kind = t.Amount >= 0 ? "Credit" : "Debit"
        });

    Console.WriteLine("Transaction report:");
    foreach (var row in rows)
    {
        Console.WriteLine($"{row.Date:d} | {row.Kind,-6} | {row.Amount,10:C} | {row.Description}");
    }
    ```

1. Locate the code comment that begins with **Task 5: Step 2**.

1. To build a "daily totals" report, enter the following code:

    ```csharp
    var dailyTotals = bankAccount.Transactions
        .GroupBy(t => DateOnly.FromDateTime(t.Date))
        .Select(g => new
        {
            Day = g.Key,
            Total = g.Sum(x => x.Amount),
            Count = g.Count()
        })
        .OrderBy(x => x.Day);

    Console.WriteLine("Daily totals:");
    foreach (var day in dailyTotals)
    {
        Console.WriteLine($"{day.Day}: {day.Total:C} ({day.Count} tx)");
    }
    ```

1. Locate the code comment that begins with **Task 5: Step 3**.

1. To add a "top 3 debits" report using `Where(t => t.Amount < 0)` and ordering.

    ```csharp
    var topDebits = bankAccount.Transactions
        .Where(t => t.Amount < 0)
        .OrderBy(t => t.Amount)
        .Take(3)
        .Select(t => new { t.Date, t.Description, t.Amount });
    
    Console.WriteLine("Top debits:");
    foreach (var d in topDebits)
    {
        Console.WriteLine($"{d.Date:d} | {d.Amount,10:C} | {d.Description}");
    }
    ```

1. Run the app, and then review the output to confirm the expected behavior.

    Your output should be similar to the following:

    ```plaintext
    Welcome to the Bank App!
    Account Holder: Ni Kang, Account Number: 000123456789, Type: Savings, Balance: $1,398.00
    Account type description: A standard checking account.
    Account Holder: Tim Shao, Account Number: 000012345678, Type: Checking, Balance: $500.00
    Account Holder: Tim Shao, Account Number: 000012345678, Type: Checking, Balance: $650.00
    Transactions:
    1/12/2026: Deposit - $200.00
    1/12/2026: ATM Withdrawal - ($50.00)
    Transaction report:
    1/12/2026 | Credit |    $200.00 | Deposit
    1/12/2026 | Debit  |   ($50.00) | ATM Withdrawal
    Daily totals:
    1/12/2026: $150.00 (2 tx)
    Top debits:
    1/12/2026 |   ($50.00) | ATM Withdrawal
    Fee ledger total: ($2.50)
    Are customers equal? True
    Original Account Number: 000123456789
    ```

## Task 6: Decide the boundary - anonymous types vs named result types

Anonymous types are not ideal for public APIs. You can introduce records/tuples for results that cross method/file boundaries.

In this task, you use anonymous types for local shaping and records/tuples for results that cross method/file boundaries.

Use the following steps to complete this task:

1. Open the Bank.cs file.

1. Locate the code comment that begins with **Task 6: Step 1**.

1. Create a named record for the report result, for example:

    Add this record (in `Bank.cs` or a new file):

    ```csharp
    public record DailyTotal(DateOnly Day, decimal Total, int Count);
    ```

1. Locate the code comment that begins with **Task 6: Step 2**.

1. To create a daily totals method that returns `IEnumerable<DailyTotal>`, enter the following code:

    Add a method to `BankAccount` (or `Bank`) like:

    ```csharp
    public IEnumerable<DailyTotal> GetDailyTotals()
    {
        return Transactions
            .GroupBy(t => DateOnly.FromDateTime(t.Date))
            .Select(g => new DailyTotal(g.Key, g.Sum(x => x.Amount), g.Count()))
            .OrderBy(x => x.Day);
    }
    ```

1. Open the Program.cs file.

1. Locate the code comment that begins with **Task 6: Step 3**.

1. Update call sites in `Program.cs` to consume the named record.

    Before (anonymous type usage):

    ```csharp
    // Task 5: Step 2 - Add an anonymous-type daily totals report (GroupBy(...) + Select(...)).
    var dailyTotals = bankAccount.Transactions
        .GroupBy(t => DateOnly.FromDateTime(t.Date))
        .Select(g => new
        {
            Day = g.Key,
            Total = g.Sum(x => x.Amount),
            Count = g.Count()
        })
        .OrderBy(x => x.Day);

    Console.WriteLine("Daily totals:");
    foreach (var day in dailyTotals)
    {
        Console.WriteLine($"{day.Day}: {day.Total:C} ({day.Count} tx)");
    }
    ```

    After:

    ```csharp
    Console.WriteLine("Daily totals:");
    foreach (var day in bankAccount.GetDailyTotals())
    {
        Console.WriteLine($"{day.Day}: {day.Total:C} ({day.Count} tx)");
    }
    ```

1. Run the app, and then review the output to confirm the expected behavior.

    Your output should be similar to the following:

    ```plaintext
    Welcome to the Bank App!
    Account Holder: Ni Kang, Account Number: 000123456789, Type: Savings, Balance: $1,398.00
    Account type description: A standard checking account.
    Account Holder: Tim Shao, Account Number: 000012345678, Type: Checking, Balance: $500.00
    Account Holder: Tim Shao, Account Number: 000012345678, Type: Checking, Balance: $650.00
    Transactions:
    1/12/2026: Deposit - $200.00
    1/12/2026: ATM Withdrawal - ($50.00)
    Transaction report:
    1/12/2026 | Credit |    $200.00 | Deposit
    1/12/2026 | Debit  |   ($50.00) | ATM Withdrawal
    Daily totals:
    1/12/2026: $150.00 (2 tx)
    Top debits:
    1/12/2026 |   ($50.00) | ATM Withdrawal
    Fee ledger total: ($2.50)
    Are customers equal? True
    Original Account Number: 000123456789
    ```

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Additionally, building a portfolio of projects can be a great way to demonstrate your skills to potential employers.
