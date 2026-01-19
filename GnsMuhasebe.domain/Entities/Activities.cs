namespace GnsMuhasebe.domain.Entities
{
    public class Activities : BaseEntity
    {
        public decimal TotalAmount { get; set; }
        public decimal CashAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public enum Type : byte 
        {
            /// <summary>
            /// Sale(1) = Selling a product
            /// </summary>
            Sale = 1,
            /// <summary>
            /// Debt(2) = Selling without takin g money,
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
            Salary = 6 
        }
        public Type ActivityType { get; set; }
        public string? Description { get; set; }
        public int? AccounterId { get; set; }
        public int? SupplierId { get; set; }
        public int? EmployeeId { get; set; }
        public List<SaleItem> SaleItems { get; set; } = new();
    }
}
