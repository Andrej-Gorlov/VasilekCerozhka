using System.ComponentModel.DataAnnotations;

namespace VasilekCerozhka.Models.ProductAPI.Category
{
    public class CreateCategoryDtoBase
    {
        [Display(Name = "Названия")]
        [Required(ErrorMessage = "Введите название продукта.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Название продукта должен содержать быть не менее 2 и не более 150 символов")]
        public string CategoryName { get; set; } = string.Empty;
        [Display(Name = "Url Изображения")]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Длина url адреса должна быть не менее 5 символов")]
        [Url(ErrorMessage = "Не веерно введен url адрес")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
