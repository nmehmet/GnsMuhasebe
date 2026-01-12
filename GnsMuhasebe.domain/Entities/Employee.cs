namespace GnsMuhasebe.domain.Entities
{
    public class Employee : BaseEntity
    {
        private string Name { get; set; } = string.Empty;
        private string? PhoneNumber { get; set; }
        private float Balance { get; set; }
        private float Salary { get; set; }
    }
}
