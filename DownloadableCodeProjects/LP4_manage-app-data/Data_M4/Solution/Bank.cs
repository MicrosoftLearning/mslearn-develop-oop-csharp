using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp;

// Component overview (C# types used in this file):
// - enum `BankAccountType`: A closed set of allowed account categories (Checking/Savings/Business).
// - static class `BankAccountTypeExtensions`: An extension method that converts an enum value into a friendly description.
// - readonly struct `BankAccountNumber`: A small value type that wraps and validates a 12-digit account number.
// - record `AccountHolderDetails`: An immutable data model for customer identity/address info (value-based equality).
// - record `Transaction`: An immutable data model for a single ledger entry (amount, date, description).
// - class `BankAccount`: The main domain object that holds account state (balance) and behavior (recording/displaying transactions).

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
public interface ILedgerEntry
{
    decimal Amount { get; }
    DateTime Date { get; }
    string Description { get; }
}

// Task 4: Step 2 - Update Transaction to implement ILedgerEntry.
public record Transaction(decimal Amount, DateTime Date, string Description) : ILedgerEntry
{
    public override string ToString()
    {
        return $"{Date.ToShortDateString()}: {Description} - {Amount:C}";
    }
}

// Task 6: Step 1 - Add the DailyTotal record near the record/type definitions.
public record DailyTotal(DateOnly Day, decimal Total, int Count);

public class BankAccount
{
    public BankAccountNumber AccountNumber { get; }
    public BankAccountType AccountType { get; }
    public decimal Balance { get; private set; }
    public AccountHolderDetails AccountHolder { get; }

    // Task 4: Step 4 - Refactor BankAccount to store transactions in Ledger<Transaction>.
    private readonly Ledger<Transaction> _ledger = new();
    public IReadOnlyList<Transaction> Transactions => _ledger.Entries;


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
        _ledger.Add(new Transaction(amount, DateTime.Now, description));
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
        foreach (var transaction in Transactions)
        {
            Console.WriteLine(transaction);
        }
    }

    // Task 2: Step 5 - Add GetTransactions() returning IEnumerable<Transaction>.
    public IEnumerable<Transaction> GetTransactions() => Transactions;


    // Task 6: Step 2 - Add GetDailyTotals() returning IEnumerable<DailyTotal>.
    public IEnumerable<DailyTotal> GetDailyTotals()
    {
        return Transactions
            .GroupBy(t => DateOnly.FromDateTime(t.Date))
            .Select(g => new DailyTotal(g.Key, g.Sum(x => x.Amount), g.Count()))
            .OrderBy(x => x.Day);
    }

}

// Task 3: Step 1 - Add the Bank class that stores accounts in Dictionary<BankAccountNumber, BankAccount>.
public sealed class Bank
{
    private readonly Dictionary<BankAccountNumber, BankAccount> _accounts = new();

    public void OpenAccount(BankAccount account)
    {
        if (account is null) throw new ArgumentNullException(nameof(account));
        _accounts.Add(account.AccountNumber, account);
    }

    public BankAccount GetAccount(BankAccountNumber number)
    {
        if (_accounts.TryGetValue(number, out var account))
            return account;

        throw new InvalidOperationException($"No account exists with number {number}.");
    }

    public bool TryGetAccount(BankAccountNumber number, out BankAccount account)
        => _accounts.TryGetValue(number, out account!);

    public bool CloseAccount(BankAccountNumber number)
        => _accounts.Remove(number);
}

// Task 4: Step 3 - Add the generic Ledger<TEntry> class (where TEntry : ILedgerEntry).
public sealed class Ledger<TEntry> where TEntry : ILedgerEntry
{
    private readonly List<TEntry> _entries = new();

    public IReadOnlyList<TEntry> Entries => _entries;

    public void Add(TEntry entry)
    {
        if (entry is null) throw new ArgumentNullException(nameof(entry));
        _entries.Add(entry);
    }

    public decimal Total() => _entries.Sum(e => e.Amount);
}

// Task 4: Step 7 - Add a second ledger entry type (e.g., Fee) that implements ILedgerEntry.
public record Fee(decimal Amount, DateTime Date, string Description) : ILedgerEntry;
