using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseApp.Models;
using ExpenseApp.Services;

namespace ExpenseApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IExpenseService _expenseService;

        [ObservableProperty]
        private ExpenseCategory? category;

        [ObservableProperty]
        private decimal amount;

        [ObservableProperty]
        private string description = string.Empty;

        [ObservableProperty]
        private DateTime date = DateTime.Now;

        [ObservableProperty]
        private ExpenseCategory selectedCategory;

        [ObservableProperty]
        private decimal totalAmount;


        public ObservableCollection<ExpenseCategory> AllCategories { get; } = new()
        {
            ExpenseCategory.Food,
            ExpenseCategory.Transport,
            ExpenseCategory.Entertainment,
            ExpenseCategory.Other,
            ExpenseCategory.All
        };

        public ObservableCollection<ExpenseCategory> AddCategories { get; } = new()
        {
            ExpenseCategory.Food,
            ExpenseCategory.Transport,
            ExpenseCategory.Entertainment,
            ExpenseCategory.Other
        };

        public MainViewModel(IExpenseService expenseService)
        {
            _expenseService = expenseService;
            SelectedCategory = ExpenseCategory.All;
            CalculateTotal();
        }


        public ObservableCollection<Expense> Expenses => _expenseService.Expenses;


        [RelayCommand]
        private void AddExpense()
        {
            if (Category == null || Amount <= 0)
                return;

            _expenseService.AddExpense(new Expense
            {
                Category = Category.Value,
                Amount = Amount,
                Description = Description,
                Date = Date
            });

            Category = null;
            Amount = 0;
            Description = string.Empty;
            Date = DateTime.Now;

            CalculateTotal();
        }

        [RelayCommand]
        private void FilterByCategory()
        {
            TotalAmount = _expenseService.CalculateTotalExpenses(SelectedCategory);
        }

        private void CalculateTotal()
        {
            TotalAmount = _expenseService.CalculateTotalExpenses();
        }
    }
}
