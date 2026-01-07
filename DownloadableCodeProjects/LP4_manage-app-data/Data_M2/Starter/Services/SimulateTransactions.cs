using System;

namespace Data_M2;

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

        // Call SimulateActivityForPeriod if the startDate is not the first day of the month
        if (!isStartDateFirstDayOfMonth)
        {
            DateOnly lastDayOfMonth = new DateOnly(startYear, startMonth, DateTime.DaysInMonth(startYear, startMonth));
            Transaction[] startMonthTransactions = SimulateActivityForPeriod(startDate, lastDayOfMonth, account1, account2);
            Array.Copy(startMonthTransactions, 0, transactions, transactionIndex, startMonthTransactions.Length);
            transactionIndex += startMonthTransactions.Length;
            startDate = lastDayOfMonth.AddDays(1);
        }

        // Need to compare the month and year of the start and end dates
        DateOnly startDayFirstFullMonth = new DateOnly(startDate.Year, startDate.Month, 1);
        DateOnly startDayLastFullMonth = new DateOnly(endYear, endMonth, 1);

        // If the start date for the first month and the start date for the last month are the same, then the date range is exactly one month
        if (startDayFirstFullMonth == startDayLastFullMonth)
        {
            // Call SimulateActivityForPeriod once
            Transaction[] fullMonthTransactions = SimulateActivityForPeriod(startDate, endDate, account1, account2);
            Array.Copy(fullMonthTransactions, 0, transactions, transactionIndex, fullMonthTransactions.Length);
            transactionIndex += fullMonthTransactions.Length;
        }
        else
        {
            // Call SimulateActivityForPeriod for each full month in the date range
            DateOnly currentMonth = startDayFirstFullMonth;
            while (currentMonth < startDayLastFullMonth)
            {
                DateOnly lastDayOfMonth = new DateOnly(currentMonth.Year, currentMonth.Month, DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month));
                Transaction[] fullMonthTransactions = SimulateActivityForPeriod(currentMonth, lastDayOfMonth, account1, account2);
                Array.Copy(fullMonthTransactions, 0, transactions, transactionIndex, fullMonthTransactions.Length);
                transactionIndex += fullMonthTransactions.Length;
                currentMonth = currentMonth.AddMonths(1);
            }

            // Call SimulateActivityForPeriod for the remaining days in the last month
            Transaction[] endMonthTransactions = SimulateActivityForPeriod(startDayLastFullMonth, endDate, account1, account2);
            Array.Copy(endMonthTransactions, 0, transactions, transactionIndex, endMonthTransactions.Length);
            transactionIndex += endMonthTransactions.Length;
        }

        // Return only the populated portion of the array
        return transactions.Take(transactionIndex).ToArray();
    }

    private static Transaction[] SimulateActivityForPeriod(DateOnly startDate, DateOnly endDate, BankAccount account1, BankAccount account2)
    {
        // Create an array of Transaction objects to hold the transactions
        Transaction[] transactions = new Transaction[40];
        int transactionIndex = 0;

        double[] monthlyExpenses = ReturnMonthlyExpenses();

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

        double runningBalance1 = account1.Balance;
        double runningBalance2 = account2.Balance;

        DateOnly middleOfMonth = new DateOnly(startDate.Year, startDate.Month, 14);
        if (middleOfMonth.DayOfWeek == DayOfWeek.Saturday)
        {
            middleOfMonth = middleOfMonth.AddDays(2);
        }
        else if (middleOfMonth.DayOfWeek == DayOfWeek.Sunday)
        {
            middleOfMonth = middleOfMonth.AddDays(1);
        }

        DateOnly endOfMonth = new DateOnly(endDate.Year, endDate.Month, DateTime.DaysInMonth(endDate.Year, endDate.Month));
        if (endOfMonth.DayOfWeek == DayOfWeek.Saturday)
        {
            endOfMonth = endOfMonth.AddDays(-1);
        }
        else if (endOfMonth.DayOfWeek == DayOfWeek.Sunday)
        {
            endOfMonth = endOfMonth.AddDays(-2);
        }

        if (middleOfMonth >= startDate && middleOfMonth <= endDate)
        {
            transactions[transactionIndex++] = new Transaction(middleOfMonth, new TimeOnly(12, 00), runningBalance1, semiMonthlyPaycheck, account1.AccountNumber, account1.AccountNumber, "Deposit", "Bi-monthly salary deposit");
            runningBalance1 += semiMonthlyPaycheck;
        }
        if (endOfMonth >= startDate && endOfMonth <= endDate)
        {
            transactions[transactionIndex++] = new Transaction(endOfMonth, new TimeOnly(12, 00), runningBalance1, semiMonthlyPaycheck, account1.AccountNumber, account1.AccountNumber, "Deposit", "Bi-monthly salary deposit");
            runningBalance1 += semiMonthlyPaycheck;
        }

        if (startDate <= new DateOnly(startDate.Year, startDate.Month, 1) && new DateOnly(startDate.Year, startDate.Month, 1) <= endDate)
        {
            transactions[transactionIndex++] = new Transaction(new DateOnly(startDate.Year, startDate.Month, 1), new TimeOnly(12, 00), runningBalance1, transferToSavings, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Transfer checking to savings account");
            runningBalance1 -= transferToSavings;
            transactions[transactionIndex++] = new Transaction(new DateOnly(startDate.Year, startDate.Month, 1), new TimeOnly(12, 00), runningBalance2, transferToSavings, account2.AccountNumber, account2.AccountNumber, "Deposit", "Transfer checking to savings account");
            runningBalance2 += transferToSavings;

            transactions[transactionIndex++] = new Transaction(new DateOnly(startDate.Year, startDate.Month, 1), new TimeOnly(12, 00), runningBalance1, rent, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay rent");
            runningBalance1 -= rent;
        }

        DateOnly saturday1 = new DateOnly(startDate.Year, startDate.Month, 1);
        while (saturday1.DayOfWeek != DayOfWeek.Saturday)
        {
            saturday1 = saturday1.AddDays(1);
        }
        DateOnly saturday2 = saturday1.AddDays(7);
        DateOnly saturday3 = saturday2.AddDays(7);
        DateOnly saturday4 = saturday3.AddDays(7);

        if (saturday1 >= startDate && saturday1 <= endDate)
        {
            transactions[transactionIndex++] = new Transaction(saturday1, new TimeOnly(21, 00), runningBalance1, entertainment1, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Debit card purchase");
            runningBalance1 -= entertainment1;
        }
        if (saturday2 >= startDate && saturday2 <= endDate)
        {
            transactions[transactionIndex++] = new Transaction(saturday2, new TimeOnly(21, 00), runningBalance1, entertainment2, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Debit card purchase");
            runningBalance1 -= entertainment2;
        }
        if (saturday3 >= startDate && saturday3 <= endDate)
        {
            transactions[transactionIndex++] = new Transaction(saturday3, new TimeOnly(21, 00), runningBalance1, entertainment3, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Debit card purchase");
            runningBalance1 -= entertainment3;
        }
        if (saturday4 >= startDate && saturday4 <= endDate)
        {
            transactions[transactionIndex++] = new Transaction(saturday4, new TimeOnly(21, 00), runningBalance1, entertainment4, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Debit card purchase");
            runningBalance1 -= entertainment4;
        }

        DateOnly billDate = new DateOnly(startDate.Year, startDate.Month, 20);
        if (billDate >= startDate && billDate <= endDate)
        {
            transactions[transactionIndex++] = new Transaction(billDate, new TimeOnly(12, 00), runningBalance1, monthlyGasElectric, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay gas and electric bill");
            runningBalance1 -= monthlyGasElectric;
            transactions[transactionIndex++] = new Transaction(billDate, new TimeOnly(12, 00), runningBalance1, monthlyWaterSewer, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay water and sewer bill");
            runningBalance1 -= monthlyWaterSewer;
            transactions[transactionIndex++] = new Transaction(billDate, new TimeOnly(12, 00), runningBalance1, monthlyWasteManagement, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay waste management bill");
            runningBalance1 -= monthlyWasteManagement;
            transactions[transactionIndex++] = new Transaction(billDate, new TimeOnly(12, 00), runningBalance1, monthlyHealthClub, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay health club membership");
            runningBalance1 -= monthlyHealthClub;
        }

        DateOnly monday1 = new DateOnly(startDate.Year, startDate.Month, 1);
        while (monday1.DayOfWeek != DayOfWeek.Monday)
        {
            monday1 = monday1.AddDays(1);
        }
        DateOnly monday2 = monday1.AddDays(7);
        DateOnly monday3 = monday2.AddDays(7);
        DateOnly monday4 = monday3.AddDays(7);

        double weeklyCash = 400.00;

        if (monday1 >= startDate && monday1 <= endDate)
        {
            transactions[transactionIndex++] = new Transaction(monday1, new TimeOnly(9, 00), runningBalance1, weeklyCash, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Withdraw for expenses");
            runningBalance1 -= weeklyCash;
        }
        if (monday2 >= startDate && monday2 <= endDate)
        {
            transactions[transactionIndex++] = new Transaction(monday2, new TimeOnly(9, 00), runningBalance1, weeklyCash, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Withdraw for expenses");
            runningBalance1 -= weeklyCash;
        }
        if (monday3 >= startDate && monday3 <= endDate)
        {
            transactions[transactionIndex++] = new Transaction(monday3, new TimeOnly(9, 00), runningBalance1, weeklyCash, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Withdraw for expenses");
            runningBalance1 -= weeklyCash;
        }
        if (monday4 >= startDate && monday4 <= endDate)
        {
            transactions[transactionIndex++] = new Transaction(monday4, new TimeOnly(9, 00), runningBalance1, weeklyCash, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Withdraw for expenses");
            runningBalance1 -= weeklyCash;
        }

        if (endOfMonth >= startDate && endOfMonth <= endDate)
        {
            transactions[transactionIndex++] = new Transaction(endOfMonth, new TimeOnly(12, 00), runningBalance1, creditCardBill, account1.AccountNumber, account1.AccountNumber, "Withdraw", "Auto-pay credit card bill");
            runningBalance1 -= creditCardBill;
        }

        DateOnly refundDate = new DateOnly(startDate.Year, startDate.Month, 5);
        double refundAmount = 100.00;
        if (refundDate >= startDate && refundDate <= endDate)
        {
            transactions[transactionIndex++] = new Transaction(refundDate, new TimeOnly(12, 00), runningBalance1, refundAmount, account2.AccountNumber, account1.AccountNumber, "Refund", "Refund for overcharge");
            runningBalance1 += refundAmount;
        }

        DateOnly feeDate1 = new DateOnly(startDate.Year, startDate.Month, 3);
        DateOnly feeDate2 = new DateOnly(startDate.Year, startDate.Month, 10);

        double bankFeeAmount = 50.00;

        if (feeDate1 >= startDate && feeDate1 <= endDate)
        {
            transactions[transactionIndex++] = new Transaction(feeDate1, new TimeOnly(12, 00), runningBalance1, bankFeeAmount, account1.AccountNumber, account1.AccountNumber, "Fee", "Monthly fee");
            runningBalance1 -= bankFeeAmount;
        }
        if (feeDate2 >= startDate && feeDate2 <= endDate)
        {
            transactions[transactionIndex++] = new Transaction(feeDate2, new TimeOnly(12, 00), runningBalance1, bankFeeAmount, account1.AccountNumber, account1.AccountNumber, "Fee", "Monthly fee");
            runningBalance1 -= bankFeeAmount;
        }

        // Return only the populated portion of the array
        return transactions.Take(transactionIndex).ToArray();

        static double[] ReturnMonthlyExpenses()
        {
            Random random = new Random();

            double semiMonthlyPaycheck = random.Next(2000, 5000);
            double transferToSavings = Math.Floor(semiMonthlyPaycheck * 0.25 / 100) * 100;
            double rent = random.Next(800, 1600) + semiMonthlyPaycheck * 0.8;
            double entertainment1 = random.Next(150, 220);
            double entertainment2 = random.Next(150, 220);
            double entertainment3 = random.Next(150, 220);
            double entertainment4 = random.Next(150, 220);
            double monthlyGasElectric = random.Next(100, 150);
            double monthlyWaterSewer = random.Next(80, 90);
            double monthlyWasteManagement = random.Next(60, 70);
            double monthlyHealthClub = random.Next(120, 160);
            double creditCardBill = random.Next(1000, 1500) + semiMonthlyPaycheck * 0.4;

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
}
