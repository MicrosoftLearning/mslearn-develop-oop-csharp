---
lab:
    title: 'Exercise - Implement tasks asynchronously and in parallel'
    description: 'Learn how to improve app responsiveness by converting synchronous methods into asynchronous tasks, and how to reduce performance bottlenecks in your apps by running asynchronous tasks in parallel.'
---

# Implement tasks asynchronously and in parallel

In this exercise, you learn how to implement asynchronous tasks in C# to improve the responsiveness of your apps. You implement the `async` and `await` keywords to convert synchronous file I/O methods into asynchronous tasks that use the `Task` class to represent the result of an asynchronous operation. You also learn how to run tasks in parallel using the `Parallel` class, using methods such as `Parallel.ForEachAsync` to improve the performance of your code.

This exercise takes approximately **20** minutes to complete.

## Before you start

Before you can start this exercise, you need to:

1. Ensure that you have the latest short term support (STS) version of the .NET SDK installed on your computer. You can download the latest versions of the .NET SDK using the following URL: <a href="https://dotnet.microsoft.com/download/" target="_blank">Download .NET</a>

1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code using the following URL: <a href="https://code.visualstudio.com/download/" target="_blank">Download Visual Studio Code</a>

1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For additional help configuring the Visual Studio Code environment, see <a href="https://learn.microsoft.com/training/modules/install-configure-visual-studio-code/" target="_blank">Install and configure Visual Studio Code for C# development</a>

## Exercise scenario

Suppose you've agreed to help a non-profit company with a software project. Before the project kicks off, you decide to update your object-oriented programming skills by developing a banking app. The current version of your app supports basic operations such as creating accounts, managing transactions, and archiving bank records. To practice asynchronous programming, you're going convert synchronous file I/O methods into asynchronous tasks that improve the responsiveness of your app. You'll also investigate the performance gains achieved by running async tasks in parallel.

This exercise includes the following tasks:

1. Review the current version of your banking app.

1. Create a performance baseline using methods that load customer data synchronously.

1. Create classes that load customer data asynchronously and evaluate improved response times.

1. Create classes run async tasks in parallel and evaluate improved performance times.

## Review the current version of your banking app

In this task, you download the existing version of your banking app and review the code.

Use the following steps to complete this section of the exercise:

1. Download the starter code from the following URL: [Access local files asynchronously - exercise code projects](https://github.com/MicrosoftLearning/mslearn-develop-oop-csharp/raw/refs/heads/main/DownloadableCodeProjects/Downloads/LP5SampleApps.zip)

1. Extract the contents of the LP5SampleApps.zip file to a folder location on your computer.

    For example, if your running Windows, you can extract the file contents to your Desktop folder.

1. Expand the LP5SampleApps folder, and then open the `Files_M3` folder.

    The Files_M3 folder contains the following code project folders:

    - Solution
    - Starter

    The **Starter** folder contains the starter project files for this exercise.

1. Use Visual Studio Code to open the **Starter** folder.

1. In the EXPLORER view, collapse the **STARTER** folder, select **SOLUTION EXPLORER**, and expand the **Files_M3** project folders.

    You should see the following project folders and files:

    - Interfaces
        - IBankAccount.cs
        - IBankCustomer.cs
        - IMonthlyReportable.cs
        - IQuarterlyReportable.cs
        - IYearlyReportable.cs
    - Models
        - Bank.cs
        - BankAccount.cs
        - BankCustomer.cs
        - BankCustomerMethods.cs
        - CheckingAccount.cs
        - MoneyMarketAccount.cs
        - SavingsAccount.cs
        - Transaction.cs
    - Services
        - AccountCalculations.cs
        - AccountReportGenerator.cs
        - BankAccountDTO.cs
        - BankCustomerDTO.cs
        - CustomerReportGenerator.cs
        - Extensions.cs
        - JsonRetrieval.cs
        - JsonStorage.cs
        - SimulateCustomerAccountActivity.cs
        - SimulateDepositsWithdrawalsTransfers.cs
        - SimulateTransactions.cs
    - Program.cs

1. Take a few minutes to open and review each of the following files:

    - `Bank.cs`: This file defines the Bank class, which implements a collection of bank customers and provides methods that manage customers and retrieve bank information.

    - `BankAccount.cs`: This file defines the BankAccount class, which implements the IBankAccount interface and includes properties, constructors, and methods for account operations.

    - `BankCustomer.cs`: This file defines the BankCustomer partial class, which implements the IBankCustomer interface and includes properties and constructors for customer constructor.

    - `BankCustomerMethods.cs`: This file defines the BankCustomerMethods partial class, which implements the IBankCustomer interface and contains methods for the BankCustomer class.

    - `Transaction.cs`: This file defines the Transaction class, which implements the ITransaction interface and includes properties, constructors, and methods for transaction operations.

    - `JsonRetrieval.cs`: This file defines the JsonRetrieval class, which includes methods that load and save customer data to JSON files.

    - `JsonStorage.cs`: This file defines the JsonStorage class, which includes methods that load and save customer data to JSON files.

    - `SimulateDepositsWithdrawalsTransfers.cs`: This file defines the SimulateDepositsWithdrawalsTransfers class, which includes methods that simulate deposits, withdrawals, and transfers for bank accounts.

    - `Program.cs`: This file includes the main entry point for the app and uses BankCustomer and BankAccount objects implement deposit, withdrawal, and transfer operations.

    Notice that a bank object includes a collection of bank customer objects, and that each customer object includes a collection of bank accounts owned by that customer. The account objects include a collection of transactions, which provide a record of the deposits, withdrawals, and transfers associated with the account. The app can simulate customer account activity by generating transactions for each account. The app can also backup and restore customer data.

1. Run the app and review the output in the terminal window.

    To run your app, right-click the **Files_M3** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    Your app should generate a series of messages that describe bank transactions. The following information should appear at the end of the output:

    ```plaintext

    Bank customer information for Niki Demetriou backed up to JSON files.
    
    Retrieved customer information for Niki Demetriou:
    Customer ID: 0019356514
    First Name: Niki
    Last Name: Demetriou
    Number of accounts: 3
    
    Account number: 19180912 is a Checking account.
     - Balance: 4212.1
     - Interest Rate: 0
     - Transactions:
        Transaction ID: cbf51390-9c25-4987-a82f-acd855756420, Type: Withdraw, Date: 2/1/2025, Time: 12:00 PM, Prior Balance: $5,000.00 Amount: $3,123.40, Source Account: 19180908, Target Account: 19180908, Description: Rent payment
        Transaction ID: 250a4ade-cd6a-41ee-9fa9-149677fbebf1, Type: Withdraw, Date: 2/1/2025, Time: 9:00 PM, Prior Balance: $1,876.60 Amount: $210.00, Source Account: 19180908, Target Account: 19180908, Description: Debit card purchase
        Transaction ID: afc4d064-cb20-454b-a24c-6918f3a78cf5, Type: Withdraw, Date: 2/3/2025, Time: 8:00 AM, Prior Balance: $1,666.60 Amount: $400.00, Source Account: 19180908, Target Account: 19180908, Description: Withdraw for expenses
        Transaction ID: ea95ca23-fcc2-4016-ae57-901b5f0f7096, Type: Bank Fee, Date: 2/3/2025, Time: 12:00 PM, Prior Balance: $1,266.60 Amount: $50.00, Source Account: 19180908, Target Account: 19180908, Description: -(BANK FEE)
        Transaction ID: c7486aca-82ec-4efa-bb10-f3bb641a78de, Type: Bank Refund, Date: 2/5/2025, Time: 12:00 PM, Prior Balance: $1,216.60 Amount: $100.00, Source Account: 19180908, Target Account: 19180908, Description: Refund for overcharge -(BANK REFUND)
        Transaction ID: f10d8b45-0154-480e-8d9c-3b882e5e849c, Type: Withdraw, Date: 2/8/2025, Time: 9:00 PM, Prior Balance: $1,316.60 Amount: $172.00, Source Account: 19180908, Target Account: 19180908, Description: Debit card purchase
        Transaction ID: eddadfb5-3607-4a5a-97f5-13734d4332da, Type: Withdraw, Date: 2/10/2025, Time: 8:00 AM, Prior Balance: $1,144.60 Amount: $400.00, Source Account: 19180908, Target Account: 19180908, Description: Withdraw for expenses
        Transaction ID: 19400612-3f7a-4e32-9f44-1d7fd5419f83, Type: Bank Fee, Date: 2/10/2025, Time: 12:00 PM, Prior Balance: $744.60 Amount: $50.00, Source Account: 19180908, Target Account: 19180908, Description: -(BANK FEE)
        Transaction ID: ca320c88-87dd-4472-bc9b-450becd3be1c, Type: Deposit, Date: 2/14/2025, Time: 12:00 PM, Prior Balance: $694.60 Amount: $3,878.00, Source Account: 19180908, Target Account: 19180908, Description: Bi-monthly salary deposit
        Transaction ID: ccc7dbc0-9bcb-4693-a472-0c4ae0233ffd, Type: Withdraw, Date: 2/15/2025, Time: 9:00 PM, Prior Balance: $4,572.60 Amount: $176.00, Source Account: 19180908, Target Account: 19180908, Description: Debit card purchase
        Transaction ID: 6cd83ff5-a259-4879-9d9f-542769f6565f, Type: Withdraw, Date: 2/17/2025, Time: 8:00 AM, Prior Balance: $4,396.60 Amount: $400.00, Source Account: 19180908, Target Account: 19180908, Description: Withdraw for expenses
        Transaction ID: 076404f8-d3ea-4604-a939-e53ca7c9ff19, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $3,996.60 Amount: $67.00, Source Account: 19180908, Target Account: 19180908, Description: Auto-pay waste management bill
        Transaction ID: 1a9c7382-4127-437a-895a-e1f873a6eaac, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $3,929.60 Amount: $82.00, Source Account: 19180908, Target Account: 19180908, Description: Auto-pay water and sewer bill
        Transaction ID: 3e0d4290-a1af-423e-9264-d1ff2caf8f67, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $3,847.60 Amount: $141.00, Source Account: 19180908, Target Account: 19180908, Description: Auto-pay gas and electric bill
        Transaction ID: 24447a0f-2b43-4488-87be-a7981676f0ee, Type: Withdraw, Date: 2/20/2025, Time: 12:00 PM, Prior Balance: $3,706.60 Amount: $158.00, Source Account: 19180908, Target Account: 19180908, Description: Auto-pay health club membership
        Transaction ID: 8abd92bf-06c0-47cd-8885-2dec8c3a9faf, Type: Withdraw, Date: 2/22/2025, Time: 9:00 PM, Prior Balance: $3,548.60 Amount: $169.00, Source Account: 19180908, Target Account: 19180908, Description: Debit card purchase
        Transaction ID: 6997228e-f99e-4f63-85eb-cc28f3cc6d7f, Type: Withdraw, Date: 2/24/2025, Time: 8:00 AM, Prior Balance: $3,379.60 Amount: $400.00, Source Account: 19180908, Target Account: 19180908, Description: Withdraw for expenses
        Transaction ID: f09399bc-d897-496a-afdc-83217ced33e6, Type: Withdraw, Date: 2/28/2025, Time: 12:00 PM, Prior Balance: $2,979.60 Amount: $1,745.50, Source Account: 19180908, Target Account: 19180908, Description: Auto-pay credit card bill
        Transaction ID: eb005071-ec65-45e7-aec8-9a3c0ceb86e9, Type: Deposit, Date: 2/28/2025, Time: 12:00 PM, Prior Balance: $1,234.10 Amount: $3,878.00, Source Account: 19180908, Target Account: 19180908, Description: Bi-monthly salary deposit
        Transaction ID: d322e94b-574b-4784-8f57-18629c7f71df, Type: Transfer, Date: 2/28/2025, Time: 12:00 PM, Prior Balance: $5,112.10 Amount: $900.00, Source Account: 19180908, Target Account: 19180908, Description: Transfer from checking to savings account-(TRANSFER)
    
    Account number: 19180913 is a Savings account.
     - Balance: 15900
     - Interest Rate: 0
     - Transactions:
        Transaction ID: d036e8a4-d74d-41fc-bebb-1fab57973bb6, Type: Transfer, Date: 2/28/2025, Time: 12:00 PM, Prior Balance: $15,000.00 Amount: $900.00, Source Account: 19180909, Target Account: 19180909, Description: Transfer from checking to savings account-(TRANSFER)
    
    Account number: 19180914 is a Money Market account.
     - Balance: 90000
     - Interest Rate: 0
     - Transactions:
    
    ```

    > **NOTE**: The customer IDs, account numbers, and transaction amounts are based on randomly generated values. The values in your output will be different from the example output.

## Create a performance baseline using methods that load customer data synchronously

File I/O operations can be time-consuming, especially when dealing with large files or network resources. Understanding baseline behavior is important because it allows you to measure the performance of your app and identify potential bottlenecks. By establishing a performance baseline, you can compare the performance of different implementations and determine if your changes have improved or degraded performance.

For the banking app, you can establish a performance baseline by measuring the time it takes to load customer data using synchronous code in methods.

In this task, you complete the following actions:

- Create an `ApprovedCustomersLoader` class that loads bank customer names from a JSON file.
- Create a `LoadCustomerLogs` class that uses customer names to find and load customer data from existing backup files.
- Update the `Program.cs` file to load BankCustomer data using synchronous tasks and establish a performance baseline.

Use the following steps to complete this section of the exercise:

1. Create a new class file named **ApprovedCustomersLoader** in the **Services** folder.

1. Replace the contents of the **ApprovedCustomersLoader** file with the following code:

    ```csharp

    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;
    
    namespace Files_M3;
    
    public static class ApprovedCustomersLoader
    {
        /*
    
        // The .csproj file needs to include the following ItemGroup element to copy the Config folder to the output directory
    
        <ItemGroup>
        <!-- Include all files in the Config folder and copy them to the output directory -->
        <Content Include="Config\**\*">
            <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
        </Content>
        </ItemGroup>
        
        */
    
        private static readonly string ConfigFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Config", "ApprovedCustomers.json");
    
        public static List<ApprovedCustomer> LoadApprovedNames()
        {
            if (!File.Exists(ConfigFilePath))
            {
                throw new FileNotFoundException($"Configuration file not found: {ConfigFilePath}");
            }
    
            var json = File.ReadAllText(ConfigFilePath);
            var config = JsonSerializer.Deserialize<ApprovedCustomersConfig>(json);
            return config?.ApprovedNames ?? new List<ApprovedCustomer>();
        }
    
        private class ApprovedCustomersConfig
        {
            public List<ApprovedCustomer> ApprovedNames { get; set; } = new List<ApprovedCustomer>();
        }

        public class ApprovedCustomer
        {
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
        }
    }

    ```

    This code defines the `ApprovedCustomersLoader` class that's used to load customer names from a JSON file and two nested classes that define the structure of the JSON file. The `LoadApprovedNames` method loads customer names from a JSON file named **ApprovedCustomers.json**. The JSON file is located in the **Config** folder, which is included in the project.

    The `ApprovedCustomersConfig` class defines the structure of the JSON file.

    The `ApprovedCustomer` class defines the properties for each customer name.

1. Create a new class file named **LoadCustomerLogs** in the **Services** folder.

1. Replace the contents of the **LoadCustomerLogs** file with the following code:

    ```csharp

    using System;
    using System.IO;
    using System.Text.Json;
    
    namespace Files_M3;
    
    public class LoadCustomerLogs
    {
        /*
    
        // The .csproj file needs to include the following ItemGroup element to copy the Config folder to the output directory
    
        <ItemGroup>
        <!-- Include all files in the Config folder and copy them to the output directory -->
        <Content Include="Config\**\*">
            <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
        </Content>
        </ItemGroup>
        
        */
    
        // create the GenerateCustomerData method
        public static void ReadCustomerData(Bank bank)
        {
            string ConfigDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Config");
            string accountsDirectoryPath = Path.Combine(ConfigDirectoryPath, "Accounts");
            string transactionsDirectoryPath = Path.Combine(ConfigDirectoryPath, "Transactions");
            
            JsonRetrieval.LoadAllCustomers(bank, ConfigDirectoryPath, accountsDirectoryPath, transactionsDirectoryPath);
    
        }
    }

    ```

    This code defines the `LoadCustomerLogs` class, which includes a method named `ReadCustomerData`. The `ReadCustomerData` method loads customer data from JSON files and adds the data to the bank object. The method uses the `JsonRetrieval` class to load customer data from JSON files.

    Notice that the `Bank.AddCustomers` method isn't recognized. You'll need to add the `AddCustomers` method to the **Bank.cs** file.

1. Open the **Program.cs** file.

1. Replace the contents of the **Program.cs** file with the following code:

    ```csharp

    using Files_M3;

    using System;
    using System.IO;
    using System.Text;
    using System.Text.Json;
    
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Create a performance baseline by loading data synchronously.");
    
            // Create Bank objects
            Bank bank1 = new Bank(); // Bank object to load data synchronously
            Bank bank2 = new Bank(); // Bank object to load data asynchronously
            Bank bank3 = new Bank(); // Bank object to load data asynchronously and in parallel
    
            // get the time before loading the data
            DateTime timeBeforeLoadCall = DateTime.Now;
    
            // Load the customer data from the file
            LoadCustomerLogs.ReadCustomerData(bank1);
    
            // get the time after loading the data
            DateTime timeAfterLoadCall = DateTime.Now;
    
            // calculate the time taken to load the data
            TimeSpan timeTakenToReturn = timeAfterLoadCall - timeBeforeLoadCall;
            Console.WriteLine($"\nPerformance baseline: time taken to return to Main: {timeTakenToReturn.TotalSeconds} seconds");

        }
    }

    ```

    This code instantiates three BankAccount objects and uses the `LoadCustomerLogs` class to load customer data from JSON files into the first bank object. The `LoadCustomerLogs` class uses synchronous methods to load the customer data.

    The code includes a timer that measures the time taken to process the `ReadCustomerData` method and return control to the `Main` method. This time establishes the "Performance baseline" for synchronous loading of customer data.

    You may notice the warning message associated with the `Main` method: "This async method lacks 'await' operators and will run synchronously". The `async` keyword in the method signature indicates that the method contains asynchronous code, which it doesn't at this point. You'll add asynchronous code in the next task.

1. Save your changes and run the app.

    To run your app, right-click the **Files_M3** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    Your app should produce output that's similar to the following example:

    ```plaintext

    Create a performance baseline by loading data synchronously.
    
    Implement File I/O tasks using synchronous code.
    
    Performance baseline: time taken to return to Main: 3.998498 seconds

    ```

    The time taken to load the customer data files will vary based on the computer that you're using.

    > **NOTE**
    > When you run this app in a clean environment, the first run may take longer than subsequent runs. During the first run, the app copies JSON files to a Config folder in the `bin\Debug\net9.0` folder. Subsequent runs will be faster because the Config files are already prepared.

## Create classes that load customer data asynchronously and evaluate improved response times

The async and await keywords are used in C# to simplify asynchronous programming. The async keyword is used to declare a method as asynchronous, allowing it to run in the background without blocking the main thread. The await keyword is used to pause the execution of an async method until the awaited task is complete, allowing other tasks to run in the meantime.

In this task, you complete the following actions:

- Create a new class named `JsonRetrievalAsync` that includes async versions of the `JsonRetrieval` methods.
- Create a new class named `ApprovedCustomersLoaderAsync` that includes async versions of the `ApprovedCustomersLoader` methods.
- Create a new class named `LoadCustomerLogsAsync` that includes async versions of the `LoadCustomerLogs` methods.
- Use the `Program.cs` file to evaluate the time it takes to load BankCustomer data using asynchronous tasks.

Use the following steps to complete this section of the exercise:

1. Create a new class file named **JsonRetrievalAsync** in the **Services** folder.

1. Replace the contents of the **JsonRetrievalAsync** file with the following code:

    ```csharp

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;
    using System.Threading.Tasks;
    
    namespace Files_M3;

    public static class JsonRetrievalAsync
    {
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            MaxDepth = 64,
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
        };

        public static async Task<BankCustomerDTO> LoadBankCustomerDTOAsync(string filePath)
        {
            using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous);
            var customerDTO = await JsonSerializer.DeserializeAsync<BankCustomerDTO>(stream, _options);

            if (customerDTO == null)
            {
                throw new Exception("Customer could not be deserialized.");
            }

            return customerDTO;
        }

        public static async Task<BankCustomer> LoadBankCustomerAsync(Bank bank, string filePath, string accountsDirectoryPath, string transactionsDirectoryPath)
        {
            var customerDTO = await LoadBankCustomerDTOAsync(filePath);

            var bankCustomer = bank.GetCustomerById(customerDTO.CustomerId);

            if (bankCustomer == null)
            {
                bankCustomer = new BankCustomer(customerDTO.FirstName, customerDTO.LastName, customerDTO.CustomerId, bank);
                bank.AddCustomer(bankCustomer);
            }

            foreach (var accountNumber in customerDTO.AccountNumbers)
            {
                var existingAccount = bankCustomer.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);

                if (existingAccount == null)
                {
                    var accountFilePath = Path.Combine(accountsDirectoryPath, $"{accountNumber}.json");
                    var recoveredAccount = await LoadBankAccountAsync(accountFilePath, transactionsDirectoryPath, bankCustomer);

                    if (recoveredAccount != null)
                    {
                        bankCustomer.AddAccount(recoveredAccount);
                    }
                }
                else
                {
                    bankCustomer.AddAccount(existingAccount);
                }
            }

            return bankCustomer;
        }

        public static async Task<IEnumerable<BankCustomer>> LoadAllCustomersAsync(Bank bank, string directoryPath, string accountsDirectoryPath, string transactionsDirectoryPath)
        {
            List<BankCustomer> customers = new List<BankCustomer>();
            foreach (var filePath in Directory.GetFiles(Path.Combine(directoryPath, "Customers"), "*.json"))
            {
                customers.Add(await LoadBankCustomerAsync(bank, filePath, accountsDirectoryPath, transactionsDirectoryPath));
            }
            return customers;
        }

        public static async Task<BankAccount> LoadBankAccountAsync(string accountFilePath, string transactionsDirectoryPath, BankCustomer customer)
        {
            var accountDTO = await LoadBankAccountDTOAsync(accountFilePath);

            var existingAccount = customer.Accounts.FirstOrDefault(a => a.AccountNumber == accountDTO.AccountNumber);

            if (existingAccount != null)
            {
                return (BankAccount)existingAccount;
            }
            else
            {
                var recoveredBankAccount = new BankAccount(customer, customer.CustomerId, accountDTO.Balance, accountDTO.AccountType);

                string transactionsFilePath = Path.Combine(transactionsDirectoryPath, $"{accountDTO.AccountNumber}-transactions.json");

                if (File.Exists(transactionsFilePath))
                {
                    var recoveredTransactions = await LoadAllTransactionsAsync(transactionsFilePath);
                    foreach (var transaction in recoveredTransactions)
                    {
                        recoveredBankAccount.AddTransaction(transaction);
                    }
                }

                return recoveredBankAccount;
            }
        }

        public static async Task<IEnumerable<Transaction>> LoadAllTransactionsAsync(string filePath)
        {
            using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous);
            var transactions = await JsonSerializer.DeserializeAsync<IEnumerable<Transaction>>(stream, _options);

            if (transactions == null)
            {
                throw new Exception("Transactions could not be deserialized.");
            }

            return transactions;
        }

        public static async Task<BankAccountDTO> LoadBankAccountDTOAsync(string filePath)
        {
            using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous);
            var accountDTO = await JsonSerializer.DeserializeAsync<BankAccountDTO>(stream, _options);

            if (accountDTO == null)
            {
                throw new Exception("Account could not be deserialized.");
            }

            return accountDTO;
        }
    }

    ```

    This code defines the `JsonRetrievalAsync` class, which includes async versions of the `LoadBankCustomerDTO`, `LoadBankCustomer`, `LoadAllCustomers`, and `LoadAllTransactions` methods found in the `JsonRetrieval` class. The `async` and `await` keywords are used to make the methods asynchronous, allowing them to run in the background without blocking the main thread. The methods are also updated to return `Task<T>` objects, which represent the result of an asynchronous operation.

1. Create a new class file named **ApprovedCustomersLoaderAsync** in the **Services** folder.

1. Replace the contents of the **ApprovedCustomersLoaderAsync** file with the following code:

    ```csharp

    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    
    namespace Files_M3;
    
    public static class ApprovedCustomersLoaderAsync
    {
        /*
        // The .csproj file needs to include the following ItemGroup element to copy the Config folder to the output directory
    
        <ItemGroup>
        <!-- Include all files in the Config folder and copy them to the output directory -->
        <Content Include="Config\**\*">
            <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
        </Content>
        </ItemGroup>
        */
    
        private static readonly string ConfigFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Config", "ApprovedCustomers.json");
    
        public static async Task<List<ApprovedCustomer>> LoadApprovedNamesAsync()
        {
            if (!File.Exists(ConfigFilePath))
            {
                throw new FileNotFoundException($"Configuration file not found: {ConfigFilePath}");
            }
    
            var json = await File.ReadAllTextAsync(ConfigFilePath);
            var config = await JsonSerializer.DeserializeAsync<ApprovedCustomersConfig>(new MemoryStream(Encoding.UTF8.GetBytes(json)));
            return config?.ApprovedNames ?? new List<ApprovedCustomer>();
        }
    
        private class ApprovedCustomersConfig
        {
            public List<ApprovedCustomer> ApprovedNames { get; set; } = new List<ApprovedCustomer>();
        }
    
        public class ApprovedCustomer
        {
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
        }
    }

    ```

    This code defines the `ApprovedCustomersLoaderAsync` class, which includes an async version of the `LoadApprovedNames` method found in the `ApprovedCustomersLoader` class. The `LoadApprovedNamesAsync` method uses the `async` and `await` keywords to make the method asynchronous, allowing it to run in the background without blocking the main thread. The method is also updated to return a `Task<T>` object, which represents the result of an asynchronous operation.

1. Create a new class file named **LoadCustomerLogsAsync** in the **Services** folder.

1. Replace the contents of the **LoadCustomerLogsAsync** file with the following code:

    ```csharp

    using System;
    using System.IO;
    using System.Threading.Tasks;
    
    namespace Files_M3;
    
    public class LoadCustomerLogsAsync
    {
        public static async Task ReadCustomerDataAsync(Bank bank)
        {
            string configDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Config");
            string accountsDirectoryPath = Path.Combine(configDirectoryPath, "Accounts");
            string transactionsDirectoryPath = Path.Combine(configDirectoryPath, "Transactions");

            await JsonRetrievalAsync.LoadAllCustomersAsync(bank, configDirectoryPath, accountsDirectoryPath, transactionsDirectoryPath);
        }
    }

    ```

    This code defines the `LoadCustomerLogsAsync` class, which includes an async version of the `ReadCustomerData` method found in the `LoadCustomerLogs` class. The `ReadCustomerDataAsync` method uses the `async` and `await` keywords to make the method asynchronous, allowing it to run in the background without blocking the main thread. The method signature specifies type `Task` to indicate that the method runs asynchronously but has no return value. The `void` keyword is not used in the method signature because it would indicate that the method runs synchronously and does not return a value.

1. Open the **Program.cs** file.

1. Add the following code to the end of the **Main** method:

    ```csharp

        // wait 2 seconds before starting the async task
         await Task.Delay(2000);

        // Load the customer data asynchronously from the file
        Console.WriteLine("\nImplement File I/O tasks asynchronously.");

        // Get the time before loading the data asynchronously
        DateTime timeBeforeAsyncLoadCall = DateTime.Now;

        // Start the async data loading task
        var asyncLoadTask = LoadCustomerLogsAsync.ReadCustomerDataAsync(bank2);

        DateTime timeAfterAsyncLoadCall = DateTime.Now;

        Console.WriteLine($"\nTime taken to return to Main: {(timeAfterAsyncLoadCall - timeBeforeAsyncLoadCall).TotalSeconds} seconds");

        // Wait for the async task to complete
        await asyncLoadTask;

        DateTime timeAfterAsyncLoadCompleted = DateTime.Now;

        Console.WriteLine($"Time taken to load the data asynchronously: {(timeAfterAsyncLoadCompleted - timeBeforeAsyncLoadCall).TotalSeconds} seconds");

    ```

    This code adds a new section to the `Main` method that loads customer data asynchronously using the `LoadCustomerLogsAsync` class. The code includes a timer that measures the time taken to return from the `ReadCustomerDataAsync` method. The code also counts the number of customers, accounts, and transactions loaded into the second bank object.

    The code uses the `await` keyword to pause the execution of the `Main` method until the async task is complete. The `Task.Delay` method is used to simulate a delay before starting the async task. The `asyncLoadTask` variable is used to store the task returned by the `ReadCustomerDataAsync` method. The `await` keyword is used to wait for the task to complete before continuing with the rest of the code.

1. Save your changes and run the app.

    To run your app, right-click the **Files_M3** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    Your app should produce output that's similar to the following example:

    ```plaintext

    Create a performance baseline by loading data synchronously.
    
    Performance baseline: time taken to return to Main: 0.398102 seconds
    
    Implement File I/O tasks asynchronously.
    
    Time taken to return to Main: 0.0559627 seconds
    Time taken to load the data asynchronously: 0.4467103 seconds

    ```

    Notice that the results for the asynchronous code includes two times:

    - The time taken to return to the `Main` method. This is the time that the app user is waiting and represents app responsiveness.
    - The time taken to load the customer data asynchronously. This is the time required to load data from disk to in-memory objects and represents code performance.

    In this case, the asynchronous code greatly improves app responsiveness. The time required to actually read file information from the disk drive isn't affected by run tasks asynchronously. However, asynchronous tasks can be run in parallel to improve performance, which is the next task.

## Create classes run async tasks in parallel and evaluate improved performance times

Parallel processing is a programming technique that allows multiple tasks to be executed simultaneously, improving performance and reducing execution time. In C#, the `Parallel` class provides methods for parallelizing loops and tasks, enabling developers to take advantage of multi-core processors.

In this task, you complete the following actions:

- Create a new class named `JsonRetrievalAsyncParallel` that includes versions of the `JsonRetrievalAsync` methods that implement parallel processing.
- Create a new class named `LoadCustomerLogsAsyncParallel` that implements the parallel processing methods in `JsonRetrievalAsyncParallel`.
- Use the `Program.cs` file to evaluate the time it takes to load BankCustomer data using asynchronous tasks running in parallel.

Use the following steps to complete this section of the exercise:

1. Create a new class file named **JsonRetrievalAsyncParallel** in the **Services** folder.

1. Replace the contents of the **JsonRetrievalAsyncParallel** file with the following code:

    ```csharp

    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;
    using System.Collections.Concurrent;
    
    namespace Files_M3;
    
    public static class JsonRetrievalAsyncParallel
    {
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            MaxDepth = 64,
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
        };
    
        public static async Task<BankCustomerDTO> LoadBankCustomerDTOAsync(string filePath)
        {
            string json = await File.ReadAllTextAsync(filePath);
    
            if (string.IsNullOrEmpty(json))
            {
                throw new Exception("No customer found.");
            }
    
            var customerDTO = JsonSerializer.Deserialize<BankCustomerDTO>(json, _options);
            if (customerDTO == null)
            {
                throw new Exception("Customer could not be deserialized.");
            }
    
            return customerDTO;
        }
    
        public static async Task<BankCustomer> LoadBankCustomerAsyncParallel(Bank bank, string filePath, string accountsDirectoryPath, string transactionsDirectoryPath)
        {
            var customerDTO = await LoadBankCustomerDTOAsync(filePath);
    
            var bankCustomer = bank.GetCustomerById(customerDTO.CustomerId);
    
            if (bankCustomer == null)
            {
                bankCustomer = new BankCustomer(customerDTO.FirstName, customerDTO.LastName, customerDTO.CustomerId, bank);
                bank.AddCustomer(bankCustomer);
            }
    
            var accountTasks = customerDTO.AccountNumbers.Select(async accountNumber =>
            {
                var existingAccount = bankCustomer.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
    
                if (existingAccount == null)
                {
                    var accountFilePath = Path.Combine(accountsDirectoryPath, $"{accountNumber}.json");
                    var recoveredAccount = await LoadBankAccountAsync(accountFilePath, transactionsDirectoryPath, bankCustomer);
    
                    if (recoveredAccount != null)
                    {
                        bankCustomer.AddAccount(recoveredAccount);
                    }
                }
                else
                {
                    bankCustomer.AddAccount(existingAccount);
                }
            });
    
            if (customerDTO.AccountNumbers.Count > 5) // Threshold for parallelism
            {
                await Task.WhenAll(accountTasks);
            }
            else
            {
                foreach (var task in accountTasks)
                {
                    await task;
                }
            }
    
            return bankCustomer;
        }
    
        public static async Task<IEnumerable<BankCustomer>> LoadAllCustomersAsyncParallel(Bank bank, string directoryPath, string accountsDirectoryPath, string transactionsDirectoryPath)
        {
            var customerFiles = Directory.GetFiles(Path.Combine(directoryPath, "Customers"), "*.json");
            var customers = new ConcurrentBag<BankCustomer>();
    
            await Parallel.ForEachAsync(customerFiles, async (filePath, _) =>
            {
                var customer = await LoadBankCustomerAsyncParallel(bank, filePath, accountsDirectoryPath, transactionsDirectoryPath);
                customers.Add(customer);
            });
    
            return customers;
        }
    
        public static async Task<BankAccount> LoadBankAccountAsync(string accountFilePath, string transactionsDirectoryPath, BankCustomer customer)
        {
            var accountDTO = await LoadBankAccountDTOAsync(accountFilePath);
    
            var existingAccount = customer.Accounts.FirstOrDefault(a => a.AccountNumber == accountDTO.AccountNumber);
    
            if (existingAccount != null)
            {
                return (BankAccount)existingAccount;
            }
    
            var recoveredBankAccount = new BankAccount(customer, customer.CustomerId, accountDTO.Balance, accountDTO.AccountType);
    
            string transactionsFilePath = Path.Combine(transactionsDirectoryPath, $"{accountDTO.AccountNumber}-transactions.json");
    
            if (File.Exists(transactionsFilePath))
            {
                var recoveredTransactions = await LoadAllTransactionsAsync(transactionsFilePath);
    
                // Add transactions to the account
                foreach (var transaction in recoveredTransactions)
                {
                    recoveredBankAccount.AddTransaction(transaction);
                }
            }
    
            return recoveredBankAccount;
        }
    
        public static async Task<IEnumerable<Transaction>> LoadAllTransactionsAsync(string filePath)
        {
            string jsonTransaction = await File.ReadAllTextAsync(filePath);
    
            if (string.IsNullOrEmpty(jsonTransaction))
            {
                throw new Exception("No transactions loaded.");
            }
    
            var transactions = JsonSerializer.Deserialize<IEnumerable<Transaction>>(jsonTransaction, _options);
            if (transactions == null)
            {
                throw new Exception("Transactions could not be deserialized.");
            }
    
            return transactions;
        }
    
        public static async Task<BankAccountDTO> LoadBankAccountDTOAsync(string filePath)
        {
            string json = await File.ReadAllTextAsync(filePath);
    
            if (string.IsNullOrEmpty(json))
            {
                throw new Exception("No account found.");
            }
    
            var accountDTO = JsonSerializer.Deserialize<BankAccountDTO>(json, _options);
            if (accountDTO == null)
            {
                throw new Exception("Account could not be deserialized.");
            }
    
            return accountDTO;
        }
    }

    ```

    This code defines the `JsonRetrievalAsyncParallel` class, which uses the `Parallel` class to run async tasks in parallel. The `Parallel.ForEachAsync` method is used in the `LoadAllCustomersAsyncParallel` task to run `LoadBankCustomerAsyncParallel` tasks in parallel, improving performance and reducing execution time.

1. Create a new class file named **LoadCustomerLogsAsyncParallel** in the **Services** folder.

1. Replace the contents of the **LoadCustomerLogsAsyncParallel** file with the following code:

    ```csharp

    using System;
    using System.IO;
    using System.Threading.Tasks;
    
    namespace Files_M3;
    
    public class LoadCustomerLogsAsyncParallel
    {
        public static async Task ReadCustomerDataAsyncParallel(Bank bank)
        {
            string configDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Config");
            string accountsDirectoryPath = Path.Combine(configDirectoryPath, "Accounts");
            string transactionsDirectoryPath = Path.Combine(configDirectoryPath, "Transactions");
    
            await JsonRetrievalAsyncParallel.LoadAllCustomersAsyncParallel(bank, configDirectoryPath, accountsDirectoryPath, transactionsDirectoryPath);
        }
    }

    ```

    This code defines the `LoadCustomerLogsAsyncParallel` class, which calls the `LoadAllCustomersAsyncParallel` method in the `JsonRetrievalAsyncParallel` class. The `LoadAllCustomersAsyncParallel` method accepts the same parameters as the `LoadAllCustomersAsync` method but uses the parallel processing methods in the `JsonRetrievalAsyncParallel` class.

1. Open the **Program.cs** file.

1. Add the following code to the end of the **Main** method:

    ```csharp

    // wait 2 seconds before starting the parallel task
    await Task.Delay(2000);

    Console.WriteLine("\nImplement File I/O tasks asynchronously and in parallel.");

    // Get the time before loading the data asynchronously using parallel tasks
    DateTime timeBeforeAsyncParallelLoadCall = DateTime.Now;

    // Start the async data loading task
    var asyncParallelLoadTask = LoadCustomerLogsAsyncParallel.ReadCustomerDataAsyncParallel(bank3);

    DateTime timeAfterAsyncParallelLoadCall = DateTime.Now;

    // Wait for the async task to complete
    await asyncParallelLoadTask;

    DateTime timeAfterAsyncParallelLoadCompleted = DateTime.Now;

    Console.WriteLine($"\nTime taken to return to Main: {(timeAfterAsyncParallelLoadCall - timeBeforeAsyncParallelLoadCall).TotalSeconds} seconds");
    Console.WriteLine($"Time taken to load the data asynchronously and in parallel: {(timeAfterAsyncParallelLoadCompleted - timeBeforeAsyncParallelLoadCall).TotalSeconds} seconds");

    ```

1. Save your changes and run the app.

    To run your app, right-click the **Files_M3** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    Your app should produce output that's similar to the following example:

    ```plaintext

    Create a performance baseline by loading data synchronously.
    
    Performance baseline: time taken to return to Main: 0.4665744 seconds
    
    Implement File I/O tasks asynchronously.
    
    Time taken to return to Main: 0.035935 seconds
    Time taken to load the data asynchronously: 0.4328723 seconds
    
    Implement File I/O tasks asynchronously and in parallel.
    
    Time taken to return to Main: 0.0247166 seconds
    Time taken to load the data asynchronously and in parallel: 0.2427858 seconds
    
    ```

    Notice that by processing the asynchronous tasks in parallel, the code performance has improved (the time required to load the data has decreased).

    In some cases you may also see some improvement in app responsiveness when implementing tasks in parallel.

In this exercise, you used the async and await keywords to implement asynchronous tasks that load customer data from JSON files. You also used the Parallel class to implement parallel processing of tasks, improving performance and reducing execution time. 

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Also, building up a portfolio of projects can be a great way to demonstrate your skills to potential employers.
