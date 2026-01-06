using System;

namespace Data_M1;

public abstract partial class BankCustomer : IBankCustomer
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
    
    public abstract bool IsPremiumCustomer();
    
    public abstract void ApplyBenefits();

}
