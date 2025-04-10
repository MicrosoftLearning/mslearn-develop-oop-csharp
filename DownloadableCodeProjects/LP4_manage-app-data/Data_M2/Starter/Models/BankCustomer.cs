using System;
using System.Collections.Generic; // Required for List<T>


namespace Data_M2;

public partial class BankCustomer : IBankCustomer
{
    private static int s_nextCustomerId;
    private string _firstName = "Tim";
    private string _lastName = "Shao";
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

        // TASK 3: Step 1 - Initialize the Accounts list in the constructor
        // Placeholder for initializing the Accounts list
    }

    // TASK 3: Step 2 - Add List<BankAccount> property
    // Placeholder for adding a property to store customer accounts

    // TASK 3: Step 3 - Add methods to manage accounts (e.g., AddAccount)
    // Placeholder for adding methods to manage accounts

    // Copy constructor for BankCustomer
    public BankCustomer(BankCustomer existingCustomer)
    {
        this.FirstName = existingCustomer.FirstName;
        this.LastName = existingCustomer.LastName;
        this.CustomerId = (s_nextCustomerId++).ToString("D10");

        // TASK 3: Step 4 - Copy the Accounts list in the copy constructor
        // Placeholder for copying the Accounts list
    }
}
