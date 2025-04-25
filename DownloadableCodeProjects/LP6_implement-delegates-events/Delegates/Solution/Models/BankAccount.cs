using System;
using System.Collections.Generic;

namespace Delegates;

// public delegate void TransactionProcessedCallback(Transaction transaction);

// Method to add a transaction to the account
public class BankAccount : IBankAccount
{
    private static int s_nextAccountNumber;
    private readonly List<Transaction> _transactions;
    protected double priorBalance;

    // Public read-only static properties
    public static double TransactionRate { get; internal set; }
    public static double MaxTransactionFee { get; internal set; }
    public static double OverdraftRate { get; internal set; }
    public static double MaxOverdraftFee { get; internal set; }

    public int AccountNumber { get; }
    public string CustomerId { get; }
    public double Balance { get; internal set; } = 0;
    public string AccountType { get; set; } = "Checking";
    public IEnumerable<Transaction> Transactions => _transactions;

    public BankCustomer Owner { get; }

    public virtual double InterestRate { get; internal set; } // Virtual property to allow overriding in derived classes

    static BankAccount()
    {
        Random random = new Random();
        s_nextAccountNumber = random.Next(10000000, 20000000);
        TransactionRate = 0.01; // Default transaction rate for wire transfers and cashier's checks
        MaxTransactionFee = 10; // Maximum transaction fee for wire transfers and cashier's checks
        OverdraftRate = 0.05; // Default penalty rate for an overdrawn checking account (negative balance)
        MaxOverdraftFee = 10; // Maximum overdraft fee for an overdrawn checking account
    }

    // // Parameterless constructor for deserialization
    // public BankAccount()
    // {
    //     AccountNumber = s_nextAccountNumber++;
    //     CustomerId = "0000000000";
    //     _transactions = new List<Transaction>();
    // }

    public BankAccount(BankCustomer owner, string customerIdNumber, double balance = 200, string accountType = "Checking")
    {
        Owner = owner;
        AccountNumber = s_nextAccountNumber++;
        CustomerId = customerIdNumber;
        Balance = balance;
        AccountType = accountType;
        _transactions = new List<Transaction>();
    }

    // Copy constructor for BankAccount
    public BankAccount(BankAccount existingAccount)
    {
        Owner = existingAccount.Owner;
        AccountNumber = s_nextAccountNumber++;
        CustomerId = existingAccount.CustomerId;
        Balance = existingAccount.Balance;
        AccountType = existingAccount.AccountType;
        _transactions = new List<Transaction>(existingAccount._transactions);
    }

    // Method to deposit money into the account
    public virtual void Deposit(double amount, DateOnly transactionDate, TimeOnly transactionTime, string description)
    {
        if (amount > 0)
        {
            priorBalance = Balance;
            Balance += amount;
            string transactionType = "Deposit";
            if (description.Contains("-(TRANSFER)"))
            {
                transactionType = "Transfer";
                AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, amount, AccountNumber, AccountNumber, transactionType, description));
            }
            else if (description.Contains("-(BANK REFUND)"))
            {
                transactionType = "Bank Refund";
                AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, amount, AccountNumber, AccountNumber, transactionType, description), transaction =>
                {
                    Console.WriteLine($"Log the refund to customer {Owner.ReturnFullName()} for account {AccountNumber}.");
                });
            }
            else
            {
                transactionType = "Deposit";
                AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, amount, AccountNumber, AccountNumber, transactionType, description));
            }
        }
    }

    // Method to withdraw money from the account
    public virtual bool Withdraw(double amount, DateOnly transactionDate, TimeOnly transactionTime, string description)
    {
        if (amount > 0 && Balance >= amount)
        {
            priorBalance = Balance;
            Balance -= amount;
            string transactionType = "Withdraw";
            if (description.Contains("-(TRANSFER)"))
            {
                transactionType = "Transfer";
            }
            else if (description.Contains("-(BANK FEE)"))
            {
                transactionType = "Bank Fee";
            }
            AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, amount, AccountNumber, AccountNumber, transactionType, description));
            return true;
        }
        return false;
    }

    // Method to transfer money to another account
    public virtual bool Transfer(IBankAccount targetAccount, double amount, DateOnly transactionDate, TimeOnly transactionTime, string description)
    {
        description += "-(TRANSFER)";
        if (Withdraw(amount, transactionDate, transactionTime, description))
        {
            targetAccount.Deposit(amount, transactionDate, transactionTime, description);
            return true;
        }
        return false;
    }

    // Method to apply interest
    public virtual void ApplyInterest(double years, DateOnly transactionDate, TimeOnly transactionTime, string description)
    {
        priorBalance = Balance;
        double interest = AccountCalculations.CalculateCompoundInterest(Balance, InterestRate, years);
        Balance += interest;
        AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, interest, AccountNumber, AccountNumber, AccountType, "Interest"));
    }

    // Method to apply refund
    public virtual void ApplyRefund(double refund, DateOnly transactionDate, TimeOnly transactionTime, string description)
    {
        priorBalance = Balance;
        Balance += refund;
        AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, refund, AccountNumber, AccountNumber, AccountType, "Refund"));
    }

    // Method to issue a cashier's check
    public virtual bool IssueCashiersCheck(double amount, DateOnly transactionDate, TimeOnly transactionTime, string description)
    {
        if (amount > 0 && Balance >= amount + BankAccount.MaxTransactionFee)
        {
            priorBalance = Balance;
            Balance -= amount;
            double fee = AccountCalculations.CalculateTransactionFee(amount, BankAccount.TransactionRate, BankAccount.MaxTransactionFee);
            Balance -= fee;
            AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, amount, AccountNumber, AccountNumber, AccountType, "Cashier's Check"));
            AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, fee, AccountNumber, AccountNumber, AccountType, "Transaction Fee"));
            return true;
        }
        return false;
    }

    // Method to display account information
    public virtual string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance.ToString("C")}, Interest Rate: {InterestRate.ToString("P")}, Customer ID: {CustomerId}";
    }

    // Method to add a transaction to the account
    // public void AddTransaction(Transaction transaction, TransactionProcessedCallback? callback = null)
    // {
    //     _transactions.Add(transaction);
    //     callback?.Invoke(transaction); // Invoke the callback if provided
    // }

    public void AddTransaction(Transaction transaction, Action<Transaction>? callback = null)
    {
        _transactions.Add(transaction);
        callback?.Invoke(transaction); // Invoke the callback if provided
    }

    // Method to remove a transaction from the account
    public void RemoveTransaction(Transaction transaction)
    {
        _transactions.Remove(transaction);
    }

    // Method to return all transactions for the account
    public List<Transaction> GetAllTransactions()
    {
        return _transactions;
    }
}
