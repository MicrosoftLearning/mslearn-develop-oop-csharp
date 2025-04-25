// TASK 3: Refactor the code to use an IDataAccess interface.
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