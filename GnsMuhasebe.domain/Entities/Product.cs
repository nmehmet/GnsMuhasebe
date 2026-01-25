using GnsMuhasebe.domain.Enums;
using GnsMuhasebe.domain.Exceptions;
using System.Xml.Linq;

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

        public Product()
        {
            Name = String.Empty;
            CategoryId = 0;
            Description = String.Empty;
            Stock = 0;
            PurchasePrice = 0;
            SalePrice = 0;
        }
        public Product(string name, int categoryId, string? description , int stock, decimal purchasePrice, decimal salePrice) : base()
        {
            if (String.IsNullOrEmpty(name)) throw new BusinessException(BusinessErrorCode.InvalidProductName);
            if (stock <= 0) throw new BusinessException(BusinessErrorCode.InvalidStockValue);
            if (salePrice <= 0) throw new BusinessException(BusinessErrorCode.InvalidSalePrice);

            Name = name;
            CategoryId = categoryId;
            Description = description??String.Empty;
            Stock = stock;
            PurchasePrice = purchasePrice;
            SalePrice = salePrice;

        }
        public void DecreaseStock(int quantity)
        {
            if (Stock < quantity) throw new BusinessException(BusinessErrorCode.NotEnoughProductToSell);

            Stock -= quantity;
        }
        public void IncreaseStock(int quantity)
        {
            Stock += quantity;
        }
    }
}
