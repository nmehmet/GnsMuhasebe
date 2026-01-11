namespace GnsMuhasebe.domain.Entities
{
    public class Suppliers : BaseEntity
    {
        private string Name { get; set; } = string.Empty;
        private string? Description { get; set; }
        private string PhoneNumber { get; set; } = string.Empty;
        private float Balance { get; set; }
    }
}
