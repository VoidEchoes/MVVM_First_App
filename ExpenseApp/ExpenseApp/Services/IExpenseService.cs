using System.Collections.ObjectModel;
using ExpenseApp.Models;

namespace ExpenseApp.Services
{
    public interface IExpenseService
    {
        ObservableCollection<Expense> Expenses { get; }
        void AddExpense(Expense expense);
        decimal CalculateTotalExpenses(ExpenseCategory? category = null);
    }
}
