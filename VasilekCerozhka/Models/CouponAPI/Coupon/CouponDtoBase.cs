namespace VasilekCerozhka.Models.CouponAPI.Coupon
{
    public class CouponDtoBase
    {
        public int CouponId { get; set; }
        [Display(Name = "Промокод")]
        public string? CouponCode { get; set; }
        [Display(Name = "Скидка")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public decimal DiscountAmount { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime DateTimeCreateCoupon { get; init; }
    }
}
