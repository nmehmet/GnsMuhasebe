namespace GnsMuhasebe.domain.Entities
{
    public class PurchaseItem : BaseEntity
    {
        private int PurchaseId { get; set; }
        private int ProductId { get; set; }
        private int Quantity { get; set; }
        private float UnitCurrentPrice { get; set; }
        private Product Product { get; set; } = null!;
    }
}
