using GnsMuhasebe.domain.Entities;

namespace GnsMuhasebe.domain.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Constructor_CreateProduct_NormalData()
        {
            string name = "TestName";
            string desc = "TestDescription";
            int categoryId = 1;
            int stock = 20;
            int purchasePrice = 25;
            int salePrice = 35;

            Product product = new Product(name, categoryId, desc, stock, purchasePrice, salePrice);

            Assert.NotNull(product);
            Assert.Equal(name, product.Name);
            Assert.Equal(desc, product.Description);
            Assert.Equal(categoryId, product.CategoryId);
            Assert.Equal(stock, product.Stock);
            Assert.Equal(purchasePrice, product.PurchasePrice);
            Assert.Equal(salePrice, product.SalePrice);
        }
    }
}