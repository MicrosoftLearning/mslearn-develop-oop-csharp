---
lab:
  title: Exercise - Implement polymorphism in a C# app
  description: Learn the principles of polymorphism and how to implement polymorphic
    behavior in C# apps using interface-based and inheritance-based approaches.
  duration: 30 minutes
  level: 100
  islab: true
---

# Implement polymorphism in a C# app

Polymorphism is a fundamental concept in object-oriented programming that allows you to treat derived classes as instances of their base class. In C#, you can implement polymorphic behavior using interface implementation and class inheritance.

In this exercise, you update an existing app to demonstrate interface-based and inheritance-based polymorphic behavior.

This exercise takes approximately **30** minutes to complete.

## Before you start

Before you can start this exercise, you need to:

1. Ensure that you have the latest short term support (STS) version of the .NET SDK installed on your computer. You can download the latest versions of the .NET SDK using the following URL: <a href="https://dotnet.microsoft.com/download/" target="_blank">Download .NET</a>

1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code using the following URL: <a href="https://code.visualstudio.com/download/" target="_blank">Download Visual Studio Code</a>

1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For additional help configuring the Visual Studio Code environment, see <a href="https://learn.microsoft.com/training/modules/install-configure-visual-studio-code/" target="_blank">Install and configure Visual Studio Code for C# development</a>

## Exercise scenario

Suppose you're helping a non-profit company with a software project. You've decided to sharpen your object-oriented programming skills by creating a banking app. You've developed an initial version of the app that includes the following files:

- AccountCalculations.cs: This file contains static utility methods for various financial calculations, such as compound interest, transaction fees, overdraft fees, and currency exchange.

- BankAccount.cs: This file defines the BankAccount class, implementing the IBankAccount interface and including properties, constructors, methods for account operations, and a copy constructor.

- BankCustomer.cs: This file defines the BankCustomer class, with properties for first name, last name, and a unique customer ID. It includes methods to return the full name, update the customer's name, and display customer information. It also maintains a static property for the next customer ID.

- BankCustomerMethods.cs: This file implements the methods defined in the IBankCustomer interface for the BankCustomer class, including methods to return full name, update name, and display customer information.

- CheckingAccount.cs: This file defines the CheckingAccount class, which inherits from the BankAccount class and includes properties and methods specific to checking accounts, such as an overdraft limit.

- Extensions.cs: This file contains extension methods for IBankCustomer and IBankAccount interfaces, providing additional functionality such as validation and greeting. For BankCustomer, it includes methods to check if the customer ID is valid and to greet the customer. For BankAccount, it includes methods to check if the account is overdrawn and if a specified amount can be withdrawn.

- IBankAccount.cs: This file defines the IBankAccount interface, specifying the properties and methods that a bank account class must implement.

- IBankCustomer.cs: This file defines the IBankCustomer interface, specifying the properties and methods that a bank customer class must implement.

- MoneyMarketAccount.cs: This file defines the MoneyMarketAccount class, which inherits from the BankAccount class and includes properties and methods specific to money market accounts, such as a minimum balance requirement.

- Program.cs: This file contains the main entry point of the application, demonstrating the creation and manipulation of objects created using base and derived classes, as well as various operations like deposits, withdrawals, and transfers.

- SavingsAccount.cs: This file defines the SavingsAccount class, which inherits from the BankAccount class and includes properties and methods specific to savings accounts, such as a withdrawal limit.

This exercise includes the following tasks:

1. Review the current version of your banking app.

1. Create interfaces that support monthly, quarterly, and yearly reporting.

1. Create classes that support customer and account reporting.

1. Implement interface-based polymorphic behavior using reporting interfaces.

1. Implement inheritance-based polymorphic behavior using the base and derived account classes.

## Review the current version of your banking app

In this task, you download the existing version of your banking app and review the code.

Use the following steps to complete this section of the exercise:

1. Download the starter code from the following URL: [Implement inheritance and polymorphism - exercise code projects](https://github.com/MicrosoftLearning/mslearn-develop-oop-csharp/raw/refs/heads/main/DownloadableCodeProjects/Downloads/LP3SampleApps.zip)

1. Extract the contents of the LP3SampleApps.zip file to a folder location on your computer.

1. Expand the LP3SampleApps folder, and then open the `Reuse_M2` folder.

    The Reuse_M2 folder contains the following code project folders:

    - Solution
    - Starter

    The **Starter** folder contains the starter project files for this exercise.

1. Use Visual Studio Code to open the **Starter** folder.

1. In the EXPLORER view, collapse the **STARTER** folder, select **SOLUTION EXPLORER**, and expand the **Reuse_M2** project.

    You should see the following project files:

    - AccountCalculations.cs
    - BankAccount.cs
    - BankCustomer.cs
    - BankCustomerMethods.cs
    - CheckingAccount.cs
    - Extensions.cs
    - IBankAccount.cs
    - IBankCustomer.cs
    - MoneyMarketAccount.cs
    - Program.cs
    - SavingsAccount.cs

1. Take a few minutes to open and review each of the files.

    - `AccountCalculations.cs`: This file contains static utility methods for various financial calculations, such as compound interest, transaction fees, overdraft fees, and currency exchange.

    - `BankAccount.cs`: This file defines the BankAccount class, implementing the IBankAccount interface and including properties, constructors, methods for account operations, and a copy constructor.

    - `BankCustomer.cs`: This file defines the BankCustomer class, implementing the IBankCustomer interface and including properties, constructors, and a copy constructor.

    - `BankCustomerMethods.cs`: This file implements the methods defined in the IBankCustomer interface for the BankCustomer class, including methods to return full name, update name, and display customer information.

    - `CheckingAccount.cs`: This file defines the CheckingAccount class, which inherits from the BankAccount class and includes properties and methods specific to checking accounts.

    - `Extensions.cs`: This file contains extension methods for IBankCustomer and IBankAccount interfaces, providing additional functionality such as validation and greeting.

    - `IBankAccount.cs`: This file defines the IBankAccount interface, specifying the properties and methods that a bank account class must implement.

    - `IBankCustomer.cs`: This file defines the IBankCustomer interface, specifying the properties and methods that a bank customer class must implement.

    - `MoneyMarketAccount.cs`: This file defines the MoneyMarketAccount class, which inherits from the BankAccount class and includes properties and methods specific to money market accounts.

    - `Program.cs`: This file contains the main entry point of the application, demonstrating the creation and manipulation of BankCustomer and BankAccount objects, as well as various operations like deposits, withdrawals, and transfers.

    - `SavingsAccount.cs`: This file defines the SavingsAccount class, which inherits from the BankAccount class and includes properties and methods specific to savings accounts.

1. Run the app and review the output in the terminal window.

    To run your app, right-click the **Reuse_M2** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    Your app should produce output that's similar to the following example:

    ```plaintext

    Creating a BankCustomer object for customer Tim Shao...
    
    Using derived classes to create bank account objects for Tim Shao...
    
    Using inherited properties to display Tim Shao's account information...
     - Checking account #15206065 has a balance of $500.00
     - Savings account #15206066 has a balance of $1,000.00
     - Money Market account #15206067 has a balance of $2,000.00
    
    Demonstrating inheritance of the Withdraw, Transfer, and Deposit methods from the base class...
     - Withdraw 200 from Checking account
     - Transfer $200.00 from Savings account into Checking account
     - Deposit $200.00 into Money Market account
     - Checking account #15206065 has a balance of $500.00
     - Savings account #15206066 has a balance of $800.00
     - Money Market account #15206067 has a balance of $2,200.00
    
    Demonstrating the use of the 'new' keyword to override a base class method...
     - Account Number: 15206065, Type: Checking, Balance: $500.00, Interest Rate: 0.00%, Customer ID: 0011540449, Overdraft Limit: 500
     - Account Number: 15206066, Type: Savings, Balance: $800.00, Interest Rate: 2.00%, Customer ID: 0011540449, Withdrawal Limit: 6, Withdrawals This Month: 1
     - Account Number: 15206067, Type: Money Market, Balance: $2,200.00, Interest Rate: 4.00%, Customer ID: 0011540449, Minimum Balance: 1000, Minimum Opening Balance: 2000
    
    Demonstrating specialized Withdraw behavior:
    
    CheckingAccount: Attempting to withdraw $600 (within overdraft limit)...
    Overdraft fee of $5 applied.
    Account Number: 15206065, Type: Checking, Balance: ($105.00), Interest Rate: 0.00%, Customer ID: 0011540449, Overdraft Limit: 500
    
    CheckingAccount: Attempting to withdraw $1000 (exceeding overdraft limit)...
    Account Number: 15206065, Type: Checking, Balance: ($105.00), Interest Rate: 0.00%, Customer ID: 0011540449, Overdraft Limit: 500
    
    SavingsAccount: Attempting to withdraw $200 (within withdrawal limit)...
    Account Number: 15206066, Type: Savings, Balance: $600.00, Interest Rate: 2.00%, Customer ID: 0011540449, Withdrawal Limit: 6, Withdrawals This Month: 2
    
    SavingsAccount: Attempting to withdraw $900 (exceeding withdrawal limit)...
    Account Number: 15206066, Type: Savings, Balance: $600.00, Interest Rate: 2.00%, Customer ID: 0011540449, Withdrawal Limit: 6, Withdrawals This Month: 2
    
    SavingsAccount: Exceeding maximum number of withdrawals per month...
    Attempting to withdraw $50 (withdrawal 1)...
    Account Number: 15206066, Type: Savings, Balance: $550.00, Interest Rate: 2.00%, Customer ID: 0011540449, Withdrawal Limit: 6, Withdrawals This Month: 1
    Attempting to withdraw $50 (withdrawal 2)...
    Account Number: 15206066, Type: Savings, Balance: $500.00, Interest Rate: 2.00%, Customer ID: 0011540449, Withdrawal Limit: 6, Withdrawals This Month: 2
    Attempting to withdraw $50 (withdrawal 3)...
    Account Number: 15206066, Type: Savings, Balance: $450.00, Interest Rate: 2.00%, Customer ID: 0011540449, Withdrawal Limit: 6, Withdrawals This Month: 3
    Attempting to withdraw $50 (withdrawal 4)...
    Account Number: 15206066, Type: Savings, Balance: $400.00, Interest Rate: 2.00%, Customer ID: 0011540449, Withdrawal Limit: 6, Withdrawals This Month: 4
    Attempting to withdraw $50 (withdrawal 5)...
    Account Number: 15206066, Type: Savings, Balance: $350.00, Interest Rate: 2.00%, Customer ID: 0011540449, Withdrawal Limit: 6, Withdrawals This Month: 5
    Attempting to withdraw $50 (withdrawal 6)...
    Account Number: 15206066, Type: Savings, Balance: $300.00, Interest Rate: 2.00%, Customer ID: 0011540449, Withdrawal Limit: 6, Withdrawals This Month: 6
    Attempting to withdraw $50 (withdrawal 7)...
    Account Number: 15206066, Type: Savings, Balance: $300.00, Interest Rate: 2.00%, Customer ID: 0011540449, Withdrawal Limit: 6, Withdrawals This Month: 6
    
    MoneyMarketAccount: Attempting to withdraw $1000 (maintaining minimum balance)...
    Account Number: 15206067, Type: Money Market, Balance: $1,200.00, Interest Rate: 4.00%, Customer ID: 0011540449, Minimum Balance: 1000, Minimum Opening Balance: 2000
    
    MoneyMarketAccount: Attempting to withdraw $1900 (exceeding minimum balance)...
    Account Number: 15206067, Type: Money Market, Balance: $1,200.00, Interest Rate: 4.00%, Customer ID: 0011540449, Minimum Balance: 1000, Minimum Opening Balance: 2000

    ```

    The customer IDs and account numbers in your output will be different from the example output. Remember that they're sequential values based on a randomly generated initial value.

## Create interfaces that support monthly, quarterly, and yearly reporting

You need to practice implementing interface-based polymorphism, but the existing app relies primarily on class inheritance. You decide to add reporting capabilities to your banking app. The reporting interfaces will define a set of methods that represent monthly, quarterly, and yearly reporting periods. Initially, the interfaces will be implemented by classes that generate reports for bank customers and bank accounts. In the future, the same interfaces could also be applied to other classes, such as bank branches or financial products. This makes the reporting interfaces a good candidate for practicing interface-based polymorphism.

In this task, you create the following interfaces:

- IMonthlyReportable: This interface defines methods for generating reports that cover a full month, a partial month, and a 30 day period.
- IQuarterlyReportable: This interface defines a method for generating a report that covers three month period.
- IYearlyReportable: This interface defines methods for generating reports that cover a full year, a partial year, and a 365 day period.

Use the following steps to complete this section of the exercise:

1. Create a new interface file named `IMonthlyReportGenerator.cs`.

1. Update the `IMonthlyReportGenerator.cs` file using the following code:

    ```csharp

    using System;

    namespace Reuse_M2;

    public interface IMonthlyReportGenerator
    {
        void GenerateMonthlyReport(); // Generates a report for a complete month
        void GenerateCurrentMonthToDateReport(); // Generates a report for the current month up to the current date
        void GeneratePrevious30DayReport(); // Generates a report for the previous 30 day period
    }

    ```

1. Create a new interface file named `IQuarterlyReportGenerator.cs`.

1. Update the `IQuarterlyReportGenerator.cs` file using the following code:

    ```csharp

    using System;

    namespace Reuse_M2;

    public interface IQuarterlyReportGenerator
    {
        void GenerateQuarterlyReport(); // Generates a report for a complete three-month period (Jan-Mar, Apr-Jun, Jul-Sep, Oct-Dec)
    }

    ```

1. Create a new interface file named `IYearlyReportGenerator.cs`.

1. Update the `IYearlyReportGenerator.cs` file using the following code:

    ```csharp

    using System;

    namespace Reuse_M2;

    public interface IYearlyReportGenerator
    {
        void GeneratePreviousYearReport(); // Generates a report for the previous year
        void GenerateCurrentYearToDateReport(); // Generates a report for the current year up to the current date
        void GenerateLast365DaysReport(); // Generates a report for the previous 365 days
    }

    ```

1. Create a folder under the `Reuse_M2` project named `Interfaces`.

1. Move all of your interface files into the `Interfaces` folder.

    Placing your interface files in a separate folder will help you keep your project organized. You can drag and drop the `IBankAccount.cs`, `IBankCustomer.cs`, `IMonthlyReportGenerator.cs`, `IQuarterlyReportGenerator.cs`, and `IYearlyReportGenerator.cs` files into the `Interfaces` folder.

## Create classes that support customer and account reporting

You need to create classes that implement the reporting interfaces you created in the previous task. The classes will include methods that generate reports for different time periods, such as monthly, quarterly, and yearly reports. The classes will accept a bank customer or bank account object as a parameter and use the object's properties to generate the reports.

In this task, you create AccountReportGenerator and CustomerReportGenerator classes that implement the reporting interfaces you created in the previous task.

Use the following steps to complete this section of the exercise:

1. Create a new class file named `CustomerReportGenerator.cs`.

1. Update the `CustomerReportGenerator.cs` file using the following code:

    ```csharp

    using System;
    
    namespace Reuse_M2;
    
    public class CustomerReportGenerator : IMonthlyReportGenerator, IQuarterlyReportGenerator, IYearlyReportGenerator
    {
        private readonly IBankCustomer _customer;
    
        public CustomerReportGenerator(IBankCustomer customer)
        {
            _customer = customer;
        }
    
        public void GenerateMonthlyReport()
        {
            Console.WriteLine($"Generating monthly report for customer: {_customer.ReturnFullName()}");
            // Logic for generating monthly report based on transaction history
        }
    
        public void GenerateCurrentMonthToDateReport()
        {
            Console.WriteLine($"Generating current month-to-date report for customer: {_customer.ReturnFullName()}");
            // Logic for generating current month-to-date report based on transaction history
        }
    
        public void GeneratePrevious30DayReport()
        {
            Console.WriteLine($"Generating previous month report for customer: {_customer.ReturnFullName()}");
            // Logic for generating previous month report based on transaction history
        }
    
        public void GenerateQuarterlyReport()
        {
            Console.WriteLine($"Generating quarterly report for customer: {_customer.ReturnFullName()}");
            // Logic for generating quarterly report based on transaction history
        }
    
        public void GeneratePreviousYearReport()
        {
            Console.WriteLine($"Generating previous year report for customer: {_customer.ReturnFullName()}");
            // Logic for generating previous year report based on transaction history
        }
    
        public void GenerateCurrentYearToDateReport()
        {
            Console.WriteLine($"Generating current year-to-date report for customer: {_customer.ReturnFullName()}");
            // Logic for generating current year-to-date report based on transaction history
        }
    
        public void GenerateLast365DaysReport()
        {
            Console.WriteLine($"Generating last 365 days report for customer: {_customer.ReturnFullName()}");
            // Logic for generating last 365 days report based on transaction history
        }
    }
    ```

    Notice that the `CustomerReportGenerator` class accepts a single parameter of type `IBankCustomer` that it uses to initialize a private read-only field named `_customer`. The class implements the `IMonthlyReportGenerator`, `IQuarterlyReportGenerator`, and `IYearlyReportGenerator` interfaces, and it defines a method for each of the methods required by the interfaces. Rather than including the logic for generating actual reports, the methods simply output a message to the console that indicates the type of report and the name of the customer. This is enough to demonstrate that the methods are being called correctly.

1. Create a new class file named `AccountReportGenerator.cs`.

1. Update the `AccountReportGenerator.cs` file using the following code:

    ```csharp

    using System;
    
    namespace Reuse_M2;
    
    public class AccountReportGenerator : IMonthlyReportGenerator, IQuarterlyReportGenerator, IYearlyReportGenerator
    {
        private readonly IBankAccount _account;
    
        public AccountReportGenerator(IBankAccount account)
        {
            _account = account;
        }
    
        public void GenerateMonthlyReport()
        {
            Console.WriteLine($"Generating monthly report for {_account.AccountType} account number: {_account.AccountNumber}");
            // Logic for generating monthly report based on transaction history
        }
    
        public void GenerateCurrentMonthToDateReport()
        {
            Console.WriteLine($"Generating current month-to-date report for {_account.AccountType} account number: {_account.AccountNumber}");
            // Logic for generating current month-to-date report based on transaction history
        }
    
        public void GeneratePrevious30DayReport()
        {
            Console.WriteLine($"Generating previous month report for for {_account.AccountType} account number: {_account.AccountNumber}");
            // Logic for generating previous month report based on transaction history
        }
    
        public void GenerateQuarterlyReport()
        {
            Console.WriteLine($"Generating quarterly report for {_account.AccountType} account number: {_account.AccountNumber}");
            // Logic for generating quarterly report based on transaction history
        }
    
        public void GeneratePreviousYearReport()
        {
            Console.WriteLine($"Generating previous year report for {_account.AccountType} account number: {_account.AccountNumber}");
            // Logic for generating previous year report based on transaction history
        }
    
        public void GenerateCurrentYearToDateReport()
        {
            Console.WriteLine($"Generating current year-to-date report for {_account.AccountType} account number: {_account.AccountNumber}");
            // Logic for generating current year-to-date report based on transaction history
        }
    
        public void GenerateLast365DaysReport()
        {
            Console.WriteLine($"Generating last 365 days report for {_account.AccountType} account number: {_account.AccountNumber}");
            // Logic for generating last 365 days report based on transaction history
        }
    }

    ```

    Notice that the `AccountReportGenerator` class accepts a single parameter of type `IBankAccount` that it uses to initialize a private read-only field named `_account`. The class implements the `IMonthlyReportGenerator`, `IQuarterlyReportGenerator`, and `IYearlyReportGenerator` interfaces, and it defines a method for each of the methods required by the interfaces. Rather than including the logic for generating actual reports, the methods simply output a message to the console that indicates the type of report, the account type, and the account number. This is enough to demonstrate that the methods are being called correctly.

1. Create a folder under the `Reuse_M2` project named `Services`.

1. Move the `AccountCalculations.cs`, `AccountReportGenerator.cs`, `CustomerReportGenerator.cs`, and `Extensions.cs` files into the `Services` folder.

1. Create a folder under the `Reuse_M2` project named `Models`.

1. Move the `BankAccount.cs`, `BankCustomer.cs`, `BankCustomerMethods.cs`, `CheckingAccount.cs`, `MoneyMarketAccount.cs`, and `SavingsAccount.cs` files into the `Models` folder.

Creating folders that help organize project files makes it easier to find and maintain specific files when you need to make changes. You can organize files by type, such as interfaces, services, and models, or by feature, such as customer-related files, account-related files, and report-related files.

## Implement interface-based polymorphic behavior using the reporting interfaces

Interface-based polymorphism allows you to treat objects of different classes as instances of a common interface.

In this task, you'll use the Program.cs file to demonstrate polymorphic behavior using the reporting classes.

Use the following steps to complete this section of the exercise:

1. Open the Program.cs file.

1. Replace the contents of the Program.cs file with the following code:

    ```csharp

    using Reuse_M2;
    using System.Globalization;
    
    class Program
    {
        static void Main()
        {
    
        }
    }

    ```

1. To demonstrate interface-based polymorphic behavior, add the following code to the `Main` method.

    ```csharp

    // Demonstrate polymorphism using interfaces
    Console.WriteLine("Demonstrating polymorphism by treating class types as instances of the same interface...");

    string firstName = "Sandy";
    string lastName = "Zoeng";

    // Create an instance of IBankCustomer using BankCustomer
    IBankCustomer customer1 = new BankCustomer(firstName, lastName);

    // Create instances of IBankAccount that reference base and derived class types
    Console.WriteLine("1. Create instances of IBankAccount that reference base and derived class types");
    IBankAccount account1 = new BankAccount(customer1.CustomerId, 10000);
    IBankAccount account2 = new CheckingAccount(customer1.CustomerId, 500, 400);
    IBankAccount account3 = new SavingsAccount(customer1.CustomerId, 1000);

    // Demonstrate polymorphism by treating different types of accounts as instances of the same interface.
    Console.WriteLine("2. Demonstrate polymorphism by treating different types of accounts as instances of the same interface");
    Console.WriteLine(account1.DisplayAccountInfo());
    Console.WriteLine(account2.DisplayAccountInfo());
    Console.WriteLine(account3.DisplayAccountInfo());

    // Demonstrate interface-based polymorphism by creating instances of AccountReportGenerator and CustomerReportGenerator
    Console.WriteLine("\nDemonstrating interface-based polymorphism...");

    // Create instances of IReportGenerator using interfaces
    Console.WriteLine("1. Create instances of IMonthlyReportGenerator, IQuarterlyReportGenerator, and IYearlyReportGenerator that reference CustomerReportGenerator and AccountReportGenerator");        
    IMonthlyReportGenerator customerMonthlyReportGenerator = new CustomerReportGenerator(customer1);
    IQuarterlyReportGenerator customerQuarterlyReportGenerator = new CustomerReportGenerator(customer1);
    IYearlyReportGenerator customerYearlyReportGenerator = new CustomerReportGenerator(customer1);

    IMonthlyReportGenerator accountMonthlyReportGenerator = new AccountReportGenerator(account1);
    IQuarterlyReportGenerator accountQuarterlyReportGenerator = new AccountReportGenerator(account1);
    IYearlyReportGenerator accountYearlyReportGenerator = new AccountReportGenerator(account1);

    Console.WriteLine("2. Demonstrate polymorphism by showing that different report generators can be used interchangeably through their interfaces.");
    customerMonthlyReportGenerator.GenerateMonthlyReport();
    customerMonthlyReportGenerator.GenerateCurrentMonthToDateReport();
    customerMonthlyReportGenerator.GeneratePrevious30DayReport();
    customerQuarterlyReportGenerator.GenerateQuarterlyReport();
    customerYearlyReportGenerator.GeneratePreviousYearReport();
    customerYearlyReportGenerator.GenerateCurrentYearToDateReport();
    customerYearlyReportGenerator.GenerateLast365DaysReport();

    accountMonthlyReportGenerator.GenerateMonthlyReport();
    accountMonthlyReportGenerator.GenerateCurrentMonthToDateReport();
    accountMonthlyReportGenerator.GeneratePrevious30DayReport();
    accountQuarterlyReportGenerator.GenerateQuarterlyReport();
    accountYearlyReportGenerator.GeneratePreviousYearReport();
    accountYearlyReportGenerator.GenerateCurrentYearToDateReport();
    accountYearlyReportGenerator.GenerateLast365DaysReport();

    ```

1. Run the app and verify that your reports are generated correctly.

    To run your app, right-click the **Reuse_M2** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    Your app should produce output that's similar to the following example:

    ```plaintext

    Demonstrating polymorphism by treating class types as instances of the same interface...
    1. Create instances of IBankAccount that reference base and derived class types
    2. Demonstrate polymorphism by treating different types of accounts as instances of the same interface
    Account Number: 17283405, Type: Checking, Balance: $10,000.00, Interest Rate: 0.00%, Customer ID: 0015561220
    Account Number: 17283406, Type: Checking, Balance: $500.00, Interest Rate: 0.00%, Customer ID: 0015561220, Overdraft Limit: 400
    Account Number: 17283407, Type: Savings, Balance: $1,000.00, Interest Rate: 2.00%, Customer ID: 0015561220, Withdrawal Limit: 6, Withdrawals This Month: 0
    
    Demonstrating interface-based polymorphism...
    1. Create instances of IMonthlyReportGenerator, IQuarterlyReportGenerator, and IYearlyReportGenerator that reference CustomerReportGenerator and AccountReportGenerator
    2. Demonstrate polymorphism by showing that different report generators can be used interchangeably through their interfaces.
    Generating monthly report for customer: Sandy Zoeng
    Generating current month-to-date report for customer: Sandy Zoeng
    Generating previous month report for customer: Sandy Zoeng
    Generating quarterly report for customer: Sandy Zoeng
    Generating previous year report for customer: Sandy Zoeng
    Generating current year-to-date report for customer: Sandy Zoeng
    Generating last 365 days report for customer: Sandy Zoeng
    Generating monthly report for Checking account number: 17283405
    Generating current month-to-date report for Checking account number: 17283405
    Generating previous month report for for Checking account number: 17283405
    Generating quarterly report for Checking account number: 17283405
    Generating previous year report for Checking account number: 17283405
    Generating current year-to-date report for Checking account number: 17283405
    Generating last 365 days report for Checking account number: 17283405

    ```

## Implement inheritance-based polymorphic behavior using the base and derived account classes

Inheritance-based polymorphism allows you to treat derived classes as instances of their base class. In this task, you'll demonstrate inheritance-based polymorphic behavior using BankAccount and the derived account classes.

Use the following steps to complete this section of the exercise:

1. Take a few minutes to review the BankAccount.cs, CheckingAccount.cs, SavingsAccount.cs, and MoneyMarketAccount.cs files.

    - `BankAccount.cs`: This file defines the BankAccount class, implementing the IBankAccount interface and including properties, constructors, methods for account operations, and a copy constructor.

    - `CheckingAccount.cs`: This file defines the CheckingAccount class, which inherits from the BankAccount class and includes properties and methods specific to checking accounts.

    - `SavingsAccount.cs`: This file defines the SavingsAccount class, which inherits from the BankAccount class and includes properties and methods specific to savings accounts.

    - `MoneyMarketAccount.cs`: This file defines the MoneyMarketAccount class, which inherits from the BankAccount class and includes properties and methods specific to money market accounts.

    Notice that the derived account classes are designed to support polymorphic behavior. Each derived class overrides the `DisplayAccountInfo` method to provide account-specific information. The derived classes also override the `Withdraw` method to implement specialized withdrawal behavior.

1. Open the Program.cs file.

1. To demonstrate class-based polymorphic behavior, replace the contents of the the Program.cs file with the following code:

    ```csharp

    using Reuse_M2;
    using System.Globalization;
    
    class Program
    {
        static void Main()
        {
            // Demonstrate inheritance-based polymorphism
            Console.WriteLine("\nDemonstrating inheritance-based polymorphism...");
            // Create a new customer and accounts for inheritance-based polymorphism
            Console.WriteLine("Creating BankCustomer and BankAccount objects...");
            string firstName = "Tim";
            string lastName = "Shao";
            BankCustomer customer2 = new BankCustomer(firstName, lastName);
    
            // Create accounts for customer1
            Console.WriteLine("Creating BankAccount objects for customer1...");
            BankAccount bankAccount1 = new BankAccount(customer2.CustomerId, 10000);
            BankAccount bankAccount2 = new CheckingAccount(customer2.CustomerId, 500, 400);
            BankAccount bankAccount3 = new SavingsAccount(customer2.CustomerId, 1000);
            BankAccount bankAccount4 = new MoneyMarketAccount(customer2.CustomerId, 2000);
    
            BankAccount[] bankAccounts = new BankAccount[4];
    
            bankAccounts[0] = bankAccount1;
            bankAccounts[1] = bankAccount2;
            bankAccounts[2] = bankAccount3;
            bankAccounts[3] = bankAccount4;
    
            // Demonstrate polymorphism by accessing overridden methods from the base class reference
            Console.WriteLine("\nDemonstrating polymorphism by accessing overridden methods from the base class reference:");
    
            foreach (BankAccount account in bankAccounts)
            {
                Console.WriteLine(account.DisplayAccountInfo());
            }
    
            foreach (BankAccount account in bankAccounts)
            {
                if (account is CheckingAccount checkingAccount)
                {
                    // CheckingAccount: Withdraw within overdraft limit
                    Console.WriteLine("\nCheckingAccount: Attempting to withdraw $600 (within overdraft limit)...");
                    checkingAccount.Withdraw(600);
                    Console.WriteLine(checkingAccount.DisplayAccountInfo());
    
                    // CheckingAccount: Withdraw exceeding overdraft limit
                    Console.WriteLine("\nCheckingAccount: Attempting to withdraw $1000 (exceeding overdraft limit)...");
                    checkingAccount.Withdraw(1000);
                    Console.WriteLine(checkingAccount.DisplayAccountInfo());
                }
                else if (account is SavingsAccount savingsAccount)
                {
                    // SavingsAccount: Withdraw within limit
                    Console.WriteLine("\nSavingsAccount: Attempting to withdraw $200 (within withdrawal limit)...");
                    savingsAccount.Withdraw(200);
                    Console.WriteLine(savingsAccount.DisplayAccountInfo());
    
                    // SavingsAccount: Withdraw exceeding limit
                    Console.WriteLine("\nSavingsAccount: Attempting to withdraw $900 (exceeding withdrawal limit)...");
                    savingsAccount.Withdraw(900);
                    Console.WriteLine(savingsAccount.DisplayAccountInfo());
    
                    // SavingsAccount: Exceeding maximum number of withdrawals per month
                    Console.WriteLine("\nSavingsAccount: Exceeding maximum number of withdrawals per month...");
                    for (int i = 0; i < 7; i++)
                    {
                        Console.WriteLine($"Attempting to withdraw $50 (withdrawal {i + 1})...");
                        savingsAccount.Withdraw(50);
                        Console.WriteLine(savingsAccount.DisplayAccountInfo());
                    }
                }
                else if (account is MoneyMarketAccount moneyMarketAccount)
                {
                    // MoneyMarketAccount: Withdraw within minimum balance
                    Console.WriteLine("\nMoneyMarketAccount: Attempting to withdraw $1000 (maintaining minimum balance)...");
                    moneyMarketAccount.Withdraw(1000);
                    Console.WriteLine(moneyMarketAccount.DisplayAccountInfo());
    
                    // MoneyMarketAccount: Withdraw exceeding minimum balance
                    Console.WriteLine("\nMoneyMarketAccount: Attempting to withdraw $1900 (exceeding minimum balance)...");
                    moneyMarketAccount.Withdraw(1900);
                    Console.WriteLine(moneyMarketAccount.DisplayAccountInfo());
                }
            }
        }
    }

    ```

    Notice that the `Main` method uses a BankCustomer object named `customer2` to create four BankAccount objects that reference base and derived account types. The BankAccount objects are stored in an array named `bankAccounts`. The method then demonstrates polymorphism by iterating over the `bankAccounts` array and calling the `DisplayAccountInfo` method for each account. Despite the array being of type BankAccount, the overridden `DisplayAccountInfo` method of each derived class is called, displaying the specific information for each account type. The method then demonstrates polymorphism by calling the `Withdraw` method for each account object, using the `is` keyword to check the type of each `account` and casting it to the appropriate derived class type.

1. Run the app to verify that the BankAccount objects implement the overridden methods in the derived classes as expected.

    ```plaintext

    Demonstrating inheritance-based polymorphism...
    Creating BankCustomer and BankAccount objects...
    Creating BankAccount objects for customer1...
    
    Demonstrating polymorphism by accessing overridden methods from the base class reference:
    Account Number: 18662843, Type: Checking, Balance: $10,000.00, Interest Rate: 0.00%, Customer ID: 0018967171
    Account Number: 18662844, Type: Checking, Balance: $500.00, Interest Rate: 0.00%, Customer ID: 0018967171, Overdraft Limit: 400
    Account Number: 18662845, Type: Savings, Balance: $1,000.00, Interest Rate: 2.00%, Customer ID: 0018967171, Withdrawal Limit: 6, Withdrawals This Month: 0
    Account Number: 18662846, Type: Money Market, Balance: $2,000.00, Interest Rate: 4.00%, Customer ID: 0018967171, Minimum Balance: 1000, Minimum Opening Balance: 2000
    
    CheckingAccount: Attempting to withdraw $600 (within overdraft limit)...
    Overdraft fee of $5 applied.
    Account Number: 18662844, Type: Checking, Balance: ($105.00), Interest Rate: 0.00%, Customer ID: 0018967171, Overdraft Limit: 400
    
    CheckingAccount: Attempting to withdraw $1000 (exceeding overdraft limit)...
    Account Number: 18662844, Type: Checking, Balance: ($105.00), Interest Rate: 0.00%, Customer ID: 0018967171, Overdraft Limit: 400
    
    SavingsAccount: Attempting to withdraw $200 (within withdrawal limit)...
    Account Number: 18662845, Type: Savings, Balance: $800.00, Interest Rate: 2.00%, Customer ID: 0018967171, Withdrawal Limit: 6, Withdrawals This Month: 1
    
    SavingsAccount: Attempting to withdraw $900 (exceeding withdrawal limit)...
    Account Number: 18662845, Type: Savings, Balance: $800.00, Interest Rate: 2.00%, Customer ID: 0018967171, Withdrawal Limit: 6, Withdrawals This Month: 1
    
    SavingsAccount: Exceeding maximum number of withdrawals per month...
    Attempting to withdraw $50 (withdrawal 1)...
    Account Number: 18662845, Type: Savings, Balance: $750.00, Interest Rate: 2.00%, Customer ID: 0018967171, Withdrawal Limit: 6, Withdrawals This Month: 2
    Attempting to withdraw $50 (withdrawal 2)...
    Account Number: 18662845, Type: Savings, Balance: $700.00, Interest Rate: 2.00%, Customer ID: 0018967171, Withdrawal Limit: 6, Withdrawals This Month: 3
    Attempting to withdraw $50 (withdrawal 3)...
    Account Number: 18662845, Type: Savings, Balance: $650.00, Interest Rate: 2.00%, Customer ID: 0018967171, Withdrawal Limit: 6, Withdrawals This Month: 4
    Attempting to withdraw $50 (withdrawal 4)...
    Account Number: 18662845, Type: Savings, Balance: $600.00, Interest Rate: 2.00%, Customer ID: 0018967171, Withdrawal Limit: 6, Withdrawals This Month: 5
    Attempting to withdraw $50 (withdrawal 5)...
    Account Number: 18662845, Type: Savings, Balance: $550.00, Interest Rate: 2.00%, Customer ID: 0018967171, Withdrawal Limit: 6, Withdrawals This Month: 6
    Attempting to withdraw $50 (withdrawal 6)...
    Account Number: 18662845, Type: Savings, Balance: $550.00, Interest Rate: 2.00%, Customer ID: 0018967171, Withdrawal Limit: 6, Withdrawals This Month: 6
    Attempting to withdraw $50 (withdrawal 7)...
    Account Number: 18662845, Type: Savings, Balance: $550.00, Interest Rate: 2.00%, Customer ID: 0018967171, Withdrawal Limit: 6, Withdrawals This Month: 6
    
    MoneyMarketAccount: Attempting to withdraw $1000 (maintaining minimum balance)...
    Account Number: 18662846, Type: Money Market, Balance: $1,000.00, Interest Rate: 4.00%, Customer ID: 0018967171, Minimum Balance: 1000, Minimum Opening Balance: 2000
    
    MoneyMarketAccount: Attempting to withdraw $1900 (exceeding minimum balance)...
    Account Number: 18662846, Type: Money Market, Balance: $1,000.00, Interest Rate: 4.00%, Customer ID: 0018967171, Minimum Balance: 1000, Minimum Opening Balance: 2000

    ```

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Also, building up a portfolio of projects can be a great way to demonstrate your skills to potential employers.
