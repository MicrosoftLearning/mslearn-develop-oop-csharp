using System;

namespace Data_M1;

public interface IQuarterlyReportGenerator
{
    void GenerateQuarterlyReport(Transaction[] transactions, DateOnly reportDate);
}
