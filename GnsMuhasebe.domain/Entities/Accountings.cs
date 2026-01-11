namespace GnsMuhasebe.domain.Entities
{
    public class Accountings : BaseEntity
    {
        private enum AccountingType : byte
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
        private int EmployeeId { get; set; }
        private float Amount { get; set; }
        private float BalanceAfterTransaction { get; set; }
        private float BalanceBeforeTransaction { get; set; }
    }
}
