using System;

namespace Data_M1;

public class BankAccount : IBankAccount
{
    private static int s_nextAccountNumber;

    // Public read-only static properties
    public static double TransactionRate { get; protected set; }
    public static double MaxTransactionFee { get; protected set; }
    public static double OverdraftRate { get; protected set; }
    public static double MaxOverdraftFee { get; protected set; }

    public int AccountNumber { get; }
    public string CustomerId { get; }
    public double Balance { get; internal set; } = 0;
    public string AccountType { get; set; } = "Checking";

    public virtual double InterestRate { get; protected set; } // Virtual property to allow overriding in derived classes

    static BankAccount()
    {
        Random random = new Random();
        s_nextAccountNumber = random.Next(10000000, 20000000);
        TransactionRate = 0.01; // Default transaction rate for wire transfers and cashier's checks
        MaxTransactionFee = 10; // Maximum transaction fee for wire transfers and cashier's checks
        OverdraftRate = 0.05; // Default penalty rate for an overdrawn checking account (negative balance)
        MaxOverdraftFee = 10; // Maximum overdraft fee for an overdrawn checking account
    }

    public BankAccount(string customerIdNumber, double balance = 200, string accountType = "Checking")
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = accountType;

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
    public virtual void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }

    // Method to withdraw money from the account
    public virtual bool Withdraw(double amount)
    {
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }

    // Method to transfer money to another account
    public virtual bool Transfer(IBankAccount targetAccount, double amount)
    {
        if (Withdraw(amount))
        {
            targetAccount.Deposit(amount);
            return true;
        }
        return false;
    }

    // Method to apply interest
    public virtual void ApplyInterest(double years)
    {
        Balance += AccountCalculations.CalculateCompoundInterest(Balance, InterestRate, years);
    }

    // Method to apply refund
    public virtual void ApplyRefund(double refund)
    {
        Balance += refund;
    }

    // Method to issue a cashier's check
    public virtual bool IssueCashiersCheck(double amount)
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
    public virtual string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance}, Interest Rate: {InterestRate}, Customer ID: {CustomerId}";
    }
}

// Summary of Changes:
//
// - Marked BankAccount as abstract.
// - Made methods virtual: Deposit, Withdraw, Transfer, ApplyInterest, ApplyRefund, IssueCashiersCheck, and DisplayAccountInfo.
//
// These changes allow derived classes to override these methods and provide specific implementations. Now you can create derived classes like CheckingAccount, SavingsAccount, MoneyMarketAccount, and CertificateOfDeposit with their specific behaviors.


// Step 3: Demonstrate the derived classes in Program.cs




