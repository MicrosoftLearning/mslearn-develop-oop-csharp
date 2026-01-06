using System;

namespace Data_M1;

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

    public CheckingAccount(string customerIdNumber, double balance = 200, double overdraftLimit = 500)
        : base(customerIdNumber, balance, "Checking")
    {
        OverdraftLimit = overdraftLimit;
    }

    public override double InterestRate
    {
        get { return DefaultInterestRate; }
        protected set { DefaultInterestRate = value; }
    }

    public override bool Withdraw(double amount)
    {
        if (amount > 0 && Balance + OverdraftLimit >= amount)
        {
            // Call the base class Withdraw method
            bool result = base.Withdraw(amount);

            // Additional logic for CheckingAccount
            if (result && Balance < 0)
            {
                double overdraftFee = AccountCalculations.CalculateOverdraftFee(Math.Abs(Balance), BankAccount.OverdraftRate, BankAccount.MaxOverdraftFee);
                Balance -= overdraftFee;
                Console.WriteLine($"Overdraft fee of ${overdraftFee} applied.");
            }

            return result;
        }
        return false;
    }

    public override string DisplayAccountInfo()
    {
        return base.DisplayAccountInfo() + $", Overdraft Limit: {OverdraftLimit}";
    }
}
