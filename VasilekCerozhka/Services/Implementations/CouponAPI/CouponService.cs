namespace VasilekCerozhka.Services.Implementations.CouponAPI
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDtoBase?> CreateCouponAsync(CreateCouponDtoBase couponDto)
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.POST,
                Data = couponDto,
                Url = StaticDitels.CouponApiBase + "/api/coupon"
            });
        }

        public async Task<ResponseDtoBase?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.DELETE,
                Url = StaticDitels.CouponApiBase + $"/api/coupon/{id}"
            });
        }

        public async Task<ResponseDtoBase?> GetAllCouponAsync()
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.GET,
                Url = StaticDitels.CouponApiBase + $"/api/coupons"                         
            });
        }

        public async Task<ResponseDtoBase?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.GET,
                Url = StaticDitels.CouponApiBase + $"/api/coupon/{id}"
            });
        }

        public async Task<ResponseDtoBase?> UpdateCouponAsync(int id, UpdateCouponDtoBase couponDto)
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.PUT,
                Data = couponDto,
                Url = StaticDitels.CouponApiBase + $"/api/coupon/{id}"
            });
        }
    }
}
