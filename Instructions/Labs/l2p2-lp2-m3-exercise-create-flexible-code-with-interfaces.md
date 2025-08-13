---
lab:
    title: 'Exercise - Create Flexible Code Using Interfaces'
    description: 'Create flexible and maintainable code by refactoring tightly coupled code to use interfaces in C#.'
---

# Create Flexible Code Using Interfaces

In object-oriented programming, interfaces define a contract that classes can implement. They specify method signatures and properties that implementing classes must provide. This allows for consistent behavior across different types while enabling flexibility in implementation. In C#, interfaces are defined using the `interface` keyword, and classes implement them using the `: InterfaceName` syntax.

In this exercise, you will refactor a tightly coupled console application to use interfaces. By introducing interfaces and dependency injection, you will decouple the application logic from specific implementations, making the code more flexible and easier to maintain.

This exercise takes approximately **20-25 minutes** to complete.

## Before you start

Before you can start this exercise, you need to:

1. Ensure that you have the latest short term support (STS) version of the .NET SDK installed on your computer. You can download the latest versions of the .NET SDK using the following URL: [Download .NET](https://dotnet.microsoft.com/download).
1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code using the following URL: [Download Visual Studio Code](https://code.visualstudio.com/).
1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For additional help configuring the Visual Studio Code environment, see [Install and configure Visual Studio Code for C# development](https://learn.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code).

## Exercise scenario

Suppose you're a software developer at a tech company working on a new project. Your team has identified that some parts of the codebase are tightly coupled, making it difficult to test and extend. To address this, you decide to refactor the code to use interfaces and dependency injection. This will decouple the application logic from specific implementations, improving flexibility and maintainability.

This exercise includes the following tasks:

1. Create a new C# project.
1. Define interfaces to abstract logging and database access.
1. Update existing classes to implement the interfaces.
1. Refactor the application to use dependency injection.
1. Test the refactored application to ensure it works as expected.

## Task 1: Review the current version of your logging application.

In this task, you download the existing version of your banking app and review the code.

Use the following steps to complete this section of the exercise:

1. Download the starter code from the following URL: [Create Flexible Code Using Interfaces - exercise code projects](https://github.com/MicrosoftLearning/mslearn-develop-oop-csharp/blob/main/DownloadableCodeProjects/Downloads/LP3SampleApps.zip)
    ![Image of raw file download button for zip on toolbar.](./Media/zip-download-button.png)

1. Extract the contents of the LP2SampleApps.zip file to a folder location on your computer.

1. Expand the LP2SampleApps folder, and then open the `Interface_M3` folder.

    The Interface_M3 folder contains the following code project folders:

    - Solution
    - Starter

    The **Starter** folder contains the starter project files for this exercise.

1. Use Visual Studio Code to open the **Starter** folder.

1. In the EXPLORER view, collapse the **STARTER** folder, select **SOLUTION EXPLORER**, and expand the **Interface_M3** project.

    You should see the following project files:

    - Application.cs
    - ConsoleLogger.cs
    - DatabaseAccess.cs
    - IDataAccess.cs
    - ILogger.cs
    - Program.cs

1. Take a minute to open and review each of the files.

- **`Application.cs`**: Defines the `Application` class, which contains the main application logic and is tightly coupled to `ConsoleLogger` and `DatabaseAccess`.

- **`ConsoleLogger.cs`**: Defines the `ConsoleLogger` class, responsible for logging messages to the console, currently tightly coupled to `Application`.

- **`DatabaseAccess.cs`**: Defines the `DatabaseAccess` class, responsible for connecting to a database and retrieving data, currently tightly coupled to `Application`.

- **`IDataAccess.cs`**: Defines the `IDataAccess` interface, specifying the contract for data access operations like `Connect` and `GetData`.

- **`ILogger.cs`**: Defines the `ILogger` interface, specifying the contract for logging operations with a `Log(string message)` method.

- **`Program.cs`**: Contains the entry point of the application, creating and running an instance of the `Application` class.

    > [!TIP]
    > Review of each file in the previous list provides understanding of the current project starting code, which is tightly coupled. Reviewing `TASK` comments in the files provides context for understanding how the project code is refactored into loosely coupled code.

1. Run the application using the following command (or debug with `F5`):

    ```bash
    dotnet run
    ```

    *To debug, set breakpoints in your code (e.g., in `Application.cs` or `Program.cs`) and press `F5` in Visual Studio Code to start debugging. This allows you to step through the code and inspect variables.*

1. Verify the output to ensure that the application logs messages to the console and retrieves data from the database.

    Your app should produce output that's similar to the following example:

    ```console
        ConsoleLogger: Application started.
        Database connected.
        ConsoleLogger: Data retrieved: Sample Data from Database
        ConsoleLogger: Application finished.
    ```

## Task 2: Create `IDataAccess` interface for data access  

In Visual Studio Code open `IDataAccess.cs`, the file only has comments.

1. Open the `IDataAccess.cs` file in Visual Studio Code.

1. Under the comment `TASK 2:` Add the following code to define the `IDataAccess` interface:

   ```csharp
    public interface IDataAccess
    {
        // Connects to the data source.
        void Connect();
    
        // Retrieves data from the data source.
        string GetData();
    }
   ```

   *The `ILogger` interface defines a contract for logging functionality, ensuring that any class implementing it provides a `Log` method.*

1. Save your changes.

1. **Notice that adding the `IDataAccess` interface definition** provides the foundation for functionality with a clearly defined contract for data access operations. This ensures that any class implementing the interface will provide concrete implementations for the `Connect` and `GetData` methods, enabling consistent and flexible data access across the application.

## Task 3: Implement the `IDataAccess` interface to decouple the `DatabaseAccess` class

Now, update the existing `DatabaseAccess` class to implement the newly defined interface.

1. Open the `DatabaseAccess.cs` file.

1. Under the comment `TASK 3:` Add the following code to modify the class to implement the `IDataAccess` interface:

   ```csharp
    // This class implements the IDataAccess interface and is responsible for connecting to a database and retrieving data.
    public class DatabaseAccess : IDataAccess
    {
        // Simulates connecting to a database.
        public void Connect()
        {
            Console.WriteLine("Database connected.");
        }
    
        // Simulates retrieving data from the database.
        public string GetData()
        {
            return "Sample Data from Database";
        }
    }
   ```

   *The `DatabaseAccess` class now implements the `IDataAccess` interface, providing methods to connect to a database and retrieve data.*

1. Save your changes.

1. **Notice that the only code change** is adding the interface reference (`: IDataAccess`) to the `DatabaseAccess` class. This ensures the class adheres to the contract defined by the `IDataAccess` interface, which includes the `Connect` and `GetData` methods.

## Task 4: Create `ILogger` interface for logging a message

1. Open the `ILogger.cs` file in Visual Studio Code.

1. Under the comment `TASK 4:`, add the following code to define the `ILogger` interface under the Task 4 comment:

    ```csharp
     // Interface for logging messages.
     public interface ILogger
     {
          // Logs a message.
          void Log(string message);
     }
    ```

    *The `ILogger` interface abstracts logging operations, requiring implementing classes to provide a method for logging messages.*

1. Save your changes.

1. **Notice that adding the `ILogger` interface definition** establishes a clear contract for logging functionality. This ensures that any class implementing the interface will provide a concrete implementation of the `Log` method, enabling consistent and reusable logging behavior across the application.

## Task 5: Update `ConsoleLogger` class to implement the interfaces

Next, you update the existing `ConsoleLogger` class to implement the newly defined interface.

1. Open the `ConsoleLogger.cs` file.

1. Under the comment `TASK 5:`, add the following code to modify the class to implement the `ILogger` interface:

   ```csharp
   public class ConsoleLogger : ILogger
    {
        // Logs a message to the console.
        public void Log(string message)
        {
            Console.WriteLine($"ConsoleLogger: {message}");
        }
    }
   ```

> [!NOTE]
> The constructor code in Task 6 is incomplete. It doesn't show the full `Application` class or how `_logger` and `_dataAccess` are declared - those items must remain intact.

   *The `ConsoleLogger` class now implements the `ILogger` interface, providing a concrete implementation of the `Log` method to log messages to the console.*

1. Save your changes.

1. **Notice that adding the `ILogger` interface definition** establishes a clear contract for logging functionality. This ensures that any class implementing the interface will provide a concrete implementation of the `Log` method, enabling consistent and reusable logging behavior across the application.

## Task 6: Refactor the application to use dependency injection

Refactor the `Application` class to depend on the `ILogger` and `IDataAccess` interfaces instead of directly instantiating the `ConsoleLogger` and `DatabaseAccess` classes.

1. Open the `Application.cs` file.

1. Under the comment `TASK 6:`, add the following code to replace the `Application` class:

   ```csharp
    // TASK 6: Implement ILogger and IDataAccess interfaces and  
    // refactor this constructor to accept them as parameters.
    public Application(ILogger logger, IDataAccess dataAccess)
    {
        _logger = logger;
        _dataAccess = dataAccess;
    }
   ```

   *The `Application` class now uses dependency injection to receive its dependencies, making it more flexible and easier to test.*

## Task 7: Refactor `Program` to use dependency injection

1. Open the `Program.cs` file.
1. Replace all of the existing code with the following:

   ```csharp
    var logger = new ConsoleLogger();
    var dataAccess = new DatabaseAccess();
    
    // Inject the dependencies into the Application class.
    var app = new Application(logger, dataAccess);
    app.Run();
   ```

   *The `Program.cs` file creates instances of `ConsoleLogger` and `DatabaseAccess` and injects them into the `Application` class, demonstrating how dependency injection works in practice.*

## Task 8: Test the refactored application

Finally, test the refactored application to ensure it works as expected.

1. Run the application using the following command (or debug with `F5`):

    ```bash
    dotnet run
    ```

    *To debug, set breakpoints in your code (e.g., in `Application.cs` or `Program.cs`) and press `F5` in Visual Studio Code to start debugging. This allows you to step through the code and inspect variables.*

1. Verify the output to ensure that the application logs messages to the console and retrieves data from the database.

    Your app should produce output that's similar to the following example:

    ```console
        ConsoleLogger: Application started.
        Database connected.
        ConsoleLogger: Data retrieved: Sample Data from Database
        ConsoleLogger: Application finished.
    ```

### Check your work: Test the refactored application

Confirm that the application runs without errors and produces the following output:

```console
    ConsoleLogger: Application started.
    Database connected.
    ConsoleLogger: Data retrieved: Sample Data from Database
    ConsoleLogger: Application finished.
```

*This output confirms that the application is functioning correctly, with logging and database operations working as expected.*

The output is the same as the starter code, but now the code is decoupled from specific implementations by using interfaces and dependency injection. This exercise demonstrated how to refactor tightly coupled code into loosely coupled components by defining interfaces (`ILogger` and `IDataAccess`), implementing them in concrete classes (`ConsoleLogger` and `DatabaseAccess`), and injecting these dependencies into the `Application` class.

Refactoring code using techniques like interfaces and dependency injection helps decouple components, making your application more flexible and maintainable. Interfaces define clear contracts between parts of the system, while dependency injection ensures that dependencies are provided in a modular and testable manner. Together, these practices improve the structure of your code, making it easier to extend, test, and adapt to future requirements.

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Additionally, building a portfolio of projects can be a great way to demonstrate your skills to potential employers.
