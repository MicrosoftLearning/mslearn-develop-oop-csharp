using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp;

public enum BankAccountType
{
    Checking,
    Savings,
    Business
}
public static class BankAccountTypeExtensions
{
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

public record AccountHolderDetails(string Name, string CustomerId, string Address);

// Task 4: Step 1 - Add the ILedgerEntry interface near the record/type definitions.


// Task 4: Step 2 - Update Transaction to implement ILedgerEntry.
public record Transaction(decimal Amount, DateTime Date, string Description)
{
    public override string ToString()
    {
        return $"{Date.ToShortDateString()}: {Description} - {Amount:C}";
    }
}

// Task 6: Step 1 - Add the DailyTotal record near the record/type definitions.


public class BankAccount
{
    public BankAccountNumber AccountNumber { get; }
    public BankAccountType AccountType { get; }
    public decimal Balance { get; private set; }
    public AccountHolderDetails AccountHolder { get; }

    // Task 4: Step 4 - Refactor BankAccount to store transactions in Ledger<Transaction>.
    // Task 2: Step 1 - Replace the transactions collection with a private backing field.
    private List<Transaction> Transactions { get; } = new();

    // Task 2: Step 2 - Expose transactions as a read-only generic view (IReadOnlyList<Transaction>).


    public BankAccount(BankAccountNumber accountNumber, BankAccountType accountType, AccountHolderDetails accountHolder, decimal initialBalance = 0)
    {
        AccountNumber = accountNumber;
        AccountType = accountType;
        AccountHolder = accountHolder;
        Balance = initialBalance;
    }

    public void AddTransaction(decimal amount, string description)
    {

        // Task 4: Step 5 - Update AddTransaction to call _ledger.Add(...) once Ledger<Transaction> is introduced.
        Balance += amount;

        // Task 2: Step 3 - Update AddTransaction to add to the backing field.
        Transactions.Add(new Transaction(amount, DateTime.Now, description));
    }

    public string DisplayAccountInfo()
    {
        return $"Account Holder: {AccountHolder.Name}, Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance:C}";
    }

    public void DisplayTransactions()
    {
        Console.WriteLine("Transactions:");

        // Task 4: Step 6 - Ensure display iterates _ledger.Entries (or the Transactions view backed by it).
        // Task 2: Step 4 - Update DisplayTransactions to iterate the public read-only Transactions view.
        foreach (Transaction transaction in Transactions)
        {
            Console.WriteLine(transaction);
        }
    }

    // Task 2: Step 5 - Add GetTransactions() returning IEnumerable<Transaction>.


    // Task 6: Step 2 - Add GetDailyTotals() returning IEnumerable<DailyTotal>.


}

// Task 3: Step 1 - Add the Bank class that stores accounts in Dictionary<BankAccountNumber, BankAccount>.


// Task 4: Step 3 - Add the generic Ledger<TEntry> class (where TEntry : ILedgerEntry).


// Task 4: Step 7 - Add a second ledger entry type (e.g., Fee) that implements ILedgerEntry.
