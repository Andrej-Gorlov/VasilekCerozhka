namespace VasilekCerozhka.Models.CouponAPI.Coupon
{
    public class CouponDtoBase
    {
        public int CouponId { get; init; }
        [Display(Name = "Промокод")]
        public string? CouponCode { get; init; }
        [Display(Name = "Размер скидки")]
        public decimal DiscountAmount { get; init; }
    }
}
