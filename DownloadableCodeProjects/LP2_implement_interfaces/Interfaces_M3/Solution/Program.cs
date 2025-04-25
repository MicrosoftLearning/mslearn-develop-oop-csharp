// TASK 7: Refactor Program to use dependency injection.
// Refactor the Program class to create instances of ILogger and IDataAccess 
// and pass them as dependencies to the Application class constructor.
// This change decouples the Program class from specific implementations 
// and aligns it with the refactored Application class.
var logger = new ConsoleLogger();
var dataAccess = new DatabaseAccess();

// Inject the dependencies into the Application class.
var app = new Application(logger, dataAccess);
app.Run();