namespace Delegates;

public interface IBankAccount
{
    int AccountNumber { get; }
    string CustomerId { get; }
    double Balance { get; }
    string AccountType { get; }
    double InterestRate { get; }
    BankCustomer Owner { get; } // This is the BankCustomer object that owns the account
    IEnumerable<Transaction> Transactions { get; } // List of transactions for the account
    
    void Deposit(double amount, DateOnly transactionDate, TimeOnly transactionTime, string description);
    bool Withdraw(double amount, DateOnly transactionDate, TimeOnly transactionTime, string description);
    bool Transfer(IBankAccount targetAccount, double amount, DateOnly transactionDate, TimeOnly transactionTime, string description);
    void ApplyInterest(double years, DateOnly transactionDate, TimeOnly transactionTime, string description);
    void ApplyRefund(double refund, DateOnly transactionDate, TimeOnly transactionTime, string description);
    bool IssueCashiersCheck(double amount, DateOnly transactionDate, TimeOnly transactionTime, string description);
    string DisplayAccountInfo();
    // void AddTransaction(Transaction transaction, TransactionProcessedCallback? transactionProcessedCallback = null);
    void AddTransaction(Transaction transaction, Action<Transaction>? transactionProcessedCallback = null);
    List<Transaction> GetAllTransactions();
}
