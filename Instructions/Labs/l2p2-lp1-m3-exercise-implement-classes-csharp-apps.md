---
lab:
    title: 'Exercise - Manage class implementations'
    description: 'Learn how to improve code quality by creating static and partial classes, using optional parameters in constructors, and by implementing copy constructors and object initializers in your applications.'
---


# Manage class implementations

The term code quality refers to the overall readability, maintainability, efficiency, reusability, reliability, and testability of your code. By improving code quality, you can make your code easier to understand, manage, and extend. Object-oriented programming (OOP) provides several features that can help you improve code quality, such as static and partial classes, nested classes, optional and named parameters, copy constructors, and object initializers. These features can help you organize your code more effectively, reduce redundancy, and make your code more flexible and concise.

In this exercise, you improve an existing application's code quality by implementing static and partial classes, and by using optional parameters in class constructors. You also improve object management in your application code by implementing copy constructors and object initializers.

This exercise takes approximately **30** minutes to complete.

## Before you start

Before you can start this exercise, you need to:

1. Ensure that you have the latest short term support (STS) version of the .NET SDK installed on your computer. You can download the latest versions of the .NET SDK using the following URL: <a href="https://dotnet.microsoft.com/download/" target="_blank">Download .NET</a>
1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code using the following URL: <a href="https://code.visualstudio.com/download/" target="_blank">Download Visual Studio Code</a>
1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For additional help configuring the Visual Studio Code environment, see <a href="https://learn.microsoft.com/training/modules/install-configure-visual-studio-code/" target="_blank">Install and configure Visual Studio Code for C# development</a>

## Exercise scenario

Suppose you're helping a non-profit company with a software project. You've decided to sharpen your object-oriented programming skills by creating a simple banking app. You've developed an initial version of the app that includes the following files:

- BankAccount.cs: The BankAccount class represents a bank account with properties for account number, customer ID, balance, and account type. It includes methods for depositing, withdrawing, transferring funds, applying interest, and displaying account information. It also maintains static properties for the next account number and interest rate.
- BankCustomer.cs: The BankCustomer class represents a bank customer with properties for first name, last name, and a unique customer ID. It includes methods to return the full name, update the customer's name, and display customer information. It also maintains a static property for the next customer ID.
- Extensions.cs: The Extensions.cs file contains extension methods for the BankCustomer and BankAccount classes. For BankCustomer, it includes methods to check if the customer ID is valid and to greet the customer. For BankAccount, it includes methods to check if the account is overdrawn and if a specified amount can be withdrawn.
- Program.cs: The Program.cs file demonstrates the creation and manipulation of BankCustomer and BankAccount objects. It includes steps to create customers and accounts, update customer names, and use various methods of the BankAccount class such as deposit, withdraw, transfer, and apply interest. It also demonstrates the use of extension methods and displays customer and account information.

This exercise includes the following tasks:

1. Review the current version of your banking app
1. Split the BankCustomer class into two partial class files
1. Create a static class for transactional BankAccount methods
1. Use optional parameters to improve constructor flexibility
1. Implement object initializers and copy constructors

## Review the current version of your banking app

In this task, you download the existing version of your banking app and review the code.

Use the following steps to complete this section of the exercise:

1. Download the starter code from the following URL: [Implement classes, properties, and methods - exercise code projects](https://github.com/MicrosoftLearning/mslearn-develop-oop-csharp/raw/refs/heads/main/DownloadableCodeProjects/Downloads/LP1SampleApps.zip)

1. Extract the contents of the LP1SampleApps.zip file to a folder location on your computer.

1. Expand the LP1SampleApps folder, and then open the `Classes_M3` folder.

    The Classes_M3 folder contains the following code project folders:

    - Solution
    - Starter

    The **Starter** folder contains the starter project files for this exercise.

1. Use Visual Studio Code to open the **Starter** folder.

1. In the EXPLORER view, collapse the **STARTER** folder, select **SOLUTION EXPLORER**, and expand the **Classes_M3** project.

    You should see the following project files:

    - BankAccount.cs
    - BankCustomer.cs
    - Extensions.cs
    - Program.cs

1. Open the BankAccount.cs file and take a minute to review the BankAccount class.

    The `BankAccount` class represents a bank account with properties and methods to manage account operations.

    Notice that the class includes static fields `s_nextAccountNumber` and `InterestRate`, which track the next account number and the interest rate applied to accounts, respectively. In addition to the static fields, the `BankAccount` class defines the following properties: `AccountNumber`, `CustomerId`, `Balance`, and `AccountType`. The class also includes constructors for initializing accounts with or without an initial balance and account type. Methods provided by the class include `Deposit` for adding funds, `Withdraw` for removing funds, `Transfer` for transferring funds between accounts, `ApplyInterest` for applying interest to the balance, and `DisplayAccountInfo` for displaying account details. The class also features a static constructor to initialize static fields.

    The `this` keyword is used to access the properties of the current class instance. For example, `this.AccountNumber` refers to the `AccountNumber` property of the current `BankAccount` instance.

1. Open the BankCustomer.cs file and take a minute to review the BankCustomer class.

    The BankCustomer class represents a bank customer with properties and methods to manage customer information.

    Notice that the class includes a static field `nextCustomerId` to track the next customer ID, and private backing fields `_firstName` and `_lastName` for storing the customer's first and last names, respectively. Each `BankCustomer` instance has a read-only `CustomerId` property, which is initialized using a static constructor that generates a random starting ID. The class provides properties `FirstName` and `LastName` for accessing and modifying the customer's name. Methods in the class include `ReturnFullName` to return the customer's full name, `UpdateName` to update the customer's name, and `DisplayCustomerInfo` to display customer details. The class also features a constructor for initializing a new customer with a first and last name.

1. Open the Extensions.cs file and take a minute to review the BankCustomerExtensions and BankAccountExtensions classes.

    The Extensions.cs file contains extension methods for the `BankCustomer` and `BankAccount` classes within the `Classes_M3` namespace. These extension methods enhance the functionality of the `BankCustomer` and `BankAccount` classes by adding useful operations without modifying the original class definitions.

    The `BankCustomerExtensions` static class provides a `IsValidCustomerId` method that validates a customer's ID (ensuring that it's 10 characters long) and a `GreetCustomer` method that returns a personalized greeting using the customer's full name.

    The `BankAccountExtensions` static class includes an `IsOverdrawn` methods that checks if an account is overdrawn (returning `true` if the balance is negative) and a `CanWithdraw` method that's used to verify whether a specified amount can be withdrawn from the account (ensuring the balance is sufficient for the withdrawal).

1. Open the Program.cs file and take a minute to review the demonstration code.

    The Program.cs file demonstrates the creation and manipulation of `BankCustomer` and `BankAccount` objects within the `Classes_M3` namespace.

    Top-level statements provide an implicit entry point for the app. The code instantiates `BankCustomer` objects with different names, followed by the creation of corresponding `BankAccount` objects with varying initial balances. The program showcases the use of properties and methods of these classes, such as updating customer names, depositing and withdrawing funds, transferring money between accounts, and applying interest. Additionally, it demonstrates the use of extension methods to greet customers, validate customer IDs, check if accounts are overdrawn, and verify if withdrawals can be made. Finally, the program displays customer and account information to the console.

1. Run the app and review the output in the terminal window.

    To run your app, right-click the **Classes_M3** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    Your app should produce output that's similar to the following example:

    ```plaintext

    Creating BankCustomer objects...
    BankCustomer 1: Tim Shao 0012396421
    BankCustomer 2: Lisa Shao 0012396422
    BankCustomer 3: Sandy Zoeng 0012396423
    
    Creating BankAccount objects for customers...
    Account 1: Account # 11657161, type Checking, balance 0, rate 0, customer ID 0012396421
    Account 2: Account # 11657162, type Checking, balance 1500, rate 0, customer ID 0012396422
    Account 3: Account # 11657163, type Checking, balance 2500, rate 0, customer ID 0012396423
    
    Updating BankCustomer 1's name...
    Updated BankCustomer 1: Thomas Margand 0012396421
    
    Demonstrating BankAccount methods...
    Depositing 500 into Account 1...
    Account 1 after deposit: Balance = 500
    Withdrawing 200 from Account 2...
    Account 2 after withdrawal: Balance = 1300, Withdrawal successful: True
    Transferring 300 from Account 3 to Account 1...
    Account 3 after transfer: Balance = 2200, Transfer successful: True
    Account 1 after receiving transfer: Balance = 800
    Applying interest to Account 1...
    Account 1 after applying interest: Balance = 800
    
    Demonstrating extension methods...
    Hello, Thomas Margand!
    Is customer1 ID valid? True
    Can account2 withdraw 2000? False
    Is account3 overdrawn? False
    
    Displaying customer and account information...
    Customer ID: 0012396421, Name: Thomas Margand
    Account Number: 11657161, Type: Checking, Balance: 800, Interest Rate: 0, Customer ID: 0012396421

    ```

    The customer IDs and account numbers in your output will be different from the example output. Remember that they're sequential values based on a randomly generated initial value.

## Split the BankCustomer class into two partial class files

Partial classes allow you to split the definition of a class across multiple files. This can be useful when a class has a large number of properties and methods, or when you want to separate the definition of a class into logical sections. Splitting a class between two partial class files can make your code easier to read and maintain. For example, if the methods of a class are logically grouped into different categories, you can place each group of methods in a separate partial class file. This enables a team of developers to work on different parts of a class without interfering with each other's work. By using partial classes, you can organize your code more effectively and improve the readability and maintainability of your code.

In this task, you split the BankCustomer class between two partial class files, moving the methods into a separate file.

Use the following steps to complete this section of the exercise:

1. Create a new class file for a class named **BankCustomerMethods**.

    Your code file should look similar to the following code snippet:

    ```csharp

    using System;
    
    namespace Classes_M3;
    
    public class BankCustomerMethods
    {
    
    }

    ```

    You can use the `Classes_M3` project to create new class file named BankCustomerMethods. Right-click the **Classes_M3** project in the Solution Explorer, select **New File**, select **Class**, and then enter **BankCustomerMethods**.

1. Update the BankCustomerMethods.cs file to match the following code:

    ```csharp

    using System;
    
    namespace Classes_M3;
    
    public partial class BankCustomer
    {

    }

    ```

    The `partial` keyword indicates that the `BankCustomer` class is defined in multiple files.

1. Open the BankCustomer.cs file.

1. Update the class definition to include the `partial` keyword.

    ```csharp

    using System;
    
    namespace Classes_M3;
    
    public partial class BankCustomer
    {

        // existing code removed for brevity

    }

    ```

    The `BankCustomer` class is now split between the BankCustomer.cs and BankCustomerMethods.cs files.

1. Move the `ReturnFullName`, `UpdateName`, and `DisplayCustomerInfo` methods to the BankCustomerMethods.cs file.

1. Take a minute to review your updated code files.

    BankCustomerMethods.cs

    ```csharp

    using System;
    
    namespace Classes_M3;
    
    public partial class BankCustomer
    {
        // Method to return the full name of the customer
        public string ReturnFullName()
        {
            return $"{FirstName} {LastName}";
        }
    
        // Method to update the customer's name
        public void UpdateName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    
        // Method to display customer information
        public string DisplayCustomerInfo()
        {
            return $"Customer ID: {CustomerId}, Name: {ReturnFullName()}";
        }
    }
    
    ```

    BankCustomer.cs

    ```csharp

    using System;
    
    namespace Classes_M3;
    
    public partial class BankCustomer
    {
        private static int s_nextCustomerId;
        private string _firstName = "Tim";
        private string _lastName = "Shao";
        public readonly string CustomerId;
    
        static BankCustomer()
        {
            Random random = new Random();
            s_nextCustomerId = random.Next(10000000, 20000000);
        }
    
        public BankCustomer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            this.CustomerId = (s_nextCustomerId++).ToString("D10");
        }
    
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
    
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
    }

    ```

1. Run the app to ensure that your partial class updates didn't introduce any bugs.

    Splitting a class into two partial class files can improve code organization, but shouldn't affect the functionality of the app. The BankCustomer class should still work as expected, and you should see the same output in the terminal window.

    Your app should produce output that's similar to the following example:

    ```plaintext

    Creating BankCustomer objects...
    BankCustomer 1: Tim Shao 0012396421
    BankCustomer 2: Lisa Shao 0012396422
    BankCustomer 3: Sandy Zoeng 0012396423
    
    Creating BankAccount objects for customers...
    Account 1: Account # 11657161, type Checking, balance 0, rate 0, customer ID 0012396421
    Account 2: Account # 11657162, type Checking, balance 1500, rate 0, customer ID 0012396422
    Account 3: Account # 11657163, type Checking, balance 2500, rate 0, customer ID 0012396423
    
    Updating BankCustomer 1's name...
    Updated BankCustomer 1: Thomas Margand 0012396421
    
    Demonstrating BankAccount methods...
    Depositing 500 into Account 1...
    Account 1 after deposit: Balance = 500
    Withdrawing 200 from Account 2...
    Account 2 after withdrawal: Balance = 1300, Withdrawal successful: True
    Transferring 300 from Account 3 to Account 1...
    Account 3 after transfer: Balance = 2200, Transfer successful: True
    Account 1 after receiving transfer: Balance = 800
    Applying interest to Account 1...
    Account 1 after applying interest: Balance = 800
    
    Demonstrating extension methods...
    Hello, Thomas Margand!
    Is customer1 ID valid? True
    Can account2 withdraw 2000? False
    Is account3 overdrawn? False
    
    Displaying customer and account information...
    Customer ID: 0012396421, Name: Thomas Margand
    Account Number: 11657161, Type: Checking, Balance: 800, Interest Rate: 0, Customer ID: 0012396421

    ```

## Create a static class for BankAccount methods

Static classes are often used to organize methods that don't require an instance of a class. Static classes can't be instantiated, and their methods can be called directly without creating an instance of a class. Static classes are useful for grouping related methods together and providing a convenient way to access them.

In this task, you add new capabilities to the `BankAccount` class and create helper methods in a static class to support the new features.

Use the following steps to complete this section of the exercise:

1. Create a new file in the `Classes_M3` project for a class named **AccountCalculations**.

    Your AccountCalculations.cs file should look similar to the following code:

    ```csharp

    using System;
    
    namespace Classes_M3;
    
    public class AccountCalculations
    {

    }

    ```

1. Add the `static` keyword to the class definition to make it a static class.

    ```csharp

    using System;
    
    namespace Classes_M3;
    
    public static class AccountCalculations
    {

    }

    ```

    You'll be adding helper methods to the `AccountCalculations` class to support new features in the `BankAccount` class.

1. Open the BankAccount.cs file.

    You're going to add the following capabilities the BankAccount class:

    - Calculate and apply compound interest to an account.
    - Issue cashier's checks from an account.
    - Enable support for an overdraft feature for accounts.
    - Enable refunds to an account.

1. Replace the `InterestRate` field with the following static properties:

    ```csharp

    // Public read-only static properties
    public static double InterestRate { get; private set; }
    public static double TransactionRate { get; private set; }
    public static double MaxTransactionFee { get; private set; }
    public static double OverdraftRate { get; private set; }
    public static double MaxOverdraftFee { get; private set; }

    ```

    These properties are used to store the interest rate, transaction rate, maximum transaction fee, overdraft rate, and maximum overdraft fee for accounts. They are static properties, so they can be accessed using the class name, `BankAccount`, rather than an instance of the class. The `private set` accessor restricts the properties to read-only access.

1. Replace the static and instance constructors with the following code snippet:

    ```csharp

    static BankAccount()
    {
        Random random = new Random();
        s_nextAccountNumber = random.Next(10000000, 20000000);
        InterestRate = 0.00; // Default interest rate for checking accounts
        TransactionRate = 0.01; // Default transaction rate for wire transfers and cashier's checks
        MaxTransactionFee = 10; // Maximum transaction fee for wire transfers and cashier's checks
        OverdraftRate = 0.05; // Default penalty rate for an overdrawn checking account (negative balance)
        MaxOverdraftFee = 10; // Maximum overdraft fee for an overdrawn checking account
    }

    public BankAccount(string customerIdNumber, double balance, string accountType)
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = customerIdNumber; // required for the constructor
        this.Balance = balance;             // required for the constructor
        this.AccountType = accountType;     // required for the constructor
    }

    ```

    The static constructor initializes the static field `s_nextAccountNumber`, and the static properties `InterestRate`, `TransactionRate`, `MaxTransactionFee`, `OverdraftRate`, and `MaxOverdraftFee`. 

    The single instance constructor now requires the `customerIdNumber`, `balance`, and `accountType` parameters in order to instantiate an account. The instance constructor uses the parameters to initialize the `CustomerId`, `Balance`, and `AccountType` properties of a `BankAccount` instance. The `AccountNumber` property is initialized using the `s_nextAccountNumber` field.

1. Replace the existing `ApplyInterest` method with the following code snippet:

    ```csharp

    // Method to apply interest
    public void ApplyInterest(double years)
    {
        Balance += AccountCalculations.CalculateCompoundInterest(Balance, InterestRate, years);
    }

    // Method to issue a cashier's check
    public bool IssueCashiersCheck(double amount)
    {
        if (amount > 0 && Balance >= amount + BankAccount.MaxTransactionFee)
        {
            Balance -= amount;
            Balance -= AccountCalculations.CalculateTransactionFee(amount, BankAccount.TransactionRate, BankAccount.MaxTransactionFee);
            return true;
        }
        return false;
    }

    // Method to apply a refund
    public void ApplyRefund(double refund)
    {
        Balance += refund;
    }

    ```

1. Take a minute to review the new methods.

    Notice that the `ApplyInterest` and `IssueCashiersCheck` methods rely on helper methods in the `AccountCalculations` class to perform calculations.

1. Open the AccountCalculations.cs file.

1. Add the following methods to the AccountCalculations class:

    ```csharp

    // Method to calculate compound interest
    public static double CalculateCompoundInterest(double principal, double annualRate, double years)
    {
        return principal * Math.Pow(1 + annualRate, years) - principal;
    }

    // Method to validate account number
    public static bool ValidateAccountNumber(int accountNumber)
    {
        return accountNumber.ToString().Length == 8;
    }

    // Method to calculate transaction fee, for things like bank checks or wire transfers
    public static double CalculateTransactionFee(double amount, double transactionRate, double maxTransactionFee)
    {
        // calculate the fee based on the transaction rate
        double fee = amount * transactionRate;

        // Return the lesser of the calculated fee or the maximum fee for transactions
        return Math.Min(fee, maxTransactionFee);
    }

    // Method to calculate overdraft fee
    public static double CalculateOverdraftFee(double amountOverdrawn, double overdraftRate, double maxOverdraftFee)
    {
        // Calculate the fee based on the overdraft rate
        double fee = amountOverdrawn * overdraftRate;

        // Return the lesser of the calculated fee or the maximum fee of $10
        return Math.Min(fee, maxOverdraftFee);
    }

    // Method to calculate the value of currency after foreign exchange 
    public static double ReturnForeignCurrency(double amount, double exchangeRate)
    {
        return amount * exchangeRate;
    }

    ```

1. Take a minute to review the methods that you just added.

    The `AccountCalculations` class provides helper methods that perform calculations for the BankAccount class. For instance, the `ApplyInterest` method in `BankAccount` uses `AccountCalculations.CalculateCompoundInterest` to compute the interest to be added to the account balance. Similarly, the `IssueCashiersCheck` method relies on `AccountCalculations.CalculateTransactionFee` to determine the transaction fee that needs to be deducted from the balance when issuing a cashier's check. By utilizing these methods from `AccountCalculations`, the `BankAccount` class can perform accurate and consistent financial computations, ensuring modularity and maintainability in the code.

1. Open the Program.cs file.

1. Add the following `using` directive to the top of the file:

    ```csharp

    using System.Globalization;

    ```

    This `using` directive allows you to use the `CultureInfo` class to format currency values.

1. Locate the code that demonstrates the use of BankAccount methods.

    ```csharp

    // Step 4: Demonstrate the use of BankAccount methods
    Console.WriteLine("\nDemonstrating BankAccount methods...");
    
    // Deposit
    Console.WriteLine("Depositing 500 into Account 1...");
    account1.Deposit(500);
    Console.WriteLine($"Account 1 after deposit: Balance = {account1.Balance}");
    
    // Withdraw
    Console.WriteLine("Withdrawing 200 from Account 2...");
    bool withdrawSuccess = account2.Withdraw(200);
    Console.WriteLine($"Account 2 after withdrawal: Balance = {account2.Balance}, Withdrawal successful: {withdrawSuccess}");
    
    // Transfer
    Console.WriteLine("Transferring 300 from Account 3 to Account 1...");
    bool transferSuccess = account3.Transfer(account1, 300);
    Console.WriteLine($"Account 3 after transfer: Balance = {account3.Balance}, Transfer successful: {transferSuccess}");
    Console.WriteLine($"Account 1 after receiving transfer: Balance = {account1.Balance}");
    
    // Apply interest
    Console.WriteLine("Applying interest to Account 1...");
    account1.ApplyInterest();
    Console.WriteLine($"Account 1 after applying interest: Balance = {account1.Balance}");

    ```

1. Replace the existing "Step 4" code with the following code snippet:

    ```csharp

    // Step 4: Demonstrate the use of BankAccount methods
    Console.WriteLine("\nDemonstrating BankAccount methods...");
    
    // Deposit
    double depositAmount = 500;
    Console.WriteLine($"Depositing {depositAmount.ToString("C", CultureInfo.CurrentCulture)} into Account 1...");
    account1.Deposit(depositAmount);
    Console.WriteLine($"Account 1 after deposit: Balance = {account1.Balance.ToString("C", CultureInfo.CurrentCulture)}");
    
    // Withdraw
    double withdrawalAmount = 200;
    Console.WriteLine($"Withdrawing {withdrawalAmount.ToString("C", CultureInfo.CurrentCulture)} from Account 2...");
    bool withdrawSuccess = account2.Withdraw(withdrawalAmount);
    Console.WriteLine($"Account 2 after withdrawal: Balance = {account2.Balance.ToString("C", CultureInfo.CurrentCulture)}, Withdrawal successful: {withdrawSuccess}");
    
    // Transfer
    double transferAmount = 300;
    Console.WriteLine($"Transferring {transferAmount.ToString("C", CultureInfo.CurrentCulture)} from Account 3 to Account 1...");
    bool transferSuccess = account3.Transfer(account1, transferAmount);
    Console.WriteLine($"Account 3 after transfer: Balance = {account3.Balance.ToString("C", CultureInfo.CurrentCulture)}, Transfer successful: {transferSuccess}");
    Console.WriteLine($"Account 1 after receiving transfer: Balance = {account1.Balance.ToString("C", CultureInfo.CurrentCulture)}");
    
    // Demonstrate the use of utility methods in AccountCalculations
    Console.WriteLine("\nDemonstrating utility methods in AccountCalculations...");
    
    // Calculate compound interest for account1
    double principal = account1.Balance;
    double rate = BankAccount.InterestRate;
    double time = 1; // 1 year
    double compoundInterest = AccountCalculations.CalculateCompoundInterest(principal, rate, time);
    Console.WriteLine($"Compound interest on account1 balance of {principal.ToString("C", CultureInfo.CurrentCulture)} at {rate * 100:F2}% for {time} year: {compoundInterest.ToString("C", CultureInfo.CurrentCulture)}");
    
    // Validate account number for account1
    int accountNumber = account1.AccountNumber;
    bool isValidAccountNumber = AccountCalculations.ValidateAccountNumber(accountNumber);
    Console.WriteLine($"Is account number {accountNumber} valid? {isValidAccountNumber}");
    
    // Calculate transaction fee using rates and max fee values from the bank account class
    double transactionAmount = 800;
    double transactionFee = AccountCalculations.CalculateTransactionFee(transactionAmount, BankAccount.TransactionRate, BankAccount.MaxTransactionFee);
    Console.WriteLine($"Transaction fee for a {transactionAmount.ToString("C", CultureInfo.CurrentCulture)} wire transfer at a {BankAccount.TransactionRate * 100:F2}% rate and a max fee of {BankAccount.MaxTransactionFee.ToString("C", CultureInfo.CurrentCulture)} is: {transactionFee.ToString("C", CultureInfo.CurrentCulture)}");
    
    // Calculate overdraft fee using rates and max fee values from the bank account class
    double overdrawnAmount = 500;
    double overdraftFee = AccountCalculations.CalculateOverdraftFee(overdrawnAmount, BankAccount.OverdraftRate, BankAccount.MaxOverdraftFee);
    Console.WriteLine($"Overdraft fee for an account that's {overdrawnAmount.ToString("C", CultureInfo.CurrentCulture)} overdrawn, using a penalty rate of {BankAccount.OverdraftRate * 100:F2}% and a max fee of {BankAccount.MaxOverdraftFee.ToString("C", CultureInfo.CurrentCulture)} is: {overdraftFee.ToString("C", CultureInfo.CurrentCulture)}");
    
    // Exchange currency
    double originalCurrencyProvided = 100;
    double currentExchangeRate = 1.2;
    double foreignCurrencyReceived = AccountCalculations.ReturnForeignCurrency(originalCurrencyProvided, currentExchangeRate);
    Console.WriteLine($"The foreign currency received after exchanging {originalCurrencyProvided.ToString("C", CultureInfo.CurrentCulture)} at an exchange rate of {currentExchangeRate:F2} is: {foreignCurrencyReceived.ToString("C", CultureInfo.CurrentCulture)}");
    
    // Apply interest
    Console.WriteLine("\nApplying interest to Account 1...");
    double timePeriodYears = 30 / 365.0;    // calculate the interest accrued during the past 30 days
    account1.ApplyInterest(timePeriodYears);
    Console.WriteLine($"Account 1 after applying interest: Balance = {account1.Balance.ToString("C", CultureInfo.CurrentCulture)}, Interest Rate = {BankAccount.InterestRate:P2}, Time Period = {timePeriodYears:F2} years");
    
    // Issue cashier's check
    Console.WriteLine("Issue cashier's check from account 2...");
    double checkAmount = 500;
    bool receivedCashiersCheck = account2.IssueCashiersCheck(checkAmount);
    Console.WriteLine($"Account 2 after requesting cashier's check: Received cashier's check: {receivedCashiersCheck}, Balance = {account2.Balance.ToString("C", CultureInfo.CurrentCulture)}, Transaction Amount = {checkAmount.ToString("C", CultureInfo.CurrentCulture)}, Transaction Fee Rate = {BankAccount.TransactionRate:P2}, Max Transaction Fee = {BankAccount.MaxTransactionFee.ToString("C", CultureInfo.CurrentCulture)}");
    
    // Apply refund
    Console.WriteLine("Applying refund to Account 3...");
    double refundAmount = 50;
    account3.ApplyRefund(refundAmount);
    Console.WriteLine($"Account 3 after applying refund: Balance = {account3.Balance.ToString("C", CultureInfo.CurrentCulture)}, Refund Amount = {refundAmount.ToString("C", CultureInfo.CurrentCulture)}");

    ```

1. Take a minute to review the updated code in "Step 4" of the Program.cs file.

    The updated code demonstrates the use of the new `BankAccount` methods and the utility methods in the `AccountCalculations` class. The `ApplyInterest` method applies compound interest to an account balance, the `IssueCashiersCheck` method issues a cashier's check from an account, and the `ApplyRefund` method applies a refund to an account balance. The utility methods in the `AccountCalculations` class are used to calculate compound interest, validate account numbers, calculate transaction fees, calculate overdraft fees, and help with foreign currency exchanges.

1. Run the app to ensure that your static class updates didn't introduce any bugs.

    By moving the transactional methods to a static class, your code is more efficiently organized and the maintainability of your code is improved. The BankAccount class should still work as expected, and you should see the same output in the terminal window.

    Your app should produce output that's similar to the following example:

    ```plaintext

    Creating BankCustomer objects...
    BankCustomer 1: Tim Shao 0016201844
    BankCustomer 2: Lisa Shao 0016201845
    BankCustomer 3: Sandy Zoeng 0016201846
    
    Creating BankAccount objects for customers...
    Account 1: Account # 18378304, type Checking, balance 0, rate 0, customer ID 0016201844
    Account 2: Account # 18378305, type Checking, balance 1500, rate 0, customer ID 0016201845
    Account 3: Account # 18378306, type Checking, balance 2500, rate 0, customer ID 0016201846
    
    Updating BankCustomer 1's name...
    Updated BankCustomer 1: Thomas Margand 0016201844
    
    Demonstrating BankAccount methods...
    Depositing $500.00 into Account 1...
    Account 1 after deposit: Balance = $500.00
    Withdrawing $200.00 from Account 2...
    Account 2 after withdrawal: Balance = $1,300.00, Withdrawal successful: True
    Transferring $300.00 from Account 3 to Account 1...
    Account 3 after transfer: Balance = $2,200.00, Transfer successful: True
    Account 1 after receiving transfer: Balance = $800.00
    
    Demonstrating utility methods in AccountCalculations...
    Compound interest on account1 balance of $800.00 at 0.00% for 1 year: $0.00
    Is account number 18378304 valid? True
    Transaction fee for a $800.00 wire transfer at a 0.00% rate and a max fee of $0.00 is: $0.00
    Overdraft fee for an account that's $500.00 overdrawn, using a penalty rate of 0.00% and a max fee of $0.00 is: $0.00
    The foreign currency received after exchanging $100.00 at an exchange rate of 1.20 is: $120.00
    
    Applying interest to Account 1...
    Account 1 after applying interest: Balance = $800.00, Interest Rate = 0.00%, Time Period = 0.08 years
    Issue cashier's check from account 2...
    Account 2 after requesting cashier's check: Received cashier's check: True, Balance = $800.00, Transaction Amount = $500.00, Transaction Fee Rate = 0.00%, Max Transaction Fee = $0.00
    Applying refund to Account 3...
    Account 3 after applying refund: Balance = $2,250.00, Refund Amount = $50.00
    
    Demonstrating extension methods...
    Hello, Thomas Margand!
    Is customer1 ID valid? True
    Can account2 withdraw 2000? False
    Is account3 overdrawn? False
    
    Displaying customer and account information...
    Customer ID: 0016201844, Name: Thomas Margand
    Account Number: 18378304, Type: Checking, Balance: 800, Interest Rate: 0, Customer ID: 0016201844

    ```

## Use optional parameters to improve constructor flexibility

Using named and optional parameters can improve code readability and flexibility, especially in constructors and methods with multiple parameters. In your banking app, the files that would benefit the most from named and optional parameters are BankAccount.cs and AccountCalculations.cs.

In this task, you update a constructor in the BankAccount class using optional parameters.

1. Open the BankAccount.cs file and locate the class constructors.

    ```csharp
    
    static BankAccount()
    {
        Random random = new Random();
        s_nextAccountNumber = random.Next(10000000, 20000000);
        InterestRate = 0.00; // Default interest rate for checking accounts
        TransactionRate = 0.01; // Default transaction rate for wire transfers and cashier's checks
        MaxTransactionFee = 10; // Maximum transaction fee for wire transfers and cashier's checks
        OverdraftRate = 0.05; // Default penalty rate for an overdrawn checking account (negative balance)
        MaxOverdraftFee = 10; // Maximum overdraft fee for an overdrawn checking account
    }

    public BankAccount(string customerIdNumber, double balance, string accountType)
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = customerIdNumber; // required for the constructor
        this.Balance = balance;             // required for the constructor
        this.AccountType = accountType;     // required for the constructor
    }
    
    ```

    You can improve the flexibility of the instance constructor by implementing optional parameters that specify common values for `balance` and `accountType`. This way, you can create `BankAccount` objects with varying levels of parameter detail, making class instantiation more flexible.

1. Replace your instance constructor with the following constructor that specifies optional `balance` and `accountType` parameters:

    ```csharp
    
    public BankAccount(string customerIdNumber, double balance = 200, string accountType = "Checking")
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = accountType;
    }
    
    ```

    By using optional parameters in the `BankAccount` constructor, you can create instances of `BankAccount` with varying levels of parameter detail, making class instantiation more flexible and reducing the need for constructor overloads. For example, you can create a `BankAccount` object with only a `customerIdNumber`, or you can add combinations of `Balance` and `accountType`:

    ```csharp
    string customerId = customer1.CustomerId;
    double openingBalance = 1500;

    // specify a customer ID and use the default optional parameters (balance and accountType)
    BankAccount account6 = new BankAccount(customerId);

    // specify the customer ID and opening balance and use default account type
    BankAccount account7 = new BankAccount(customer2.CustomerId, openingBalance);

    // specify the customer ID and use a named parameter to specify account type
    BankAccount account8 = new BankAccount(customer4.CustomerId, accountType: "Checking");
    
    // use named parameters to specify all parameters
    BankAccount account9 = new BankAccount(accountType: "Checking", balance: 5000, customerIdNumber: customer5.CustomerId);

    ```

    > [!NOTE]
    > Optional parameters can make your code more flexible and easier to read. In this case, there are no changes required to the code in your Program.cs. In fact, new constructor enables you to create BankAccount objects with parameter combinations that were not possible before.

1. Take a minute to review your BankAccount.cs code.

    ```csharp

    using System;
    
    namespace Classes_M3;
    
    public class BankAccount
    {
        private static int s_nextAccountNumber;
        public static double InterestRate;
        public int AccountNumber { get; }
        public string CustomerId { get; }
        public double Balance { get; private set; } = 0;
        public string AccountType { get; set; } = "Checking";
    
        static BankAccount()
        {
            Random random = new Random();
            s_nextAccountNumber = random.Next(10000000, 20000000);
            InterestRate = 0;
        }
    
        public BankAccount(string customerIdNumber, double balance = 200, string accountType = "Checking")
        {
            this.AccountNumber = s_nextAccountNumber++;
            this.CustomerId = customerIdNumber;
            this.Balance = balance;
            this.AccountType = accountType;
        }
    
        // Method to display account information
        public string DisplayAccountInfo()
        {
            return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance}, Interest Rate: {InterestRate}, Customer ID: {CustomerId}";
        }
    
    }

    ```

1. Run the app to ensure that your optional parameter updates didn't introduce any bugs.

    Your app should produce output that's similar to the following example:

    ```plaintext

    Creating BankCustomer objects...
    BankCustomer 1: Tim Shao 0016320839
    BankCustomer 2: Lisa Shao 0016320840
    BankCustomer 3: Sandy Zoeng 0016320841
    
    Creating BankAccount objects for customers...
    Account 1: Account # 12848501, type Checking, balance 0, rate 0, customer ID 0016320839
    Account 2: Account # 12848502, type Checking, balance 1500, rate 0, customer ID 0016320840
    Account 3: Account # 12848503, type Checking, balance 2500, rate 0, customer ID 0016320841
    
    Updating BankCustomer 1's name...
    Updated BankCustomer 1: Thomas Margand 0016320839
    
    Demonstrating BankAccount methods...
    Depositing 500 into Account 1...
    Account 1 after deposit: Balance = 500
    Withdrawing 200 from Account 2...
    Account 2 after withdrawal: Balance = 1300, Withdrawal successful: True
    Transferring 300 from Account 3 to Account 1...
    Account 3 after transfer: Balance = 2200, Transfer successful: True
    Account 1 after receiving transfer: Balance = 800
    Applying interest to Account 1...
    Account 1 after applying interest: Balance = 800
    
    Demonstrating extension methods...
    Hello, Thomas Margand!
    Is customer1 ID valid? True
    Can account2 withdraw 2000? False
    Is account3 overdrawn? False
    
    Displaying customer and account information...
    Customer ID: 0016320839, Name: Thomas Margand
    Account Number: 12848501, Type: Checking, Balance: 800, Interest Rate: 0, Customer ID: 0016320839

    ```

## Implement copy constructors and object initializers

Object initializers and copy constructors are useful techniques for creating and copying objects in C#. Both techniques can enhance code readability and maintainability.

- Copy constructors allow you to create a new object that's a copy of an existing object. This is useful when you need to duplicate objects with the same state.
- Object initializers allow you to initialize an object and set its properties in a single statement. This can make the code more concise and readable.

In this task, you implement copy constructors and object initializers by updating constructors in the `BankCustomer` and `BankAccount` classes, and the demonstration code in Program.cs.

Use the following steps to complete this section of the exercise:

1. Open the BankCustomer.cs file.

1. To create a copy constructor for the BankCustomer class, add the following code:

    ```csharp

    // Copy constructor for BankCustomer
    public BankCustomer(BankCustomer existingCustomer)
    {

        this.FirstName = existingCustomer.FirstName;
        this.LastName = existingCustomer.LastName;
        //this.CustomerId = existingCustomer.CustomerId;
        this.CustomerId = (s_nextCustomerId++).ToString("D10");

    }

    ```

    Notice that the `CustomerId` field from the existing customer isn't used. Instead, a new `CustomerId` is generated for the new customer. This supports the logic already implemented by the BankCustomer class.

1. Open the BankAccount.cs file.

1. To create a copy constructor for the BankAccount class, add the following code:

    ```csharp

    // Copy constructor for BankAccount
    public BankAccount(BankAccount existingAccount)
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = existingAccount.CustomerId;
        this.Balance = existingAccount.Balance;
        this.AccountType = existingAccount.AccountType;
    }

    ```

    Notice that a new `AccountNumber` field is generated for the new account. The `CustomerId`, `Balance`, and `AccountType` fields are copied from the existing account. The `InterestRate` field is not copied because it's a static field that's shared across all instances of the BankAccount class. The `CustomerId` field is copied because the intension is to create a new account for the same customer.

1. Open the Program.cs file.

1. Add the following Step 7 and Step 8 code to the end of the Program.cs file

    ```csharp

    // Step 7: Demonstrate the use of named and optional parameters
    Console.WriteLine("\nDemonstrating named and optional parameters...");
    string customerId = customer1.CustomerId;
    double openingBalance = 1500;
    
    // specify a customer ID and use the default optional parameters (balance and accountType)
    BankAccount account4 = new BankAccount(customerId);
    Console.WriteLine(account4.DisplayAccountInfo());
    
    // specify the customer ID and opening balance and use default account type
    BankAccount account5 = new BankAccount(customer1.CustomerId, openingBalance);
    Console.WriteLine(account5.DisplayAccountInfo());
    
    // specify the customer ID and use a named parameter to specify account type
    BankAccount account6 = new BankAccount(customer2.CustomerId, accountType: "Checking");
    Console.WriteLine(account6.DisplayAccountInfo());
    
    // use named parameters to specify all parameters
    BankAccount account7 = new BankAccount(accountType: "Checking", balance: 5000, customerIdNumber: customer2.CustomerId);
    Console.WriteLine(account7.DisplayAccountInfo());
    
    // Step 8: Demonstrate using object initializers and copy constructors
    Console.WriteLine("\nDemonstrating object initializers and copy constructors...");
    
    // Using object initializer
    BankCustomer customer4 = new BankCustomer("Mikaela", "Lee") { FirstName = "Mikaela", LastName = "Lee" };
    Console.WriteLine($"BankCustomer 4: {customer4.FirstName} {customer4.LastName} {customer4.CustomerId}");
    
    // Using copy constructor
    BankCustomer customer5 = new BankCustomer(customer4);
    Console.WriteLine($"BankCustomer 5 (copy of customer4): {customer5.FirstName} {customer5.LastName} {customer5.CustomerId}");
    
    // Using object initializer
    BankAccount account8 = new BankAccount(customer4.CustomerId) {AccountType = "Savings"};
    Console.WriteLine($"Account 8: Account # {account8.AccountNumber}, type {account8.AccountType}, balance {account8.Balance}, rate {BankAccount.InterestRate}, customer ID {account8.CustomerId}");
    
    // Using copy constructor
    BankAccount account9 = new BankAccount(account4);
    Console.WriteLine($"Account 9 (copy of account4): Account # {account9.AccountNumber}, type {account9.AccountType}, balance {account9.Balance}, rate {BankAccount.InterestRate}, customer ID {account9.CustomerId}");

    ```

    Notice the following about Step 7:

    - Optional parameters are used to create `BankAccount` objects with varying levels of parameter detail.
    - Named parameters allow you to specify parameters by name, with less regard to their order in the constructor.

    Notice the following about Step 8:

    - The `customer4` object is created using an object initializer. The `FirstName` and `LastName` properties are set using the object initializer syntax.
    - The `customer5` object is created using a copy constructor. The `customer5` object is a copy of the `customer4` object.
    - The `account8` object is created using an object initializer. The `AccountType` property is set using the object initializer syntax. However, the `Balance` property has a private set accessor, so it can't be set using an object initializer.
    - The `account9` object is created using a copy constructor. The `account9` object is a copy of the `account4` object.

1. Run the app and review the output in the terminal window.

    Your app should produce output that's similar to the following example:

    ```plaintext

    Creating BankCustomer objects...
    BankCustomer 1: Tim Shao 0016484785
    BankCustomer 2: Lisa Shao 0016484786
    BankCustomer 3: Sandy Zoeng 0016484787
    
    Creating BankAccount objects for customers...
    Account 1: Account # 16017880, type Checking, balance 200, rate 0, customer ID 0016484785
    Account 2: Account # 16017881, type Checking, balance 1500, rate 0, customer ID 0016484786
    Account 3: Account # 16017882, type Checking, balance 2500, rate 0, customer ID 0016484787
    
    Updating BankCustomer 1's name...
    Updated BankCustomer 1: Thomas Margand 0016484785
    
    Demonstrating BankAccount methods...
    Depositing $500.00 into Account 1...
    Account 1 after deposit: Balance = $700.00
    Withdrawing $200.00 from Account 2...
    Account 2 after withdrawal: Balance = $1,300.00, Withdrawal successful: True
    Transferring $300.00 from Account 3 to Account 1...
    Account 3 after transfer: Balance = $2,200.00, Transfer successful: True
    Account 1 after receiving transfer: Balance = $1,000.00
    
    Demonstrating utility methods in AccountCalculations...
    Compound interest on account1 balance of $1,000.00 at 0.00% for 1 year: $0.00
    Is account number 16017880 valid? True
    Transaction fee for a $800.00 wire transfer at a 1.00% rate and a max fee of $10.00 is: $8.00
    Overdraft fee for an account that's $500.00 overdrawn, using a penalty rate of 5.00% and a max fee of $10.00 is: $10.00
    The foreign currency received after exchanging $100.00 at an exchange rate of 1.20 is: $120.00
    
    Applying interest to Account 1...
    Account 1 after applying interest: Balance = $1,000.00, Interest Rate = 0.00%, Time Period = 0.08 years
    Issue cashier's check from account 2...
    Account 2 after requesting cashier's check: Received cashier's check: True, Balance = $795.00, Transaction Amount = $500.00, Transaction Fee Rate = 1.00%, Max Transaction Fee = $10.00
    Applying refund to Account 3...
    Account 3 after applying refund: Balance = $2,250.00, Refund Amount = $50.00
    
    Demonstrating extension methods...
    Hello, Thomas Margand!
    Is customer1 ID valid? True
    Can account2 withdraw 2000? False
    Is account3 overdrawn? False
    
    Displaying customer and account information...
    Customer ID: 0016484785, Name: Thomas Margand
    Account Number: 16017880, Type: Checking, Balance: 1000, Interest Rate: 0, Customer ID: 0016484785
    
    Demonstrating named and optional parameters...
    Account Number: 16017883, Type: Checking, Balance: 200, Interest Rate: 0, Customer ID: 0016484785
    Account Number: 16017884, Type: Checking, Balance: 1500, Interest Rate: 0, Customer ID: 0016484785
    Account Number: 16017885, Type: Checking, Balance: 200, Interest Rate: 0, Customer ID: 0016484786
    Account Number: 16017886, Type: Checking, Balance: 5000, Interest Rate: 0, Customer ID: 0016484786
    
    Demonstrating object initializers and copy constructors...
    BankCustomer 4: Mikaela Lee 0016484788
    BankCustomer 5 (copy of customer4): Mikaela Lee 0016484789
    Account 8: Account # 16017887, type Savings, balance 200, rate 0, customer ID 0016484788
    Account 9 (copy of account8): Account # 16017888, type Savings, balance 200, rate 0, customer ID 0016484788

    ```

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Also, building up a portfolio of projects can be a great way to demonstrate your skills to potential employers.
