namespace GnsMuhasebe.domain.Entities
{
    public class Product : BaseEntity
    {   
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }

    }
}
