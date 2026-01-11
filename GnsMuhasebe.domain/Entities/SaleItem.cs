namespace GnsMuhasebe.domain.Entities
{
    public class SaleItem : BaseEntity
    {
        private int SaleId { get; set; }
        private int ProductId { get; set; }
        private int Quantity { get; set; }
        private float UnitCurrentPrice { get; set; }
        private Product Product { get; set; } = null!;
    }
}
