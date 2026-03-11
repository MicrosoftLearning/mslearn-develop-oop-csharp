---
lab:
  title: Exercise - Implement base and derived classes
  description: Learn how to create a class hierarchy that implements base and derived classes. Explore using the abstract, virtual, sealed, new, and override keywords to extend base class behavior in derived classes, and how to access base class members from within a derived class using the base keyword.
  duration: 30 minutes
  level: 100
  islab: true
---

# Implement base and derived classes

Class inheritance is a fundamental concept in object-oriented programming that allows you to develop a hierarchy of classes that share common properties and methods. Inheritance enables you to define a base class with common properties and methods that can be shared by derived classes. Derived classes inherit the members of the base class and can extend or modify them to create specialized classes. In this exercise, you create a base class and derived classes to represent different types of bank accounts.

In this exercise, you create three derived classes that inherit from the `BankAccount` base class: `CheckingAccount`, `SavingsAccount`, and `MoneyMarketAccount`. Each derived class will have include an instance constructor that accesses the base class constructor. You explore the use of `abstract`, `virtual`, `sealed`, `new`, and `override` keywords to implement specialized behavior in the derived classes. You update the Program.cs file to demonstrate the extended features implemented in the derived classes.

This exercise takes approximately **30** minutes to complete.

## Before you start

Before you can start this exercise, you need to:

1. Ensure that you have the latest short term support (STS) version of the .NET SDK installed on your computer. You can download the latest versions of the .NET SDK using the following URL: <a href="https://dotnet.microsoft.com/download/" target="_blank">Download .NET</a>

1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code using the following URL: <a href="https://code.visualstudio.com/download/" target="_blank">Download Visual Studio Code</a>

1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For additional help configuring the Visual Studio Code environment, see <a href="https://learn.microsoft.com/training/modules/install-configure-visual-studio-code/" target="_blank">Install and configure Visual Studio Code for C# development</a>

## Exercise scenario

Suppose you're helping a non-profit company with a software project. You've decided to sharpen your object-oriented programming skills by creating a simple banking app. You've developed an initial version of the app that includes the following files:

- AccountCalculations.cs: This file contains static utility methods for various financial calculations, such as compound interest, transaction fees, overdraft fees, and currency exchange.

- BankAccount.cs: This file defines the BankAccount class, implementing the IBankAccount interface and including properties, constructors, methods for account operations, and a copy constructor.

- BankCustomer.cs: This file defines the BankCustomer class, with properties for first name, last name, and a unique customer ID. It includes methods to return the full name, update the customer's name, and display customer information. It also maintains a static property for the next customer ID.

- BankCustomerMethods.cs: This file implements the methods defined in the IBankCustomer interface for the BankCustomer class, including methods to return full name, update name, and display customer information.

- Extensions.cs: This file contains extension methods for IBankCustomer and IBankAccount interfaces, providing additional functionality such as validation and greeting. For BankCustomer, it includes methods to check if the customer ID is valid and to greet the customer. For BankAccount, it includes methods to check if the account is overdrawn and if a specified amount can be withdrawn.

- IBankAccount.cs: This file defines the IBankAccount interface, specifying the properties and methods that a bank account class must implement.

- IBankCustomer.cs: This file defines the IBankCustomer interface, specifying the properties and methods that a bank customer class must implement.

- Program.cs: This file contains the main entry point of the application, demonstrating the creation and manipulation of BankCustomer and BankAccount objects, as well as various operations like deposits, withdrawals, and transfers.

This exercise includes the following tasks:

1. Review the current version of your banking app.

1. Create the `CheckingAccount`, `SavingsAccount`, and `MoneyMarketAccount` derived classes.

1. Update the `BankAccount` class definition with `abstract` and `sealed` keywords.

1. Implement specialized features in derived classes using properties and constructors.

1. Use the `new` keyword to hide base class methods in derived classes.

1. Override methods and properties in derived classes.

1. Use the `base` keyword in overridden methods to access base class members.

## Review the current version of your banking app

In this task, you download the existing version of your banking app and review the code.

Use the following steps to complete this section of the exercise:

1. Download the starter code from the following URL: [Implement inheritance and polymorphism - exercise code projects](https://github.com/MicrosoftLearning/mslearn-develop-oop-csharp/raw/refs/heads/main/DownloadableCodeProjects/Downloads/LP3SampleApps.zip)

1. Extract the contents of the LP3SampleApps.zip file to a folder location on your computer.

1. Expand the LP3SampleApps folder, and then open the `Reuse_M1` folder.

    The Reuse_M1 folder contains the following code project folders:

    - Solution
    - Starter

    The **Starter** folder contains the starter project files for this exercise.

1. Use Visual Studio Code to open the **Starter** folder.

1. In the EXPLORER view, collapse the **STARTER** folder, select **SOLUTION EXPLORER**, and expand the **Reuse_M1** project.

    You should see the following project files:

    - AccountCalculations.cs
    - BankAccount.cs
    - BankCustomer.cs
    - BankCustomerMethods.cs
    - Extensions.cs
    - IBankAccount.cs
    - IBankCustomer.cs
    - Program.cs

1. Take a few minutes to open and review each of the files.

    - `AccountCalculations.cs`: This file contains static utility methods for various financial calculations, such as compound interest, transaction fees, overdraft fees, and currency exchange.

    - `BankAccount.cs`: This file defines the BankAccount class, implementing the IBankAccount interface and including properties, constructors, methods for account operations, and a copy constructor.

    - `BankCustomer.cs`: This file defines the BankCustomer class, implementing the IBankCustomer interface and including properties, constructors, and a copy constructor.

    - `BankCustomerMethods.cs`: This file implements the methods defined in the IBankCustomer interface for the BankCustomer class, including methods to return full name, update name, and display customer information.

    - `Extensions.cs`: This file contains extension methods for IBankCustomer and IBankAccount interfaces, providing additional functionality such as validation and greeting.

    - `IBankAccount.cs`: This file defines the IBankAccount interface, specifying the properties and methods that a bank account class must implement.

    - `IBankCustomer.cs`: This file defines the IBankCustomer interface, specifying the properties and methods that a bank customer class must implement.

    - `Program.cs`: This file contains the main entry point of the application, demonstrating the creation and manipulation of BankCustomer and BankAccount objects, as well as various operations like deposits, withdrawals, and transfers.

1. Run the app and review the output in the terminal window.

    To run your app, right-click the **Reuse_M1** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    Your app should produce output that's similar to the following example:

    ```plaintext

    Creating BankCustomer objects...
    BankCustomer 1: Tim Shao 0012761163
    BankCustomer 2: Lisa Shao 0012761164
    BankCustomer 3: Sandy Zoeng 0012761165
    
    Creating BankAccount objects for customers...
    Account 1: Account # 13847819, type Checking, balance 200, rate 0, customer ID 0012761163
    Account 2: Account # 13847820, type Checking, balance 1500, rate 0, customer ID 0012761164
    Account 3: Account # 13847821, type Checking, balance 2500, rate 0, customer ID 0012761165
    
    Updating BankCustomer 1's name...
    Updated BankCustomer 1: Thomas Margand 0012761163
    
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
    Is account number 13847819 valid? True
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
    Customer ID: 0012761163, Name: Thomas Margand
    Account Number: 13847819, Type: Checking, Balance: 1000, Interest Rate: 0, Customer ID: 0012761163
    
    Demonstrating named and optional parameters...
    Account Number: 13847822, Type: Checking, Balance: 200, Interest Rate: 0, Customer ID: 0012761163
    Account Number: 13847823, Type: Checking, Balance: 1500, Interest Rate: 0, Customer ID: 0012761163
    Account Number: 13847824, Type: Checking, Balance: 200, Interest Rate: 0, Customer ID: 0012761164
    Account Number: 13847825, Type: Checking, Balance: 5000, Interest Rate: 0, Customer ID: 0012761164
    
    Demonstrating object initializers and copy constructors...
    BankCustomer 4: Mikaela Lee 0012761166
    BankCustomer 5 (copy of customer4): Mikaela Lee 0012761167
    Account 8: Account # 13847826, type Savings, balance 200, rate 0, customer ID 0012761166
    Account 9 (copy of account8): Account # 13847827, type Savings, balance 200, rate 0, customer ID 0012761166

    ```

    The customer IDs and account numbers in your output will be different from the example output. Remember that they're sequential values based on a randomly generated initial value.

## Create the CheckingAccount, SavingsAccount, and MoneyMarketAccount derived classes

In this task, you create derived classes that inherit from the `BankAccount` base class. You'll create three derived classes: `CheckingAccount`, `SavingsAccount`, and `MoneyMarketAccount`. Each derived class will have a simple constructor that accesses the base class constructor. You'll update the Program.cs file to demonstrate instantiating the derived classes and inheriting base class properties and methods.

Use the following steps to complete this section of the exercise:

1. Create a new class named `CheckingAccount`.

    You should see the following code in the new file:

    ```csharp

    using System;
    
    namespace Reuse_M1;
    
    public class CheckingAccount
    {
    
    }

    ```

    You'll configure `CheckingAccount` to inherit from `BankAccount`.

1. Update the class definition to specify that `CheckingAccount` inherits from `BankAccount`.

    For example:

    ```csharp

    public class CheckingAccount : BankAccount
    {
    
    }

    ```

    The `CheckingAccount : BankAccount` syntax indicates that `CheckingAccount` inherits from `BankAccount`.

1. Update the `CheckingAccount` class with a constructor that accesses the base class constructor.

    For example:

    ```csharp

    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(string customerId, double initialBalance)
            : base(customerId, initialBalance, "Checking" )
        {
        }
    }

    ```

    Notice that the `CheckingAccount` constructor calls the base class constructor using the `base` keyword. The constructor takes two parameters: `customerId` and `initialBalance`. It passes these parameters to the base class constructor along with a string containing the account type, which is "Checking".

1. Create derived classes for `SavingsAccount` and `MoneyMarketAccount`.

    The SavingsAccount.cs file should contain the following code:

    ```csharp

    using System;

    namespace Reuse_M1;

    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string customerId, double initialBalance)
            : base(customerId, initialBalance, "Savings")
        {
        }
    }

    ```

    The MoneyMarketAccount.cs file should contain the following code:

    ```csharp

    using System;

    namespace Reuse_M1;

    public class MoneyMarketAccount : BankAccount
    {
        public MoneyMarketAccount(string customerId, double initialBalance)
            : base(customerId, initialBalance, "Money Market")
        {
        }
    }

    ```

1. Open the Program.cs file.

1. Replace the contents of the Program.cs file with the following code snippet:

    ```csharp
    
    using Reuse_M1;
    using System.Globalization;
    
    class Program
    {
        static void Main()
        {
            // Create BankCustomer objects
            string firstName = "Tim";
            string lastName = "Shao";
    
            Console.WriteLine($"Creating a BankCustomer object for customer {firstName} {lastName}...");
            BankCustomer customer1 = new BankCustomer(firstName, lastName);

            // Task 1: Review the code files in the Starter project    
            // Task 2: Create derived classes (CheckingAccount, SavingsAccount, and MoneyMarketAccount)


        }
    }
    
    ```

    The Program class uses `Main` as the entry point of the application and creates a `BankCustomer` object for a customer named Tim Shao.

1. To demonstrate instantiating the derived classes, add the following code to the end of `Main`:

    ```csharp

    // Step 1 - Create account objects using the base and derived classes - BankAccount, CheckingAccount, SavingsAccount, and MoneyMarketAccount
    Console.WriteLine($"\nUsing derived classes to create bank account objects for {customer1.ReturnFullName()}...");
    BankAccount bankAccount1 = new BankAccount(customer1.CustomerId, 1000, "Checking");
    CheckingAccount checkingAccount1 = new CheckingAccount(customer1.CustomerId, 500);
    SavingsAccount savingsAccount1 = new SavingsAccount(customer1.CustomerId, 1000);
    MoneyMarketAccount moneyMarketAccount1 = new MoneyMarketAccount(customer1.CustomerId, 2000);

    ```

    Notice that objects are created using the base and derived classes.

1. To demonstrate inheritance of base class properties and methods, add the following code to the end of `Main`:

    ```csharp

    // Step 2 - Demonstrate using inherited properties to display account information
    Console.WriteLine($"\nUsing inherited properties to display {customer1.ReturnFullName()}'s account information...");
    Console.WriteLine($" - {checkingAccount1.AccountType} account #{checkingAccount1.AccountNumber} has a balance of {checkingAccount1.Balance.ToString("C", CultureInfo.CurrentCulture)}");
    Console.WriteLine($" - {savingsAccount1.AccountType} account #{savingsAccount1.AccountNumber} has a balance of {savingsAccount1.Balance.ToString("C", CultureInfo.CurrentCulture)}");
    Console.WriteLine($" - {moneyMarketAccount1.AccountType} account #{moneyMarketAccount1.AccountNumber} has a balance of {moneyMarketAccount1.Balance.ToString("C", CultureInfo.CurrentCulture)}");

    ```

1. Run the app and verify that the following output is generated:

    ```plaintext

    Creating a BankCustomer object for customer Tim Shao...
    
    Using derived classes to create bank account objects for Tim Shao...
    
    Using inherited properties to display Tim Shao's account information...
     - Checking account #10027975 has a balance of $1,000.00
     - Checking account #10027976 has a balance of $500.00
     - Savings account #10027977 has a balance of $1,000.00
     - Money Market account #10027978 has a balance of $2,000.00

    ```

    This output demonstrates the following:

    - Bank account objects can be created using base and derived classes.
    - The base class properties can be accessed from within the derived classes.

1. To demonstrate inheritance of the base class methods, add the following code to `Main`:

    ```csharp

    // Step 3 - Demonstrate using inherited methods to withdraw, transfer, and deposit funds
    Console.WriteLine("\nDemonstrating inheritance of the Withdraw, Transfer, and Deposit methods from the base class...");

    // define a transaction amount
    double transactionAmount = 200;

    // Withdraw from checking account, transfer from savings account to checking account, and deposit into money market account
    Console.WriteLine($" - Withdraw {transactionAmount} from {checkingAccount1.AccountType} account");
    checkingAccount1.Withdraw(transactionAmount);
    
    Console.WriteLine($" - Transfer {transactionAmount.ToString("C", CultureInfo.CurrentCulture)} from {savingsAccount1.AccountType} account into {checkingAccount1.AccountType} account");
    savingsAccount1.Transfer(checkingAccount1, transactionAmount);
    
    Console.WriteLine($" - Deposit {transactionAmount.ToString("C", CultureInfo.CurrentCulture)} into {moneyMarketAccount1.AccountType} account");
    moneyMarketAccount1.Deposit(transactionAmount);

    Console.WriteLine($" - {checkingAccount1.AccountType} account #{checkingAccount1.AccountNumber} has a balance of {checkingAccount1.Balance.ToString("C", CultureInfo.CurrentCulture)}");
    Console.WriteLine($" - {savingsAccount1.AccountType} account #{savingsAccount1.AccountNumber} has a balance of {savingsAccount1.Balance.ToString("C", CultureInfo.CurrentCulture)}");
    Console.WriteLine($" - {moneyMarketAccount1.AccountType} account #{moneyMarketAccount1.AccountNumber} has a balance of {moneyMarketAccount1.Balance.ToString("C", CultureInfo.CurrentCulture)}");

    ```

1. Run the app and verify that the following output is generated:

    ```plaintext

    Creating a BankCustomer object for customer Tim Shao...
    
    Using derived classes to create bank account objects for Tim Shao...
    
    Using inherited properties to display Tim Shao's account information...
     - Checking account #13358753 has a balance of $500.00
     - Savings account #13358754 has a balance of $1,000.00
     - Money Market account #13358755 has a balance of $2,000.00
    
    Demonstrating inheritance of the Withdraw, Transfer, and Deposit methods from the base class...
     - Withdraw 200 from Checking account
     - Transfer $200.00 from Savings account into Checking account
     - Deposit $200.00 into Money Market account
     - Checking account #13358753 has a balance of $500.00
     - Savings account #13358754 has a balance of $800.00
     - Money Market account #13358755 has a balance of $2,200.00

    ```

    The additional output demonstrates the following:

    - Base class methods are accessible from instances of a derived class.

## Update the BankAccount class definition with abstract and sealed keywords

In this task, you update the base class definition using `abstract` and `sealed` keywords and you observe the effect on instantiating base and derived classes.

Use the following steps to complete this section of the exercise:

1. Open the BankAccount.cs file.

1. Update the definition for `BankAccount` to include the `abstract` keyword.

    ```csharp

    public abstract class BankAccount : IBankAccount

    ```

1. Build the `Starter` solution.

1. Notice the error message that appears in the terminal window.

    ```plaintext

    error CS0144: Cannot create an instance of the abstract type or interface 'BankAccount'

    ```

    This error message reminds you that classes defined using the `abstract` keyword can't be directly instantiated.

1. Open the Program.cs file.

1. Comment out the two code lines that include references to the BankAccount class.

    ```csharp

    // Step 1 - Create account objects using the base and derived classes - BankAccount, CheckingAccount, SavingsAccount, and MoneyMarketAccount
    Console.WriteLine($"\nUsing derived classes to create bank account objects for {customer1.ReturnFullName()}...");

    //BankAccount bankAccount1 = new BankAccount(customer1.CustomerId, 1000, "Checking");

    CheckingAccount checkingAccount1 = new CheckingAccount(customer1.CustomerId, 500);
    SavingsAccount savingsAccount1 = new SavingsAccount(customer1.CustomerId, 1000);
    MoneyMarketAccount moneyMarketAccount1 = new MoneyMarketAccount(customer1.CustomerId, 2000);

    // Step 2 - Demonstrate using inherited properties to display account information
    Console.WriteLine($"\nUsing inherited properties to display {customer1.ReturnFullName()}'s account information...");

    //Console.WriteLine($" - {bankAccount1.AccountType} account #{bankAccount1.AccountNumber} has a balance of {bankAccount1.Balance.ToString("C", CultureInfo.CurrentCulture)}");

    ```

1. Run the app and verify that the following output is generated:

    ```plaintext

    Creating a BankCustomer object for customer Tim Shao...
    
    Using derived classes to create bank account objects for Tim Shao...
    
    Using inherited properties to display Tim Shao's account information...
     - Checking account #13358753 has a balance of $500.00
     - Savings account #13358754 has a balance of $1,000.00
     - Money Market account #13358755 has a balance of $2,000.00
    
    Demonstrating inheritance of the Withdraw, Transfer, and Deposit methods from the base class...
     - Withdraw 200 from Checking account
     - Transfer $200.00 from Savings account into Checking account
     - Deposit $200.00 into Money Market account
     - Checking account #13358753 has a balance of $500.00
     - Savings account #13358754 has a balance of $800.00
     - Money Market account #13358755 has a balance of $2,200.00

    ```

    Defining `BankAccount` as an abstract class prevents it from being instantiated directly. The derived classes can still be instantiated and inherit the properties and methods of the base class.

1. Open the BankAccount.cs file.

1. Update the definition for `BankAccount` to include the `sealed` keyword.

    ```csharp

    public sealed class BankAccount : IBankAccount

    ```

1. Build the `Starter` solution.

1. Notice the error messages that appear in the terminal window.

    Attempting to instantiate a derived class using a sealed base class generates an error. For example:

    ```plaintext

    error CS0509: 'CheckingAccount': cannot derive from sealed type 'BankAccount'

    ```

    Classes that are defined using the `sealed` keyword can't be used as base classes for other classes.

1. Update the BankAccount class definition to remove the `sealed` keyword.

    ```csharp

    public class BankAccount : IBankAccount

    ```

## Implement specialized features in derived classes using properties and constructors

Derived classes can extend the functionality of a base class by adding new properties and constructors that are specific to the derived class. For example, the `CheckingAccount`, `SavingsAccount`, and `MoneyMarketAccount` classes extend `BankAccount` by with features that are specific to their account type:

- `CheckingAccount` initializes an InterestRate of 0.0 percent, a limit on the overdraft amount, and an overdraft fee that's applied to the account if the balance drops below zero.
- `SavingsAccount` initializes an InterestRate of 2.0 percent, a limit on the number of withdrawals per month, and a minimum opening balance requirement.
- `MoneyMarketAccount` initializes an InterestRate of 4.0 percent, a minimum balance requirement, and a minimum opening balance requirement.

In this task, you extend base class functionality by adding feature specific properties and constructors to the derived classes.

Use the following steps to complete this section of the exercise:

1. Open the `CheckingAccount` class.

    `CheckingAccount` extends the `BankAccount` base class with the following features:

    - A public static property named `DefaultOverdraftLimit` that's used to set a overdraft limit for checking accounts (a negative balance limit).
    - A public static property named `DefaultInterestRate` that's used to set the interest rate for checking accounts.
    - A public property named `OverdraftLimit` that's used to get and set the overdraft limit for a checking account. The property should be initialized to the default overdraft limit. Premium customers receive a higher overdraft limit and no overdraft fee.

1. Update the `CheckingAccount` class with the following properties:

    ```csharp

    // public static properties with private setters for default overdraft limit and default interest rate
    public static double DefaultOverdraftLimit { get; private set; }
    public static double DefaultInterestRate { get; private set; }

    // public property for overdraft limit
    public double OverdraftLimit { get; set; }

    ```

    The private setters for the `DefaultOverdraftLimit` and `DefaultInterestRate` properties ensure that the values can only be set within the class.

1. Update the `CheckingAccount` class with a static constructor that initializes the `DefaultOverdraftLimit` and `DefaultInterestRate` properties.

    ```csharp

    static CheckingAccount()
    {
        DefaultOverdraftLimit = 500;
        DefaultInterestRate = 0.0;
    }

    ```

    Static constructors are called automatically before the first instance of a class is created or any static members are referenced. Static read-only properties can be initialized in the static constructor.

1. Update the `CheckingAccount` class constructor to include an `overdraftLimit` parameter that's used to initialize the `OverdraftLimit` property.

    ```csharp

    public CheckingAccount(string customerIdNumber, double balance = 200, double overdraftLimit = 500)
        : base(customerIdNumber, balance, "Checking")
    {
        OverdraftLimit = overdraftLimit;

    }

    ```

    The updated constructor takes three parameters: `customerIdNumber`, `balance`, and `overdraftLimit`. It initializes the `OverdraftLimit` property with the `overdraftLimit` parameter value.

1. Open the `SavingsAccount` class.

    `SavingsAccount` extends the `BankAccount` base class with the following features:

    - A public static property named `DefaultWithdrawalLimit` that's used to set a limit on the number of withdrawals per month.
    - A public static property named `DefaultMinimumOpeningBalance` that's used to set the minimum opening balance requirement for a savings account.
    - A public static property named `DefaultInterestRate` that's used to set the interest rate for savings accounts.
    - A public property named `WithdrawalLimit` that's used to get and set the withdrawal limit for a savings account. The property should be initialized to the default withdrawal limit.
    - A public property named `MinimumOpeningBalance` that's used to get and set the minimum opening balance requirement for a savings account. The property should be initialized to the default minimum opening balance.

1. Update the `SavingsAccount` class with the following fields and properties:

    ```csharp

    // private field to track the number of withdrawals this month
    private int _withdrawalsThisMonth;

    // public static properties with private setters for default withdrawal limit, default minimum opening balance, and default interest rate
    public static int DefaultWithdrawalLimit { get; private set; }
    public static double DefaultMinimumOpeningBalance { get; private set; }
    public static double DefaultInterestRate { get; private set; }

    // public property for withdrawal limit and minimum opening balance
    public int WithdrawalLimit { get; set; }
    public double MinimumOpeningBalance { get; set; }

    ```

    Notice the following about these fields and properties:

    - The `_withdrawalsThisMonth` field tracks the number of withdrawals made from the account in the current month.
    - The `DefaultWithdrawalLimit`, `DefaultMinimumOpeningBalance`, and `DefaultInterestRate` properties have a private setter that ensures the values can only be set within the class.
    - The `WithdrawalLimit` and `MinimumOpeningBalance` properties are public.

1. Update the `SavingsAccount` class with a static constructor that initializes the `DefaultWithdrawalLimit`, `DefaultMinimumOpeningBalance`, and `DefaultInterestRate` properties.

    ```csharp

    static SavingsAccount()
    {
        DefaultWithdrawalLimit = 6;
        DefaultMinimumOpeningBalance = 500;
        DefaultInterestRate = 0.02; // 2 percent interest rate
    }

    ```

1. Update the `SavingsAccount` class with a constructor that enforces a minimum opening balance and sets a limit on the number of withdrawals per month.

    ```csharp

    public SavingsAccount(string customerIdNumber, double balance = 500, int withdrawalLimit = 6)
        : base(customerIdNumber, balance, "Savings")
    {
        if (balance < DefaultMinimumOpeningBalance)
        {
            throw new ArgumentException($"Balance must be at least {DefaultMinimumOpeningBalance}");
        }

        WithdrawalLimit = withdrawalLimit;
        _withdrawalsThisMonth = 0;
        MinimumOpeningBalance = DefaultMinimumOpeningBalance; // Set the minimum opening balance to the default value
    }

    ```

    Notice that the constructor takes three parameters: `customerIdNumber`, `balance`, and `withdrawalLimit`. It initializes the `WithdrawalLimit` property with the `withdrawalLimit` parameter value. The constructor also enforces a minimum opening balance requirement.

1. Open the `MoneyMarketAccount` class.

    `MoneyMarketAccount` extends the `BankAccount` base class with the following features:

    - A public static property named `DefaultInterestRate` that's used to set the interest rate for money market accounts.
    - A public static property named `DefaultMinimumBalance` that's used to set the minimum balance requirement for a money market account.
    - A public static property named `DefaultMinimumOpeningBalance` that's used to set the minimum opening balance requirement for a money market account.
    - A public property named `MinimumBalance` that's used to get and set the minimum balance requirement for a money market account. The property should be initialized to the default minimum balance.
    - A public property named `MinimumOpeningBalance` that's used to get and set the minimum opening balance requirement for a money market account. The property should be initialized to the default minimum opening balance.

1. Update the `MoneyMarketAccount` class with the following properties:

    ```csharp

    // public static properties with private setters for default interest rate, default minimum balance, and default minimum opening balance
    public static double DefaultInterestRate { get; private set; }
    public static double DefaultMinimumBalance { get; private set; }
    public static double DefaultMinimumOpeningBalance { get; private set; }

    // public property for minimum balance and minimum opening balance
    public double MinimumBalance { get; set; }
    public double MinimumOpeningBalance { get; set; }

    ```

1. Update the `MoneyMarketAccount` class with a static constructor that initializes the `DefaultInterestRate`, `DefaultMinimumBalance`, and `DefaultMinimumOpeningBalance` properties.

    ```csharp

    static MoneyMarketAccount()
    {
        DefaultInterestRate = 0.04; // 4 percent interest rate
        DefaultMinimumBalance = 1000; // Default minimum balance
        DefaultMinimumOpeningBalance = 2000; // Default minimum opening balance
    }

    ```

1. Update the `MoneyMarketAccount` class with a constructor that enforces a minimum balance requirement.

    ```csharp

    public MoneyMarketAccount(string customerIdNumber, double balance = 2000, double minimumBalance = 1000)
        : base(customerIdNumber, balance, "Money Market")
    {
        if (balance < DefaultMinimumOpeningBalance)
        {
            throw new ArgumentException($"Balance must be at least {DefaultMinimumOpeningBalance}");
        }

        MinimumBalance = minimumBalance;
        MinimumOpeningBalance = DefaultMinimumOpeningBalance; // Set the minimum opening balance to the default value
    }

    ```

    The constructor takes three parameters: `customerIdNumber`, `balance`, and `minimumBalance`. It initializes the `MinimumBalance` property with the `minimumBalance` parameter value. The constructor also enforces a minimum balance requirement.

1. Build and run the app to verify that the previous output is still generated:

    ```plaintext

    Creating a BankCustomer object for customer Tim Shao...
    
    Using derived classes to create bank account objects for Tim Shao...
    
    Using inherited properties to display Tim Shao's account information...
     - Checking account #13358753 has a balance of $500.00
     - Savings account #13358754 has a balance of $1,000.00
     - Money Market account #13358755 has a balance of $2,000.00
    
    Demonstrating inheritance of the Withdraw, Transfer, and Deposit methods from the base class...
     - Withdraw 200 from Checking account
     - Transfer $200.00 from Savings account into Checking account
     - Deposit $200.00 into Money Market account
     - Checking account #13358753 has a balance of $500.00
     - Savings account #13358754 has a balance of $800.00
     - Money Market account #13358755 has a balance of $2,200.00

    ```

    You'll update the Program.cs file later in this exercise to demonstrate the use of the new properties and constructors.

## Use the new keyword to hide base class methods in derived classes

Derived classes can extend the behavior of a base class by defining a method that has the same name and signature as a base class method. The `new` keyword is used to indicate that the method is intended to hide the base class method.

In this task, you examine the use of the `new` keyword when extending the behavior of a base class method.

Use the following steps to complete this section of the exercise:

1. Open the CheckingAccount.cs file.

1. To duplicate the base class's `DisplayAccountInfo` method in the derived class, add the following code to the end of the `CheckingAccount` class:

    ```csharp

    public string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance}, Interest Rate: {InterestRate}, Customer ID: {CustomerId}";
    }

    ```

    This method is an exact duplicate of the `DisplayAccountInfo` method in the base class.

1. Hover the mouse pointer over the `DisplayAccountInfo` method in `CheckingAccount`.

    When you hover the mouse pointer over the `DisplayAccountInfo` method, you see a warning that indicates the method hides the inherited member `BankAccount.DisplayAccountInfo()`. This warning is generated because the method has the same name and signature as the base class method.

1. Use the following code to customize the method's return value and apply the `new` keyword:

    ```csharp

    public new string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance:C}, Interest Rate: {InterestRate}, Customer ID: {CustomerId} - Checking Accounts have an overdraft limit of {DefaultOverdraftLimit:C}";
    }

    ```

    The `DisplayAccountInfo` method in `CheckingAccount` now returns information specific to the `CheckingAccount` class. The `new` keyword clarifies your intension to hide the base class method. Since your intension is clear, there's no longer a warning message about hiding the base class method.

    The `C` format specifier is used to format currency values in the string that's returned.

1. Open the Program.cs file.

1. Add the following code to the bottom of the `Main` method:

    ```csharp

    // Step 4 - Demonstrate using the 'new' keyword to override a base class method
    Console.WriteLine("\nDemonstrating the use of the 'new' keyword to override a base class method...");

    // Display account information for each account
    Console.WriteLine($" - {checkingAccount1.DisplayAccountInfo()}");
    Console.WriteLine($" - {savingsAccount1.DisplayAccountInfo()}");
    Console.WriteLine($" - {moneyMarketAccount1.DisplayAccountInfo()}");

    ```

    Notice that the `DisplayAccountInfo` method is called on each of the derived classes. The `CheckingAccount` classes uses the new `DisplayAccountInfo` method that hides the base class method, while the `SavingsAccount` and `MoneyMarketAccount` classes are still using the base class method.

1. Run the app and verify that the following output is generated:

    ```plaintext

    Creating a BankCustomer object for customer Tim Shao...
    
    Using derived classes to create bank account objects for Tim Shao...
    
    Using inherited properties to display Tim Shao's account information...
     - Checking account #10866248 has a balance of $500.00
     - Savings account #10866249 has a balance of $1,000.00
     - Money Market account #10866250 has a balance of $2,000.00
    
    Demonstrating inheritance of the Withdraw, Transfer, and Deposit methods from the base class...
     - Withdraw 200 from Checking account
     - Transfer $200.00 from Savings account into Checking account
     - Deposit $200.00 into Money Market account
     - Checking account #10866248 has a balance of $500.00
     - Savings account #10866249 has a balance of $800.00
     - Money Market account #10866250 has a balance of $2,200.00
    
    Demonstrating the use of the 'new' keyword to override a base class method...
     - Account Number: 10866248, Type: Checking, Balance: $500.00, Interest Rate: 0, Customer ID: 0010986337 - Checking Accounts have an overdraft limit of $500.00
     - Account Number: 10866249, Type: Savings, Balance: 800, Interest Rate: 0, Customer ID: 0010986337
     - Account Number: 10866250, Type: Money Market, Balance: 2200, Interest Rate: 0, Customer ID: 0010986337

    ```

## Override properties and methods in derived classes

Derived classes can modify the behavior of a base class by overriding base class properties and methods. For example, you can override the `InterestRate` property and the `Withdraw` method in the `CheckingAccount`, `SavingsAccount`, and `MoneyMarketAccount` classes to implement specialized behavior in your derived classes.

In this task, you override properties and methods in the derived classes to implement specialized behavior.

Use the following steps to complete this section of the exercise:

1. Open the BankAccount.cs file.

1. Use the following code to change the `InterestRate` property from `static` to `virtual`:

    ```csharp

    public virtual double InterestRate { get; protected set; } // Virtual property to allow overriding in derived classes

    ```

    The `virtual` keyword allows the `InterestRate` property to be overridden in derived classes. The `protected` access modifier allows the property to be `set` within the derived classes.

1. To remove the code that initializes the `InterestRate` property in the base class, update the static constructor as follows:

    ```csharp

    static BankAccount()
    {
        Random random = new Random();
        s_nextAccountNumber = random.Next(10000000, 20000000);
        TransactionRate = 0.01; // Default transaction rate for wire transfers and cashier's checks
        MaxTransactionFee = 10; // Maximum transaction fee for wire transfers and cashier's checks
        OverdraftRate = 0.05; // Default penalty rate for an overdrawn checking account (negative balance)
        MaxOverdraftFee = 10; // Maximum overdraft fee for an overdrawn checking account
    }

    ```

1. Use the following code to the make the `Withdraw` method `virtual`:

    ```csharp

    public virtual bool Withdraw(double amount)
    {
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }

    ```

    The `virtual` keyword allows the `Withdraw` method to be overridden in derived classes.

1. Use the following code to make the `DisplayAccountInfo` method `virtual`:

    ```csharp

    public virtual string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance}, Interest Rate: {InterestRate}, Customer ID: {CustomerId}";
    }

    ```

1. Open the CheckingAccount.cs file.

1. Use the following code to override the `Withdraw` method:

    ```csharp

    public override bool Withdraw(double amount)
    {
        if (amount > 0 && Balance + OverdraftLimit >= amount)
        {
            Balance -= amount;

            // Check if the account is overdrawn
            if (Balance < 0)
            {
                double overdraftFee = AccountCalculations.CalculateOverdraftFee(Math.Abs(Balance), BankAccount.OverdraftRate, BankAccount.MaxOverdraftFee);
                Balance -= overdraftFee;
                Console.WriteLine($"Overdraft fee of ${overdraftFee} applied.");
            }

            return true;
        }
        return false;
    }

    ```

    Notice that the `Withdraw` method in the `CheckingAccount` class uses the `OverdraftLimit` property to determine how far below zero the account can be overdrawn. If the account is withdrawal is allowed and the account is overdrawn, an overdraft fee is applied to the balance.

1. Open the SavingsAccount.cs file.

1. Use the following code to override the `Withdraw` method:

    ```csharp

    public override bool Withdraw(double amount)
    {
        if (amount > 0 && Balance >= amount && _withdrawalsThisMonth < WithdrawalLimit)
        {
            Balance -= amount;
            _withdrawalsThisMonth++;
            return true;
        }
        return false;
    }

    ```

    Notice that the `Withdraw` method in the `SavingsAccount` class uses the `_withdrawalsThisMonth` field to track the number of withdrawals made from the account in the current month. If the number of withdrawals exceeds the `WithdrawalLimit`, the method returns `false`.

1. Use the following code to add a method that resets the `_withdrawalsThisMonth` field:

    ```csharp

    public void ResetWithdrawalLimit()
    {
        _withdrawalsThisMonth = 0;
    }

    ```

    This method can be used to reset the `_withdrawalsThisMonth` field to zero. For example, the method can be called at the beginning of each month to reset the withdrawal count.

1. Open the MoneyMarketAccount.cs file.

1. Use the following code to override the `Withdraw` method:

    ```csharp

    public override bool Withdraw(double amount)
    {
        if (amount > 0 && Balance - amount >= MinimumBalance)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }

    ```

    Notice that the `Withdraw` method in the `MoneyMarketAccount` class enforces a minimum balance requirement.

1. Use the following code to override the `InterestRate` property in each of the derived classes:

    ```csharp

    public override double InterestRate
    {
        get { return DefaultInterestRate; }
        protected set { DefaultInterestRate = value; }
    }

    ```

    Each of the derived classes initializes a static `DefaultInterestRate` value that's used by the overridden `InterestRate` property.

    - Checking – interest rate is 0.0%
    - Savings – interest rate is 2.0%
    - MoneyMarket - interest rate is 4.0%

1. Open the Program.cs file.

1. To demonstrate the overridden properties and methods, add the following code to the bottom of the `Main` method:

    ```csharp

    //Step 5: Demonstrate the overridden properties and methods in the derived classes
    Console.WriteLine("\nDemonstrating specialized Withdraw behavior:");

    // CheckingAccount: Withdraw within overdraft limit
    Console.WriteLine("\nCheckingAccount: Attempting to withdraw $600 (within overdraft limit)...");
    checkingAccount1.Withdraw(600);
    Console.WriteLine(checkingAccount1.DisplayAccountInfo());

    // CheckingAccount: Withdraw exceeding overdraft limit
    Console.WriteLine("\nCheckingAccount: Attempting to withdraw $1000 (exceeding overdraft limit)...");
    checkingAccount1.Withdraw(1000);
    Console.WriteLine(checkingAccount1.DisplayAccountInfo());

    // SavingsAccount: Withdraw within limit
    Console.WriteLine("\nSavingsAccount: Attempting to withdraw $200 (within withdrawal limit)...");
    savingsAccount1.Withdraw(200);
    Console.WriteLine(savingsAccount1.DisplayAccountInfo());

    // SavingsAccount: Withdraw exceeding limit
    Console.WriteLine("\nSavingsAccount: Attempting to withdraw $900 (exceeding withdrawal limit)...");
    savingsAccount1.Withdraw(900);
    Console.WriteLine(savingsAccount1.DisplayAccountInfo());

    // SavingsAccount: Exceeding maximum number of withdrawals per month
    Console.WriteLine("\nSavingsAccount: Exceeding maximum number of withdrawals per month...");
    
    savingsAccount1.ResetWithdrawalLimit();

    for (int i = 0; i < 7; i++)
    {
        Console.WriteLine($"Attempting to withdraw $50 (withdrawal {i + 1})...");
        savingsAccount1.Withdraw(50);
        Console.WriteLine(savingsAccount1.DisplayAccountInfo());
    }

    // MoneyMarketAccount: Withdraw within minimum balance
    Console.WriteLine("\nMoneyMarketAccount: Attempting to withdraw $1000 (maintaining minimum balance)...");
    moneyMarketAccount1.Withdraw(1000);
    Console.WriteLine(moneyMarketAccount1.DisplayAccountInfo());

    // MoneyMarketAccount: Withdraw exceeding minimum balance
    Console.WriteLine("\nMoneyMarketAccount: Attempting to withdraw $1900 (exceeding minimum balance)...");
    moneyMarketAccount1.Withdraw(1900);
    Console.WriteLine(moneyMarketAccount1.DisplayAccountInfo());

    ```

    Notice that this code tests the overridden `Withdraw` method in each of the derived classes:

    - The `CheckingAccount` class demonstrates overdraft behavior and fees.
    - The `SavingsAccount` class enforces a positive balance and demonstrates the limited number of monthly withdrawals
    - The `MoneyMarketAccount` class demonstrates the minimum balance requirements.

1. Run the app and verify that the following output is generated:

    ```plaintext

    Creating a BankCustomer object for customer Tim Shao...
    
    Using derived classes to create bank account objects for Tim Shao...
    
    Using inherited properties to display Tim Shao's account information...
     - Checking account #12406201 has a balance of $500.00
     - Savings account #12406202 has a balance of $1,000.00
     - Money Market account #12406203 has a balance of $2,000.00
    
    Demonstrating inheritance of the Withdraw, Transfer, and Deposit methods from the base class...
     - Withdraw 200 from Checking account
     - Transfer $200.00 from Savings account into Checking account
     - Deposit $200.00 into Money Market account
     - Checking account #12406201 has a balance of $500.00
     - Savings account #12406202 has a balance of $800.00
     - Money Market account #12406203 has a balance of $2,200.00
    
    Demonstrating the use of the 'new' keyword to override a base class method...
     - Account Number: 12406201, Type: Checking, Balance: $500.00, Interest Rate: 0, Customer ID: 0010876989 - Checking Accounts have an overdraft limit of $500.00
     - Account Number: 12406202, Type: Savings, Balance: 800, Interest Rate: 0.02, Customer ID: 0010876989
     - Account Number: 12406203, Type: Money Market, Balance: 2200, Interest Rate: 0.04, Customer ID: 0010876989
    
    Demonstrating specialized Withdraw behavior:
    
    CheckingAccount: Attempting to withdraw $600 (within overdraft limit)...
    Overdraft fee of $5 applied.
    Account Number: 12406201, Type: Checking, Balance: ($105.00), Interest Rate: 0, Customer ID: 0010876989 - Checking Accounts have an overdraft limit of $500.00
    
    CheckingAccount: Attempting to withdraw $1000 (exceeding overdraft limit)...
    Account Number: 12406201, Type: Checking, Balance: ($105.00), Interest Rate: 0, Customer ID: 0010876989 - Checking Accounts have an overdraft limit of $500.00
    
    SavingsAccount: Attempting to withdraw $200 (within withdrawal limit)...
    Account Number: 12406202, Type: Savings, Balance: 600, Interest Rate: 0.02, Customer ID: 0010876989
    
    SavingsAccount: Attempting to withdraw $900 (exceeding withdrawal limit)...
    Account Number: 12406202, Type: Savings, Balance: 600, Interest Rate: 0.02, Customer ID: 0010876989
    
    SavingsAccount: Exceeding maximum number of withdrawals per month...
    Attempting to withdraw $50 (withdrawal 1)...
    Account Number: 12406202, Type: Savings, Balance: 550, Interest Rate: 0.02, Customer ID: 0010876989
    Attempting to withdraw $50 (withdrawal 2)...
    Account Number: 12406202, Type: Savings, Balance: 500, Interest Rate: 0.02, Customer ID: 0010876989
    Attempting to withdraw $50 (withdrawal 3)...
    Account Number: 12406202, Type: Savings, Balance: 450, Interest Rate: 0.02, Customer ID: 0010876989
    Attempting to withdraw $50 (withdrawal 4)...
    Account Number: 12406202, Type: Savings, Balance: 400, Interest Rate: 0.02, Customer ID: 0010876989
    Attempting to withdraw $50 (withdrawal 5)...
    Account Number: 12406202, Type: Savings, Balance: 350, Interest Rate: 0.02, Customer ID: 0010876989
    Attempting to withdraw $50 (withdrawal 6)...
    Account Number: 12406202, Type: Savings, Balance: 300, Interest Rate: 0.02, Customer ID: 0010876989
    Attempting to withdraw $50 (withdrawal 7)...
    Account Number: 12406202, Type: Savings, Balance: 300, Interest Rate: 0.02, Customer ID: 0010876989
    
    MoneyMarketAccount: Attempting to withdraw $1000 (maintaining minimum balance)...
    Account Number: 12406203, Type: Money Market, Balance: 1200, Interest Rate: 0.04, Customer ID: 0010876989
    
    MoneyMarketAccount: Attempting to withdraw $1900 (exceeding minimum balance)...
    Account Number: 12406203, Type: Money Market, Balance: 1200, Interest Rate: 0.04, Customer ID: 0010876989

    ```

## Use the base keyword in overridden methods to access base class members

In this task, you use the `base` keyword in overridden methods to access base class members.

Use the following steps to complete this section of the exercise:

1. Open the BankAccount.cs file.

1. Use the following code to update the `DisplayAccountInfo` method with the `virtual` keyword:

    ```csharp

    public virtual string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance:C}, Interest Rate: {InterestRate:P}, Customer ID: {CustomerId}";
    }

    ```

    The `virtual` keyword allows the `DisplayAccountInfo` method to be overridden in derived classes. Currency and percentage values are formatted using the `C` and `P` format specifiers.

1. Open the CheckingAccount.cs file.

1. Use the following code to override the `DisplayAccountInfo` method and use `base` keyword to access the base class's `DisplayAccountInfo` method:

    ```csharp

    public override string DisplayAccountInfo()
    {
        return base.DisplayAccountInfo() + $", Overdraft Limit: {OverdraftLimit}";
    }

    ```

    Using the `base` keyword enables you to reuse the base class's `DisplayAccountInfo` method, which is a best practice. The method appends information specific to the `CheckingAccount` class to the string returned by the base class method.

1. Open the SavingsAccount.cs file.

1. Use the following code to override and extend the base class's `DisplayAccountInfo` method inside the `SavingsAccount` class:

    ```csharp

    public override string DisplayAccountInfo()
    {
        return base.DisplayAccountInfo() + $", Withdrawal Limit: {WithdrawalLimit}, Withdrawals This Month: {_withdrawalsThisMonth}";
    }

    ```

    The `DisplayAccountInfo` method in the `SavingsAccount` class uses the `base` keyword to access the base class's `DisplayAccountInfo` method. The method then appends information specific to the `SavingsAccount` class.

1. Open the MoneyMarketAccount.cs file.

1. Use the following code to override and extend the base class's `DisplayAccountInfo` method inside the `MoneyMarketAccount` class:

    ```csharp

    public override string DisplayAccountInfo()
    {
        return base.DisplayAccountInfo() + $", Minimum Balance: {MinimumBalance}, Minimum Opening Balance: {MinimumOpeningBalance}";
    }

    ```

    The `DisplayAccountInfo` method in the `MoneyMarketAccount` class uses the `base` keyword to access the base class's `DisplayAccountInfo` method. The method then appends information specific to the `MoneyMarketAccount` class.

1. Run the app and verify that the following output is generated:

    ```plaintext

    Creating a BankCustomer object for customer Tim Shao...
    
    Using derived classes to create bank account objects for Tim Shao...
    
    Using inherited properties to display Tim Shao's account information...
     - Checking account #12552069 has a balance of $500.00
     - Savings account #12552070 has a balance of $1,000.00
     - Money Market account #12552071 has a balance of $2,000.00
    
    Demonstrating inheritance of the Withdraw, Transfer, and Deposit methods from the base class...
     - Withdraw 200 from Checking account
     - Transfer $200.00 from Savings account into Checking account
     - Deposit $200.00 into Money Market account
     - Checking account #12552069 has a balance of $500.00
     - Savings account #12552070 has a balance of $800.00
     - Money Market account #12552071 has a balance of $2,200.00
    
    Demonstrating the use of the 'new' keyword to override a base class method...
     - Account Number: 12552069, Type: Checking, Balance: $500.00, Interest Rate: 0.00%, Customer ID: 0013536499, Overdraft Limit: 500
     - Account Number: 12552070, Type: Savings, Balance: $800.00, Interest Rate: 2.00%, Customer ID: 0013536499, Withdrawal Limit: 6, Withdrawals This Month: 1
     - Account Number: 12552071, Type: Money Market, Balance: $2,200.00, Interest Rate: 4.00%, Customer ID: 0013536499, Minimum Balance: 1000, Minimum Opening Balance: 2000
    
    Demonstrating specialized Withdraw behavior:
    
    CheckingAccount: Attempting to withdraw $600 (within overdraft limit)...
    Overdraft fee of $5 applied.
    Account Number: 12552069, Type: Checking, Balance: ($105.00), Interest Rate: 0.00%, Customer ID: 0013536499, Overdraft Limit: 500
    
    CheckingAccount: Attempting to withdraw $1000 (exceeding overdraft limit)...
    Account Number: 12552069, Type: Checking, Balance: ($105.00), Interest Rate: 0.00%, Customer ID: 0013536499, Overdraft Limit: 500
    
    SavingsAccount: Attempting to withdraw $200 (within withdrawal limit)...
    Account Number: 12552070, Type: Savings, Balance: $600.00, Interest Rate: 2.00%, Customer ID: 0013536499, Withdrawal Limit: 6, Withdrawals This Month: 2
    
    SavingsAccount: Attempting to withdraw $900 (exceeding withdrawal limit)...
    Account Number: 12552070, Type: Savings, Balance: $600.00, Interest Rate: 2.00%, Customer ID: 0013536499, Withdrawal Limit: 6, Withdrawals This Month: 2
    
    SavingsAccount: Exceeding maximum number of withdrawals per month...
    Attempting to withdraw $50 (withdrawal 1)...
    Account Number: 12552070, Type: Savings, Balance: $550.00, Interest Rate: 2.00%, Customer ID: 0013536499, Withdrawal Limit: 6, Withdrawals This Month: 1
    Attempting to withdraw $50 (withdrawal 2)...
    Account Number: 12552070, Type: Savings, Balance: $500.00, Interest Rate: 2.00%, Customer ID: 0013536499, Withdrawal Limit: 6, Withdrawals This Month: 2
    Attempting to withdraw $50 (withdrawal 3)...
    Account Number: 12552070, Type: Savings, Balance: $450.00, Interest Rate: 2.00%, Customer ID: 0013536499, Withdrawal Limit: 6, Withdrawals This Month: 3
    Attempting to withdraw $50 (withdrawal 4)...
    Account Number: 12552070, Type: Savings, Balance: $400.00, Interest Rate: 2.00%, Customer ID: 0013536499, Withdrawal Limit: 6, Withdrawals This Month: 4
    Attempting to withdraw $50 (withdrawal 5)...
    Account Number: 12552070, Type: Savings, Balance: $350.00, Interest Rate: 2.00%, Customer ID: 0013536499, Withdrawal Limit: 6, Withdrawals This Month: 5
    Attempting to withdraw $50 (withdrawal 6)...
    Account Number: 12552070, Type: Savings, Balance: $300.00, Interest Rate: 2.00%, Customer ID: 0013536499, Withdrawal Limit: 6, Withdrawals This Month: 6
    Attempting to withdraw $50 (withdrawal 7)...
    Account Number: 12552070, Type: Savings, Balance: $300.00, Interest Rate: 2.00%, Customer ID: 0013536499, Withdrawal Limit: 6, Withdrawals This Month: 6
    
    MoneyMarketAccount: Attempting to withdraw $1000 (maintaining minimum balance)...
    Account Number: 12552071, Type: Money Market, Balance: $1,200.00, Interest Rate: 4.00%, Customer ID: 0013536499, Minimum Balance: 1000, Minimum Opening Balance: 2000
    
    MoneyMarketAccount: Attempting to withdraw $1900 (exceeding minimum balance)...
    Account Number: 12552071, Type: Money Market, Balance: $1,200.00, Interest Rate: 4.00%, Customer ID: 0013536499, Minimum Balance: 1000, Minimum Opening Balance: 2000

    ```

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Also, building up a portfolio of projects can be a great way to demonstrate your skills to potential employers.
