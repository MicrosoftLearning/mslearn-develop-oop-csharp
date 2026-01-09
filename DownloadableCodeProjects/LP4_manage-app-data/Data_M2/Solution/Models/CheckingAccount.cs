using System;

namespace Data_M2;

public class CheckingAccount : BankAccount
{
    // public static properties with private setters for default overdraft limit and default interest rate
    public static double DefaultOverdraftLimit { get; private set; }
    public static double DefaultInterestRate { get; private set; }

    // public property for overdraft limit
    public double OverdraftLimit { get; set; }

    static CheckingAccount()
    {
        DefaultOverdraftLimit = 500;
        DefaultInterestRate = 0.0;
    }

    public CheckingAccount(BankCustomer owner, string customerIdNumber, double balance = 200, double overdraftLimit = 500)
        : base(owner, customerIdNumber, balance, "Checking")
    {
        OverdraftLimit = overdraftLimit;
    }

    public override bool Withdraw(double amount, DateOnly transactionDate, TimeOnly transactionTime, string description)
    {
        // try the base class Withdraw method
        bool result = base.Withdraw(amount, transactionDate, transactionTime, description);

        if (result == false && !description.Contains("-(TRANSFER)"))
        {
            // if the base class Withdraw method failed and the transaction isn't an attempted transfer
            //  - calculate the overdraft fee
            //  - check the overdraft limit with the fee applied 
            //  - charge an overdraft fee
            double overdraftFee = AccountCalculations.CalculateOverdraftFee(Math.Abs(Balance), BankAccount.OverdraftRate, BankAccount.MaxOverdraftFee);

            if (Balance + OverdraftLimit + overdraftFee >= amount)
            {
                priorBalance = Balance;
                Balance -= amount;
                string transactionType = "Withdraw";

                // Task 4: Step 8a - Create withdrawal transaction
                AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, amount, AccountNumber, AccountNumber, transactionType, description));


                priorBalance = Balance;
                Balance -= overdraftFee;
                transactionType = "Bank Fee";
                string overdraftDescription = "Overdraft fee applied";

                // Task 4: Step 8b - Create overdraft fee transaction
                AddTransaction(new Transaction(transactionDate, transactionTime, priorBalance, overdraftFee, AccountNumber, AccountNumber, transactionType, overdraftDescription));


                return true;
            }

        }

        return result;
    }


    public override string DisplayAccountInfo()
    {
        return base.DisplayAccountInfo() + $", Overdraft Limit: {OverdraftLimit}";
    }

    public override double InterestRate
    {
        get { return DefaultInterestRate; }
        protected set { DefaultInterestRate = value; }
    }
}
