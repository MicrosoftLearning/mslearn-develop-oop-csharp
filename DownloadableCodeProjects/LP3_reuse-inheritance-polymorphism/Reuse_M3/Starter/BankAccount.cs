using System;

namespace Classes_M2;

public class BankAccount
{
    private static int nextAccountNumber;
    public static double interestRate;
    public int AccountNumber { get; }
    public string CustomerId { get; }
    public double Balance { get; private set; } = 0;
    public string AccountType { get; set; } = "Checking";

    static BankAccount()
    {
        Random random = new Random();
        nextAccountNumber = random.Next(10000000, 20000000);
        interestRate = 0;
    }

    public BankAccount(string customerIdNumber)
    {
        this.AccountNumber = nextAccountNumber++;
        this.CustomerId = customerIdNumber;
    }

    public BankAccount(string customerIdNumber, double balance, string accountType)
    {
        this.AccountNumber = nextAccountNumber++;
        this.CustomerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = accountType;
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
    public bool Transfer(BankAccount targetAccount, double amount)
    {
        if (Withdraw(amount))
        {
            targetAccount.Deposit(amount);
            return true;
        }
        return false;
    }

    // Method to apply interest to the account
    public void ApplyInterest()
    {
        Balance += Balance * interestRate;
    }

    // Method to display account information
    public string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance}, Interest Rate: {interestRate}, Customer ID: {CustomerId}";
    }
}
