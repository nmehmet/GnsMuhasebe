using GnsMuhasebe.domain.Entities;
using GnsMuhasebe.domain.Exceptions;

namespace GnsMuhasebe.domain.Tests
{
    public class CategoryTests
    {
        public string Name = "TestCategory";
        public string Description = "Desc";

        [Fact]
        public void Constructor_CorrectData_CreatesCategory()
        {
            Category category = new Category(Name, Description);

            Assert.NotNull(category);
            Assert.Equal(Name, category.Name);
            Assert.Equal(Description, category.Description);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Constructor_InvalidName_ThrowsException(string invalidName)
        {
            Assert.Throws<BusinessException>(() => new Category(invalidName, Description));
        }
    }
}
