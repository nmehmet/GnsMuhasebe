namespace GnsMuhasebe.domain.Entities
{
    public class Activities : BaseEntity
    {
        private float TotalAmount { get; set; }
        private float CashAmount { get; set; }
        private float CreditAmount { get; set; }
        private enum SaleType : byte 
        {
            /// <summary>
            /// Sale(1) = Selling a product
            /// </summary>
            Sale = 1,
            /// <summary>
            /// Debt(2) = Selling without taking money,
            /// </summary>
            Debt = 2,
            /// <summary>
            /// Collection(3) = Collecting debts,
            /// </summary>
            Collection = 3,
            /// <summary>
            /// Expense(4) = Expenses except theese options
            /// </summary>
            Expense = 4,
            /// <summary>
            /// Payment(5) = Paying for suppliers debt
            /// </summary>
            Payment = 5,
            /// <summary>
            /// Salary(6) = Paying salaries for employees
            /// </summary>
            Salary = 6 }
        private string? Description { get; set; }
        private int? AccounterId { get; set; }
        private int? SupplierId { get; set; }
        private int? EmployeeId { get; set; }
        private List<SaleItem> SaleItems { get; set; } = new();
    }
}
