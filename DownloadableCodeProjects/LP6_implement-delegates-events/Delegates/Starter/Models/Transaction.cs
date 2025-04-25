using System;

namespace Delegates;

// Represents a financial transaction with details such as date, time, amount, source and target accounts, type, and description.
public class Transaction
{
    // private fields
    private Guid transactionId;
    private string transactionType;
    private DateOnly transactionDate;
    private TimeOnly transactionTime;
    private double priorBalance;
    private double transactionAmount;
    private int sourceAccountNumber;
    private int targetAccountNumber;
    private string description;

    // Gets the unique identifier for the transaction.
    public Guid TransactionId
    {
        get => transactionId;
        set => transactionId = value;
    }

    // Gets or sets the type of the transaction (e.g., Withdraw, Deposit, Transfer, Bank Fee, Bank Refund).
    public string TransactionType
    {
        get => transactionType;
        set => transactionType = value;
    }

    // Gets or sets the date of the transaction.
    public DateOnly TransactionDate
    {
        get => transactionDate;
        set => transactionDate = value;
    }

    // Gets or sets the time of the transaction.
    public TimeOnly TransactionTime
    {
        get => transactionTime;
        set => transactionTime = value;
    }

    // Gets the prior balance of the account before the transaction.
    public double PriorBalance
    {
        get => priorBalance;
        set => priorBalance = value;
    }

    // Gets or sets the amount of the transaction.
    public double TransactionAmount
    {
        get => transactionAmount;
        set => transactionAmount = value;
    }

    // Gets or sets the source bank account number for the transaction.
    public int SourceAccountNumber
    {
        get => sourceAccountNumber;
        set => sourceAccountNumber = value;
    }

    // Gets or sets the target bank account number for the transaction.
    public int TargetAccountNumber
    {
        get => targetAccountNumber;
        set => targetAccountNumber = value;
    }

    // Gets or sets the description of the transaction.
    public string Description
    {
        get => description;
        set => description = value;
    }


    // Parameterless constructor for deserialization
    public Transaction()
    { 
        transactionType = "";
        description = "";
    }


    // constructors
    public Transaction(DateOnly date, TimeOnly time, double balance, double amount, int sourceAccountNum, int targetAccountNum, string typeOfTransaction, string descriptionMessage = "")
    {
        transactionId = Guid.NewGuid();
        transactionDate = date;
        transactionTime = time;
        priorBalance = balance;
        transactionAmount = amount;
        sourceAccountNumber = sourceAccountNum;
        targetAccountNumber = targetAccountNum;
        transactionType = typeOfTransaction;
        description = descriptionMessage;
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
        return $"Transaction ID: {transactionId}, Type: {transactionType}, Date: {transactionDate}, Time: {transactionTime}, Prior Balance: {PriorBalance:C} Amount: {transactionAmount:C}, Source Account: {sourceAccountNumber}, Target Account: {targetAccountNumber}, Description: {description}";
    }
}
