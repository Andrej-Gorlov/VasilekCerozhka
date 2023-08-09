namespace VasilekCerozhka.Services.Interfaces.ICouponAPI
{
    public interface ICouponService
    {
        Task<ResponseDtoBase?> GetAllCouponAsync();
        Task<ResponseDtoBase?> GetCouponByIdAsync(int id);
        Task<ResponseDtoBase?> CreateCouponAsync(CreateCouponDtoBase couponDto);
        Task<ResponseDtoBase?> UpdateCouponAsync(int id, UpdateCouponDtoBase couponDto);
        Task<ResponseDtoBase?> DeleteCouponAsync(int id);
    }
}
