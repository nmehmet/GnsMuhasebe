namespace GnsMuhasebe.domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public decimal Balance { get; set; }
        public decimal Salary { get; set; }
    }
}
