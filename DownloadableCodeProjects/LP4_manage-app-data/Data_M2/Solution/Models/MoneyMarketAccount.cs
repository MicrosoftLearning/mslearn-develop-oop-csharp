using System;

namespace Data_M2;

public class MoneyMarketAccount : BankAccount
{
    // public static properties with private setters for default interest rate, default minimum balance, and default minimum opening balance
    public static double DefaultInterestRate { get; private set; }
    public static double DefaultMinimumBalance { get; private set; }
    public static double DefaultMinimumOpeningBalance { get; private set; }

    // public property for minimum balance and minimum opening balance
    public double MinimumBalance { get; set; }
    public double MinimumOpeningBalance { get; set; }

    static MoneyMarketAccount()
    {
        DefaultInterestRate = 0.04; // 4 percent interest rate
        DefaultMinimumBalance = 1000; // Default minimum balance
        DefaultMinimumOpeningBalance = 2000; // Default minimum opening balance
    }

    public MoneyMarketAccount(BankCustomer owner,string customerIdNumber, double balance = 2000, double minimumBalance = 1000)
        : base(owner, customerIdNumber, balance, "Money Market")
    {
        if (balance < DefaultMinimumOpeningBalance)
        {
            throw new ArgumentException($"Balance must be at least {DefaultMinimumOpeningBalance}");
        }

        MinimumBalance = minimumBalance;
        MinimumOpeningBalance = DefaultMinimumOpeningBalance; // Set the minimum opening balance to the default value
    }

    public override bool Withdraw(double amount, DateOnly transactionDate, TimeOnly transactionTime, string description)
    {
        if (amount > 0 && Balance - amount >= MinimumBalance)
        {
            // Call the base class Withdraw method
            bool result = base.Withdraw(amount, transactionDate, transactionTime, description);

            return result;
        }
        return false;
    }

    public override double InterestRate
    {
        get { return DefaultInterestRate; }
        protected set { DefaultInterestRate = value; }
    }

    public override string DisplayAccountInfo()
    {
        return base.DisplayAccountInfo() + $", Minimum Balance: {MinimumBalance}, Minimum Opening Balance: {MinimumOpeningBalance}";
    }
}
