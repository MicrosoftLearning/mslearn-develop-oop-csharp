using System;

namespace Data_M1;

// Represents a financial transaction with details such as date, time, amount, source and target accounts, type, and description.
public class Transaction
{
    // private fields
    private readonly Guid transactionId;
    private string transactionType;
    private DateOnly transactionDate;
    private TimeOnly transactionTime;
    private double transactionAmount;
    private int sourceAccountNumber;
    private int targetAccountNumber;
    private string description;

    // Gets the unique identifier for the transaction.
    public Guid TransactionId => transactionId;

    // Gets or sets the type of the transaction (e.g., Withdraw, Deposit, Transfer, Bank Fee, Bank Refund).
    public string TransactionType => transactionType;

    // Gets or sets the date of the transaction.
    public DateOnly TransactionDate => transactionDate;

     // Gets or sets the time of the transaction.
    public TimeOnly TransactionTime => transactionTime;

    // Gets or sets the amount of the transaction.
    public double TransactionAmount => transactionAmount;

     // Gets or sets the source bank account number for the transaction.
    public int SourceAccountNumber => sourceAccountNumber;

    // Gets or sets the target bank account number for the transaction.
    public int TargetAccountNumber => targetAccountNumber;

    // Gets or sets the description of the transaction.
    public string Description => description;

    // constructors
    public Transaction(DateOnly date, TimeOnly time, double amount, int sourceAccountNum, int targetAccountNum, string type, string description = "")
    {
        transactionId = Guid.NewGuid();
        transactionDate = date;
        transactionTime = time;
        transactionAmount = amount;
        sourceAccountNumber = sourceAccountNum;
        targetAccountNumber = targetAccountNum;
        transactionType = type;
        this.description = description;
    }

    // Determines whether the transaction is valid based on its type and details.
    public bool IsValidTransaction()
    {
        // Check for valid Withdraw transaction
        if (transactionAmount <= 0 && sourceAccountNumber == targetAccountNumber && transactionType == "Withdraw")
        {
            return true;
        }
        // Check for valid Deposit transaction
        else if (transactionAmount > 0 && sourceAccountNumber == targetAccountNumber && transactionType == "Deposit")
        {
            return true;
        }
        // Check for valid Transfer transaction
        else if (transactionAmount > 0 && sourceAccountNumber != targetAccountNumber && transactionType == "Transfer")
        {
            return true;
        }
        // Check for bank fees transaction
        else if (transactionAmount < 0 && sourceAccountNumber == targetAccountNumber && transactionType == "Bank Fee")
        {
            return true;
        }
        // Check for bank refund transaction
        else if (transactionAmount > 0 && sourceAccountNumber == targetAccountNumber && transactionType == "Bank Refund")
        {
            return true;
        }
        return false;
    }

    // Returns a formatted string with transaction details for logging.
    public string ReturnTransaction()
    {
        return $"Transaction ID: {transactionId}, Type: {transactionType}, Date: {transactionDate}, Time: {transactionTime}, Amount: {transactionAmount}, Source Account: {sourceAccountNumber}, Target Account: {targetAccountNumber}, Description: {description}";
    }
}
