using System;

namespace Data_M2;

public class SavingsAccount : BankAccount
{
    // private field to track the number of withdrawals this month
    private int _withdrawalsThisMonth;

    // public static properties with private setters for default withdrawal limit, default minimum opening balance, and default interest rate
    public static int DefaultWithdrawalLimit { get; private set; }
    public static double DefaultMinimumOpeningBalance { get; private set; }
    public static double DefaultInterestRate { get; private set; }

    // public property for withdrawal limit and minimum opening balance
    public int WithdrawalLimit { get; set; }
    public double MinimumOpeningBalance { get; set; }

    static SavingsAccount()
    {
        DefaultWithdrawalLimit = 6;
        DefaultMinimumOpeningBalance = 500;
        DefaultInterestRate = 0.02; // 2 percent interest rate
    }

    public SavingsAccount(BankCustomer owner, string customerIdNumber, double balance = 500, int withdrawalLimit = 6)
        : base(owner, customerIdNumber, balance, "Savings")
    {
        if (balance < DefaultMinimumOpeningBalance)
        {
            throw new ArgumentException($"Balance must be at least {DefaultMinimumOpeningBalance}");
        }

        WithdrawalLimit = withdrawalLimit;
        _withdrawalsThisMonth = 0;
        MinimumOpeningBalance = DefaultMinimumOpeningBalance; // Set the minimum opening balance to the default value
    }

    public override bool Withdraw(double amount, DateOnly transactionDate, TimeOnly transactionTime, string description)
    {
        if (amount > 0 && Balance >= amount && _withdrawalsThisMonth < WithdrawalLimit)
        {
            // Call the base class Withdraw method
            bool result = base.Withdraw(amount, transactionDate, transactionTime, description);

            _withdrawalsThisMonth++;
            return result;
        }
        return false;
    }

    public void ResetWithdrawalLimit()
    {
        _withdrawalsThisMonth = 0;
    }

    public override double InterestRate
    {
        get { return DefaultInterestRate; }
        protected set { DefaultInterestRate = value; }
    }

    public override string DisplayAccountInfo()
    {
        return base.DisplayAccountInfo() + $", Withdrawal Limit: {WithdrawalLimit}, Withdrawals This Month: {_withdrawalsThisMonth}";
    }
}
