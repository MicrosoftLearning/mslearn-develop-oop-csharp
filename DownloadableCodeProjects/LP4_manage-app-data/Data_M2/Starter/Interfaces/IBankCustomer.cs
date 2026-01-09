namespace Data_M2;

public interface IBankCustomer
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string CustomerId { get; }

    // TASK 3: Step 1 - Expose Accounts property


    string ReturnFullName();
    void UpdateName(string firstName, string lastName);
    string DisplayCustomerInfo();

    // TASK 3: Step 2 - Add account-management methods 


}
