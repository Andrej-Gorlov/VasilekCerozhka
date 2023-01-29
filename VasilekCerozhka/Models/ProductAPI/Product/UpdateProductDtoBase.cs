using System.ComponentModel.DataAnnotations;
using VasilekCerozhka.Models.ProductAPI.Category;
using VasilekCerozhka.Models.ProductAPI.Image;

namespace VasilekCerozhka.Models.ProductAPI.Product
{
    public class UpdateProductDtoBase
    {
        public int ProductId { get; set; }
        [Display(Name = "Названия")]
        [Required(ErrorMessage = "Введите название продукта.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Название продукта должен содержать быть не менее 2 и не более 150 символов")]
        public string ProductName { get; set; } = string.Empty;
        [Display(Name = "Цена")]
        [Range(0, 1000000000, ErrorMessage = "Цена не может быть меньше 0 и больше 1 000 000 000.")]
        public double Price { get; set; }
        [Display(Name = "Описание")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "Описание продукта не должно превышать 1000 символов.")]
        public string Description { get; set; } = string.Empty;
        public UpdateCategoryDtoBase? Category { get; set; }
        [Display(Name = "Url Изображения")]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Длина url адреса должна быть не менее 5 символов")]
        [Url(ErrorMessage = "Не веерно введен url адрес")]
        public string MainImageUrl { get; set; } = string.Empty;
        [Display(Name = "Список изображений")]
        public ICollection<UpdateImageDtoBase>? SecondaryImages { get; set; }
    }
}
