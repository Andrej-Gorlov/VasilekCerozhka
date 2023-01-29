namespace VasilekCerozhka.Models.ProductAPI.Category
{
    public class CreateCategoryDtoBase
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
