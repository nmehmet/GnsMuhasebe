namespace GnsMuhasebe.domain.Entities
{
    public class Works : BaseEntity
    {
        public int EmployeeId { get; set; }
        public string? Description { get; set; } = string.Empty;
        public enum Type : byte
        {
            /// <summary>
            /// Products given to employee to work on
            /// </summary>
            ItemGiven = 1,
            /// <summary>
            /// Products returned by employee after work
            /// </summary>
            ItemReturned = 2,
            /// <summary>
            /// Payment of salary to employee
            /// </summary>
            SalaryPaid = 3
        }
        public Type WorkType { get; set; }
        /// <summary>
        /// Products that given to employee to work on or returned by employee after work
        /// </summary>
        public List<WorkItem>? WorkItems { get; set; } = new();
        public decimal CurrentSalary { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
