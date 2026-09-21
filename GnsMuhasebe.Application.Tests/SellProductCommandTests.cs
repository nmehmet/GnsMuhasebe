using AutoMapper;
using GnsMuhasebe.Application.Features.Commands.ProductCommands.SellProduct;
using GnsMuhasebe.Application.Interfaces;
using GnsMuhasebe.domain.Entities;
using Moq;

namespace GnsMuhasebe.Application.Tests
{
    public class SellProductCommandTests
    {
        private readonly Mock<IGenericRepository<Product>> _productRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly SellProductCommand _handler;
        private Product testProduct;
        public SellProductCommandTests()
        {
            _mapper = new Mock<IMapper>();
            _productRepository = new Mock<IGenericRepository<Product>>();
            _handler = new SellProductCommand(_productRepository.Object, _mapper.Object);

            testProduct = new Product("TestName", 1, "Description", 20, 25, 35, "1234567890123");
        }

        [Fact]
        public async Task SellProductCommand_CorrectData_SellsProduct()
        {
            SellProductRequest request = new SellProductRequest
            {
                ProductId = 1,
                ProductQuantity = 5,
            };

            _productRepository.Setup(x => x.GetByIdAsync(request.ProductId)).ReturnsAsync(testProduct);
            _productRepository.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            int initialStock = testProduct.Stock;

            SellProductResponse response = await _handler.Handle(request, CancellationToken.None);

            Assert.Equal(200, response.Status);
            Assert.NotNull(response.UpdatedProduct);
            Assert.Equal(initialStock - request.ProductQuantity, response.UpdatedProduct.Stock);

            _productRepository.Verify(x => x.Update(It.IsAny<Product>()), Times.Once);


        }
    }
}
