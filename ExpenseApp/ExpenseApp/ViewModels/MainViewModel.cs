using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseApp.Models;
using ExpenseApp.Services;
using ExpenseApp.Views;

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

        [ObservableProperty]
        private bool canEdit;

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

            Expenses.CollectionChanged += (s, e) =>
            {
                if (e.OldItems != null)
                    foreach (Expense item in e.OldItems)
                        item.PropertyChanged -= Expense_PropertyChanged;

                if (e.NewItems != null)
                    foreach (Expense item in e.NewItems)
                        item.PropertyChanged += Expense_PropertyChanged;

                UpdateCanEdit();
            };

            foreach (var expense in Expenses)
                expense.PropertyChanged += Expense_PropertyChanged;
        }


        public ObservableCollection<Expense> Expenses => _expenseService.Expenses;

        private void Expense_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Expense.IsSelected))
                UpdateCanEdit();
        }

        private void UpdateCanEdit()
        {
            CanEdit = Expenses.Count(e => e.IsSelected) == 1;
        }

        [RelayCommand]
        private void EditExpense()
        {
            var selectedExpense = Expenses.FirstOrDefault(e => e.IsSelected);
            if (selectedExpense == null) return;

            var editWindow = new EditExpenseWindow(selectedExpense);
            if (editWindow.ShowDialog() == true)
            {
                 FilterByCategory();
            }

            selectedExpense.IsSelected = false;
        }

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
