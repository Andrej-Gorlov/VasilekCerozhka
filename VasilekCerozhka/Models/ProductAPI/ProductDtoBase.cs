using System.ComponentModel.DataAnnotations;

namespace VasilekCerozhka.Models.ProductAPI
{
    public class ProductDtoBase
    {
        public ProductDtoBase()
        {
            Count = 1;
        }
        public int ProductId { get; set; }
        [Display(Name = "Названия")]
        public string? ProductName { get; set; } = string.Empty;
        [Display(Name = "Цена")]
        public double Price { get; set; }
        [Display(Name = "Время создания")]
        public DateTime CreateDateTime { get; set; };
        [Display(Name = "Описание")]
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        [Display(Name = "Категория")]
        public CategoryDtoBase? Category { get; set; }
        [Display(Name = "Url Изображения")]
        public string MainImageUrl { get; set; } = string.Empty;
        [Display(Name = "Список изображений")]
        public ICollection<ImageDtoDase>? SecondaryImages { get; set; }
        [Range(1, 100)]
        public int Count { get; set; }
    }
}
