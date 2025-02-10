---
lab:
    title: 'Exercise - Implement inheritance with base and derived classes'
    description: 'Learn how to implement inheritance with base and derived classes.'
---


# Implement inheritance with base and derived classes

Inheritance enables you to create new classes that reuse, extend, and modify the behavior defined in other classes. The class whose members are inherited is called the base class, and the class that inherits those members is called the derived class.

In this exercise, you update an existing code project with inheritance by implementing base and derived classes.

This exercise takes approximately **20** minutes to complete.

## Before you start

Before you can start this exercise, you need to:

1. Ensure that you have the latest LTS version of the .NET SDK installed on your computer. You can download the latest version of the .NET SDK from the following URL: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code from the following URL: [https://code.visualstudio.com/](https://code.visualstudio.com/)
1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For additional help configuring the Visual Studio Code environment, see [https://learn.microsoft.com/en-us/training/modules/install-configure-visual-studio-code/](https://learn.microsoft.com/en-us/training/modules/install-configure-visual-studio-code/)

## Exercise scenario

Suppose you're helping a non-profit company with a software project. You've decided to sharpen your object-oriented programming skills by creating a simple banking app. You've developed an initial version of the app that includes the following files:

- BankCustomer.cs: The BankCustomer class includes fields for first name, last name, and customer ID. The class also includes constructors that initialize the fields.
- BankAccount.cs: The BankAccount class includes fields for account number, balance, interest rate, account type, and customer ID. The class also includes constructors that initialize the fields.
- Program.cs: The Program.cs file includes code that creates instances of the BankCustomer and BankAccount classes and demonstrates how each class is used.

This exercise includes the following tasks:

1. Review the current version of your banking app
1. Create a base class for the BankCustomer and BankAccount classes
1. Create derived classes for the BankCustomer and BankAccount classes

## Review the current version of your banking app

In this task, you download the existing version of your banking app and review the code.

Use the following steps to complete this section of the exercise:

1. Download the starter code from the following URL: [Implement core reuse and inheritance - exercise code projects](https://github.com/MicrosoftLearning/mslearn-develop-oop-csharp/raw/refs/heads/main/DownloadableCodeProjects/Downloads/LP3SampleApps.zip)

1. Extract the contents of the LP3SampleApps.zip file to a folder location on your computer.

1. Expand the LP3SampleApps folder, and then open the `Reuse_M1` folder.

    The Reuse_M1 folder contains the following code project folders:

    - Solution
    - Starter

    The **Starter** folder contains the starter project files for this exercise.

1. Use Visual Studio Code to open the **Starter** folder.

1. In the EXPLORER view, collapse the **STARTER** folder, select **SOLUTION EXPLORER**, and expand the **Classes_M2** project.

    You should see the following project files:

    - BankAccount.cs
    - BankCustomer.cs
    - Program.cs

1. Open the BankCustomer.cs file.

1. Take a minute to review the BankCustomer class.

    ```csharp



    ```

    The `BankCustomer` class ...

1. Open the BankAccount.cs file.

1. Take a minute to review the BankAccount class.

    ```csharp



    ```

    The `BankAccount` class ...

1. Open the Program.cs file.

1. Take a minute to review the code.

    ```csharp



    ```

    Top-level statements provide an implicit entry point for the app. The code in Program.cs demonstrates how to create and use `BankCustomer` and `BankAccount` objects. the code initializes customer details, creates three `BankCustomer` objects, and prints their information. Then, it creates three `BankAccount` objects for these customers, specifying different balances and account types, and prints the account details, including account number, type, balance, interest rate, and customer ID.

1. Run the app and review the output in the terminal window.

    Your app should produce output that's similar to the following example:

    ```plaintext



    ```

    The customer IDs and account numbers in your output will be different from the example output. Remember that they're sequential values based on a randomly generated initial value.

    > [!TIP]
    > To run your app, right-click the **Reuse_M1** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**. If you don't see the **Debug** option listed, ensure that you've selected the **Reuse_M1** project in the Solution Explorer. The **Debug** option isn't available when the **Reuse_M1** solution is selected.

## Create

Base and derived classes ...

In this task, you create ...

Use the following steps to complete this section of the exercise:

1. Open the BankCustomer.cs file.

    ```csharp



    ```

    Notice ...

1. To ...

    ```csharp



    ```

    Notice ...

## Create ...

Inheritance ...

In this task, you ...

Use the following steps to complete this section of the exercise:

1. Open the BankAccount.cs file.

1. Notice ...



1. To ...

    ```csharp



    ```

    Notice ...

1. Run the app and review the output in the terminal window.

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

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Also, building up a portfolio of projects can be a great way to demonstrate your skills to potential employers.
