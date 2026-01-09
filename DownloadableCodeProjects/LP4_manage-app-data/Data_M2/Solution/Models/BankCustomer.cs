using System;
using System.Collections.Generic; // Required for List<T>


namespace Data_M2;

public partial class BankCustomer : IBankCustomer
{
    // TASK 3: Steps 1 and 2 should be completed in the IBankCustomer interface  
    private static int s_nextCustomerId;
    private string _firstName = "Tim";
    private string _lastName = "Shao";

    // TASK 3: Step 3 - declare the Accounts field
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


    // TASK 3: Step 4 - expose the Accounts property
    public IReadOnlyList<IBankAccount> Accounts => _accounts.AsReadOnly();

    static BankCustomer()
    {
        Random random = new Random();
        s_nextCustomerId = random.Next(10000000, 20000000);
    }

    public BankCustomer(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        this.CustomerId = (s_nextCustomerId++).ToString("D10");

        // TASK 3: Step 5 - initialize the Accounts field
        _accounts = new List<IBankAccount>();
    }

    // Copy constructor for BankCustomer
    public BankCustomer(BankCustomer existingCustomer)
    {
        this.FirstName = existingCustomer.FirstName;
        this.LastName = existingCustomer.LastName;
        this.CustomerId = (s_nextCustomerId++).ToString("D10");

        // TASK 3: Step 6 - initialize the Accounts field by copying from existingCustomer
        _accounts = new List<IBankAccount>(existingCustomer._accounts);
    }

    // TASK 3: Step 7 - should be completed in BankCustomerMethods.cs
}
