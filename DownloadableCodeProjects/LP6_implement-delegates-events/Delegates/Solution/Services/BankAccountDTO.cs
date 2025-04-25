using System;

namespace Delegates;

public class BankAccountDTO
{
    public int AccountNumber { get; set; }
    public string CustomerId { get; set; } = "";
    public double Balance { get; set; }
    public string AccountType { get; set; } = "";
    public double InterestRate { get; set; }

        public static BankAccountDTO MapToDTO(BankAccount bankAccount)
    {
        return new BankAccountDTO
        {
            AccountNumber = bankAccount.AccountNumber,
            CustomerId = bankAccount.CustomerId,
            Balance = bankAccount.Balance,
            AccountType = bankAccount.AccountType,
            InterestRate = bankAccount.InterestRate
        };
    }
}
