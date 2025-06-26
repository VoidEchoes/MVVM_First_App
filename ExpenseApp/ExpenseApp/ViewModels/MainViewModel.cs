using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseApp.Models;

namespace ExpenseApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string category = string.Empty;

        [ObservableProperty]
        private decimal amount;

        [ObservableProperty]
        private string description = string.Empty;

        [ObservableProperty]
        private DateTime date = DateTime.Now;

        [ObservableProperty]
        private string? selectedCategory;

        [ObservableProperty]
        private decimal totalAmount;


        public ObservableCollection<string> AllCategories { get; } = new()
    {
        "Продукти", "Транспорт", "Розваги", "Інше", "Всі"
    };

        public ObservableCollection<string> AddCategories { get; } = new()
    {
        "Продукти", "Транспорт", "Розваги", "Інше"
    };

        public MainViewModel()
        {
            SelectedCategory = "Всі";
        }


        public ObservableCollection<Expense> Expenses { get; } = new();


        [RelayCommand]
        private void AddExpense()
        {
            if (string.IsNullOrWhiteSpace(Category) || Amount <= 0)
                return;

            Expenses.Add(new Expense
            {
                Category = Category,
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
            if (string.IsNullOrWhiteSpace(SelectedCategory) || SelectedCategory == "Всі")
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
