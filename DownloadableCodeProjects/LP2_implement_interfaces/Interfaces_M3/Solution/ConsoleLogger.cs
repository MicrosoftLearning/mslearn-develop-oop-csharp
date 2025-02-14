using System;

// This class implements the ILogger interface and is responsible for logging messages to the console.
public class ConsoleLogger : ILogger
{
    // Logs a message to the console.
    public void Log(string message)
    {
        Console.WriteLine($"ConsoleLogger: {message}");
    }
}