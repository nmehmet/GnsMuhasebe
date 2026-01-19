namespace GnsMuhasebe.domain.Entities
{
    public class Purchaces : BaseEntity
    {
        public enum Type : byte
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
        public int SupplierId { get; set; }
        public Type PurchaseType { get; set; }
        public List<PurchaseItem> PurchaseItems { get; set; } = new();
        public decimal TotalAmount { get; set; }
    }
}
