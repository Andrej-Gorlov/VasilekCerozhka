namespace VasilekCerozhka.Models.CouponAPI.Coupon
{
    public class CreateCouponDtoBase
    {
        [Display(Name = "Промокод")]
        public string? CouponCode { get; set; }
        [Display(Name = "Скидка")]
        [Range(0, 100, ErrorMessage = "Скидка не может быть меньше 0 и больше 100.")]
        public decimal DiscountAmount { get; set; }
    }
}
