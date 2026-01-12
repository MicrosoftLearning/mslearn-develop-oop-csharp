using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp;

// TASK 2: Define Enum, Struct, and Record types

// TASK 2: Step 1 - Define the BankAccountType enum with Checking, Savings, and Business values

public enum BankAccountType
{
    Checking,
    Savings,
    Business
}

// TASK 2: Step 2 - Define an extension method to provide descriptions for each BankAccountType value
public static class BankAccountTypeExtensions
{
    // TASK 1: Step 2 - Add an extension method to provide descriptions for each AccountType.
    public static string GetDescription(this BankAccountType accountType)
    {
        return accountType switch
        {
            BankAccountType.Checking => "A standard checking account.",
            BankAccountType.Savings => "A savings account with interest.",
            BankAccountType.Business => "A business account for companies.",
            _ => "Unknown account type."
        };
    }
}

// TASK 2: Step 3 - Define the BankAccountNumber struct
public readonly struct BankAccountNumber
{
    public string Value { get; }
    public BankAccountNumber(string value)
    {
        // Simple format: 12 digits (demo-friendly)
        if (value is null || value.Length != 12 || !value.All(char.IsDigit))
            throw new ArgumentException("Account numbers must be 12 digits.");
        Value = value;
    }
    public override string ToString() => Value;
}

// TASK 2: Step 4 - Define the AccountHolderDetails record
public record AccountHolderDetails(string Name, string CustomerId, string Address);

// TASK 2: Step 5 - Define the Transaction record
public record Transaction(decimal Amount, DateTime Date, string Description)
{
    public override string ToString()
    {
        return $"{Date.ToShortDateString()}: {Description} - {Amount:C}";
    }
}


public class BankAccount
{
    // TASK 3: Implement the BankAccount class
    // TASK 3: Step 1 - Add properties for BankAccountNumber, BankAccountType, Balance, AccountHolderDetails, and a Transactions list.
    public BankAccountNumber AccountNumber { get; }
    public BankAccountType AccountType { get; }
    public decimal Balance { get; private set; }
    public AccountHolderDetails AccountHolder { get; }
    private List<Transaction> Transactions { get; } = new();


    // TASK 3: Step 2 - Add a constructor to initialize the properties.
    public BankAccount(BankAccountNumber accountNumber, BankAccountType accountType, AccountHolderDetails accountHolder, decimal initialBalance = 0)
    {
        AccountNumber = accountNumber;
        AccountType = accountType;
        AccountHolder = accountHolder;
        Balance = initialBalance;
    }

    // TASK 3: Step 3 - Add a method for deposits/withdrawals that updates the balance and records the transaction.
    public void AddTransaction(decimal amount, string description)
    {
        Balance += amount;
        Transactions.Add(new Transaction(amount, DateTime.Now, description));
    }

    // TASK 3: Step 4 - Add a method to display account information.
    public string DisplayAccountInfo()
    {
        return $"Account Holder: {AccountHolder.Name}, Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance:C}";
    }

    // TASK 3: Step 5 - Add a method to display transactions.
    public void DisplayTransactions()
    {
        Console.WriteLine("Transactions:");
        foreach (Transaction transaction in Transactions)
        {
            Console.WriteLine(transaction);
        }
    }
}
