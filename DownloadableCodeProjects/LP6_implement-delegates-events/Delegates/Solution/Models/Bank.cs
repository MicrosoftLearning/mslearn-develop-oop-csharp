using System;
using System.Collections.Generic;

namespace Delegates;

// public delegate int CustomerComparison(BankCustomer x, BankCustomer y);

public class Bank
{
    // Fields
    private readonly Guid _bankId;
    private readonly List<BankCustomer> _customers;

    // Properties
    public Guid BankId => _bankId;
    public IReadOnlyList<BankCustomer> Customers => _customers.AsReadOnly();

    // Constructors
    public Bank()
    {
        _bankId = Guid.NewGuid();
        _customers = new List<BankCustomer>();
    }

    // Methods
    internal IEnumerable<BankCustomer> GetAllCustomers()
    {
        return new List<BankCustomer>(_customers);
    }

    // public IEnumerable<BankCustomer> GetSortedCustomers(CustomerComparison comparison)
    // {
    //     var sortedCustomers = _customers.ToList();
    //     sortedCustomers.Sort((x, y) => comparison(x, y));
    //     return sortedCustomers;
    // }

    public IEnumerable<BankCustomer> GetSortedCustomers(Func<BankCustomer, BankCustomer, int> comparison)
    {
        var sortedCustomers = _customers.ToList();
        sortedCustomers.Sort((x, y) => comparison(x, y));
        return sortedCustomers;
    }

    internal IEnumerable<BankCustomer> GetCustomersByName(string firstName, string lastName)
    {
        List<BankCustomer> matchingCustomers = new List<BankCustomer>();
        foreach (var customer in _customers)
        {
            if (customer.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                customer.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
            {
                matchingCustomers.Add(customer);
            }
        }
        return matchingCustomers;
    }

    // get customer based on Customer ID
    internal BankCustomer? GetCustomerById(string customerId)
    {
        return _customers.FirstOrDefault(customer => customer.CustomerId.Equals(customerId, StringComparison.OrdinalIgnoreCase));

    }

    internal int GetNumberOfTransactions()
    {
        int totalTransactions = 0;
        foreach (BankCustomer customer in _customers)
        {
            foreach (BankAccount account in customer.Accounts)
            {
                foreach (Transaction transaction in account.Transactions)
                {
                    totalTransactions++;
                }
            }
        }
        return totalTransactions;
    }

    internal double GetTotalMoneyInVault()
    {
        double totalBankCash = 0;
        foreach (BankCustomer customer in _customers)
        {
            foreach (BankAccount account in customer.Accounts)
            {
                totalBankCash += account.Balance;
            }
        }
        return totalBankCash;
    }

    internal double GetDailyDeposits(DateOnly date)
    {
        double totalDailyDeposits = 0;
        foreach (BankCustomer customer in _customers)
        {
            foreach (BankAccount account in customer.Accounts)
            {
                foreach (Transaction transaction in account.Transactions)
                {
                    if (transaction.TransactionDate == date && transaction.TransactionType == "Deposit")
                    {
                        totalDailyDeposits += transaction.TransactionAmount;
                    }
                }
            }
        }
        return totalDailyDeposits;
    }

    internal double GetDailyWithdrawals(DateOnly date)
    {
        double totalDailyWithdrawals = 0;
        foreach (BankCustomer customer in _customers)
        {
            foreach (BankAccount account in customer.Accounts)
            {
                foreach (Transaction transaction in account.Transactions)
                {
                    if (transaction.TransactionDate == date && transaction.TransactionType == "Withdraw")
                    {
                        totalDailyWithdrawals += transaction.TransactionAmount;
                    }
                }
            }
        }
        return totalDailyWithdrawals;
    }

    internal void AddCustomer(BankCustomer customer)
    {
        _customers.Add(customer);
    }

    internal void RemoveCustomer(BankCustomer customer)
    {
        _customers.Remove(customer);
    }

    internal void AddCustomers(IEnumerable<BankCustomer> customers)
    {
        _customers.AddRange(customers);
    }
}