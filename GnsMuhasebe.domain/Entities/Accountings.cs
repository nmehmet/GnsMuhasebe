namespace GnsMuhasebe.domain.Entities
{
    public class Accountings : BaseEntity
    {
        public enum Type : byte
        {
            /// <summary>
            /// Paying Salary for employees
            /// </summary>
            Payment = 1,
            /// <summary>
            /// Adding debt myself to empoloyee
            /// </summary>
            Debt = 2
        }
        public Type AccountingType { get; set; }
        public int EmployeeId { get; set; }
        public decimal Amount { get; set; }
        public decimal BalanceAfterTransaction { get; set; }
        public decimal BalanceBeforeTransaction { get; set; }
    }
}
