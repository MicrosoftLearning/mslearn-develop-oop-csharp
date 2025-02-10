using Classes_M3;

// Step 1: Create BankCustomer objects
Console.WriteLine("Creating BankCustomer objects...");
string firstName = "Tim";
string lastName = "Shao";

BankCustomer customer1 = new BankCustomer(firstName, lastName);

firstName = "Lisa";
BankCustomer customer2 = new BankCustomer(firstName, lastName);

firstName = "Sandy";
lastName = "Zoeng";
BankCustomer customer3 = new BankCustomer(firstName, lastName);

Console.WriteLine($"BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.customerId}");
Console.WriteLine($"BankCustomer 2: {customer2.FirstName} {customer2.LastName} {customer2.customerId}");
Console.WriteLine($"BankCustomer 3: {customer3.FirstName} {customer3.LastName} {customer3.customerId}");

// Step 2: Create BankAccount objects for customers
Console.WriteLine("\nCreating BankAccount objects for customers...");
BankAccount account1 = new BankAccount(customer1.customerId);
BankAccount account2 = new BankAccount(customer2.customerId, 1500, "Checking");
BankAccount account3 = new BankAccount(customer3.customerId, 2500, "Checking");

Console.WriteLine($"Account 1: Account # {account1.AccountNumber}, type {account1.AccountType}, balance {account1.Balance}, rate {BankAccount.interestRate}, customer ID {account1.CustomerId}");
Console.WriteLine($"Account 2: Account # {account2.AccountNumber}, type {account2.AccountType}, balance {account2.Balance}, rate {BankAccount.interestRate}, customer ID {account2.CustomerId}");
Console.WriteLine($"Account 3: Account # {account3.AccountNumber}, type {account3.AccountType}, balance {account3.Balance}, rate {BankAccount.interestRate}, customer ID {account3.CustomerId}");

// Step 3: Demonstrate the use of BankCustomer properties
Console.WriteLine("\nUpdating BankCustomer 1's name...");
customer1.FirstName = "Thomas";
customer1.LastName = "Margand";
Console.WriteLine($"Updated BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.customerId}");

// Step 4: Demonstrate the use of BankAccount methods
Console.WriteLine("\nDemonstrating BankAccount methods...");

// Deposit
Console.WriteLine("Depositing 500 into Account 1...");
Transactions.Deposit(account1, 500);
Console.WriteLine($"Account 1 after deposit: Balance = {account1.Balance}");

// Withdraw
Console.WriteLine("Withdrawing 200 from Account 2...");
bool withdrawSuccess = Transactions.Withdraw(account2, 200);
Console.WriteLine($"Account 2 after withdrawal: Balance = {account2.Balance}, Withdrawal successful: {withdrawSuccess}");

// Transfer
Console.WriteLine("Transferring 300 from Account 3 to Account 1...");
bool transferSuccess = Transactions.Transfer(account3, account1, 300);
Console.WriteLine($"Account 3 after transfer: Balance = {account3.Balance}, Transfer successful: {transferSuccess}");
Console.WriteLine($"Account 1 after receiving transfer: Balance = {account1.Balance}");

// Apply interest
Console.WriteLine("Applying interest to Account 1...");
Transactions.ApplyInterest(account1);
Console.WriteLine($"Account 1 after applying interest: Balance = {account1.Balance}");

// Step 5: Demonstrate the use of extension methods
Console.WriteLine("\nDemonstrating extension methods...");
Console.WriteLine(customer1.GreetCustomer());
Console.WriteLine($"Is customer1 ID valid? {customer1.IsValidCustomerId()}");
Console.WriteLine($"Can account2 withdraw 2000? {account2.CanWithdraw(2000)}");
Console.WriteLine($"Is account3 overdrawn? {account3.IsOverdrawn()}");

// Step 6: Display customer and account information
Console.WriteLine("\nDisplaying customer and account information...");
Console.WriteLine(customer1.DisplayCustomerInfo());
Console.WriteLine(account1.DisplayAccountInfo());

// Step 7: Demonstrate using object initializers and copy constructors
Console.WriteLine("\nDemonstrating object initializers and copy constructors...");

// Using object initializer
BankCustomer customer4 = new BankCustomer("Mikaela", "Lee") { FirstName = "Mikaela", LastName = "Lee" };
Console.WriteLine($"BankCustomer 4: {customer4.FirstName} {customer4.LastName} {customer4.customerId}");

// Using copy constructor
BankCustomer customer5 = new BankCustomer(customer4);
Console.WriteLine($"BankCustomer 5 (copy of customer4): {customer5.FirstName} {customer5.LastName} {customer5.customerId}");

BankAccount account4 = new BankAccount(customer4.customerId, 3000, "Savings");
BankAccount account5 = new BankAccount(account4);
Console.WriteLine($"Account 4: Account # {account4.AccountNumber}, type {account4.AccountType}, balance {account4.Balance}, rate {BankAccount.interestRate}, customer ID {account4.CustomerId}");
Console.WriteLine($"Account 5 (copy of account4): Account # {account5.AccountNumber}, type {account5.AccountType}, balance {account5.Balance}, rate {BankAccount.interestRate}, customer ID {account5.CustomerId}");
