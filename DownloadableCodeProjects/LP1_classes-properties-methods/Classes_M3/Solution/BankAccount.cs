using System;

namespace Classes_M3;

public class BankAccount
{
    private static int s_nextAccountNumber;
    public static double InterestRate;
    public int AccountNumber { get; }
    public string CustomerId { get; }
    public double Balance { get; private set; } = 0;
    public string AccountType { get; set; } = "Checking";

    static BankAccount()
    {
        Random random = new Random();
        s_nextAccountNumber = random.Next(10000000, 20000000);
        InterestRate = 0;
    }

    public BankAccount(string customerIdNumber, double balance = 0, string accountType = "Checking")
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = accountType;
    }

    // Add a copy constructor here
    public BankAccount(BankAccount existingAccount)
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = existingAccount.CustomerId;
        this.Balance = existingAccount.Balance;
        this.AccountType = existingAccount.AccountType;
    }

    // Method to deposit money into the account. Only accessible within the assembly
    internal void SetBalance(double amount)
    {
        Balance = amount;
    }

    // Method to display account information
    public string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance}, Interest Rate: {InterestRate}, Customer ID: {CustomerId}";
    }
}
