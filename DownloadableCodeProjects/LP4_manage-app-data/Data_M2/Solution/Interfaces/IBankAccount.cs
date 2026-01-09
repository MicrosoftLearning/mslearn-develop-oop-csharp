namespace Data_M2;

public interface IBankAccount
{
    int AccountNumber { get; }
    string CustomerId { get; }
    double Balance { get; }
    string AccountType { get; }
    BankCustomer Owner { get; } // This is the BankCustomer object that owns the account

    // Task 4: Step 1 - Add Transactions property
    IReadOnlyList<Transaction> Transactions { get; } // List of transactions for the account

    void Deposit(double amount, DateOnly transactionDate, TimeOnly transactionTime, string description);
    bool Withdraw(double amount, DateOnly transactionDate, TimeOnly transactionTime, string description);
    bool Transfer(IBankAccount targetAccount, double amount, DateOnly transactionDate, TimeOnly transactionTime, string description);
    void ApplyInterest(double years, DateOnly transactionDate, TimeOnly transactionTime, string description);
    void ApplyRefund(double refund, DateOnly transactionDate, TimeOnly transactionTime, string description);
    bool IssueCashiersCheck(double amount, DateOnly transactionDate, TimeOnly transactionTime, string description);
    string DisplayAccountInfo();

    // Task 4: Step 2 - Add methods to log and retrieve transactions
    void AddTransaction(Transaction transaction);
    List<Transaction> GetAllTransactions();

}
