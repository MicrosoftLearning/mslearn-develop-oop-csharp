using System;

namespace Delegates;

public static class BankCustomerExtensions
{
    // Extension method to check if the customer ID is valid
    public static bool IsValidCustomerId(this IBankCustomer customer)
    {
        return customer.CustomerId.Length == 10;
    }

    // Extension method to greet the customer
    public static string GreetCustomer(this IBankCustomer customer)
    {
        return $"Hello, {customer.ReturnFullName()}!";
    }
}

public static class BankAccountExtensions
{
    // Extension method to check if the account is overdrawn
    public static bool IsOverdrawn(this IBankAccount account)
    {
        return account.Balance < 0;
    }

    // Extension method to check if a specified amount can be withdrawn
    public static bool CanWithdraw(this IBankAccount account, double amount)
    {
        return account.Balance >= amount;
    }
}
