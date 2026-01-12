namespace GnsMuhasebe.domain.Entities
{
    public class Works : BaseEntity
    {
        private int EmployeeId { get; set; }
        private string? Description { get; set; } = string.Empty;
        private enum Type : byte
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
        /// <summary>
        /// Products that given to employee to work on or returned by employee after work
        /// </summary>
        private List<WorkItem>? WorkItems { get; set; } = new();
        private float CurrentSalary { get; set; }
        private float TotalAmount { get; set; }
    }
}
