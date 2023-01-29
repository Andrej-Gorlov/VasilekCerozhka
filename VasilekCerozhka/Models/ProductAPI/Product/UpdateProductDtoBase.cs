using VasilekCerozhka.Models.ProductAPI.Category;
using VasilekCerozhka.Models.ProductAPI.Image;

namespace VasilekCerozhka.Models.ProductAPI.Product
{
    public class UpdateProductDtoBase
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public UpdateCategoryDtoBase? Category { get; set; }
        public string MainImageUrl { get; set; } = string.Empty;
        public ICollection<UpdateImageDtoBase>? SecondaryImages { get; set; }
    }
}
