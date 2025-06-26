namespace ExpenseApp.Models;

public class Expense
{
    public string Category { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string Description { get; set; } = string.Empty;
}
