using System;

namespace Reuse_M1;

public class BankAccount : IBankAccount
{
    private static int s_nextAccountNumber;

    // Public read-only static properties
    public static double InterestRate { get; private set; }
    public static double TransactionRate { get; private set; }
    public static double MaxTransactionFee { get; private set; }
    public static double OverdraftRate { get; private set; }
    public static double MaxOverdraftFee { get; private set; }

    public string AccountType { get; }
    public int AccountNumber { get; }
    public string CustomerId { get; }
    public double Balance { get; internal set; } = 0;


    static BankAccount()
    {
        Random random = new Random();
        s_nextAccountNumber = random.Next(10000000, 20000000);
        InterestRate = 0.00; // Default interest rate for checking accounts
        TransactionRate = 0.01; // Default transaction rate for wire transfers and cashier's checks
        MaxTransactionFee = 10; // Maximum transaction fee for wire transfers and cashier's checks
        OverdraftRate = 0.05; // Default penalty rate for an overdrawn checking account (negative balance)
        MaxOverdraftFee = 10; // Maximum overdraft fee for an overdrawn checking account
    }

    public BankAccount(string customerIdNumber, double balance, string accountType)
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = customerIdNumber; // required for the constructor
        this.Balance = balance;             // required for the constructor
        this.AccountType = accountType;     // required for the constructor
    }

    // Copy constructor for BankAccount
    public BankAccount(BankAccount existingAccount)
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = existingAccount.CustomerId;
        this.Balance = existingAccount.Balance;
        this.AccountType = existingAccount.AccountType;
    }

    // Method to deposit money into the account
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }

    // Method to withdraw money from the account
    public bool Withdraw(double amount)
    {
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }

    // Method to transfer money to another account
    public bool Transfer(IBankAccount targetAccount, double amount)
    {
        if (Withdraw(amount))
        {
            targetAccount.Deposit(amount);
            return true;
        }
        return false;
    }

    // Method to apply interest
    public void ApplyInterest(double years)
    {
        Balance += AccountCalculations.CalculateCompoundInterest(Balance, InterestRate, years);
    }

    // Method to apply refund
    public void ApplyRefund(double refund)
    {
        Balance += refund;
    }

    // Method to issue a cashier's check
    public bool IssueCashiersCheck(double amount)
    {
        if (amount > 0 && Balance >= amount + BankAccount.MaxTransactionFee)
        {
            Balance -= amount;
            Balance -= AccountCalculations.CalculateTransactionFee(amount, BankAccount.TransactionRate, BankAccount.MaxTransactionFee);
            return true;
        }
        return false;
    }

    // Method to display account information
    public string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance}, Interest Rate: {InterestRate}, Customer ID: {CustomerId}";
    }
}
