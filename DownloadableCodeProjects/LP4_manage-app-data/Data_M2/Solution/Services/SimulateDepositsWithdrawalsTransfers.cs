using System;
using System.Collections.Generic;

namespace Data_M2;

// TASK 6: Update SimulateDepositWithdrawTransfer Class
// Purpose: Simulate and log transactions using accounts collection for a customer.

public class SimulateDepositsWithdrawalsTransfers
{
    public static BankCustomer SimulateActivityDateRange(DateOnly startDate, DateOnly endDate, BankCustomer bankCustomer)
    {
        // Determine the starting day, month, and year
        int startDay = startDate.Day;
        int startMonth = startDate.Month;
        int startYear = startDate.Year;

        // Determine the ending day, month, and year
        int endDay = endDate.Day;
        int endMonth = endDate.Month;
        int endYear = endDate.Year;

        DateOnly currentDate = startDate;

        // Call SimulateActivityForPeriod if the startDate is not the first day of the month
        if (startDay != 1)
        {
            DateOnly lastDayOfMonth = new DateOnly(startYear, startMonth, DateTime.DaysInMonth(startYear, startMonth));
            bankCustomer = SimulateActivityForPeriod(startDate, lastDayOfMonth, bankCustomer);

            // Update the currentDate to the first day of the next month
            currentDate = lastDayOfMonth.AddDays(1);
        }

        // Need to compare the month and year of the start and end dates
        DateOnly firstDayFirstFullMonth = new DateOnly(currentDate.Year, currentDate.Month, 1);
        DateOnly lastDayOfFirstFullMonth = new DateOnly(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month));
        DateOnly firstDayLastMonth = new DateOnly(endYear, endMonth, 1);
        DateOnly lastDayOfLastMonth = new DateOnly(endYear, endMonth, DateTime.DaysInMonth(endYear, endMonth));

        // If the first day of the current month and the first day of the last month are the same, then the remaining date range is exactly one month
        if (firstDayFirstFullMonth == firstDayLastMonth && lastDayOfFirstFullMonth == lastDayOfLastMonth)
        {
            // Call SimulateActivityForPeriod once
            bankCustomer = SimulateActivityForPeriod(currentDate, endDate, bankCustomer);
        }
        else
        {
            // Call SimulateActivityForPeriod for each full month in the date range
            DateOnly currentMonth = firstDayFirstFullMonth;
            while (currentMonth < firstDayLastMonth)
            {
                DateOnly lastDayOfMonth = new DateOnly(currentMonth.Year, currentMonth.Month, DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month));
                bankCustomer = SimulateActivityForPeriod(currentMonth, lastDayOfMonth, bankCustomer);
                currentMonth = currentMonth.AddMonths(1);
            }

            // Call SimulateActivityForPeriod for the remaining days in the last month
            bankCustomer = SimulateActivityForPeriod(firstDayLastMonth, endDate, bankCustomer);
        }

        // Return the updated bankCustomer
        return bankCustomer;
    }

    private static BankCustomer SimulateActivityForPeriod(DateOnly startDate, DateOnly endDate, BankCustomer bankCustomer)
    {

        // Task 6: Step 1 - Reset withdrawal limits for savings accounts at the start of the month
        foreach (BankAccount account in bankCustomer.Accounts)
        {
            if (account.AccountType == "Savings")
            {
                SavingsAccount savingsAccount = (SavingsAccount)account;
                savingsAccount.ResetWithdrawalLimit();
            }
        }

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

        double minCheckingBalance = 3000.00;
        double maxCheckingBalance = 5000.00;
        double transferToChecking = 2000.00;

        List<TransactionInfo> transactions = new List<TransactionInfo>();

        DateOnly dateMiddleWeekday = new DateOnly(startDate.Year, startDate.Month, 14);
        if (dateMiddleWeekday.DayOfWeek == DayOfWeek.Saturday)
        {
            dateMiddleWeekday = dateMiddleWeekday.AddDays(2);
        }
        else if (dateMiddleWeekday.DayOfWeek == DayOfWeek.Sunday)
        {
            dateMiddleWeekday = dateMiddleWeekday.AddDays(1);
        }

        DateOnly dateFinalWeekday = new DateOnly(endDate.Year, endDate.Month, DateTime.DaysInMonth(endDate.Year, endDate.Month));
        if (dateFinalWeekday.DayOfWeek == DayOfWeek.Saturday)
        {
            dateFinalWeekday = dateFinalWeekday.AddDays(-1);
        }
        else if (dateFinalWeekday.DayOfWeek == DayOfWeek.Sunday)
        {
            dateFinalWeekday = dateFinalWeekday.AddDays(-2);
        }

        // Add transactions to the list
        if (dateMiddleWeekday >= startDate && dateMiddleWeekday <= endDate)
        {
            transactions.Add(new TransactionInfo { Date = dateMiddleWeekday, Time = new TimeOnly(12, 00), Amount = semiMonthlyPaycheck, Description = "Bi-monthly salary deposit", TransactionType = "Deposit" });
        }
        if (dateFinalWeekday >= startDate && dateFinalWeekday <= endDate)
        {
            transactions.Add(new TransactionInfo { Date = dateFinalWeekday, Time = new TimeOnly(12, 00), Amount = semiMonthlyPaycheck, Description = "Bi-monthly salary deposit", TransactionType = "Deposit" });
        }

        DateOnly rentDueDate = new DateOnly(startDate.Year, startDate.Month, 1);
        if (startDate <= rentDueDate && rentDueDate <= endDate)
        {
            transactions.Add(new TransactionInfo { Date = rentDueDate, Time = new TimeOnly(12, 00), Amount = rent, Description = "Rent payment", TransactionType = "Withdraw" });
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
            transactions.Add(new TransactionInfo { Date = saturday1, Time = new TimeOnly(21, 00), Amount = entertainment1, Description = "Debit card purchase", TransactionType = "Withdraw" });
        }
        if (saturday2 >= startDate && saturday2 <= endDate)
        {
            transactions.Add(new TransactionInfo { Date = saturday2, Time = new TimeOnly(21, 00), Amount = entertainment2, Description = "Debit card purchase", TransactionType = "Withdraw" });
        }
        if (saturday3 >= startDate && saturday3 <= endDate)
        {
            transactions.Add(new TransactionInfo { Date = saturday3, Time = new TimeOnly(21, 00), Amount = entertainment3, Description = "Debit card purchase", TransactionType = "Withdraw" });
        }
        if (saturday4 >= startDate && saturday4 <= endDate)
        {
            transactions.Add(new TransactionInfo { Date = saturday4, Time = new TimeOnly(21, 00), Amount = entertainment4, Description = "Debit card purchase", TransactionType = "Withdraw" });
        }

        DateOnly billPayDate = new DateOnly(startDate.Year, startDate.Month, 20);
        if (billPayDate >= startDate && billPayDate <= endDate)
        {
            transactions.Add(new TransactionInfo { Date = billPayDate, Time = new TimeOnly(12, 00), Amount = monthlyGasElectric, Description = "Auto-pay gas and electric bill", TransactionType = "Withdraw" });
            transactions.Add(new TransactionInfo { Date = billPayDate, Time = new TimeOnly(12, 00), Amount = monthlyWaterSewer, Description = "Auto-pay water and sewer bill", TransactionType = "Withdraw" });
            transactions.Add(new TransactionInfo { Date = billPayDate, Time = new TimeOnly(12, 00), Amount = monthlyWasteManagement, Description = "Auto-pay waste management bill", TransactionType = "Withdraw" });
            transactions.Add(new TransactionInfo { Date = billPayDate, Time = new TimeOnly(12, 00), Amount = monthlyHealthClub, Description = "Auto-pay health club membership", TransactionType = "Withdraw" });
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
            transactions.Add(new TransactionInfo { Date = monday1, Time = new TimeOnly(8, 00), Amount = weeklyCash, Description = "Withdraw for expenses", TransactionType = "Withdraw" });
        }
        if (monday2 >= startDate && monday2 <= endDate)
        {
            transactions.Add(new TransactionInfo { Date = monday2, Time = new TimeOnly(8, 00), Amount = weeklyCash, Description = "Withdraw for expenses", TransactionType = "Withdraw" });
        }
        if (monday3 >= startDate && monday3 <= endDate)
        {
            transactions.Add(new TransactionInfo { Date = monday3, Time = new TimeOnly(8, 00), Amount = weeklyCash, Description = "Withdraw for expenses", TransactionType = "Withdraw" });
        }
        if (monday4 >= startDate && monday4 <= endDate)
        {
            transactions.Add(new TransactionInfo { Date = monday4, Time = new TimeOnly(8, 00), Amount = weeklyCash, Description = "Withdraw for expenses", TransactionType = "Withdraw" });
        }

        if (dateFinalWeekday >= startDate && dateFinalWeekday <= endDate)
        {
            transactions.Add(new TransactionInfo { Date = dateFinalWeekday, Time = new TimeOnly(12, 00), Amount = creditCardBill, Description = "Auto-pay credit card bill", TransactionType = "Withdraw" });
        }

        DateOnly refundDate = new DateOnly(startDate.Year, startDate.Month, 5);
        if (refundDate >= startDate && refundDate <= endDate)
        {
            transactions.Add(new TransactionInfo { Date = refundDate, Time = new TimeOnly(12, 00), Amount = 100.00, Description = "Refund for overcharge -(BANK REFUND)", TransactionType = "Deposit" });
        }

        DateOnly feeDate1 = new DateOnly(startDate.Year, startDate.Month, 3);
        DateOnly feeDate2 = new DateOnly(startDate.Year, startDate.Month, 10);
        if (feeDate1 >= startDate && feeDate1 <= endDate)
        {
            transactions.Add(new TransactionInfo { Date = feeDate1, Time = new TimeOnly(12, 00), Amount = 50.00, Description = "-(BANK FEE)", TransactionType = "Withdraw" });
        }
        if (feeDate2 >= startDate && feeDate2 <= endDate)
        {
            transactions.Add(new TransactionInfo { Date = feeDate2, Time = new TimeOnly(12, 00), Amount = 50.00, Description = "-(BANK FEE)", TransactionType = "Withdraw" });
        }

        // Task 6: Step 2 - Check account balance and perform transfers between checking and savings accounts at the end of the month
        DateOnly dateFinalDayOfMonth = new DateOnly(endDate.Year, endDate.Month, DateTime.DaysInMonth(endDate.Year, endDate.Month));
        if (startDate <= dateFinalDayOfMonth && dateFinalDayOfMonth <= endDate)
        {
            if (bankCustomer.Accounts[0].Balance <= minCheckingBalance)
            {
                transactions.Add(new TransactionInfo { Date = dateFinalDayOfMonth, Time = new TimeOnly(12, 00), Amount = transferToChecking, Description = "Transfer from savings to checking account", TransactionType = "Transfer" });
            }
            else if (bankCustomer.Accounts[0].Balance >= maxCheckingBalance)
            {
                transactions.Add(new TransactionInfo { Date = dateFinalDayOfMonth, Time = new TimeOnly(12, 00), Amount = transferToSavings, Description = "Transfer from checking to savings account", TransactionType = "Transfer" });
            }
        }


        // Sort transactions by date and time
        transactions.Sort();

        // Process transactions
        foreach (var transaction in transactions)
        {

            // Task 6: Step 3 - Update accounts for each transaction based on its type
            if (transaction.TransactionType == "Deposit")
            {
                bankCustomer.Accounts[0].Deposit(transaction.Amount, transaction.Date, transaction.Time, transaction.Description);
            }
            else if (transaction.TransactionType == "Withdraw")
            {
                bankCustomer.Accounts[0].Withdraw(transaction.Amount, transaction.Date, transaction.Time, transaction.Description);
            }
            else if (transaction.TransactionType == "Transfer")
            {
                if (transaction.Description.Contains("savings to checking"))
                {
                    bankCustomer.Accounts[1].Transfer(bankCustomer.Accounts[0], transaction.Amount, transaction.Date, transaction.Time, transaction.Description);
                }
                else if (transaction.Description.Contains("checking to savings"))
                {
                    bankCustomer.Accounts[0].Transfer(bankCustomer.Accounts[1], transaction.Amount, transaction.Date, transaction.Time, transaction.Description);
                }
            }


        }

        return bankCustomer;
    }

    static double[] ReturnMonthlyExpenses()
    {
        Random random = new Random();

        // Generate a salary paycheck amount. Calculate a random salary amount between 2000 and 5000.
        double semiMonthlyPaycheck = random.Next(3000, 4000);

        // Generate a default transfer that's 25% of the salary paycheck amount rounded down to nearest 100.
        double transferToSavings = Math.Floor(semiMonthlyPaycheck * 0.25 / 100) * 100;

        // Generate a rent amount using random value between 800 and 1000 plus 30% of a paycheck.
        double rent = random.Next(1800, 2000) + semiMonthlyPaycheck * 0.3;

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

        // Generate a random credit card bill between 1000 and 1500 plus 30% of a paycheck.
        double creditCardBill = random.Next(500, 800) + semiMonthlyPaycheck * 0.25;

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

    // TASK 6: Step 4 - Add methods to simulate deposits



    // TASK 6: Step 5 - Add methods to simulate withdrawals



    // TASK 6: Step 6 - Add methods to simulate transfers


}

public class TransactionInfo : IComparable<TransactionInfo>
{
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public double Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public string TransactionType { get; set; } = string.Empty;

    public int CompareTo(TransactionInfo? other)
    {
        if (other == null) return 1;
        int dateComparison = Date.CompareTo(other.Date);
        if (dateComparison == 0)
        {
            return Time.CompareTo(other.Time);
        }
        return dateComparison;
    }
}
