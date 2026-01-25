using GnsMuhasebe.domain.Entities;
using GnsMuhasebe.domain.Exceptions;

namespace GnsMuhasebe.domain.Tests
{
    public class ProductTests
    {
        string name = "TestName";
        string desc = "TestDescription";
        int categoryId = 1;
        int stock = 20;
        int purchasePrice = 25;
        int salePrice = 35;
        [Fact]
        public void Constructor_CreateProduct_NormalData()
        {

            Product product = new Product(name, categoryId, desc, stock, purchasePrice, salePrice);

            Assert.NotNull(product);
            Assert.Equal(name, product.Name);
            Assert.Equal(desc, product.Description);
            Assert.Equal(categoryId, product.CategoryId);
            Assert.Equal(stock, product.Stock);
            Assert.Equal(purchasePrice, product.PurchasePrice);
            Assert.Equal(salePrice, product.SalePrice);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void Constructor_InvalidData_ThrowException(string invalidName)
        {
            Assert.Throws<BusinessException>(() => new Product(invalidName, categoryId, desc, stock, purchasePrice, salePrice));
        }

        [Fact]
        public void Constructoor_NegativeSalePrice_ThrowException()
        {
            Assert.Throws<BusinessException>(() => new Product(name, categoryId, desc, stock, purchasePrice, -5));
        }

        [Fact]
        public void Constructoor_NegativePurchasePrice_ThrowException()
        {
            Assert.Throws<BusinessException>(() => new Product(name, categoryId, desc, stock, -5, salePrice));
        }

        [Fact]
        public void DecreaseStock_CorrectData_StockDecreased()
        {
            Product product = new Product(name, categoryId, desc, stock, purchasePrice, salePrice);

            product.DecreaseStock(5);

            Assert.Equal(stock - 5, product.Stock);
        }

        [Fact]
        public void DecreaseStock_NotEnoughStock_ThrowException()
        {
            Product product = new Product(name, categoryId, desc, stock, purchasePrice, salePrice);

            Assert.Throws<BusinessException>(() => product.DecreaseStock(stock + 5));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void DecreaseStock_NegativeOrZero_ThrowException(int invalidQuantity)
        {
            Product product = new Product(name, categoryId, desc, stock, purchasePrice, salePrice);
            Assert.Throws<BusinessException>(() => product.DecreaseStock(invalidQuantity));
        }

        [Fact]
        public void IncreaseStock_CorrectData_IncreasesStock()
        {
            Product product = new Product(name, categoryId, desc, stock, purchasePrice, salePrice);

            product.IncreaseStock(5);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void IncreaseStock_NegativeOrNull_ThrowException(int invalidQuantity)
        {
            Product product = new Product(name, categoryId, desc, stock, purchasePrice, salePrice);

            Assert.Throws<BusinessException>(() => product.IncreaseStock(invalidQuantity));
        }
    }
}