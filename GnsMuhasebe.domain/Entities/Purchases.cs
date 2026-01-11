namespace GnsMuhasebe.domain.Entities
{
    public class Purchases : BaseEntity
    {
        private float TotalAmount { get; set; }
        private int SupplierId { get; set; }
        /// <summary>
        /// 1 for debt , 2 for payment
        /// </summary>
        private enum Type : byte { Debt = 1, Payment =2}  
        private List<Product> Products { get; set; } = new();
    }
}
