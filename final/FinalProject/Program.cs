using System;
using System.Collections.Generic;

class Expense
{
    public decimal Amount { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
}

class Budget
{
    public decimal Amount { get; set; }
    public string Category { get; set; }
    public string Period { get; set; }
}

class Income
{
    public List<string> Sources { get; set; }
    public decimal TotalIncome { get; set; }
}

class Report
{
    public Dictionary<string, object> ReportData { get; set; }
}

class PersonalFinanceManager
{
    public List<Expense> Expenses { get; set; }
    public List<Budget> Budgets { get; set; }
    public Income Income { get; set; }

    public PersonalFinanceManager()
    {
        Expenses = new List<Expense>();
        Budgets = new List<Budget>();
        Income = new Income();
        Income.Sources = new List<string>();
    }

    public void AddExpense(decimal amount, string category, string description, DateTime date)
    {
        Expense expense = new Expense { Amount = amount, Category = category, Description = description, Date = date };
        Expenses.Add(expense);
    }

    public decimal GetTotalExpenses()
    {
        decimal totalExpenses = 0;
        foreach (Expense expense in Expenses)
        {
            totalExpenses += expense.Amount;
        }
        return totalExpenses;
    }

    public decimal CalculateRemainingFunds()
    {
        decimal totalExpenses = GetTotalExpenses();
        decimal totalIncome = Income.TotalIncome;
        decimal remainingFunds = totalIncome - totalExpenses;
        return remainingFunds;
    }
}

class Program
{
    static void Main(string[] args)
    {
        PersonalFinanceManager financeManager = new PersonalFinanceManager();

        // Get user's salary
        Console.Write("Enter your salary: ");
        decimal salary = decimal.Parse(Console.ReadLine());
        financeManager.Income.TotalIncome = salary;

        // Get user's expenses
        string[] expenseCategories = { "Transport", "Utility bills", "Food" };
        foreach (string category in expenseCategories)
        {
            Console.Write($"Please enter the amount owed for {category}: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            financeManager.AddExpense(amount, category, $"Expense for {category}", DateTime.Now);
        }

        // Calculate and display remaining funds
        decimal remainingFunds = financeManager.CalculateRemainingFunds();
        Console.WriteLine($"Your remaining funds: {remainingFunds}");
    }
}



