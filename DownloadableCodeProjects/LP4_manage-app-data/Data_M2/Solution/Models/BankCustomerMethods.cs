using System;

namespace Data_M2;

public partial class BankCustomer : IBankCustomer
{
    // Method to return the full name of the customer
    public string ReturnFullName()
    {
        return $"{FirstName} {LastName}";
    }

    // Method to update the customer's name
    public void UpdateName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    // Method to display customer information
    public string DisplayCustomerInfo()
    {
        return $"Customer ID: {CustomerId}, Name: {ReturnFullName()}";
    }

    // Task 3: Step 7 - Add account-management methods
    public void AddAccount(IBankAccount account)
    {
        _accounts.Add(account);
    }
}
