namespace GnsMuhasebe.domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public int ActivityId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCurrentPrice { get; set; }
        public Product Product { get; set; } = null!;
    }
}
