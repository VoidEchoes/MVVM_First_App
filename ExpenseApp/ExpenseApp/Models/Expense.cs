using System;

namespace ExpenseApp.Models
{
    public class Expense
    {
        public ExpenseCategory Category { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
