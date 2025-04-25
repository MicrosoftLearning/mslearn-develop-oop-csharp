using System;

namespace Delegates;

public partial class BankCustomer : IBankCustomer
{
    private const double MinimumCombinedBalance = 100000;

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


    public bool IsPremiumCustomer()
    {
        if (MeetsPremiumBalanceRequirement() && HasPremiumAccountTypes())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    internal bool HasPremiumAccountTypes()
    {
        // logic to check for required account types, must have: Checking, Savings, and MoneyMarket
        bool hasChecking = false;
        bool hasSavings = false;
        bool hasMoneyMarket = false;

        foreach (BankAccount account in Accounts.Cast<BankAccount>())
        {
            if (account.AccountType == "Checking")
            {
                hasChecking = true;
            }
            else if (account.AccountType == "Savings")
            {
                hasSavings = true;
            }
            else if (account.AccountType == "Money Market")
            {
                hasMoneyMarket = true;
            }
        }

        if (!hasChecking || !hasSavings || !hasMoneyMarket)
        {
            return false;
        }

        return true;
    }

    internal bool MeetsPremiumBalanceRequirement()
    {
        // logic to return the combined balance of all accounts belonging to the customer
        double combinedBalance = 0;
        foreach (BankAccount account in Accounts.Cast<BankAccount>())
        {
            combinedBalance += account.Balance;
        }

        if (combinedBalance >= MinimumCombinedBalance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ApplyBenefits()
    {
        if (this.IsPremiumCustomer())
        {
            // logic to apply benefits for premium customers
            Console.WriteLine("Congratulations! Your premium customer benefits include:");
            Console.WriteLine(" - Dedicated customer service line");
            Console.WriteLine(" - Free overdraft protection for your checking account");
            Console.WriteLine(" - Higher interest rates on savings accounts");
            Console.WriteLine(" - Free wire transfers and cashier's checks");
            Console.WriteLine(" - Free safe deposit box rental");

            // logic to apply account-specific benefits

        }
        else
        {
            Console.WriteLine("See a manager to learn about our premium accounts.");
        }
    }

    public void AddAccount(IBankAccount account)
    {
        _accounts.Add(account);
    }

    public void RemoveAccount(IBankAccount account)
    {
        _accounts.Remove(account);
    }

    public IEnumerable<IBankAccount> GetAllAccounts()
    {
        return _accounts;
    }

    public IEnumerable<IBankAccount> GetAccountsByType(string accountType)
    {
        List<IBankAccount> accountsByType = new List<IBankAccount>();
        foreach (var account in _accounts)
        {
            if (account.AccountType.Equals(accountType, StringComparison.OrdinalIgnoreCase))
            {
                accountsByType.Add(account);
            }
        }
        return accountsByType;
    }
}
