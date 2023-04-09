namespace VasilekCerozhka.Models.ProductAPI.Category
{
    public class CategoryDtoBase
    {
        public int CategoryId { get; set; }
        [Display(Name = "Название")]
        public string CategoryName { get; set; } = string.Empty;
        [Display(Name = "Url Изображения")]
        public string ImageUrl { get; set; } = string.Empty;
        [StringLength(250, MinimumLength = 0, ErrorMessage = "Описание продукта не должно превышать 250 символов.")]
        public string Description { get; set; } = string.Empty;
    }
}
