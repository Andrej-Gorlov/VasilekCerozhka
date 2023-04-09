namespace VasilekCerozhka.Models.CouponAPI.Coupon
{
    public class UpdateCouponDtoBase
    {
        [Required(ErrorMessage = "Введите id купона.")]
        public int CouponId { get; init; }
        [Display(Name = "Промокод")]
        [Required(ErrorMessage = "Введите промокод.")]
        [StringLength(9, MinimumLength = 5, ErrorMessage = "Код купона должен содержать быть не менее 5 и не более 9 символов")]
        public string? CouponCode { get; init; }
        [Display(Name = "Размер скидки")]
        [Range(0, 100, ErrorMessage = "Скидка не может быть меньше 0 и больше 100.")]
        public decimal DiscountAmount { get; init; }
    }
}
