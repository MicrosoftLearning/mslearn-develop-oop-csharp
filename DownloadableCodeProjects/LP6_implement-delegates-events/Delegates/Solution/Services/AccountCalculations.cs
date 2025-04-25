using System;

namespace Delegates;

public static class AccountCalculations
{
    // Method to calculate compound interest
    public static double CalculateCompoundInterest(double principal, double annualRate, double years)
    {
        return principal * Math.Pow(1 + annualRate, years) - principal;
    }

    // Method to validate account number
    public static bool ValidateAccountNumber(int accountNumber)
    {
        return accountNumber.ToString().Length == 8;
    }

    // Method to calculate transaction fee, for things like bank checks or wire transfers
    public static double CalculateTransactionFee(double amount, double transactionRate, double maxTransactionFee)
    {
        // calculate the fee based on the transaction rate
        double fee = amount * transactionRate;

        // Return the lesser of the calculated fee or the maximum fee for transactions
        return Math.Min(fee, maxTransactionFee);
    }

    // Method to calculate overdraft fee
    public static double CalculateOverdraftFee(double amountOverdrawn, double overdraftRate, double maxOverdraftFee)
    {
        // Calculate the fee based on the overdraft rate
        double fee = amountOverdrawn * overdraftRate;

        // Return the lesser of the calculated fee or the maximum fee of $10
        return Math.Min(fee, maxOverdraftFee);
    }

    // Method to calculate the value of currency after foreign exchange 
    public static double ReturnForeignCurrency(double amount, double exchangeRate)
    {
        return amount * exchangeRate;
    }
}
