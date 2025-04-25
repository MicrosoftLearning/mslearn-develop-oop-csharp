using System;
using System.Collections.Generic;

namespace Delegates;

public partial class BankCustomer : IBankCustomer
{
    private static int s_nextCustomerId;
    private string _firstName = "Tim";
    private string _lastName = "Shao";
    private readonly List<IBankAccount> _accounts;

    public string CustomerId { get; }

    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }

    public IReadOnlyList<IBankAccount> Accounts => _accounts.AsReadOnly();

    static BankCustomer()
    {
        Random random = new Random();
        s_nextCustomerId = random.Next(10000000, 20000000);
    }

    // // Parameterless constructor for deserialization
    // public BankCustomer()
    // {
    //     this.CustomerId = (s_nextCustomerId++).ToString("D10");        
    //     _accounts = new List<IBankAccount>();
    // }

    public BankCustomer(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        this.CustomerId = (s_nextCustomerId++).ToString("D10");
        _accounts = new List<IBankAccount>();
    }

    public BankCustomer(string firstName, string lastName, string customerId, Bank bank)
    {
        // Verify that the CustomerId isn't already in use
        if (bank.GetCustomerById(customerId) == null)
        {
            FirstName = firstName;
            LastName = lastName;
            this.CustomerId = customerId;
            _accounts = new List<IBankAccount>();
        }
        else
        {
            throw new ArgumentException("Customer ID already in use");
        }
    }


    // Copy constructor for BankCustomer
    public BankCustomer(BankCustomer existingCustomer)
    {
        this.FirstName = existingCustomer.FirstName;
        this.LastName = existingCustomer.LastName;
        this.CustomerId = (s_nextCustomerId++).ToString("D10");
        _accounts = new List<IBankAccount>(existingCustomer._accounts);
    }
}