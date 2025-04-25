using System;

namespace Delegates;

public class MoneyMarketAccount : BankAccount
{
    public double MinimumBalance { get; set; }
    public double MinimumOpeningBalance { get; set; }

    public static double DefaultInterestRate { get; private set; }
    public static double DefaultMinimumBalance { get; private set; }
    public static double DefaultMinimumOpeningBalance { get; private set; }

    static MoneyMarketAccount()
    {
        DefaultInterestRate = 0.04; // 4 percent interest rate
        DefaultMinimumBalance = 1000; // minimum balance
        DefaultMinimumOpeningBalance = 2000; // minimum opening balance
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

    public override double InterestRate
    {
        get { return DefaultInterestRate; }
        internal set { DefaultInterestRate = value; }
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

    public override string DisplayAccountInfo()
    {
        return base.DisplayAccountInfo() + $", Minimum Balance: {MinimumBalance}, Interest Rate: {InterestRate * 100}%, Minimum Opening Balance: {MinimumOpeningBalance}";
    }
}
