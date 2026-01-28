using AutoMapper;
using GnsMuhasebe.Application.Features.Commands.CreateProduct;
using GnsMuhasebe.Application.Interfaces;
using GnsMuhasebe.domain.Entities;
using GnsMuhasebe.domain.Enums;
using GnsMuhasebe.domain.Exceptions;
using Moq;

namespace GnsMuhasebe.Application.Tests
{
    public class CreateProductTests
    {
        private readonly Mock<IGenericRepository<Product>> _productRepository;
        private readonly Mock<IGenericRepository<Category>> _categoryRepository;
        private readonly Mock<IMapper> _mapper;

        private readonly CreateProductCommand _handler;

        public CreateProductTests()
        {
            _productRepository = new Mock<IGenericRepository<Product>>();
            _categoryRepository = new Mock<IGenericRepository<Category>>();
            _mapper = new Mock<IMapper>();

            _handler = new CreateProductCommand(_productRepository.Object, _categoryRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task CreateProductCommand_CorrectData_CreatedProducttoDatabase()
        {
            CreateProductRequest request = new CreateProductRequest
            {
                Name = "TestProduct",
                Description = "description",
                CategoryId = 1,
                SalePrice = 40,
                PurchasePrice = 30,
                Stock = 20
            };

            _categoryRepository.Setup(x => x.GetByIdAsync(request.CategoryId)).ReturnsAsync(new Category("TestCategory","Description"));
            _productRepository.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            CreateProductResponse response = await _handler.Handle(request, CancellationToken.None);

            Assert.Equal(200, response.Status);

            Assert.NotNull(response.AddedProduct);
            Assert.Equal("TestProduct", response.AddedProduct.Name);
        }

        [Fact]
        public async Task CreateProductCommand_InvalidCategory_ThrowException()
        {
            CreateProductRequest request = new CreateProductRequest
            {
                Name = "TestProduct",
                Description = "description",
                CategoryId = 2,
                SalePrice = 40,
                PurchasePrice = 30,
                Stock = 20
            };

            _categoryRepository.Setup(x => x.GetByIdAsync(request.CategoryId)).ReturnsAsync((Category)null);

            BusinessException exception = await Assert.ThrowsAsync<BusinessException>(() => _handler.Handle(request, CancellationToken.None));

            Assert.Equal(BusinessErrorCode.CategoryCouldNotFound, exception.ErrorCode);


            _productRepository.Verify(x => x.AddAsync(It.IsAny<Product>()), Times.Never());
            _productRepository.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never());
         
        }
        
        [Fact]
        public async Task CreateProductCommand_ProductCouldNotAdded_ThrowException()
        {
            CreateProductRequest request = new CreateProductRequest
            {
                Name = "TestProduct",
                Description = "description",
                CategoryId = 1,
                SalePrice = 40,
                PurchasePrice = 30,
                Stock = 20
            };

            _categoryRepository.Setup(x => x.GetByIdAsync(request.CategoryId)).ReturnsAsync(new Category("TestCategory", "Description"));
            _productRepository.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);

            BusinessException exception = await Assert.ThrowsAsync<BusinessException>(() => _handler.Handle(request, CancellationToken.None));

            Assert.Equal(BusinessErrorCode.ProductCouldNotBeAdded, exception.ErrorCode);
        }
        [Fact]
        public async Task CreateProductCommand_NullRequest_ThrowException()
        {
            BusinessException exception = await Assert.ThrowsAsync<BusinessException>(() => _handler.Handle(null, CancellationToken.None));

            Assert.Equal(BusinessErrorCode.RequestIsEmpty, exception.ErrorCode);
        }
    }
}