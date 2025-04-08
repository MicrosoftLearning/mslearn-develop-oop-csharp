using System;

namespace Data_M1;

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

    public MoneyMarketAccount(string customerIdNumber, double balance = 2000, double minimumBalance = 1000)
        : base(customerIdNumber, balance, "Money Market")
    {
        if (balance < DefaultMinimumOpeningBalance)
        {
            throw new ArgumentException($"Balance must be at least {DefaultMinimumOpeningBalance:C}");
        }

        MinimumBalance = minimumBalance;
        MinimumOpeningBalance = DefaultMinimumOpeningBalance; // Set the minimum opening balance to the default value
    }

    public override bool Withdraw(double amount)
    {
        if (amount > 0 && Balance - amount >= MinimumBalance)
        {
            Balance -= amount;
            return true;
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
        return base.DisplayAccountInfo() + $", Minimum Balance: {MinimumBalance:C}, Minimum Opening Balance: {MinimumOpeningBalance:C}";
    }
}
