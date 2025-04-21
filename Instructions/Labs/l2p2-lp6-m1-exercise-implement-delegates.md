---
lab:
    title: 'Exercise - Implement delegates in a C# app'
    description: 'Learn how to declare, instantiate, and invoke delegates for scenarios that require dynamic method invocation. Learn how to implement sorting and callback and sorting scenarios using custom delegates, and then replace the custom delegates with strongly typed delegates that provide the same functionality.'
---

# Implement delegates in a C# app

Delegates enable developers to encapsulate methods and pass them as parameters, allowing for flexible and extensible code design. Delegates are useful when implementing callback methods, custom sorting or filtering, multicast, and other real-world scenarios.

> [!NOTE]
> Delegates are also used in event handling, where you can define a delegate type that represents the signature of the event handler methods. The event-handling scenario is covered separately.

In this exercise, you declare, instantiate, and invoke delegates that implement callback and sorting scenarios. You will implement custom delegates to perform callback sorting scenarios, and then replace the custom delegates with strongly-typed `Action` and `Func` delegates that reduce code complexity and improve readability.

This exercise takes approximately **20** minutes to complete.

## Before you start

Before you can start this exercise, you need to:

1. Ensure that you have the latest short term support (STS) version of the .NET SDK installed on your computer. You can download the latest versions of the .NET SDK using the following URL: <a href="https://dotnet.microsoft.com/download/" target="_blank">Download .NET</a>

1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code using the following URL: <a href="https://code.visualstudio.com/download/" target="_blank">Download Visual Studio Code</a>

1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For additional help configuring the Visual Studio Code environment, see <a href="https://learn.microsoft.com/training/modules/install-configure-visual-studio-code/" target="_blank">Install and configure Visual Studio Code for C# development</a>

## Exercise scenario

Suppose you've agreed to help a non-profit company with a software project. Before the project kicks off, you decide to update your object-oriented programming skills by developing a banking app. The current version of your app supports basic operations such as creating accounts, depositing and withdrawing money, and transferring funds between accounts. To practice working with delegates, you're going implement delegates in the `BankAccount` and `Bank` classes. You plan to start by implementing custom delegates and then transition to using strongly-typed delegates.

This exercise includes the following tasks:

1. Review the current version of your banking app.

1. Implement a custom delegate that performs callback tasks adding transactions to an account.

1. Implement a custom delegate that returns a list of sorted customers.

1. Replace custom delegates with strongly-typed `Action` and `Func` delegates.

## Review the current version of your banking app

In this task, you download the existing version of your banking app and review the code.

Use the following steps to complete this section of the exercise:

1. Download the starter code from the following URL: [Access local files asynchronously - exercise code projects](https://github.com/MicrosoftLearning/mslearn-develop-oop-csharp/raw/refs/heads/main/DownloadableCodeProjects/Downloads/LP6SampleApps.zip)

1. Extract the contents of the LP5SampleApps.zip file to a folder location on your computer.

    For example, if your running Windows, you can extract the file contents to your Desktop folder.

1. Expand the LP6SampleApps folder, and then open the `Delegates` folder.

    The Delegates folder contains the following code project folders:

    - Solution
    - Starter

    The **Starter** folder contains the starter project files for this exercise.

1. Use Visual Studio Code to open the **Starter** folder.

1. In the EXPLORER view, collapse the **STARTER** folder, select **SOLUTION EXPLORER**, and expand the **Delegates** project folders.

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
        - ApprovedCustomerLoaderAsync.cs
        - BankAccountDTO.cs
        - BankCustomerDTO.cs
        - CustomerReportGenerator.cs
        - Extensions.cs
        - JsonRetrievalAsync.cs
        - JsonStorageAsync.cs
        - LoadCustomerLogsAsync.cs
        - SimulateDepositsWithdrawalsTransfers.cs
    - Program.cs

1. Take a few minutes to open and review each of the following files:

    - `Bank.cs`: This file defines the Bank class, which implements a collection of bank customers and provides methods that manage customers and retrieve bank information.

    - `BankAccount.cs`: This file defines the BankAccount class, which implements the IBankAccount interface and includes properties, constructors, and methods for account operations.

    - `BankCustomer.cs`: This file defines the BankCustomer partial class, which implements the IBankCustomer interface and includes properties and constructors for customer constructor.

    - `CreateDataLogsAsync.cs`: This file includes a method that uses `ApprovedCustomerLoaderAsync` and `SimulateDepositsWithdrawalsTransfers` to generate two years of transactions for 50 bank customers,and then stores the data as JSON files using `JsonStorageAsync`.

    - `SimulateDepositsWithdrawalsTransfers.cs`: This file includes methods that simulate deposits, withdrawals, and transfers for bank accounts.

    - `Program.cs`: This file includes the main entry point for the app. Program.cs uses `CreateDataLogsAsync` to create two years of transaction data for 50 customers, and then uses `LoadCustomerLogsAsync` to load the customer data into a `bank` object.

    Notice that a bank object includes a collection of bank customer objects, and that each bank customer object includes a collection of bank account objects for that customer. The account objects include a collection of transactions, which provide a record of the deposits, withdrawals, and transfers associated with the account. The SimulateDepositsWithdrawalsTransfers class is used simulate customer account activity by generating transactions for each account. The app is able to store and retrieve customer and account information.

1. Run the app and review the output in the terminal window.

    To run your app, right-click the **Delegates** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    Your app should produce output that's similar to the following example:

    ```plaintext

    Created BankCustomer: Elize Harmsen
    Created BankCustomer: Mattia Trentini
    Created BankCustomer: Peter Zammit
    Created BankCustomer: Lennart Kangur
    Created BankCustomer: Erik Valjas
    Created BankCustomer: Nedelya Grigorova
    Created BankCustomer: Anette Thomsen
    Created BankCustomer: Kasper Frisk
    Created BankCustomer: Niki Demetriou
    Created BankCustomer: Janez Horvat
    Created BankCustomer: Petros Doudis
    Created BankCustomer: Ivan Krajnc
    Created BankCustomer: Cao Huy
    Created BankCustomer: Phung Hang
    Created BankCustomer: Gil Gabbai
    Created BankCustomer: Maya Meyerson
    Created BankCustomer: Suttida Bunyasarn
    Created BankCustomer: Akkarat Leelapun
    Created BankCustomer: Julia Linares
    Created BankCustomer: Larissa Sevilla
    Created BankCustomer: Renata Amaya
    Created BankCustomer: Federico Tercedor
    Created BankCustomer: Sergio Valladares
    Created BankCustomer: Tatiana Seleznyova
    Created BankCustomer: Vitaly Toporov
    Created BankCustomer: Chingfan Chou
    Created BankCustomer: Lai Chou
    Created BankCustomer: Ethan Brooks
    Created BankCustomer: Hannah Haynes
    Created BankCustomer: Staffan Bergqvist
    Created BankCustomer: Anna Hedlund
    Created BankCustomer: Afshin Behzadi
    Created BankCustomer: Elaheh Mansouri
    Created BankCustomer: Rayna Bacheva
    Created BankCustomer: Milena Stoichkova
    Created BankCustomer: Rayko Dimitrov
    Created BankCustomer: Saki Yoshida
    Created BankCustomer: Jun Uchida
    Created BankCustomer: Hannah Weber
    Created BankCustomer: Conrad Nuber
    Created BankCustomer: Erna Nilsson
    Created BankCustomer: Viktor Magnusson
    Created BankCustomer: Genevieve Arcouet
    Created BankCustomer: Alain Davignon
    Created BankCustomer: Danielle Brasseur
    Created BankCustomer: Claude Aupry
    Created BankCustomer: Chung-Ae Ryang
    Created BankCustomer: Bong-Jin Lee
    Created BankCustomer: Faruk Keskin
    Created BankCustomer: Yasemin Ozkan
    
    Bank information...
    Number of customers: 50
    Number of accounts: 150
    Number of transactions: 24443
    
    ```

    The output shows the names of the 50 customer objects that were created. Each customer has three account types: Checking, Savings, and MoneyMarket. Transactions are generated at a rate of about 20 per month, so each customer has about 480 transactions spread across two years. The transactions are mostly associated with the checking accounts. Transactions include deposits, withdrawals, transfers, and bank refunds.

## Implement a custom delegate that performs callback tasks adding transactions to an account

Delegates can be used to implement callback methods that run when an asynchronous operation completes. In this task, you implement a custom delegate that performs callback tasks after adding transactions to an account. A callback delegate can be used to log transactions or perform additional actions.

Use the following steps to complete this section of the exercise:

1. Open the BankAccount.cs file and then scroll to the top of the file.

1. To add the delegate definition above the BankAccount class, update the code as follows:

    ```csharp
    
    namespace Delegates;
    
    public delegate void TransactionProcessedCallback(Transaction transaction);
    
    // Method to add a transaction to the account
    public class BankAccount : IBankAccount
    
    ```

1. Scroll down to find the `AddTransaction` method in the BankAccount class.

1. To include the delegate as a parameter of the `AddTransaction` method, update the `AddTransaction` method:

    ```csharp
    
    public void AddTransaction(Transaction transaction, TransactionProcessedCallback? callback = null)
    {
        _transactions.Add(transaction);
        callback?.Invoke(transaction); // Invoke the callback if provided
    }
    
    ```

1. Scroll up to find the `Deposit` method.

1. To invoke the delegate when an account transfer transaction is detected, update the `Deposit` method:

    ```csharp
    
    public virtual void Deposit(double amount, DateOnly transactionDate, TimeOnly transactionTime, string description)
    {
        if (amount > 0)
        {
            priorBalance = Balance;
            Balance += amount;
            string transactionType = "Deposit";
            if (description.Contains("-(TRANSFER)"))
            {
                transactionType = "Transfer";
                AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, amount, AccountNumber, AccountNumber, transactionType, description));
            }
            else if (description.Contains("-(BANK REFUND)"))
            {
                transactionType = "Bank Refund";
                AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, amount, AccountNumber, AccountNumber, transactionType, description), transaction =>
                {
                    Console.WriteLine($"Log the refund to customer {Owner.ReturnFullName()} for account {AccountNumber}.");
                });
            }
            else
            {
                transactionType = "Deposit";
                AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, amount, AccountNumber, AccountNumber, transactionType, description));
            }
        }
    }
    
    ```

1. Open the IBankAccount.cs file and then scroll to the top of the file.

1. To include the delegate as a parameter of the `AddTransaction` method, update the IBankAccount interface:

    ```csharp
    
    void AddTransaction(Transaction transaction, TransactionProcessedCallback? transactionProcessedCallback = null);
    
    ```

1. Run the app and notice the message generated by the delegate.

    When the app detects a bank refund transaction, a message is written to the console. Messages should appear similar to the following output

    ```plaintext

    Log the refund to customer Yasemin Ozkan for account 13442121.
    
    ```

## Implement a custom delegate that returns a list of sorted customers

Use a delegate to sort customers based on different criteria, such as name, total balance, or number of accounts.

Use the following steps:

1. Open the Bank.cs file and then scroll to the top of the file.

1. Add the delegate definition above the Bank class:

    ```csharp

    public delegate int CustomerComparison(BankCustomer x, BankCustomer y);

    ```

1. Add a method in the Bank class that accepts a delegate for sorting:

    ```csharp

    public IEnumerable<BankCustomer> GetSortedCustomers(CustomerComparison comparison)
    {
        var sortedCustomers = _customers.ToList();
        sortedCustomers.Sort((x, y) => comparison(x, y));
        return sortedCustomers;
    }

    ```

    The `GetSortedCustomers` method is a public method in the `Bank` class that provides a way to retrieve a sorted list of bank customers based on a custom sorting logic. This method is highly flexible because it uses a delegate, `CustomerComparison`, to define the sorting criteria.

    Key Details:

    1. Delegate Parameter (CustomerComparison): The method takes a parameter of type CustomerComparison, which is a delegate defined as:

        ```csharp
    
        public delegate int CustomerComparison(BankCustomer x, BankCustomer y);
    
        ```

        This delegate represents a method that compares two BankCustomer objects and returns an integer:

        - A negative value if x should come before y.
        - Zero if x and y are considered equal.
        - A positive value if x should come after y.

        By passing a custom comparison function, the caller can define how customers should be sorted (e.g., by name, account balance, or customer ID).

    1. Sorting Logic: Inside the method, the _customers list (a private field containing all customers of the bank) is first converted to a new List<BankCustomer> using ToList(). This ensures that the original list is not modified. The Sort method is then called on this new list, using a lambda function:

    Here, the comparison delegate is invoked for each pair of customers to determine their relative order.

    Return Value: The method returns the sorted list as an IEnumerable<BankCustomer>. By returning an IEnumerable, the method provides a read-only view of the sorted customers, ensuring that the caller cannot modify the internal state of the bank's customer list.

    Example Usage:
    Suppose you want to sort customers by their last name in ascending order. You could call the method like this:

    This lambda function compares the LastName properties of two BankCustomer objects, ignoring case.

    Benefits:
    Flexibility: The use of a delegate allows the sorting logic to be defined at runtime, making the method adaptable to various use cases.
    Encapsulation: The method does not expose the internal _customers list directly, preserving the integrity of the bank's data.
    Reusability: The same method can be reused for different sorting criteria without requiring changes to the Bank class.
    This design demonstrates a clean and extensible approach to implementing custom sorting in C#.

1. Open the Program.cs file and then scroll to the bottom of the file.

1. To sort customers by total balance, enter the following code:

    ```csharp

    var sortedCustomers = bank.GetSortedCustomers((x, y) =>
    {
        double balanceX = x.Accounts.Sum(a => a.Balance);
        double balanceY = y.Accounts.Sum(a => a.Balance);
        return balanceY.CompareTo(balanceX); // Descending order
    });
    
    Console.WriteLine("\nCustomers sorted by total balance:");
    foreach (var customer in sortedCustomers)
    {
        Console.WriteLine($"{customer.ReturnFullName()} - Total Balance: {customer.Accounts.Sum(a => a.Balance):C}");
    }

    ```

    This code implements a delegate to sort the customers by their total balance in descending order. The `GetSortedCustomers` method is called with a lambda expression that compares the total balances of two customers. The `Sum` method is used to calculate the total balance of each customer by summing the balances of all their accounts.

1. Run the app and review the output.

    Notice that the customers are sorted by total balance in descending order. The output should be similar to the following:

    ```plaintext

    Customers sorted by total balance:
    Alain Davignon - Total Balance: $109,928.85
    Claude Aupry - Total Balance: $109,917.25
    Lai Chou - Total Balance: $109,708.80
    Erik Valjas - Total Balance: $109,409.10
    Federico Tercedor - Total Balance: $109,239.10
    Lennart Kangur - Total Balance: $109,067.05
    Chung-Ae Ryang - Total Balance: $108,905.75
    Saki Yoshida - Total Balance: $108,738.45
    Jun Uchida - Total Balance: $108,337.95
    Hannah Weber - Total Balance: $108,280.95
    Janez Horvat - Total Balance: $108,233.90
    Nedelya Grigorova - Total Balance: $108,109.75
    Renata Amaya - Total Balance: $108,090.30
    Erna Nilsson - Total Balance: $108,020.80
    Ivan Krajnc - Total Balance: $107,776.80
    Rayko Dimitrov - Total Balance: $107,596.80
    Gil Gabbai - Total Balance: $107,575.05
    Vitaly Toporov - Total Balance: $107,574.30
    Anette Thomsen - Total Balance: $107,534.80
    Petros Doudis - Total Balance: $107,504.35
    Cao Huy - Total Balance: $107,086.30
    Viktor Magnusson - Total Balance: $107,084.25
    Akkarat Leelapun - Total Balance: $107,033.95
    Julia Linares - Total Balance: $106,915.15
    Sergio Valladares - Total Balance: $106,877.90
    Bong-Jin Lee - Total Balance: $106,361.80
    Genevieve Arcouet - Total Balance: $105,963.80
    Peter Zammit - Total Balance: $105,602.05
    Tatiana Seleznyova - Total Balance: $105,384.35
    Staffan Bergqvist - Total Balance: $105,377.60
    Milena Stoichkova - Total Balance: $105,329.45
    Kasper Frisk - Total Balance: $104,989.60
    Conrad Nuber - Total Balance: $104,921.25
    Hannah Haynes - Total Balance: $104,772.90
    Larissa Sevilla - Total Balance: $104,663.00
    Yasemin Ozkan - Total Balance: $104,586.05
    Niki Demetriou - Total Balance: $104,568.30
    Rayna Bacheva - Total Balance: $104,547.65
    Anna Hedlund - Total Balance: $104,468.70
    Elize Harmsen - Total Balance: $104,389.50
    Phung Hang - Total Balance: $104,361.50
    Chingfan Chou - Total Balance: $104,317.05
    Suttida Bunyasarn - Total Balance: $104,303.30
    Danielle Brasseur - Total Balance: $104,210.35
    Faruk Keskin - Total Balance: $104,204.05
    Mattia Trentini - Total Balance: $103,792.85
    Elaheh Mansouri - Total Balance: $103,348.25
    Maya Meyerson - Total Balance: $102,771.45
    Afshin Behzadi - Total Balance: $101,767.81
    Ethan Brooks - Total Balance: $101,747.83

    ```

> [!NOTE]
> Transactions are generated using random values. The final account balances, and the order of customers may vary each time you run the app.

1. To demonstrate using the delegate to sort by name rather than by balance, add the following code:

    ```csharp

    // Implement customer sorting using a delegate - sort by name
    var sortedCustomersByName = bank.GetSortedCustomers((x, y) =>
    {
        int lastNameComparison = x.LastName.CompareTo(y.LastName);
        return lastNameComparison != 0 ? lastNameComparison : x.FirstName.CompareTo(y.FirstName);
    });
    Console.WriteLine("\nCustomers sorted by name:");
    foreach (var customer in sortedCustomersByName)
    {
        Console.WriteLine($"{customer.ReturnFullName()} - Total Balance: {customer.Accounts.Sum(a => a.Balance):C}");
    }

    ```

    The `GetSortedCustomers` method is called with a lambda expression that compares the last names of two customers. If the last names are equal, it compares their first names.

1. Run the app again and review the output.

    The output should be similar to the following:

    ```plaintext

    Customers sorted by name:
    Renata Amaya - Total Balance: $104,161.75
    Genevieve Arcouet - Total Balance: $107,817.70
    Claude Aupry - Total Balance: $104,561.80
    Rayna Bacheva - Total Balance: $106,844.55
    Afshin Behzadi - Total Balance: $107,733.35
    Staffan Bergqvist - Total Balance: $112,054.30
    Danielle Brasseur - Total Balance: $105,372.15
    Ethan Brooks - Total Balance: $106,370.20
    Suttida Bunyasarn - Total Balance: $104,686.85
    Chingfan Chou - Total Balance: $110,066.55
    Lai Chou - Total Balance: $104,684.60
    Alain Davignon - Total Balance: $106,617.25
    Niki Demetriou - Total Balance: $108,372.00
    Rayko Dimitrov - Total Balance: $106,111.00
    Petros Doudis - Total Balance: $109,319.60
    Kasper Frisk - Total Balance: $102,522.64
    Gil Gabbai - Total Balance: $105,666.80
    Nedelya Grigorova - Total Balance: $105,069.53
    Phung Hang - Total Balance: $106,703.80
    Elize Harmsen - Total Balance: $103,568.45
    Hannah Haynes - Total Balance: $104,919.85
    Anna Hedlund - Total Balance: $107,872.15
    Janez Horvat - Total Balance: $107,503.70
    Cao Huy - Total Balance: $107,509.45
    Lennart Kangur - Total Balance: $106,434.10
    Faruk Keskin - Total Balance: $104,437.95
    Ivan Krajnc - Total Balance: $108,758.45
    Bong-Jin Lee - Total Balance: $110,643.15
    Akkarat Leelapun - Total Balance: $107,467.15
    Julia Linares - Total Balance: $102,406.51
    Viktor Magnusson - Total Balance: $103,692.40
    Elaheh Mansouri - Total Balance: $106,574.80
    Maya Meyerson - Total Balance: $108,886.50
    Erna Nilsson - Total Balance: $109,602.60
    Conrad Nuber - Total Balance: $107,762.90
    Yasemin Ozkan - Total Balance: $106,746.00
    Chung-Ae Ryang - Total Balance: $108,359.15
    Tatiana Seleznyova - Total Balance: $104,880.40
    Larissa Sevilla - Total Balance: $105,553.50
    Milena Stoichkova - Total Balance: $102,018.35
    Federico Tercedor - Total Balance: $103,352.75
    Anette Thomsen - Total Balance: $106,407.60
    Vitaly Toporov - Total Balance: $106,902.75
    Mattia Trentini - Total Balance: $103,996.90
    Jun Uchida - Total Balance: $107,365.45
    Erik Valjas - Total Balance: $102,204.37
    Sergio Valladares - Total Balance: $104,866.35
    Hannah Weber - Total Balance: $109,530.50
    Saki Yoshida - Total Balance: $105,007.05
    Peter Zammit - Total Balance: $109,858.80

    ```

The `GetSortedCustomers` method is a public method in the `Bank` class that provides a way to retrieve a sorted list of bank customers based on a custom sorting logic. This method is highly flexible because it uses a delegate, `CustomerComparison`, to define the sorting criteria.

## Replace custom delegates with strongly-typed `Action` and `Func` delegates

In C#, strongly-typed delegates like `Action` and `Func` provide a way to define and use delegates without explicitly declaring custom delegate types. These are part of the `System` namespace and are commonly used for scenarios involving callbacks, event handling, or passing methods as parameters.

In this task, you will replace custom delegate types with strongly-typed delegates in the BankAccount and Bank classes.

1. Open the BankAccount.cs file and then scroll to the top of the file.

1. Comment out the custom delegate definition:

    ```csharp

    // public delegate void TransactionProcessedCallback(Transaction transaction);

    ```

1. Scroll down to find the `AddTransaction` method in the BankAccount class.

1. To replace the custom delegate with `Action<Transaction>`, update the method using the following code:

    ```csharp

    // public void AddTransaction(Transaction transaction, TransactionProcessedCallback? callback = null)
    // {
    //     _transactions.Add(transaction);
    //     callback?.Invoke(transaction); // Invoke the callback if provided
    // }

    public void AddTransaction(Transaction transaction, Action<Transaction>? callback = null)
    {
        _transactions.Add(transaction);
        callback?.Invoke(transaction); // Invoke the callback if provided
    }

    ```

1. Open the IBankAccount.cs file and then scroll to the top of the file.

1. To replace the custom delegate with `Action<Transaction>`, update the IBankAccount interface:

    ```csharp

    void AddTransaction(Transaction transaction, Action<Transaction>? transactionProcessedCallback = null);

    ```

1. Open the Bank.cs file.

    You can replace the `CustomerComparison` delegate with `Func<BankCustomer, BankCustomer, int>`, which is a strongly-typed delegate that takes two `BankCustomer` objects and returns an integer.

1. Scroll to the top of the file and then comment out the custom delegate definition:

    ```csharp

    // public delegate int CustomerComparison(BankCustomer x, BankCustomer y);

    ```

1. Scroll down to find the `GetSortedCustomers` method in the Bank class.

1. To replace the custom delegate with `Func<BankCustomer, BankCustomer, int>`, update the method using the following code:

    ```csharp

    // public IEnumerable<BankCustomer> GetSortedCustomers(CustomerComparison comparison)
    // {
    //     var sortedCustomers = _customers.ToList();
    //     sortedCustomers.Sort((x, y) => comparison(x, y));
    //     return sortedCustomers;
    // }

    public IEnumerable<BankCustomer> GetSortedCustomers(Func<BankCustomer, BankCustomer, int> comparison)
    {
        var sortedCustomers = _customers.ToList();
        sortedCustomers.Sort((x, y) => comparison(x, y));
        return sortedCustomers;
    }

    ```

1. Run the app and review the output.

    Notice that the app still works as expected. The strongly-typed delegates `Action` and `Func` are used instead of custom delegate types.
