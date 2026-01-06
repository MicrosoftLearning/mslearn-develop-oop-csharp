using System;

namespace Data_M1;

public static class SimulateTransactions
{
    /// <summary>
    /// Processes transactions within a specified date range for two bank accounts.
    /// </summary>
    /// <param name="startDate">The start date of the date range.</param>
    /// <param name="endDate">The end date of the date range.</param>
    /// <param name="account1">The first bank account involved in the transactions.</param>
    /// <param name="account2">The second bank account involved in the transactions.</param>
    /// <returns>An array of Transaction objects representing the processed transactions within the specified date range.</returns>
    public static Transaction[] SimulateTransactionsDateRange(DateOnly startDate, DateOnly endDate, BankAccount account1, BankAccount account2)
    {
        // Create an array of Transaction objects that's used to hold the simulated transactions
        Transaction[] transactions = new Transaction[2000];
        int transactionIndex = 0;

        // Determine the starting day, month, and year
        int startDay = startDate.Day;
        int startMonth = startDate.Month;
        int startYear = startDate.Year;

        // Determine the ending day, month, and year
        int endDay = endDate.Day;
        int endMonth = endDate.Month;
        int endYear = endDate.Year;

        // Check if the startDate is the first day of the month
        bool isStartDateFirstDayOfMonth = startDay == 1;

        // Check if the endDate is the last day of the month
        bool isEndDateLastDayOfMonth = endDay == DateTime.DaysInMonth(endYear, endMonth);

        // Call SimulateTransactionsStartDateToEndOfMonth if the startDate is not the first day of the month
        if (!isStartDateFirstDayOfMonth)
        {
            Transaction[] startMonthTransactions = SimulateTransactionsStartDateToEndOfMonth(startDate, account1, account2);
            Array.Copy(startMonthTransactions, 0, transactions, transactionIndex, startMonthTransactions.Length);
            transactionIndex += startMonthTransactions.Length;
            startDate = new DateOnly(startYear, startMonth, DateTime.DaysInMonth(startYear, startMonth)).AddDays(1);
        }

        // Need to compare the month and year of the start and end dates
        DateOnly startDayFirstFullMonth = new DateOnly(startDate.Year, startDate.Month, 1);
        DateOnly startDayLastFullMonth = new DateOnly(endYear, endMonth, 1);

        // If the start date for the first month and the start date for hte last month are the same, then the date range is exactly one month
        if (startDayFirstFullMonth == startDayLastFullMonth)
        {
            // Call SimulateTransActionsFullMonth once
            Transaction[] fullMonthTransactions = SimulateTransActionsFullMonth(startDate.Month, startDate.Year, account1, account2);
            Array.Copy(fullMonthTransactions, 0, transactions, transactionIndex, fullMonthTransactions.Length);
            transactionIndex += fullMonthTransactions.Length;
            startDate = startDayFirstFullMonth.AddMonths(1);
        }
        else
        {
            // Call SimulateTransActionsFullMonth for each full month in the date range
            DateOnly currentMonth = startDayFirstFullMonth;
            while (currentMonth < new DateOnly(endYear, endMonth, 1))
            {
                Transaction[] fullMonthTransactions = SimulateTransActionsFullMonth(currentMonth.Month, currentMonth.Year, account1, account2);
                Array.Copy(fullMonthTransactions, 0, transactions, transactionIndex, fullMonthTransactions.Length);
                transactionIndex += fullMonthTransactions.Length;
                currentMonth = currentMonth.AddMonths(1);
            }
        }

        // Call SimulateTransactionsStartMonthToEndDate if the endDate is not the last day of the month
        if (!isEndDateLastDayOfMonth)
        {
            Transaction[] endMonthTransactions = SimulateTransactionsStartMonthToEndDate(endDate, account1, account2);
            Array.Copy(endMonthTransactions, 0, transactions, transactionIndex, endMonthTransactions.Length);
            transactionIndex += endMonthTransactions.Length;
        }

        // Return only the populated portion of the array
        return transactions.Take(transactionIndex).ToArray();
    }

    /// <summary>
    /// Processes transactions for a full month for two bank accounts.
    /// </summary>
    /// <param name="month">The month for which transactions are to be processed.</param>
    /// <param name="year">The year for which transactions are to be processed.</param>
    /// <param name="account1">The first bank account involved in the transactions.</param>
    /// <param name="account2">The second bank account involved in the transactions.</param>
    /// <returns>An array of Transaction objects representing the processed transactions for the specified month.</returns>

    static Transaction[] SimulateTransActionsFullMonth(int month, int year, BankAccount account1, BankAccount account2)
    {
        // Create an array of Transaction objects to hold the monthly transactions
        Transaction[] monthlyTransactions = new Transaction[40];

        // Monthly expenses: semiMonthlyPaycheck, transferToSavings, rent, entertainment1, entertainment2, entertainment3, entertainment4, monthlyGasElectric, monthlyWaterSewer, monthlyWasteManagement, monthlyHealthClub, creditCardBill
        // Call ReturnMonthlyExpenses to get the monthly expenses
        double[] monthlyExpenses = ReturnMonthlyExpenses();

        // Associate the array values with the list of expenses
        double semiMonthlyPaycheck = monthlyExpenses[0];
        double transferToSavings = monthlyExpenses[1];
        double rent = monthlyExpenses[2];
        double entertainment1 = monthlyExpenses[3];
        double entertainment2 = monthlyExpenses[4];
        double entertainment3 = monthlyExpenses[5];
        double entertainment4 = monthlyExpenses[6];
        double monthlyGasElectric = monthlyExpenses[7];
        double monthlyWaterSewer = monthlyExpenses[8];
        double monthlyWasteManagement = monthlyExpenses[9];
        double monthlyHealthClub = monthlyExpenses[10];
        double creditCardBill = monthlyExpenses[11];

        // Combine month and year parameters with day = 1 to create a DateOnly object for the first day of the month
        DateOnly firstDayOfMonth = new DateOnly(year, month, 1);

        // Calculate the last day of the month, account for leap years
        int lastDayOfMonth = DateTime.DaysInMonth(year, month);
        DateOnly lastDay = new DateOnly(year, month, lastDayOfMonth);

        // Calculate the workday that's closest to the middle of the month
        DateOnly middleOfMonth = firstDayOfMonth.AddDays(14);
        if (middleOfMonth.DayOfWeek == DayOfWeek.Saturday)
        {
            middleOfMonth = middleOfMonth.AddDays(2);
        }
        else if (middleOfMonth.DayOfWeek == DayOfWeek.Sunday)
        {
            middleOfMonth = middleOfMonth.AddDays(1);
        }

        // Calculate the workday that's closest to the end of the month
        DateOnly endOfMonth = lastDay;
        if (endOfMonth.DayOfWeek == DayOfWeek.Saturday)
        {
            endOfMonth = endOfMonth.AddDays(-1);
        }
        else if (endOfMonth.DayOfWeek == DayOfWeek.Sunday)
        {
            endOfMonth = endOfMonth.AddDays(-2);
        }

        // Use account1 to deposit the semiMonthlyPaycheck. Deposit paychecks into the checking account on a workday in the middle of the month and the final workday of the month.
        monthlyTransactions[0] = new Transaction(middleOfMonth, new TimeOnly(12, 00), semiMonthlyPaycheck, account1.AccountNumber, account1.AccountNumber, "Deposit", "Bi-monthly salary deposit");
        monthlyTransactions[1] = new Transaction(endOfMonth, new TimeOnly(12, 00), semiMonthlyPaycheck, account1.AccountNumber, account1.AccountNumber, "Deposit", "Bi-monthly salary deposit");

        // Use account1, account2, and transferToSavings to create a transfer transaction from checking to savings on the first day of the month.
        monthlyTransactions[2] = new Transaction(firstDayOfMonth, new TimeOnly(12, 00), transferToSavings, account1.AccountNumber, account2.AccountNumber, "Transfer", "Transfer checking to savings account");

        // Use account1 to generate a withdraw transaction for rent on the first day of the month.
        monthlyTransactions[3] = new Transaction(firstDayOfMonth, new TimeOnly(12, 00), rent, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay rent");

        // Use account1 and the four entertainment amounts to generate a withdraw transaction using a debit card every Saturday night of the month. Calculate the DateOnly value for each Saturday in the month.
        DateOnly saturday1 = firstDayOfMonth;
        while (saturday1.DayOfWeek != DayOfWeek.Saturday)
        {
            saturday1 = saturday1.AddDays(1);
        }
        DateOnly saturday2 = saturday1.AddDays(7);
        DateOnly saturday3 = saturday2.AddDays(7);
        DateOnly saturday4 = saturday3.AddDays(7);

        monthlyTransactions[4] = new Transaction(saturday1, new TimeOnly(21, 00), entertainment1, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Debit card purchase");
        monthlyTransactions[5] = new Transaction(saturday2, new TimeOnly(21, 00), entertainment2, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Debit card purchase");
        monthlyTransactions[6] = new Transaction(saturday3, new TimeOnly(21, 00), entertainment3, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Debit card purchase");
        monthlyTransactions[7] = new Transaction(saturday4, new TimeOnly(21, 00), entertainment4, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Debit card purchase");

        // Generate withdraw transactions for monthly bills on the 20th of the month. Bills include gas and electric, water and sewer, waste management, and health club membership.
        monthlyTransactions[8] = new Transaction(new DateOnly(year, month, 20), new TimeOnly(12, 00), monthlyGasElectric, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay gas and electric bill");
        monthlyTransactions[9] = new Transaction(new DateOnly(year, month, 20), new TimeOnly(12, 00), monthlyWaterSewer, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay water and sewer bill");
        monthlyTransactions[10] = new Transaction(new DateOnly(year, month, 20), new TimeOnly(12, 00), monthlyWasteManagement, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay waste management bill");
        monthlyTransactions[11] = new Transaction(new DateOnly(year, month, 20), new TimeOnly(12, 00), monthlyHealthClub, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay health club membership");

        // Generate a withdraw transactions for weekly expenses every Monday morning during the month. Weekly expense withdrawals are for 400. Calculate the DateOnly value for each Monday in the month.
        DateOnly monday1 = firstDayOfMonth;
        while (monday1.DayOfWeek != DayOfWeek.Monday)
        {
            monday1 = monday1.AddDays(1);
        }
        DateOnly monday2 = monday1.AddDays(7);
        DateOnly monday3 = monday2.AddDays(7);
        DateOnly monday4 = monday3.AddDays(7);

        monthlyTransactions[12] = new Transaction(monday1, new TimeOnly(9, 00), 400.00, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Withdraw for expenses");
        monthlyTransactions[13] = new Transaction(monday2, new TimeOnly(9, 00), 400.00, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Withdraw for expenses");
        monthlyTransactions[14] = new Transaction(monday3, new TimeOnly(9, 00), 400.00, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Withdraw for expenses");
        monthlyTransactions[15] = new Transaction(monday4, new TimeOnly(9, 00), 400.00, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Withdraw for expenses");

        // Generate a withdraw transaction for a credit card bill on the last day of the month.
        monthlyTransactions[16] = new Transaction(lastDay, new TimeOnly(12, 00), creditCardBill, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay credit card bill");

        // Generate a refund transaction for an overcharge on the 5th of the month.
        monthlyTransactions[17] = new Transaction(new DateOnly(year, month, 5), new TimeOnly(12, 00), 100.00, account2.AccountNumber, account1.AccountNumber, "Refund", "Refund for overcharge");

        // Generate a bank fee transaction on the 3rd and 10th of the month.
        monthlyTransactions[18] = new Transaction(new DateOnly(year, month, 3), new TimeOnly(12, 00), -50.00, account1.AccountNumber, account1.AccountNumber, "Fee", "Monthly fee");
        monthlyTransactions[19] = new Transaction(new DateOnly(year, month, 10), new TimeOnly(12, 00), -50.00, account1.AccountNumber, account1.AccountNumber, "Fee", "Monthly fee");

        return monthlyTransactions;
    }

    public static Transaction[] SimulateTransactionsStartDateToEndOfMonth(DateOnly startDate, BankAccount account1, BankAccount account2)
    {
        // Create an array of Transaction objects to hold the monthly transactions
        Transaction[] monthlyTransactions = new Transaction[40];
        int transactionIndex = 0;

        // use startDate to determine the last day of the month
        int lastDayOfMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);
        DateOnly lastDay = new DateOnly(startDate.Year, startDate.Month, lastDayOfMonth);

        // Monthly expenses: semiMonthlyPaycheck, transferToSavings, rent, entertainment1, entertainment2, entertainment3, entertainment4, monthlyGasElectric, monthlyWaterSewer, monthlyWasteManagement, monthlyHealthClub, creditCardBill
        // Call ReturnMonthlyExpenses to get the monthly expenses
        double[] monthlyExpenses = ReturnMonthlyExpenses();

        // Associate the array values with the list of expenses
        double semiMonthlyPaycheck = monthlyExpenses[0];
        double transferToSavings = monthlyExpenses[1];
        double rent = monthlyExpenses[2];
        double entertainment1 = monthlyExpenses[3];
        double entertainment2 = monthlyExpenses[4];
        double entertainment3 = monthlyExpenses[5];
        double entertainment4 = monthlyExpenses[6];
        double monthlyGasElectric = monthlyExpenses[7];
        double monthlyWaterSewer = monthlyExpenses[8];
        double monthlyWasteManagement = monthlyExpenses[9];
        double monthlyHealthClub = monthlyExpenses[10];
        double creditCardBill = monthlyExpenses[11];

        // Calculate the workday that's closest to the middle of the month
        DateOnly middleOfMonth = new DateOnly(startDate.Year, startDate.Month, 14);
        if (middleOfMonth.DayOfWeek == DayOfWeek.Saturday)
        {
            middleOfMonth = middleOfMonth.AddDays(2);
        }
        else if (middleOfMonth.DayOfWeek == DayOfWeek.Sunday)
        {
            middleOfMonth = middleOfMonth.AddDays(1);
        }

        // Calculate the workday that's closest to the end of the month
        DateOnly endOfMonth = lastDay;
        if (endOfMonth.DayOfWeek == DayOfWeek.Saturday)
        {
            endOfMonth = endOfMonth.AddDays(-1);
        }
        else if (endOfMonth.DayOfWeek == DayOfWeek.Sunday)
        {
            endOfMonth = endOfMonth.AddDays(-2);
        }

        // Use account1 to deposit the semiMonthlyPaycheck. Deposit paychecks into the checking account on a workday in the middle of the month and the final workday of the month.
        if (middleOfMonth >= startDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(middleOfMonth, new TimeOnly(12, 00), semiMonthlyPaycheck, account1.AccountNumber, account1.AccountNumber, "Deposit", "Bi-monthly salary deposit");
        }
        if (endOfMonth >= startDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(endOfMonth, new TimeOnly(12, 00), semiMonthlyPaycheck, account1.AccountNumber, account1.AccountNumber, "Deposit", "Bi-monthly salary deposit");
        }

        // Use account1, account2, and transferToSavings to create a transfer transaction from checking to savings on the first day of the month.
        if (startDate <= new DateOnly(startDate.Year, startDate.Month, 1))
        {
            monthlyTransactions[transactionIndex++] = new Transaction(new DateOnly(startDate.Year, startDate.Month, 1), new TimeOnly(12, 00), transferToSavings, account1.AccountNumber, account2.AccountNumber, "Transfer", "Transfer checking to savings account");
        }

        // Use account1 to generate a withdraw transaction for rent on the first day of the month.
        if (startDate <= new DateOnly(startDate.Year, startDate.Month, 1))
        {
            monthlyTransactions[transactionIndex++] = new Transaction(new DateOnly(startDate.Year, startDate.Month, 1), new TimeOnly(12, 00), rent, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay rent");
        }

        // Use account1 and the four entertainment amounts to generate a withdraw transaction using a debit card every Saturday night of the month. Calculate the DateOnly value for each Saturday in the month.
        DateOnly saturday1 = new DateOnly(startDate.Year, startDate.Month, 1);
        while (saturday1.DayOfWeek != DayOfWeek.Saturday)
        {
            saturday1 = saturday1.AddDays(1);
        }
        DateOnly saturday2 = saturday1.AddDays(7);
        DateOnly saturday3 = saturday2.AddDays(7);
        DateOnly saturday4 = saturday3.AddDays(7);

        if (saturday1 >= startDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(saturday1, new TimeOnly(21, 00), entertainment1, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Debit card purchase");
        }
        if (saturday2 >= startDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(saturday2, new TimeOnly(21, 00), entertainment2, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Debit card purchase");
        }
        if (saturday3 >= startDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(saturday3, new TimeOnly(21, 00), entertainment3, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Debit card purchase");
        }
        if (saturday4 >= startDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(saturday4, new TimeOnly(21, 00), entertainment4, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Debit card purchase");
        }

        // Generate withdraw transactions for monthly bills on the 20th of the month. Bills include gas and electric, water and sewer, waste management, and health club membership.
        DateOnly billDate = new DateOnly(startDate.Year, startDate.Month, 20);
        if (billDate >= startDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(billDate, new TimeOnly(12, 00), monthlyGasElectric, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay gas and electric bill");
            monthlyTransactions[transactionIndex++] = new Transaction(billDate, new TimeOnly(12, 00), monthlyWaterSewer, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay water and sewer bill");
            monthlyTransactions[transactionIndex++] = new Transaction(billDate, new TimeOnly(12, 00), monthlyWasteManagement, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay waste management bill");
            monthlyTransactions[transactionIndex++] = new Transaction(billDate, new TimeOnly(12, 00), monthlyHealthClub, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay health club membership");
        }

        // Generate a withdraw transactions for weekly expenses every Monday morning during the month. Weekly expense withdrawals are for 400. Calculate the DateOnly value for each Monday in the month.
        DateOnly monday1 = new DateOnly(startDate.Year, startDate.Month, 1);
        while (monday1.DayOfWeek != DayOfWeek.Monday)
        {
            monday1 = monday1.AddDays(1);
        }
        DateOnly monday2 = monday1.AddDays(7);
        DateOnly monday3 = monday2.AddDays(7);
        DateOnly monday4 = monday3.AddDays(7);

        if (monday1 >= startDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(monday1, new TimeOnly(9, 00), 400.00, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Withdraw for expenses");
        }
        if (monday2 >= startDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(monday2, new TimeOnly(9, 00), 400.00, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Withdraw for expenses");
        }
        if (monday3 >= startDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(monday3, new TimeOnly(9, 00), 400.00, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Withdraw for expenses");
        }
        if (monday4 >= startDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(monday4, new TimeOnly(9, 00), 400.00, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Withdraw for expenses");
        }

        // Generate a withdraw transaction for a credit card bill on the last day of the month.
        if (endOfMonth >= startDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(endOfMonth, new TimeOnly(12, 00), creditCardBill, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay credit card bill");
        }

        // Generate a refund transaction for an overcharge on the 5th of the month.
        DateOnly refundDate = new DateOnly(startDate.Year, startDate.Month, 5);
        if (refundDate >= startDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(refundDate, new TimeOnly(12, 00), 100.00, account2.AccountNumber, account1.AccountNumber, "Refund", "Refund for overcharge");
        }

        // Generate a bank fee transaction on the 3rd and 10th of the month.
        DateOnly feeDate1 = new DateOnly(startDate.Year, startDate.Month, 3);
        DateOnly feeDate2 = new DateOnly(startDate.Year, startDate.Month, 10);
        if (feeDate1 >= startDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(feeDate1, new TimeOnly(12, 00), -50.00, account1.AccountNumber, account1.AccountNumber, "Fee", "Monthly fee");
        }
        if (feeDate2 >= startDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(feeDate2, new TimeOnly(12, 00), -50.00, account1.AccountNumber, account1.AccountNumber, "Fee", "Monthly fee");
        }

        // Return only the populated portion of the array
        return monthlyTransactions.Take(transactionIndex).ToArray();
    }

    public static Transaction[] SimulateTransactionsStartMonthToEndDate(DateOnly endDate, BankAccount account1, BankAccount account2)
    {
        // Create an array of Transaction objects to hold the monthly transactions
        Transaction[] monthlyTransactions = new Transaction[40];
        int transactionIndex = 0;

        // use endDate to determine the first day of the month
        DateOnly firstDayOfMonth = new DateOnly(endDate.Year, endDate.Month, 1);

        // Monthly expenses: semiMonthlyPaycheck, transferToSavings, rent, entertainment1, entertainment2, entertainment3, entertainment4, monthlyGasElectric, monthlyWaterSewer, monthlyWasteManagement, monthlyHealthClub, creditCardBill
        // Call ReturnMonthlyExpenses to get the monthly expenses
        double[] monthlyExpenses = ReturnMonthlyExpenses();

        // Associate the array values with the list of expenses
        double semiMonthlyPaycheck = monthlyExpenses[0];
        double transferToSavings = monthlyExpenses[1];
        double rent = monthlyExpenses[2];
        double entertainment1 = monthlyExpenses[3];
        double entertainment2 = monthlyExpenses[4];
        double entertainment3 = monthlyExpenses[5];
        double entertainment4 = monthlyExpenses[6];
        double monthlyGasElectric = monthlyExpenses[7];
        double monthlyWaterSewer = monthlyExpenses[8];
        double monthlyWasteManagement = monthlyExpenses[9];
        double monthlyHealthClub = monthlyExpenses[10];
        double creditCardBill = monthlyExpenses[11];

        // Calculate the workday that's closest to the middle of the month
        DateOnly middleOfMonth = firstDayOfMonth.AddDays(14);
        if (middleOfMonth.DayOfWeek == DayOfWeek.Saturday)
        {
            middleOfMonth = middleOfMonth.AddDays(2);
        }
        else if (middleOfMonth.DayOfWeek == DayOfWeek.Sunday)
        {
            middleOfMonth = middleOfMonth.AddDays(1);
        }

        // Calculate the workday that's closest to the end of the month
        DateOnly endOfMonth = endDate;
        if (endOfMonth.DayOfWeek == DayOfWeek.Saturday)
        {
            endOfMonth = endOfMonth.AddDays(-1);
        }
        else if (endOfMonth.DayOfWeek == DayOfWeek.Sunday)
        {
            endOfMonth = endOfMonth.AddDays(-2);
        }

        // Use account1 to deposit the semiMonthlyPaycheck. Deposit paychecks into the checking account on a workday in the middle of the month and the final workday of the month.
        if (middleOfMonth <= endDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(middleOfMonth, new TimeOnly(12, 00), semiMonthlyPaycheck, account1.AccountNumber, account1.AccountNumber, "Deposit", "Bi-monthly salary deposit");
        }
        if (endOfMonth <= endDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(endOfMonth, new TimeOnly(12, 00), semiMonthlyPaycheck, account1.AccountNumber, account1.AccountNumber, "Deposit", "Bi-monthly salary deposit");
        }

        // Use account1, account2, and transferToSavings to create a transfer transaction from checking to savings on the first day of the month.
        if (firstDayOfMonth <= endDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(firstDayOfMonth, new TimeOnly(12, 00), transferToSavings, account1.AccountNumber, account2.AccountNumber, "Transfer", "Transfer checking to savings account");
        }

        // Use account1 to generate a withdraw transaction for rent on the first day of the month.
        if (firstDayOfMonth <= endDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(firstDayOfMonth, new TimeOnly(12, 00), rent, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay rent");
        }

        // Use account1 and the four entertainment amounts to generate a withdraw transaction using a debit card every Saturday night of the month. Calculate the DateOnly value for each Saturday in the month.
        DateOnly saturday1 = firstDayOfMonth;
        while (saturday1.DayOfWeek != DayOfWeek.Saturday)
        {
            saturday1 = saturday1.AddDays(1);
        }
        DateOnly saturday2 = saturday1.AddDays(7);
        DateOnly saturday3 = saturday2.AddDays(7);
        DateOnly saturday4 = saturday3.AddDays(7);

        if (saturday1 <= endDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(saturday1, new TimeOnly(21, 00), entertainment1, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Debit card purchase");
        }
        if (saturday2 <= endDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(saturday2, new TimeOnly(21, 00), entertainment2, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Debit card purchase");
        }
        if (saturday3 <= endDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(saturday3, new TimeOnly(21, 00), entertainment3, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Debit card purchase");
        }
        if (saturday4 <= endDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(saturday4, new TimeOnly(21, 00), entertainment4, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Debit card purchase");
        }

        // Generate withdraw transactions for monthly bills on the 20th of the month. Bills include gas and electric, water and sewer, waste management, and health club membership.
        DateOnly billDate = new DateOnly(endDate.Year, endDate.Month, 20);
        if (billDate <= endDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(billDate, new TimeOnly(12, 00), monthlyGasElectric, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay gas and electric bill");
            monthlyTransactions[transactionIndex++] = new Transaction(billDate, new TimeOnly(12, 00), monthlyWaterSewer, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay water and sewer bill");
            monthlyTransactions[transactionIndex++] = new Transaction(billDate, new TimeOnly(12, 00), monthlyWasteManagement, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay waste management bill");
            monthlyTransactions[transactionIndex++] = new Transaction(billDate, new TimeOnly(12, 00), monthlyHealthClub, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay health club membership");
        }

        // Generate a withdraw transactions for weekly expenses every Monday morning during the month. Weekly expense withdrawals are for 400. Calculate the DateOnly value for each Monday in the month.
        DateOnly monday1 = firstDayOfMonth;
        while (monday1.DayOfWeek != DayOfWeek.Monday)
        {
            monday1 = monday1.AddDays(1);
        }
        DateOnly monday2 = monday1.AddDays(7);
        DateOnly monday3 = monday2.AddDays(7);
        DateOnly monday4 = monday3.AddDays(7);

        if (monday1 <= endDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(monday1, new TimeOnly(9, 00), 400.00, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Withdraw for expenses");
        }
        if (monday2 <= endDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(monday2, new TimeOnly(9, 00), 400.00, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Withdraw for expenses");
        }
        if (monday3 <= endDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(monday3, new TimeOnly(9, 00), 400.00, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Withdraw for expenses");
        }
        if (monday4 <= endDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(monday4, new TimeOnly(9, 00), 400.00, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Withdraw for expenses");
        }

        // Generate a withdraw transaction for a credit card bill on the last day of the month.
        if (endOfMonth <= endDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(endOfMonth, new TimeOnly(12, 00), creditCardBill, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay credit card bill");
        }

        // Generate a refund transaction for an overcharge on the 5th of the month.
        DateOnly refundDate = new DateOnly(endDate.Year, endDate.Month, 5);
        if (refundDate <= endDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(refundDate, new TimeOnly(12, 00), 100.00, account2.AccountNumber, account1.AccountNumber, "Refund", "Refund for overcharge");
        }

        // Generate a bank fee transaction on the 3rd and 10th of the month.
        DateOnly feeDate1 = new DateOnly(endDate.Year, endDate.Month, 3);
        DateOnly feeDate2 = new DateOnly(endDate.Year, endDate.Month, 10);
        if (feeDate1 <= endDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(feeDate1, new TimeOnly(12, 00), -50.00, account1.AccountNumber, account1.AccountNumber, "Fee", "Monthly fee");
        }
        if (feeDate2 <= endDate)
        {
            monthlyTransactions[transactionIndex++] = new Transaction(feeDate2, new TimeOnly(12, 00), -50.00, account1.AccountNumber, account1.AccountNumber, "Fee", "Monthly fee");
        }

        // Return only the populated portion of the array
        return monthlyTransactions.Take(transactionIndex).ToArray();
    }

    static double[] ReturnMonthlyExpenses()
    {
        Random random = new Random();

        // Generate a salary paycheck amount. Calculate a random salary amount between 2000 and 5000.
        double semiMonthlyPaycheck = random.Next(2000, 5000);

        // Generate a default transfer that's 25% of the salary paycheck amount rounded down to nearest 100.
        double transferToSavings = Math.Floor(semiMonthlyPaycheck * 0.25 / 100) * 100;

        // Generate a rent amount using random value between 800 and 1600 plus 80% of a paycheck.
        double rent = random.Next(800, 1600) + semiMonthlyPaycheck * 0.8;

        // Generate four random entertainment expense amounts between 150 and 220.
        double entertainment1 = random.Next(150, 220);
        double entertainment2 = random.Next(150, 220);
        double entertainment3 = random.Next(150, 220);
        double entertainment4 = random.Next(150, 220);

        // Generate a monthly gas and electric bill using a random number between 100 and 150.
        double monthlyGasElectric = random.Next(100, 150);

        // Generate a monthly water and sewer bill using a random number between 80 and 90.
        double monthlyWaterSewer = random.Next(80, 90);

        // Generate a monthly waste management bill using a random number between 60 and 70.
        double monthlyWasteManagement = random.Next(60, 70);

        // Generate a monthly health club membership bill using a random number between 120 and 160.
        double monthlyHealthClub = random.Next(120, 160);

        // Generate a random credit card bill between 1000 and 1500 plus 40% of a paycheck.
        double creditCardBill = random.Next(1000, 1500) + semiMonthlyPaycheck * 0.4;

        // Create an array with the monthly expenses
        double[] monthlyExpenses = new double[]
        {
        semiMonthlyPaycheck,
        transferToSavings,
        rent,
        entertainment1,
        entertainment2,
        entertainment3,
        entertainment4,
        monthlyGasElectric,
        monthlyWaterSewer,
        monthlyWasteManagement,
        monthlyHealthClub,
        creditCardBill
        };

        return monthlyExpenses;
    }
}
