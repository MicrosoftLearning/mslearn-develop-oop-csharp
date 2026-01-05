---
lab:
    title: 'Exercise - Implement Interfaces in a Project'
    description: 'Define and implement interfaces in C# to enforce consistent behavior across multiple classes, including explicit interface implementations.'
---

# Implement Interfaces in a Project

In object-oriented programming, interfaces define a contract that classes can implement. They specify method signatures and properties that implementing classes must provide. This allows for consistent behavior across different types while enabling flexibility in implementation. In C#, interfaces are defined using the `interface` keyword, and classes implement them using the `: InterfaceName` syntax.

In this exercise, you will create a console app to define and implement interfaces, including explicit interface implementations, to ensure consistent behavior across various components of an application.

This exercise takes approximately **20** minutes to complete.

## Before you start

Before you can start this exercise, you need to:

1. Ensure that you have the latest short term support (STS) version of the .NET SDK installed on your computer. You can download the latest versions of the .NET SDK using the following URL: [Download .NET](https://dotnet.microsoft.com/download).

1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code using the following URL: [Download Visual Studio Code](https://code.visualstudio.com/).

1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For additional help configuring the Visual Studio Code environment, see [Install and configure Visual Studio Code for C# development](https://learn.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code).

## Exercise scenario

Suppose you're a software developer at a tech company working on a new project. Your team needs to define common behaviors across different classes using interfaces. To ensure consistent behavior, you decide to create and implement interfaces, including explicit interface implementations, in a simple console application.

This exercise includes the following tasks:

1. Create a new C# project.
1. Define an interface with method signatures and properties.
1. Implement the defined interface in a class.
1. Create another class that implements the same interface with different behavior.
1. Demonstrate interface implementation by creating instances of the classes and calling their methods.
1. Test the implemented interfaces and their implementations to ensure they work as expected.

## Task 1: Create a new C# project

To start, you need to create a new C# project in your development environment. This project will serve as the foundation for implementing interfaces and their respective classes.

1. Open Visual Studio Code.

1. Ensure that the C# Dev Kit extension is installed.

1. Open the terminal in Visual Studio Code by selecting `View > Terminal`.

1. Navigate to the directory where you want to create your project.

1. Run the following command to create a new console application:

   ```bash
   dotnet new console -n ImplementInterfaces
   ```

1. Navigate into the newly created project directory:

   ```bash
   cd ImplementInterfaces
   ```

1. Open the project in Visual Studio Code:

   ```bash
   code .
   ```

### Check your work

Ensure that the project has been created successfully by verifying the presence of the `Program.cs` file in the project directory. You should also see the project structure in the Visual Studio Code Explorer pane.

## Task 2: Define the `IPerson` interface with method signatures and properties

Next, you will define an interface that includes method signatures and properties. This interface will be used to enforce a contract for any class that implements it. The code defines an interface in C# which shows interfaces enforcing consistent behavior across classes.

1. Create a new file named `IPerson.cs` in the `ImplementInterfaces` project.

1. Add the following code to define the `IPerson` interface:

   ```csharp
   namespace ImplementInterfaces
   {
       public interface IPerson
       {
           string Name { get; set; }
           int Age { get; set; }
           void DisplayInfo();
       }
   }
   ```

    *The `IPerson` interface has been defined to include the `Name` and `Age` properties, along with the `DisplayInfo` method signature, ensuring a consistent contract for implementing classes.*

## Task 3: Implement the defined `IPerson` interface in a class

Now, you will create a class that implements the `IPerson` interface. This class will provide concrete implementations for the interface members. The code in this step implements an interface in a class and provides concrete implementations for the interface.

1. In the `ImplementInterfaces` project, create a new file named `Student.cs`.

1. Add the following code to implement the `IPerson` interface in the `Student` class:

   ```csharp
   namespace ImplementInterfaces
   {
       public class Student : IPerson
       {
           public string Name { get; set; } = string.Empty;
           public int Age { get; set; } = 0;

           public void DisplayInfo()
           {
               Console.WriteLine($"Student Name: {Name}, Age: {Age}");
           }
       }
   }
   ```

    *The `Student` class has been implemented to adhere to the `IPerson` interface. It provides concrete implementations for the `Name` and `Age` properties, as well as the `DisplayInfo` method, ensuring compliance with the interface contract.*

## Task 4: Create a second class to implement `IPerson` interface with different behavior

You will now create another class that implements the `IPerson` interface but with different behavior. Task 4 implements the same interface in multiple classes. This demonstrates how to provide unique behavior for each class using an interface.

1. Create a new file named `Teacher.cs` in the `ImplementInterfaces` project.

1. Add the following code to implement the `IPerson` interface in the `Teacher` class:

   ```csharp
   namespace ImplementInterfaces
   {
       public class Teacher : IPerson
       {
           public string Name { get; set; } = string.Empty;
           public int Age { get; set; } = 0;

           public void DisplayInfo()
           {
               Console.WriteLine($"Teacher Name: {Name}, Age: {Age}");
           }
       }
   }
   ```

*You have created the `Teacher` class, which implements the `IPerson` interface. This class provides its own implementation for the `Name` and `Age` properties, as well as the `DisplayInfo` method, ensuring it adheres to the interface contract.*

## Task 5: Demonstrate the interface implementation

In this task, you will demonstrate the use of the interface by creating instances of the `Student` and `Teacher` classes and calling their methods. This demonstrates how to use polymorphism to treat objects of different classes as the same interface type.

1. Open the `Program.cs` file in the `ImplementInterfaces` project.

1. Replace the existing code with the following:

   ```csharp
   using System;

   namespace ImplementInterfaces
   {
       class Program
       {
           static void Main(string[] args)
           {
               IPerson student = new Student { Name = "Eric Solomon", Age = 20 };
               IPerson teacher = new Teacher { Name = "Kayla Lewis", Age = 35 };

               student.DisplayInfo();
               teacher.DisplayInfo();
           }
       }
   }
   ```

    *The `Program.cs` file demonstrates how to use the `IPerson` interface to create polymorphic behavior. By creating instances of the `Student` and `Teacher` classes, you can observe how each class adheres to the interface contract while providing its own unique implementation of the `DisplayInfo` method.*

## Task 6: Test the implemented interfaces

Next, you will test the implemented interfaces and their respective classes to ensure they function correctly. This section of code demonstrates how to test interface implementations in a C# application.

1. Ensure that the `Program.cs` file contains the code to create instances of `Student` and `Teacher` and calls their `DisplayInfo` methods and all files are saved.

1. Build the application using the following command:

    ```bash
    dotnet build
    ```

    *Ensure that the build completes successfully without any errors.*

1. Run the application again using the following command:

   ```bash
   dotnet run
   ```

1. Confirm that the application runs without errors and displays the correct information for both the student and the teacher. The output should look similar to the following:

    ```console
    Student Name: Eric Solomon, Age: 20
    Teacher Name: Kayla Lewis, Age: 35
    ```

    *Observe that the output confirms the successful implementation of the `IPerson` interface in both the `Student` and `Teacher` classes. Each class adheres to the interface contract while providing its unique implementation of the `DisplayInfo` method, demonstrating polymorphism in action.*

## Key learnings

This exercise demonstrated how to use interfaces in C# to enforce consistent behavior across multiple classes. By implementing the `IPerson` interface in both `Student` and `Teacher` classes, you explored how interfaces enable polymorphism and allow different classes to share a common contract while maintaining unique behavior. This approach is essential for building scalable and maintainable applications.

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Also, building up a portfolio of projects can be a great way to demonstrate your skills to potential employers.
