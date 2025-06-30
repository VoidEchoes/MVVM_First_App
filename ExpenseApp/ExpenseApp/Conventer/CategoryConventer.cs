using System;
using System.Globalization;
using System.Windows.Data;
using ExpenseApp.Models;

namespace ExpenseApp.Conventer
{
    public class CategoryConventer : IValueConverter
    {
        public object Convert(object value, Type type, object parameter, CultureInfo culture)
        {
            if (value is ExpenseCategory category)
            {
                return category switch
                {
                    ExpenseCategory.Food => "Продукти",
                    ExpenseCategory.Transport => "Транспорт",
                    ExpenseCategory.Entertainment => "Розваги",
                    ExpenseCategory.Other => "Інше",
                    ExpenseCategory.All => "Всі категорії",
                    _ => throw new ArgumentException("Немає збігу")
                };
            }
            return string.Empty;
        }
        public object ConvertBack(object value, Type type, object parameter, CultureInfo culture)
        {
            if (value is string strValue)
            {
                return strValue switch
                {
                    "Продукти" => ExpenseCategory.Food,
                    "Транспорт" => ExpenseCategory.Transport,
                    "Розваги" => ExpenseCategory.Entertainment,
                    "Інше" => ExpenseCategory.Other,
                    "Всі категорії" => ExpenseCategory.All,
                    _ => throw new ArgumentException("Немає збігу")
                };
            }
            return ExpenseCategory.Other;
        }
    }
}
