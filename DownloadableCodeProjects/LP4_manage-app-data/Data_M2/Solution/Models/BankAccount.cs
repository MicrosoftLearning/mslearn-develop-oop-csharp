using System;
using System.Collections.Generic;

namespace Data_M2;

public class BankAccount : IBankAccount
{
    private static int s_nextAccountNumber;
    protected double priorBalance;

    // Task 4: Step 3 - define a private readonly list to store transactions
    private readonly List<Transaction> _transactions;

    // Public read-only static properties
    public static double TransactionRate { get; private set; }
    public static double MaxTransactionFee { get; private set; }
    public static double OverdraftRate { get; private set; }
    public static double MaxOverdraftFee { get; private set; }

    public int AccountNumber { get; }
    public string CustomerId { get; }
    public double Balance { get; internal set; } = 0;
    public string AccountType { get; set; } = "Checking";
    public virtual double InterestRate { get; protected set; } // Virtual property to allow overriding in derived classes
    public BankCustomer Owner { get; }

    // Task 4: Step 4 - Add a readonly Transactions property
    public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();

    static BankAccount()
    {
        Random random = new Random();
        s_nextAccountNumber = random.Next(10000000, 20000000);
        TransactionRate = 0.01; // Default transaction rate for wire transfers and cashier's checks
        MaxTransactionFee = 10; // Maximum transaction fee for wire transfers and cashier's checks
        OverdraftRate = 0.05; // Default penalty rate for an overdrawn checking account (negative balance)
        MaxOverdraftFee = 10; // Maximum overdraft fee for an overdrawn checking account
    }

    public BankAccount(BankCustomer owner, string customerIdNumber, double balance = 200, string accountType = "Checking")
    {
        Owner = owner;
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = accountType;

        // Task 4: Step 5a - Initialize the transactions list
        _transactions = new List<Transaction>();

    }

    // Copy constructor for BankAccount
    public BankAccount(BankAccount existingAccount)
    {
        Owner = existingAccount.Owner;

        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = existingAccount.CustomerId;
        this.Balance = existingAccount.Balance;
        this.AccountType = existingAccount.AccountType;

        // Task 4: Step 5b - Initialize the transactions list
        _transactions = new List<Transaction>(existingAccount._transactions);

    }


    // TASK 4: Step 6 - Implement AddTransaction and GetAllTransactions methods
    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
    }

    // Method to return all transactions for the account
    public List<Transaction> GetAllTransactions()
    {
        return _transactions;
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
            }
            else if (description.Contains("-(BANK REFUND)"))
            {
                transactionType = "Bank Refund";
            }

            // TASK 4: Step 7a - Add logic to log the deposit transaction
            AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, amount, AccountNumber, AccountNumber, transactionType, description));


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

            // TASK 4: Step 7b - Add logic to log the withdrawal transaction
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

        // TASK 4: Step 7d - Add logic to log the interest transaction
        AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, interest, AccountNumber, AccountNumber, AccountType, "Interest"));


    }

    // Method to apply refund
    public virtual void ApplyRefund(double refund, DateOnly transactionDate, TimeOnly transactionTime, string description)
    {
        priorBalance = Balance;
        Balance += refund;
        // TASK 4: Step 7e - Add logic to log the refund transaction
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

            // TASK 4: Step 7f - Add logic to log the cashier's check transaction
            AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, amount, AccountNumber, AccountNumber, AccountType, "Cashier's Check"));
            AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, fee, AccountNumber, AccountNumber, AccountType, "Transaction Fee"));


            return true;
        }
        return false;
    }

    // Method to display account information
    public virtual string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance:C}, Interest Rate: {InterestRate:P}, Customer ID: {CustomerId}";
    }
}