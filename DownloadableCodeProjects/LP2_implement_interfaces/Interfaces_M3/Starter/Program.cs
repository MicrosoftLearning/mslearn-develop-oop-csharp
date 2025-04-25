// This is the entry point of the application.
// It creates an instance of the Application class and runs it.
// After refactoring, the Application class will accept dependencies via its constructor.

// TASK 7: Refactor Program to use dependency injection.
// Refactor the Program class to create instances of ILogger and IDataAccess 
// and pass them as dependencies to the Application class constructor.
// This change decouples the Program class from specific implementations 
// and align it with the refactored Application class.


// Note: After refactoring, the Application class will require ILogger and IDataAccess
// instances to be passed into its constructor.
var app = new Application();
app.Run();
