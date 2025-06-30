using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseApp.Models;

namespace ExpenseApp.Services
{
    public class ExpenseService : IExpenseService
    {
        public ObservableCollection<Expense> Expenses { get; } = new();

        public void AddExpense(Expense expense)
        {
            Expenses.Add(expense);
        }

        public decimal CalculateTotalExpenses(ExpenseCategory? category = null)
        {
            if (category == null || category == ExpenseCategory.All)
            {
                return Expenses.Sum(e => e.Amount);
            }
            return Expenses.Where(e => e.Category == category).Sum(e => e.Amount);
        }
    }
}
