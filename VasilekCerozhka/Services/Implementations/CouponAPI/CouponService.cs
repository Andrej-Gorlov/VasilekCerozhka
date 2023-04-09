namespace VasilekCerozhka.Services.Implementations.CouponAPI
{
    public class CouponService : BaseService, ICouponService
    {
        private readonly IHttpClientFactory _clientFactory;
        public CouponService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateCouponAsync<T>(CreateCouponDtoBase couponDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.POST,
                Data = couponDto,
                Url = StaticDitels.CouponApiBase + "/api/coupon",
                //AccessToken = token
            });
        }

        public async Task<T> DeleteCouponAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.DELETE,
                Url = StaticDitels.CouponApiBase + $"/api/coupon/{id}",
                //AccessToken = token
            });
        }

        public async Task<T> GetAllCouponAsync<T>(string? token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.GET,
                Url = StaticDitels.CouponApiBase + $"/api/coupons"
                //AccessToken = token                           
            });
        }

        public async Task<T> GetCouponByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.GET,
                Url = StaticDitels.CouponApiBase + $"/api/coupon/{id}",
                //AccessToken = token
            });
        }

        public async Task<T> UpdateCouponAsync<T>(int id, UpdateCouponDtoBase couponDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.PUT,
                Data = couponDto,
                Url = StaticDitels.CouponApiBase + $"/api/coupon/{id}",
                //AccessToken = token
            });
        }
    }
}
