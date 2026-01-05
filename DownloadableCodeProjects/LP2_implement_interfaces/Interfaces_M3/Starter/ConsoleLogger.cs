// TASK 5: Refactor the code to use an ILogger interface.

// *This class is responsible for logging messages to the console.
// *Currently, it is tightly coupled to the Application class.
// *In this exercise, you will refactor the code to use an ILogger interface.
public class ConsoleLogger
{
    // Logs a message to the console.
    public void Log(string message)
    {
        Console.WriteLine($"ConsoleLogger: {message}");
    }
}
