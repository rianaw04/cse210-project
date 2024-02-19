using System;
using System.Collections.Generic;

class Expense {
    public decimal Amount { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
}

class Budget {
    public decimal Amount { get; set; }
    public string Category { get; set; }
    public string Period { get; set; }
}

class Income {
    public List<string> Sources { get; set; }
    public decimal TotalIncome { get; set; }
}

class Report {
    public Dictionary<string, object> ReportData { get; set; }
}

class PersonalFinanceManager {
    public List<Expense> Expenses { get; set; }
    public List<Budget> Budgets { get; set; }
    public Income Income { get; set; }

    public PersonalFinanceManager() {
        Expenses = new List<Expense>();
        Budgets = new List<Budget>();
        Income = new Income();
        Income.Sources = new List<string>();
    }

    public void AddExpense(decimal amount, string category, string description, DateTime date) {
        Expense expense = new Expense { Amount = amount, Category = category, Description = description, Date = date };
        Expenses.Add(expense);
    }

    public decimal GetTotalExpenses() {
        decimal totalExpenses = 0;
        foreach (Expense expense in Expenses) {
            totalExpenses += expense.Amount;
        }
        return totalExpenses;
    }

    public List<Expense> GetExpensesByCategory(string category) {
        List<Expense> expensesByCategory = new List<Expense>();
        foreach (Expense expense in Expenses) {
            if (expense.Category == category) {
                expensesByCategory.Add(expense);
            }
        }
        return expensesByCategory;
    }

    public List<Expense> GetExpensesByDate(DateTime date) {
        List<Expense> expensesByDate = new List<Expense>();
        foreach (Expense expense in Expenses) {
            if (expense.Date == date) {
                expensesByDate.Add(expense);
            }
        }
        return expensesByDate;
    }

    public void SetBudget(decimal amount, string category, string period) {
        Budget budget = new Budget { Amount = amount, Category = category, Period = period };
        Budgets.Add(budget);
    }

    public void AddIncomeSource(string source) {
        Income.Sources.Add(source);
    }

    public decimal GetTotalIncome() {
        return Income.TotalIncome;
    }

    public Report GenerateExpenseReport() {
        // Generate expense report logic
        return new Report();
    }

    public Report GenerateIncomeReport() {
        // Generate income report logic
        return new Report();
    }

    public Report GenerateBudgetReport() {
        // Generate budget report logic
        return new Report();
    }

    public Report GenerateMonthlySummaryReport(int month, int year) {
        // Generate monthly summary report logic
        return new Report();
    }
}

class Program {
    static void Main(string[] args) {
        // Initialize PersonalFinanceManager
        PersonalFinanceManager financeManager = new PersonalFinanceManager();

        // Add expenses
        financeManager.AddExpense(50, "Food", "Lunch", DateTime.Now);
        financeManager.AddExpense(30, "Transportation", "Bus fare", DateTime.Now);
        financeManager.AddExpense(100, "Entertainment", "Movie tickets", DateTime.Now);

        // Set budget
        financeManager.SetBudget(500, "Food", "Monthly");

        // Add income sources
        financeManager.AddIncomeSource("Salary");
        financeManager.AddIncomeSource("Freelance");

        // Generate reports
        Report expenseReport = financeManager.GenerateExpenseReport();
        Report incomeReport = financeManager.GenerateIncomeReport();
        Report budgetReport = financeManager.GenerateBudgetReport();
        Report monthlySummaryReport = financeManager.GenerateMonthlySummaryReport(DateTime.Now.Month, DateTime.Now.Year);

        // Display reports or perform further actions
        // ...
    }
}
