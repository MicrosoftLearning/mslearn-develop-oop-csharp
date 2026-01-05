public class Application
{
    // The Application class represents the main application logic. 

    // TASK 6: Create references to the ILogger and IDataAccess
    // interfaces, then refactor the Application constructor
    // to accept them as parameters.

    private readonly ILogger _logger;
    private readonly IDataAccess _dataAccess;

    public Application(ILogger logger, IDataAccess dataAccess)
    {
        _logger = logger;
        _dataAccess = dataAccess;
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