namespace GnsMuhasebe.domain.Entities
{
    public class Purchaces : BaseEntity
    {
        private int SupplierId { get; set; }
        private enum Type : byte
        {
            /// <summary>
            /// Taking items from supplier
            /// </summary>
            Purchase = 1,
            /// <summary>
            /// Paying debt to supplier
            /// </summary>
            Payment = 2
        }
        private List<PurchaseItem> PurchaseItems { get; set; } = new();
        private float TotalAmount { get; set; }
    }
}
