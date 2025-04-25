using System;

namespace Delegates;

public interface IYearlyReportGenerator
{
    void GeneratePreviousYearReport(BankCustomer bankCustomer, int accountNumber, DateOnly reportDate);
    void GenerateCurrentYearToDateReport(BankCustomer bankCustomer, int accountNumber, DateOnly reportDate);
    void GenerateLast365DaysReport(BankCustomer bankCustomer, int accountNumber, DateOnly reportDate);
}
