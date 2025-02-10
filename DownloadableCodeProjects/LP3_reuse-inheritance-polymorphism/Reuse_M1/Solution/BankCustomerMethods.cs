using System;

namespace Classes_M3;

public partial class BankCustomer
{
    // Method to return the full name of the customer
    public string FullName()
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
        return $"Customer ID: {customerId}, Name: {FullName()}";
    }

    // Override Equals method to compare customers by customerId
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        BankCustomer other = (BankCustomer)obj;
        return customerId == other.customerId;
    }

    // Override GetHashCode method
    public override int GetHashCode()
    {
        return customerId.GetHashCode();
    }
}
