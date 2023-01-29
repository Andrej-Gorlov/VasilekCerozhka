using VasilekCerozhka.Models.ProductAPI.Category;
using VasilekCerozhka.Models.ProductAPI.Image;

namespace VasilekCerozhka.Models.ProductAPI.Product
{
    public class CreateProductDtoBase
    {
        public string ProductName { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public CreateCategoryDtoBase? Category { get; set; }
        public string MainImageUrl { get; set; } = string.Empty;
        public ICollection<CreateImageDtoBase>? SecondaryImages { get; set; }

        public List<string>? Images { get; set; }
    }
}
