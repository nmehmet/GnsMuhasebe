namespace GnsMuhasebe.domain.Entities
{
    public class Product : BaseEntity
    {   
        public string Name { get; private set; } = string.Empty;
        public int CategoryId { get; private set; }
        public string? Description { get; private set; }
        public int Stock { get; private set; }
        public decimal PurchasePrice { get; private set; }
        public decimal SalePrice { get; private set; }
      
        public Product(string name, int categoryId, string description , int stock, decimal purchasePrice, decimal salePrice) : base()
        {
            Name = name;
            CategoryId = categoryId;
            Description = description??String.Empty;
            Stock = stock;
            PurchasePrice = purchasePrice;
            SalePrice = salePrice;

        }
        public void DecreaseStock(int quantity)
        {
            if (Stock < quantity) Stock -= quantity;
        }
    }
}
