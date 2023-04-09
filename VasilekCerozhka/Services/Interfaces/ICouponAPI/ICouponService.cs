using VasilekCerozhka.Models.CouponAPI.Coupon;

namespace VasilekCerozhka.Services.Interfaces.ICouponAPI
{
    public interface ICouponService
    {
        Task<T> GetAllCouponAsync<T>(string? token = null);
        Task<T> GetCouponByIdAsync<T>(int id, string token);
        Task<T> CreateCouponAsync<T>(CreateCouponDtoBase couponDto, string token);
        Task<T> UpdateCouponAsync<T>(int id, UpdateCouponDtoBase couponDto, string token);
        Task<T> DeleteCouponAsync<T>(int id, string token);
    }
}
