
public class Application
{
    private readonly ConsoleLogger _logger;
    private readonly DatabaseAccess _dataAccess;

    // TASK 6: Implement ILogger and IDataAccess interfaces and  
    // refactor this constructor to accept them as parameters.

    // *The Application class represents the main application logic, and 
    // *is tightly coupled to ConsoleLogger and DatabaseAccess.
    // *Currently, the constructor directly instantiates the 
    // *ConsoleLogger and DatabaseAccess classes, creating tight coupling. 
    public Application()
    {
        _logger = new ConsoleLogger();
        _dataAccess = new DatabaseAccess();
    }

    // Runs the application logic.
    public void Run()
    {
        // Log the start of the application.
        _logger.Log("Application started.");

        // Connect to the database and retrieve data.
        _dataAccess.Connect();
        var data = _dataAccess.GetData();

        // Log the retrieved data.
        _logger.Log($"Data retrieved: {data}");

        // Log the end of the application.
        _logger.Log("Application finished.");
    }
}