using ExpenseApp.ViewModels;
using ExpenseApp.Models;
using System.Windows;

namespace ExpenseApp.Views
{
    public partial class EditExpenseWindow : Window
    {
        public EditExpenseWindow(Expense expense)
        {
            InitializeComponent();
            DataContext = new EditExpenseViewModel(this, expense);
            Owner = Application.Current.MainWindow;
        }
    }
}