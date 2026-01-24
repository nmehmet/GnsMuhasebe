using GnsMuhasebe.domain.Enums;
using GnsMuhasebe.domain.Exceptions;

namespace GnsMuhasebe.domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; }

        public Category()
        {
            Name = String.Empty;
            Description = String.Empty;
        }
        public Category(string name, string description)
        {
            if (String.IsNullOrEmpty(name)) throw new BusinessException(BusinessErrorCode.InvalidCategoryName);

            Name = name;
            Description = description;
        }
    }
}
