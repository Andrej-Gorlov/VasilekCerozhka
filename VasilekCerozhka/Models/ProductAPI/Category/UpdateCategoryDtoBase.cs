using System.ComponentModel.DataAnnotations;

namespace VasilekCerozhka.Models.ProductAPI.Category
{
    public class UpdateCategoryDtoBase
    {
        public int CategoryId { get; set; }
        [Display(Name = "Названия")]
        [Required(ErrorMessage = "Введите название категории.")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "Название категории должено содержать не менее 2 и не более 80 символов")]
        public string CategoryName { get; set; } = string.Empty;
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Длина url адреса должна быть не менее 5 символов")]
        [Url(ErrorMessage = "Не веерно введен url адрес")]
        public string ImageUrl { get; set; } = string.Empty;
        [StringLength(250, MinimumLength = 0, ErrorMessage = "Описание продукта не должно превышать 250 символов.")]
        public string Description { get; set; } = string.Empty;
    }
}
