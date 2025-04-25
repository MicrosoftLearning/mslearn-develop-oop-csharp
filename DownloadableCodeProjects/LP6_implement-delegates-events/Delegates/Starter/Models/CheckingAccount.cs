using System;

namespace Delegates;

public class CheckingAccount : BankAccount
{
    public double OverdraftLimit { get; set; }

    public static double DefaultOverdraftLimit { get; private set; }
    public static double DefaultInterestRate { get; private set; }

    static CheckingAccount()
    {
        DefaultOverdraftLimit = 500;
        DefaultInterestRate = 0.00;
    }

    public CheckingAccount(BankCustomer owner, string customerIdNumber, double balance = 200, double overdraftLimit = 500)
        : base(owner, customerIdNumber, balance, "Checking")
    {
        OverdraftLimit = overdraftLimit;
    }

    public override double InterestRate
    {
        get { return DefaultInterestRate; }
        internal set { DefaultInterestRate = value; }
    }

    public override bool Withdraw(double amount, DateOnly transactionDate, TimeOnly transactionTime, string description)
    {
        // try the base class Withdraw method
        bool result = base.Withdraw(amount, transactionDate, transactionTime, description);

        if (result == false && !description.Contains("-(TRANSFER)"))
        {
            // if the base class Withdraw method failed and the transaction isn't an attempted transfer, check premium status of the customer

            if (Owner.IsPremiumCustomer() == true)
            {
                // If the customer is a premium customer, allow the withdrawal and transfer money from savings
                priorBalance = Balance;
                Balance -= amount;
                string transactionType = "Withdraw";
                AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, amount, AccountNumber, AccountNumber, transactionType, description));

                // Transfer money from savings to checking
                BankAccount savingsAccount = (SavingsAccount)Owner.Accounts[1];
                BankAccount checkingAccount = (CheckingAccount)Owner.Accounts[0];

                string transferDescription = "free overdraft protection-(TRANSFER)";
                savingsAccount.Transfer(checkingAccount, amount + 1000.00, transactionDate, transactionTime, transferDescription);

                return true;
            }
            else
            {
                // If the customer is not a premium customer:
                //  - calculate the overdraft fee
                //  - check the overdraft limit with the fee applied 
                //  - charge an overdraft fee
                double overdraftFee = AccountCalculations.CalculateOverdraftFee(Math.Abs(Balance), BankAccount.OverdraftRate, BankAccount.MaxOverdraftFee);

                if (Balance + OverdraftLimit + overdraftFee >= amount)
                {
                    priorBalance = Balance;
                    Balance -= amount;
                    string transactionType = "Withdraw";
                    AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, amount, AccountNumber, AccountNumber, transactionType, description));

                    priorBalance = Balance;
                    Balance -= overdraftFee;
                    transactionType = "Bank Fee";
                    string overdraftDescription = "Overdraft fee applied";
                    AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, overdraftFee, AccountNumber, AccountNumber, transactionType, overdraftDescription));

                    return true;
                }
            }
        }

        return result;
    }


    public override string DisplayAccountInfo()
    {
        return base.DisplayAccountInfo() + $", Overdraft Limit: {OverdraftLimit}";
    }
}
