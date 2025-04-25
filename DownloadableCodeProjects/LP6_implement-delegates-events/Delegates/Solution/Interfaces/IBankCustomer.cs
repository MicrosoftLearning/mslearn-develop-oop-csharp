namespace Delegates;

public interface IBankCustomer
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string CustomerId { get; }
    IReadOnlyList<IBankAccount> Accounts { get; }

    string ReturnFullName();
    void UpdateName(string firstName, string lastName);
    string DisplayCustomerInfo();
    bool IsPremiumCustomer();
    void ApplyBenefits();
    void AddAccount(IBankAccount account);
    void RemoveAccount(IBankAccount account);
    IEnumerable<IBankAccount> GetAllAccounts();
    IEnumerable<IBankAccount> GetAccountsByType(string accountType);
}