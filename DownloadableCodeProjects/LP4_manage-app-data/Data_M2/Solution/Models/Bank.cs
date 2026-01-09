using System;
using System.Collections.Generic;

namespace Data_M2;

// TASK 2: Create Bank Class
// Purpose: Manage customers and transaction reports.

public class Bank
{
    // TASK 2: Step 1 - Add bank's unique identifier and customers list
    // Fields
    private readonly Guid _bankId;
    private readonly List<BankCustomer> _customers;

    // Properties
    public Guid BankId => _bankId;
    public IReadOnlyList<BankCustomer> Customers => _customers.AsReadOnly();


    // TASK 2: Step 2 - Add constructor to initialize properties
    // Constructors
    public Bank()
    {
        _bankId = Guid.NewGuid();
        _customers = new List<BankCustomer>();
    }

    // TASK 2: Step 3 - Implement AddCustomer method
    //Methods
    internal void AddCustomer(BankCustomer customer)
    {
        _customers.Add(customer);
    }

    // TASK 10: Add Dictionary for Reports
    // Purpose: Manage transaction data for reports in the Bank class.

    // TASK 10: Step 1 - Add a method to add transactions to the dictionary
    // Placeholder for AddTransactionToReport method

    // TASK 10: Step 2 - Add a method to retrieve transactions for a specific key
    // Placeholder for GetTransactionsForKey method
}