using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExpenseApp.Models
{
    public class Expense : INotifyPropertyChanged
    {
        private ExpenseCategory _category;
        private decimal _amount;
        private string _description = string.Empty;
        private DateTime _date;
        private bool _isSelected;

        public ExpenseCategory Category
        {
            get => _category;
            set { _category = value; OnPropertyChanged(); }
        }
        public decimal Amount
        {
            get => _amount;
            set { _amount = value; OnPropertyChanged(); }
        }
        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(); }
        }
        public DateTime Date
        {
            get => _date;
            set { _date = value; OnPropertyChanged(); }
        }
        public bool IsSelected
        {
            get => _isSelected;
            set { _isSelected = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}