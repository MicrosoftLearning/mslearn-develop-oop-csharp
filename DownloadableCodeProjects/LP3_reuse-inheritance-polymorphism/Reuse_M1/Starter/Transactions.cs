using System;

namespace Reuse_M1;

public static class Transactions
{
    // Method to deposit money into the account
    public static void Deposit(BankAccount account, double amount)
    {
        if (amount > 0)
        {
            account.Balance += amount;
        }
    }

    // Method to withdraw money from the account
    public static bool Withdraw(BankAccount account, double amount)
    {
        if (amount > 0 && account.Balance >= amount)
        {
            account.Balance -= amount;
            return true;
        }
        return false;
    }

    // Method to transfer money to another account
    public static bool Transfer(BankAccount sourceAccount, BankAccount targetAccount, double amount)
    {
        if (Withdraw(sourceAccount, amount))
        {
            Deposit(targetAccount, amount);
            return true;
        }
        return false;
    }

    // Method to apply interest to the account balance
    public static void ApplyInterest(BankAccount account)
    {
        account.Balance += account.Balance * BankAccount.interestRate;
    }
}
