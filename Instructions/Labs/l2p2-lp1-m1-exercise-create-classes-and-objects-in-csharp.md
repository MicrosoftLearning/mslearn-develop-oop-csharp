---
lab:
    title: 'Exercise - Create class definitions and instantiate objects'
    description: 'Learn how to create class definitions that include fields and constructors, and how to use the "new" operator to instantiate objects that expose encapsulated field data.'
---


# Create class definitions and instantiate objects

In object-oriented programming, a class serves as a template for creating objects, which are the fundamental components of a program. In C#, classes are defined using the class keyword. Objects, the instances of a class, are instantiated using the `new` operator. Each object created from a class represents a specific realization of that class. Objects have their own data fields, and the values assigned to the fields can be different for each object.

In this exercise, you create a console app that uses class definitions to instantiate objects.

This exercise takes approximately **25** minutes to complete.

## Before you start

Before you can start this exercise, you need to:

1. Ensure that you have the latest short term support (STS) version of the .NET SDK installed on your computer. You can download the latest versions of the .NET SDK using the following URL: <a href="https://dotnet.microsoft.com/download/" target="_blank">Download .NET</a>
1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code using the following URL: <a href="https://code.visualstudio.com/download/" target="_blank">Download Visual Studio Code</a>
1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For additional help configuring the Visual Studio Code environment, see <a href="https://learn.microsoft.com/training/modules/install-configure-visual-studio-code/" target="_blank">Install and configure Visual Studio Code for C# development</a>

## Exercise scenario

Suppose you're helping a non-profit company with a software project. You have experience creating structured apps in C#, but no experience with object-oriented programming. You need to gain experience before starting work on the company software. You decide to create a simple banking app that includes "BankCustomer" and "BankAccount" classes.

This exercise includes the following tasks:

1. Create a console app and a class named BankCustomer.
1. Update the Program.cs file to create instances of the BankCustomer class.
1. Add public fields and updated constructors to the BankCustomer class.
1. Update the BankCustomer class using static members to ensure unique customer IDs.
1. Create a class named BankAccount that implements private, public, and static members.

## Create a console app and a class named BankCustomer

In this task, you create a new console app, add a `BankCustomer` class to the project, and then create a class definition for the `BankCustomer` class. The class definition includes public fields and a parameterless constructor.

Use the following steps to complete this task:

1. Open Visual Studio Code.

1. Use Visual Studio Code to open a new folder named **My CSharp Projects** that's located in the Windows Desktop folder.

    For example:

    1. On the Visual Studio Code welcome screen, select **Open Folder**. If the Welcome page isn't displayed in the editor, open the **File** menu and select **Open Folder**.
    1. In the **Open Folder** dialog box, navigate to the Windows Desktop folder.
    1. Select **New Folder** and name the folder **My CSharp Projects**.
    1. Select the **My CSharp Projects** folder and then select **Select Folder**.

1. Use the Command Palette to create a new console app named **Classes_M1**.

    For example:

    1. To open the Command Palette, press **Ctrl+Shift+P**.
    1. In the Command Palette, type **.NET:** and then select **.NET: New Project**.
    1. In the 'Create a new .NET Project' box, select **Console App**.
    1. In the 'Name the new project' box, type **Classes_M1** and then press Enter.
    1. In the 'Select location for the project' box, select **Default directory**
    1. In the 'Create project or view options' box, select **Create project**

    You should see a new console app project named **Classes_M1** in the Visual Studio Code EXPLORER view.

1. If the Welcome page is still open in the Visual Studio Code editor, close the Welcome page.

1. In the EXPLORER view, collapse the **MY CSHARP PROJECTS** folder structure, and then select **SOLUTION EXPLORER**.

    The Solution Explorer in Visual Studio Code is a feature provided by the C# Dev Kit extension. It offers a structured view of your application, its solutions, and its projects, making it easier to manage .NET projects within VS Code. When you open a workspace containing .NET solution files or project files, the Solution Explorer will automatically appear and load the solution files.

    Key features of the Solution Explorer include:

    - Automatically loading single or multiple solution files in a workspace.
    - Remembering the last loaded solution file for a workspace.
    - Providing context menu options for managing solutions and projects.
    - Supporting Solution Folders for organizing projects within a solution.

1. Under **SOLUTION EXPLORER**, expand the **Classes_M1** project and locate the **Program.cs** file.

    The structure of your solution should be similar to the following example:

    ```plaintext
    Classes_M1
        Classes_M1
            Dependencies
            Program.cs
    ```

1. Hover the mouse pointer over the two **Classes_M1** "folders" to reveal their association to the solution.

    The **Classes_M1** folder at the top level of the solution represents the solution folder. The **Classes_M1** folder nested under the solution folder represents the project folder. The **Program.cs** file is located within the project folder.

1. Open the **Program.cs** file, and then delete the existing "hello, world" code.

1. Right-click the **Classes_M1** project, and then select **New File**.

    If you don't see the option to create a new file, ensure that you're accessing the **Classes_M1** project folder not the **Classes_M1** solution folder.

1. In the 'Create a new file' dropdown, to create a class file named BankCustomer.cs, select **Class** and then enter **BankCustomer**.

    You should see a new file named **BankCustomer.cs** open in the Visual Studio Code editor. The file should be located in the **Classes_M1** project folder, and the code should look similar to the following code snippet:

    ```csharp

    using System;

    namespace Classes_M1;

    class BankCustomer
    {
    
    }

    ```

    At this point, your `BankCustomer` class definition is empty. You'll add constructors and fields to the class during this task.

1. Notice that a `Classes_M1` namespace is specified.

    A namespace is a way to organize code in C#. It provides a way to group related classes and other types into a single unit. You can use this namespace to access the `BankCustomer` class from other classes in the project.

1. To create a constructor for the `BankCustomer` class, add the following code to your `BankCustomer` class definition:

    ```csharp

    public BankCustomer()
    {
        Console.WriteLine("BankCustomer created");
    }

    ```

    The `BankCustomer` class now includes a parameterless constructor that writes a message to the console when a new instance of the `BankCustomer` class is created.

1. Your updated `BankCustomer` class should now look similar to the following code snippet:

    ```csharp

    public class BankCustomer
    {
        public BankCustomer()
        {
            Console.WriteLine("BankCustomer created");
        }
    }

    ```

1. To create a second constructor that accepts parameters for the bank customer's first and last name, add the following code to your `BankCustomer` class definition:

    ```csharp

    public BankCustomer(string firstName, string lastName)
    {
        Console.WriteLine($"BankCustomer created: {firstName} {lastName}");
    }

    ```

    The `BankCustomer` class now includes a second constructor that accepts parameters for the customer's first and last name. The constructor writes a message to the console that includes the customer's first and last name when a new instance of the `BankCustomer` class is created.

1. Your updated `BankCustomer` class should now look similar to the following code snippet:

    ```csharp

    public class BankCustomer
    {
        public BankCustomer()
        {
            Console.WriteLine("BankCustomer created");
        }

        public BankCustomer(string firstName, string lastName)
        {
            Console.WriteLine($"BankCustomer created: {firstName} {lastName}");
        }
    }

    ```

## Update the Program.cs file to create instances of the BankCustomer class

The `new` operator is used to create objects based on a class constructor. Each object has its own data fields, and the values assigned to the fields can be different for each object.

In this task, you update the Program.cs file to create instances of the `BankCustomer` class and run the app to verify that the instances are created successfully.

Use the following steps to complete this task:

1. Switch to the Program.cs file

    You're using the Program.cs file to create instances of the `BankCustomer` class, but at this point it should be empty. If the "hello, world" code is still present, delete it now.

1. To create a `using` statement that specifies the namespace defined by the customer `BankCustomer` class, add the following code to the Program.cs file:

    ```csharp

    using Classes_M1;

    ```

    This `using` statement allows you to access the `BankCustomer` class from within the Program.cs file.

1. To create an instance of the `BankCustomer` class, add the following code to the Program.cs file:

    ```csharp

    BankCustomer customer1 = new BankCustomer();

    ```

    The `new` operator is used to create a new instance of the `BankCustomer` class. The `BankCustomer` class constructor is called when the new instance is created.

1. To create a second instance of the `BankCustomer` class using the second constructor, add the following code to the Program.cs file:

    ```csharp

    BankCustomer customer2 = new BankCustomer("Tim", "Shao");

    ```

    The `BankCustomer` class constructor that accepts parameters for the customer's first and last name is called when the new instance is created. The constructor writes a message to the console that includes the customer's first and last name.

1. Take a minute to review your Program.cs and BankCustomer.cs files.

    Program.cs file:

    ```csharp

    using Classes_M1;
    
    BankCustomer customer1 = new BankCustomer();

    BankCustomer customer2 = new BankCustomer("Tim", "Shao");
    
    ```

    BankCustomer.cs file:

    ```csharp

    using System;

    namespace Classes_M1;

    public class BankCustomer
    {
        public BankCustomer()
        {
            Console.WriteLine("BankCustomer created");
        }

        public BankCustomer(string firstName, string lastName)
        {
            Console.WriteLine($"BankCustomer created: {firstName} {lastName}");
        }
    }

    ```

1. Ensure that you've saved your changes to both files.

    Visual Studio Code can be configured to automatically save changes for you. If you haven't configured Visual Studio Code to automatically save changes, you can manually save your changes by selecting **File** > **Save** or **File** > **Save ALL** from the top menu bar.

1. To ensure that your solution builds without errors, right-click the **Classes_M1** solution in the Solution Explorer, and then select **Build**.

    If you don't see the **Build** option listed, ensure that you've selected the **Classes_M1** solution in the Solution Explorer. The **Build** option isn't available when a project is selected.

    You need to fix any errors before you can run your app.

1. To run your app, right-click the **Classes_M1** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    If you don't see the **Debug** option listed, ensure that you've selected the **Classes_M1** project in the Solution Explorer. The **Debug** option isn't available when a solution is selected.

    There are several ways to run your app in Visual Studio Code. For example:

    - You can use the **Run** menu
    - You can select the **Run** button in the top menu bar
    - You can use the **F5** key
    - You can use the Terminal panel and type `dotnet run`

    Any of these options is fine. Some options are more convenient than others, depending on your preferences. Also, some options use the debugger, which can be helpful when you need to step through your code.

1. Review the output in the Debug Console panel.

    You should see the following output:

    ```plaintext

    BankCustomer created
    BankCustomer created: Tim Shao

    ```

## Add public fields and updated constructors to the BankCustomer class

Public fields are accessible from outside the class. They can be read from and written to by any code that has access to the object. Public fields are often used to expose object data to other classes.

In this task, you add public fields to the `BankCustomer` class, update the instance constructors to use additional parameters, and then update the Program.cs file to access each object's public data.

Use the following steps to complete this task:

1. Open the BankCustomer.cs file.

1. Add the following public fields to the class definition:

    ```csharp

    public string FirstName = "Tim";
    public string LastName = "Shao";
    public string CustomerId = "1010101010";

    ```

    Notice that the fields are initialized with default values.

1. Update the second constructor to assign constructor parameters to the local variables.

    ```csharp

    public BankCustomer(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        Console.WriteLine($"BankCustomer created: {firstName} {lastName}");
    }

    ```

1. Delete the `Console.WriteLine()` messages from the constructors.

    You'll update the Program.cs file to display object data using the public fields. The updated constructors should be similar to the following code snippet:

    ```csharp

    public BankCustomer()
    {

    }

    public BankCustomer(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

    }

    ```

1. To create a third constructor that accepts `firstName`, `lastName`, and `customerIdNumber` parameters, add the following code to the `BankCustomer` class definition:

    ```csharp

    public BankCustomer(string firstName, string lastName, string customerIdNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        CustomerId = customerIdNumber;
    }

    ```

    The constructor initializes the `FirstName`, `LastName`, and `CustomerId` fields with the values of the `firstName`, `lastName`, and `customerIdNumber` parameters, respectively.

1. Switch to the Program.cs file

1. To create local variables for `firstName`, `lastName`, and `customerIdNumber` just below the `namespace` declaration, enter the following code:

    ```csharp

    string firstName = "Tim";
    string lastName = "Shao";
    string customerIdNumber = "1010101010";

    ```

1. To use `firstName` and `lastName` when creating `customer2`, replace your existing code for `customer2` with the following code snippet:

    ```csharp

    firstName = "Lisa";
    BankCustomer customer2 = new BankCustomer(firstName, lastName);
    ```

1. To create a third object named `customer3` that uses your third constructor, add the following code to the Program.cs file:

    ```csharp

    firstName = "Sandy";
    lastName = "Zoeng";
    customerIdNumber = "2020202020";
    BankCustomer customer3 = new BankCustomer(firstName, lastName, customerIdNumber);

    ```

1. To display the public data fields for each object, add the following code to the end of the Program.cs file:

    ```csharp

    Console.WriteLine($"BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.CustomerId}");
    Console.WriteLine($"BankCustomer 2: {customer2.FirstName} {customer2.LastName} {customer2.CustomerId}");
    Console.WriteLine($"BankCustomer 3: {customer3.FirstName} {customer3.LastName} {customer3.CustomerId}");

    ```

1. Take a minute to review your updated code files.

    Program.cs file:

    ```csharp

    using Classes_M1;

    string firstName = "Tim";
    string lastName = "Shao";
    string customerIdNumber = "1010101010";
    
    BankCustomer customer1 = new BankCustomer();
    
    firstName = "Lisa";
    BankCustomer customer2 = new BankCustomer(firstName, lastName);
    
    firstName = "Sandy";
    lastName = "Zoeng";
    customerIdNumber = "2020202020";
    BankCustomer customer3 = new BankCustomer(firstName, lastName, customerIdNumber);
    
    Console.WriteLine($"BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.CustomerId}");
    Console.WriteLine($"BankCustomer 2: {customer2.FirstName} {customer2.LastName} {customer2.CustomerId}");
    Console.WriteLine($"BankCustomer 3: {customer3.FirstName} {customer3.LastName} {customer3.CustomerId}");

    ```

    BankCustomer.cs file:

    ```csharp

    using System;

    namespace Classes_M1;

    public class BankCustomer
    {
        // add public fields for FirstName, LastName, and CustomerId
        public string FirstName = "Tim";
        public string LastName = "Shao";
        public string CustomerId = "1010101010";
    
        public BankCustomer()
        {
    
        }
    
        public BankCustomer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
    
        }
    
        public BankCustomer(string firstName, string lastName, string customerIdNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerId = customerIdNumber;
        }
    }

    ```

1. Run your updated app and verify that you get the following output:

    You should see the following output:

    ```plaintext

    BankCustomer 1: Tim Shao 1010101010
    BankCustomer 2: Lisa Doe 1010101010
    BankCustomer 3: Sandy Zoeng 2020202020

    ```

1. Notice that the first two customers share the same ID number.

    The BankCustomer class initializes data fields using default values. Although the constructors update field values using parameters, the current approach doesn't ensure unique customer IDs.

## Update the BankCustomer class using static members to ensure unique customer IDs

Static fields are initialized before an instance of the class is created. When an object is created, static fields are accessed using the class name, not an instance of the class. The same value is shared by all instances of the class.

Static constructors are called when a class is loaded into memory. A static constructor is called only once, regardless of how many instances of the class are created. Static constructors are used to initialize static fields.

In this task, you update the `BankCustomer` class using a static field and static constructor to ensure unique `CustomerId` values are assigned to each new customer object.

Use the following steps to complete this task:

1. Open the `BankCustomer`class.

1. To convert `CustomerId` into a read-only field, add the `readonly` keyword to the `CustomerId` field declaration:

    ```csharp

    public readonly string CustomerId;

    ```

    Notice that `CustomerId` is no longer initialized when it's declared. The `readonly` keyword is used to declare a field that can be assigned a value only when it's declared or in a constructor. In this case, you'll assign a unique value to `CustomerId` in the constructors, so no value is assigned when the field is declared.

1. To create a static field named `s_nextCustomerId`, add the following code to the `BankCustomer` class definition:

    ```csharp

    private static int s_nextCustomerId;

    ```

    The `s_nextCustomerId` field is used to ensure that each new instance of the `BankCustomer` class is assigned a unique customer ID. The field is declared as a static field, which means that it's shared among all instances of the `BankCustomer` class.

1. To create a static constructor that initializes the `s_nextCustomerId` field, add the following code to the `BankCustomer` class definition:

    ```csharp

    static BankCustomer()
    {
        Random random = new Random();
        s_nextCustomerId = random.Next(10000000, 20000000);
    }

    ```

    The static constructor is called when the `BankCustomer` class is loaded into memory, and before any instances of the class are created. The static constructor initializes the `s_nextCustomerId` field with a random eight digit integer.

1. To assign a unique value to `CustomerId` inside your parameterless constructor, update the constructor to match the following code:

    ```csharp

    public BankCustomer()
    {
        this.CustomerId = (s_nextCustomerId++).ToString("D10");
    }

    ```

    The updated constructor initializes the `CustomerId` field using the already initialized `s_nextCustomerId` field. Notice that `s_nextCustomerId` is incremented by 1 before the `CustomerId` field is assigned a value.

    > [!NOTE]
    > The `this` keyword refers to the current instance of the class. It's used to access fields, properties, and methods of the current instance. In the `BankCustomer` class, the `this` keyword is used to access the read-only `CustomerId` field. The `this` keyword is not required in this context, but it's used for clarity. The `this` keyword is not available in a static constructor.

1. To assign a unique value to `CustomerId` inside your constructor that accepts `firstName` and `lastName` parameters, update the constructor to match the following code:

    ```csharp

    public BankCustomer(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        this.CustomerId = (s_nextCustomerId++).ToString("D10");
    }

    ```

    Once again, the constructor initializes the `CustomerId` field using an incremented `s_nextCustomerId` value.

1. Delete the constructor that accepts the `firstName`, `lastName`, and `customerIdNumber` parameters.

    Ensuring unique customer IDs includes removing the opportunity to create a new customer with an externally provided ID. Also, your parameterless and static constructors ensure that every new instance of the `BankCustomer` class is assigned a unique customer ID.

1. Switch to the Program.cs file.

1. Locate the code line that's used to create `customer3`:

    ```csharp

    BankCustomer customer3 = new BankCustomer(firstName, lastName, customerIdNumber);

    ```

1. Replace the code line with the following code:

    ```csharp

    BankCustomer customer3 = new BankCustomer(firstName, lastName);

    ```

1. Since the `CustomerId` field is no longer accepted as a constructor parameter, you can delete the following references to the `customerIdNumber` variable in Program.cs.

    ```csharp

    string customerIdNumber = "1010101010"; // delete this line near the top of the file
    customerIdNumber = "2020202020"; // delete this line just before creating customer3

    ```

1. Take a minute to review the updated Program.cs and BankCustomer.cs files.

    Program.cs file:

    ```csharp

    using Classes_M1;

    string firstName = "Tim";
    string lastName = "Shao";
    
    BankCustomer customer1 = new BankCustomer();
    
    firstName = "Lisa";
    BankCustomer customer2 = new BankCustomer(firstName, lastName);
    
    firstName = "Sandy";
    lastName = "Zoeng";
    BankCustomer customer3 = new BankCustomer(firstName, lastName);
    
    Console.WriteLine($"BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.CustomerId}");
    Console.WriteLine($"BankCustomer 2: {customer2.FirstName} {customer2.LastName} {customer2.CustomerId}");
    Console.WriteLine($"BankCustomer 3: {customer3.FirstName} {customer3.LastName} {customer3.CustomerId}");
    
    ```

    BankCustomer.cs file:

    ```csharp

    public class BankCustomer
    {
        private static int s_nextCustomerId;
        public string FirstName = "Tim";
        public string LastName = "Shao";
        public readonly string CustomerId;
    
        static BankCustomer()
        {
            Random random = new Random();
            s_nextCustomerId = random.Next(10000000, 20000000);
        }
    
        public BankCustomer()
        {
            this.CustomerId = (s_nextCustomerId++).ToString("D10");
        }
    
        public BankCustomer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            this.CustomerId = (s_nextCustomerId++).ToString("D10");
        }
    }

    ```

## Create a class named BankAccount that implements private, public, and static members

In this task, you create an `BankAccount` class that initializes a combination of public and static fields. You also create constructors that initialize the fields with default values and values passed as parameters.

You want a `BankAccount` class that includes the following fields:

- `AccountNumber` - A public field that stores the account number.
- `Balance` - A public field that stores the account balance.
- `InterestRate` - A static field that stores the interest rate.
- `AccountType` - A public field that stores the account type.
- `CustomerId` - A public field that stores the customer ID associated with the account. This field must be read-only.
- `s_nextAccountNumber` - A static field that stores the next account number. This field is used to ensure that each object is assigned a unique account number.

Use the following steps to complete this task:

1. Use the **Classes_M1** project to create a class named `BankAccount`.

    You can use the `Classes_M1` project to create the `BankAccount` class. Right-click the **Classes_M1** project in the Solution Explorer, select **New File**, select **Class**, and then enter **BankAccount**.

    Your `BankAccount` class should look similar to the following code snippet:

    ```csharp

    using System;

    namespace Classes_M1;

    public class BankAccount
    {

    }

    ```

1. To create public fields for the `AccountNumber`, `Balance`, `InterestRate`, `AccountType`, and `CustomerId` fields, add the following code to the `BankAccount` class definition:

    ```csharp

    public int AccountNumber;
    public double Balance = 0;
    public static double InterestRate;
    public string AccountType = "Checking";
    public readonly string CustomerId;

    ```

    Notice that the `InterestRate` field is declared as `static` and that `CustomerId` is declared as `readonly`. Static fields are accessed using the class name, not an instance of the class, and are shared among all instances of a class. The value of a static field is initialized before an instance of the class is created. Readonly fields can be assigned a value only when they're declared or in a constructor.

1. To create a static field named `s_nextAccountNumber`, add the following code to the `BankAccount` class definition:

    ```csharp

    private static int s_nextAccountNumber = 1;

    ```

    The `s_nextAccountNumber` field is used to ensure that each new instance of the `BankAccount` class is assigned a unique account number. The field is initialized with a value of 1.

1. To create a static constructor that initializes the `s_nextAccountNumber`  and `InterestRate` fields, add the following code to the `BankAccount` class definition:

    ```csharp

    static BankAccount()
    {
        Random random = new Random();
        s_nextAccountNumber = random.Next(10000000, 20000000);
        InterestRate = 0;
    }

    ```

    The static constructor is called when the `BankAccount` class is loaded into memory. This constructor is used to initialize the `s_nextAccountNumber` and `InterestRate` fields. Since the `s_nextAccountNumber` field is a private field, it can't be assigned a value from outside the class.

1. To create a constructor that accepts a `CustomerId` parameter and initializes the other fields with default values, add the following code to the `BankAccount` class definition:

    ```csharp

    public BankAccount(string customerIdNumber)
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = customerIdNumber;
    }

    ```

    The constructor initializes the `AccountNumber` field using the `s_nextAccountNumber` field. The `CustomerId` field is initialized with the value of the `customerIdNumber` parameter.

1. To create a constructor that accepts parameters for the `CustomerId`, `Balance`, and `AccountType` fields, add the following code to the `BankAccount` class definition:

    ```csharp

    public BankAccount(string customerIdNumber, double balance, string accountType)
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = accountType;
    }

    ```

    The constructor initializes the `AccountNumber` field using the `s_nextAccountNumber` field. The `CustomerId`, `Balance`, and `AccountType` fields are initialized with the values of the `customerIdNumber`, `Balance`, and `AccountType` parameters, respectively.

1. Switch to the Program.cs file.

1. To create instances of the `BankAccount` class, add the following code to the end of the Program.cs file:

    ```csharp

    BankAccount account1 = new BankAccount(customer1.CustomerId);
    BankAccount account2 = new BankAccount(customer2.CustomerId, 1500, "Checking");
    BankAccount account3 = new BankAccount(customer3.CustomerId, 2500, "Checking");

    ```

    The `new` operator is used to create new instances of the `BankAccount` class. The constructors are called when the new instances are created.

1. To display the public data fields for each of the bank account objects, add the following code to the end of the Program.cs file:

    ```csharp

    Console.WriteLine($"Account 1: Account # {account1.AccountNumber}, type {account1.AccountType}, balance {account1.Balance}, rate {BankAccount.InterestRate}, customer ID {account1.CustomerId}");
    Console.WriteLine($"Account 2: Account # {account2.AccountNumber}, type {account2.AccountType}, balance {account2.Balance}, rate {BankAccount.InterestRate}, customer ID {account2.CustomerId}");
    Console.WriteLine($"Account 3: Account # {account3.AccountNumber}, type {account3.AccountType}, balance {account3.Balance}, rate {BankAccount.InterestRate}, customer ID {account3.CustomerId}");

    ```

1. Take a minute to review your code files.

    Program.cs file:

    ```csharp

    using Classes_M1;
    
    string firstName = "Tim";
    string lastName = "Shao";
    
    BankCustomer customer1 = new BankCustomer(firstName, lastName);
    
    firstName = "Lisa";
    BankCustomer customer2 = new BankCustomer(firstName, lastName);
    
    firstName = "Sandy";
    lastName = "Zoeng";
    BankCustomer customer3 = new BankCustomer(firstName, lastName);
    
    Console.WriteLine($"BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.CustomerId}");
    Console.WriteLine($"BankCustomer 2: {customer2.FirstName} {customer2.LastName} {customer2.CustomerId}");
    Console.WriteLine($"BankCustomer 3: {customer3.FirstName} {customer3.LastName} {customer3.CustomerId}");
    
    // Create accounts for customers
    BankAccount account1 = new BankAccount(customer1.CustomerId);
    BankAccount account2 = new BankAccount(customer2.CustomerId, 1500, "Checking");
    BankAccount account3 = new BankAccount(customer3.CustomerId, 2500, "Checking");
    
    Console.WriteLine($"Account 1: Account # {account1.AccountNumber}, type {account1.AccountType}, balance {account1.Balance}, rate {BankAccount.InterestRate}, customer ID {account1.CustomerId}");
    Console.WriteLine($"Account 2: Account # {account2.AccountNumber}, type {account2.AccountType}, balance {account2.Balance}, rate {BankAccount.InterestRate}, customer ID {account2.CustomerId}");
    Console.WriteLine($"Account 3: Account # {account3.AccountNumber}, type {account3.AccountType}, balance {account3.Balance}, rate {BankAccount.InterestRate}, customer ID {account3.CustomerId}");

    
    ```

    BankCustomer.cs file:

    ```csharp

    public class BankCustomer
    {
        private static int s_nextCustomerId;
        public string FirstName = "Tim";
        public string LastName = "Shao";
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
        
    }

    ```

    BankAccount.cs file:

    ```csharp

    public class BankAccount
    {
        private static int s_nextAccountNumber;
        public readonly int AccountNumber;
        public double Balance = 0;
        public static double InterestRate;
        public string AccountType = "Checking";
        public readonly string CustomerId;
    
        static BankAccount()
        {
            Random random = new Random();
            s_nextAccountNumber = random.Next(10000000, 20000000);
            InterestRate = 0;
        }
    
        public BankAccount(string customerIdNumber)
        {
            this.AccountNumber = s_nextAccountNumber++;
            this.CustomerId = customerIdNumber;
        }
    
        public BankAccount(string customerIdNumber, double balance, string accountType)
        {
            this.AccountNumber = s_nextAccountNumber++;
            this.CustomerId = customerIdNumber;
            this.Balance = balance;
            this.AccountType = accountType;
        }
    }

    ```

1. Run the app and review the output in the terminal window.

    Your app should produce output that's similar to the following example:

    ```plaintext

    BankCustomer 1: Tim Shao 0014653176
    BankCustomer 2: Lisa Shao 0014653177
    BankCustomer 3: Sandy Zoeng 0014653178
    Account 1: Account # 12885967, type Checking, balance 0, rate 0, customer ID 0014653176
    Account 2: Account # 12885968, type Checking, balance 1500, rate 0, customer ID 0014653177
    Account 3: Account # 12885969, type Checking, balance 2500, rate 0, customer ID 0014653178

    ```

    The customer IDs and account numbers in your output will be different from the example output. Remember that they're sequential values based on a randomly generated initial value.

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Also, building up a portfolio of projects can be a great way to demonstrate your skills to potential employers.
