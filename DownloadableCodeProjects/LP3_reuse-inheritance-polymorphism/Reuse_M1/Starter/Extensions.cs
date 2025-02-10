using System;

namespace Reuse_M1;

public static class BankCustomerExtensions
{
    // Extension method to check if the customer ID is valid
    public static bool IsValidCustomerId(this BankCustomer customer)
    {
        return customer.customerId.Length == 10;
    }

    // Extension method to greet the customer
    public static string GreetCustomer(this BankCustomer customer)
    {
        return $"Hello, {customer.FirstName} {customer.LastName}!";
    }
}

public static class BankAccountExtensions
{
    // Extension method to check if the account is overdrawn
    public static bool IsOverdrawn(this BankAccount account)
    {
        return account.Balance < 0;
    }

    // Extension method to check if a specified amount can be withdrawn
    public static bool CanWithdraw(this BankAccount account, double amount)
    {
        return account.Balance >= amount;
    }
}
