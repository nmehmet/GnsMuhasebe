namespace GnsMuhasebe.domain.Entities
{
    public class Suppliers : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }
}
