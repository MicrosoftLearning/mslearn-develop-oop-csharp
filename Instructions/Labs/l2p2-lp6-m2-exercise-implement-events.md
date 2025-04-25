---
lab:
    title: 'Exercise: Implement events in C#'
    description: 'Practice creating, subscribing to, and raising events in C# using delegates and custom event data classes.'
---

# Implement events in C#

Events in C# are a powerful feature that allows objects to communicate with each other, making it easier to build interactive and dynamic applications.

**Learning Objective:**

- Learners will be able to subscribe to, handle, and raise events in C# using event handlers, delegates, and custom event data classes to create interactive applications.

**Scenario:**

- You are tasked with building a simple application that tracks a counter value and raises an event when the counter exceeds a predefined threshold. This application will demonstrate how to handle user interactions programmatically and dynamically respond to changes using the event-driven programming model in .NET.

This exercise takes approximately **25** minutes to complete.

## Task 1: Set up a new C# project and create the Counter class

**Goal:** Create a new C# project and define a `Counter` class with properties for tracking the counter value and threshold.  

1. Open Visual Studio or Visual Studio Code.

1. Create a new Console Application project:

   - In Visual Studio, select **File > New > Project**, choose **Console App (.NET Core)**, and click **Next**.
   - In Visual Studio Code, open the terminal and run the following command:

    ```bash
     dotnet new console -n CounterApp
     ```

1. Navigate to the newly created project directory (if using Visual Studio Code):

   ```bash
   cd CounterApp
   ```

1. Add a new class file named `Counter.cs` to the project.

1. Define the `Counter` class with the following properties:
   - `int Total`: Tracks the current counter value.
   - `int Threshold`: Represents the threshold value.

   Example code:

   ```csharp
   public class Counter
   {
       public int Total { get; private set; }
       public int Threshold { get; set; }

       public Counter(int threshold)
       {
           Threshold = threshold;
           Total = 0;
       }

       public void Add(int value)
       {
           Total += value;
           Console.WriteLine($"Current Total: {Total}"); // Debugging output
       }
   }
   ```

### Check your work: Set up the Counter class

Ensure that the `Counter` class is correctly defined with the `Total` and `Threshold` properties. Verify that the `Add` method increments the `Total` property and outputs the current total.

## Task 2: Define and implement the ThresholdReached event

**Goal:** Define an event named `ThresholdReached` using the `EventHandler` delegate and implement a method to raise this event when the threshold is exceeded.  

1. In the `Counter` class, add the following event declaration:
   ```csharp
   public event EventHandler ThresholdReached = delegate { };
   ```

1. Implement a protected virtual method named `OnThresholdReached` to raise the event:

   ```csharp
   protected virtual void OnThresholdReached(EventArgs e)
   {
       ThresholdReached?.Invoke(this, e);
   }
   ```

1. Modify the `Add` method to check if the `Total` exceeds the `Threshold`. If it does, call the `OnThresholdReached` method:

   ```csharp
   public void Add(int value)
   {
       Total += value;
       Console.WriteLine($"Current Total: {Total}"); // Debugging output
       if (Total >= Threshold)
       {
           OnThresholdReached(EventArgs.Empty);
       }
   }
   ```

### Implement the ThresholdReached event

1. Create an instance of the `Counter` class in a `Main` method in the Program.cs file:

    ```csharp
    var counter = new Counter(5);
    ```

1. Subscribe to the `ThresholdReached` event:

    ```csharp
    counter.ThresholdReached += (sender, e) =>
    {
         Console.WriteLine("Threshold reached!");
    };
    ```

1. Increment the counter value using the `Add` method and verify that the event is triggered when the threshold is exceeded:

    ```csharp
    counter.Add(3);
    counter.Add(2); // This should trigger the event
    ```

1. Verify that the completed Program.cs has the following code:

    ```csharp
    var counter = new Counter(5);
    
    counter.ThresholdReached += (sender, e) =>
    {
        Console.WriteLine("Threshold reached!");
    };
    
    counter.Add(3);
    counter.Add(2); // This should trigger the event
    ```

### Check your work: implement the ThresholdReached event

Run the application and confirm that the message is simlar to the following when running after pressing `a` ten times.
 
```console
    Press 'a' to add 1 to the counter or 'q' to quit.
    Current Total: 1
    Current Total: 2
    Current Total: 3
    Current Total: 4
    Current Total: 5
    Current Total: 6
    Current Total: 7
    Current Total: 8
    Current Total: 9
    Current Total: 10
    Threshold of 10 reached at 4/22/2025 8:54:42 AM.
```

is displayed when the threshold is exceeded.

## Task 3: Create a custom event data class

**Goal:** Create a custom event data class named `ThresholdReachedEventArgs` to include additional information about the event, such as the threshold value and the time it was reached.  

1. Add a new class file named `ThresholdReachedEventArgs.cs` to the project.

1. Define the `ThresholdReachedEventArgs` class, inheriting from `EventArgs`:

   ```csharp
   public class ThresholdReachedEventArgs : EventArgs
   {
       public int Threshold { get; set; }
       public DateTime TimeReached { get; set; }
   }
   ```

1. Update the `ThresholdReached` event in the `Counter` class to use the `EventHandler<ThresholdReachedEventArgs>` delegate:
   ```csharp
   public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
   ```

1. Modify the `OnThresholdReached` method to accept a `ThresholdReachedEventArgs` parameter:
   ```csharp
   protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
   {
       ThresholdReached?.Invoke(this, e);
   }
   ```

1. Update the `Add` method to create and pass a `ThresholdReachedEventArgs` object when raising the event:

   ```csharp
   public void Add(int value)
   {
       Total += value;
       Console.WriteLine($"Current Total: {Total}");
       if (Total >= Threshold)
       {
           var args = new ThresholdReachedEventArgs
           {
               Threshold = Threshold,
               TimeReached = DateTime.Now
           };
           OnThresholdReached(args);
       }
   }
   ```

### Check your work: Create the custom event data class

Verify that the `ThresholdReachedEventArgs` class is correctly implemented and that the `ThresholdReached` event now includes additional event data.

## Task 4: Write an event handler method

**Goal:** Write an event handler method in the main program to respond to the `ThresholdReached` event and display a message when the event is triggered.  

1. In the `Program.cs` file, create an instance of the `Counter` class in the `Main` method:

   ```csharp
   var counter = new Counter(10);
   ```

1. Subscribe to the `ThresholdReached` event using the `+=` operator:

   ```csharp
   counter.ThresholdReached += Counter_ThresholdReached;
   ```

1. Define the `Counter_ThresholdReached` event handler method:

   ```csharp
   static void Counter_ThresholdReached(object? sender, ThresholdReachedEventArgs e)
   {
       Console.WriteLine($"Threshold of {e.Threshold} reached at {e.TimeReached}.");
   }
   ```

### Check your work: Write the event handler

Run the application and verify that the message is displayed when the threshold is reached.

## Task 5: Subscribe and unsubscribe from the event

**Goal:** Programmatically subscribe to and unsubscribe from the `ThresholdReached` event using the `+=` and `-=` operators, and test the application by incrementing the counter value.  

1. In the `Main` method, subscribe to the `ThresholdReached` event as shown in Task 4.

1. Add a loop to increment the counter value and test the event:

   ```csharp
   Console.WriteLine("Press 'a' to add 1 to the counter or 'q' to quit.");
   while (true)
   {
       var key = Console.ReadKey(true).KeyChar;
       if (key == 'a')
       {
           counter.Add(1);
       }
       else if (key == 'q')
       {
           break;
       }
   }
   ```

1. Unsubscribe from the `ThresholdReached` event before exiting the program:

   ```csharp
   counter.ThresholdReached -= Counter_ThresholdReached;
   ```

### Check your work: Subscribe and unsubscribe from the event

Test the application by pressing 'a' to increment the counter and verify that the event is triggered. Ensure that unsubscribing from the event prevents further notifications.

### Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Also, building up a portfolio of projects can be a great way to demonstrate your skills to potential employers.
