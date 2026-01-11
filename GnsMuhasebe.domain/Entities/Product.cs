namespace GnsMuhasebe.domain.Entities
{
    public class Product : BaseEntity
    {   
        private string Name { get; set; } = string.Empty;
        private string? Description { get; set; }
        private int Stock { get; set; }
        private float PurchasePrice { get; set; }
        private float SalePrice { get; set; }

    }
}
