namespace Data_M2;

public interface IBankCustomer
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string CustomerId { get; }

    // TASK 3: Step 1 - Expose Accounts property
    IReadOnlyList<IBankAccount> Accounts { get; }

    string ReturnFullName();
    void UpdateName(string firstName, string lastName);
    string DisplayCustomerInfo();

    // TASK 3: Step 2 - Add account-management methods 
    void AddAccount(IBankAccount account);

    // Task 3: Steps 3 - 6 should be completed in BankCustomer.cs

}
