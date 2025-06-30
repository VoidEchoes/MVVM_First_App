using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseApp.Models;

namespace ExpenseApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
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

        public MainViewModel()
        {
            SelectedCategory = ExpenseCategory.All;
        }


        public ObservableCollection<Expense> Expenses { get; } = new();


        [RelayCommand]
        private void AddExpense()
        {
            if (Category == null || Amount <= 0)
                return;

            Expenses.Add(new Expense
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
            if (SelectedCategory == ExpenseCategory.All)
            {
                CalculateTotal();
                return;
            }

            TotalAmount = Expenses
                .Where(e => e.Category == SelectedCategory)
                .Sum(e => e.Amount);
        }

        private void CalculateTotal()
        {
            TotalAmount = Expenses.Sum(e => e.Amount);
        }
    }
}
