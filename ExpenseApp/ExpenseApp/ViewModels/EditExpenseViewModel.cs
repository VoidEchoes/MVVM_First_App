using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseApp.Models;
using System.ComponentModel;
using System.Windows;

namespace ExpenseApp.ViewModels
{
    public class EditExpenseViewModel : ObservableObject
    {
        private readonly Window _window;

        public Expense OriginalExpense { get; }
        public Expense EditingExpense { get; }
        public IEnumerable<ExpenseCategory> AvailableCategories { get; } =
            new[] { ExpenseCategory.Food, ExpenseCategory.Transport, ExpenseCategory.Entertainment, ExpenseCategory.Other };

        public RelayCommand SaveCommand { get; }
        public RelayCommand CloseCommand { get; }

        public EditExpenseViewModel(Window window, Expense expense)
        {
            _window = window;
            OriginalExpense = expense;
            EditingExpense = new Expense()
            {
                Category = expense.Category,
                Amount = expense.Amount,
                Description = expense.Description,
                Date = expense.Date
            };

            SaveCommand = new RelayCommand(Save, CanSave);
            CloseCommand = new RelayCommand(Close);

            EditingExpense.PropertyChanged += (s, e) => SaveCommand.NotifyCanExecuteChanged();
        }

        private bool CanSave() => !PropertiesEqual();

        private bool PropertiesEqual()
        {
            return OriginalExpense.Category == EditingExpense.Category &&
                   OriginalExpense.Amount == EditingExpense.Amount &&
                   OriginalExpense.Description == EditingExpense.Description &&
                   OriginalExpense.Date == EditingExpense.Date;
        }

        private void Save()
        {
            OriginalExpense.Category = EditingExpense.Category;
            OriginalExpense.Amount = EditingExpense.Amount;
            OriginalExpense.Description = EditingExpense.Description;
            OriginalExpense.Date = EditingExpense.Date;

            _window.DialogResult = true;
            _window.Close();
        }

        private void Close()
        {
            _window.DialogResult = false;
            _window.Close();
        }
    }
}