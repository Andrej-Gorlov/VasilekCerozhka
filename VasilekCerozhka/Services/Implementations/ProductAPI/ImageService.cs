using VasilekCerozhka.Helpers;
using VasilekCerozhka.Models;
using VasilekCerozhka.Models.ProductAPI.Image;
using VasilekCerozhka.Services.Interfaces.IProductAPI;

namespace VasilekCerozhka.Services.Implementations.ProductAPI
{
    public class ImageService : BaseService, IImageService
    {
        private readonly IHttpClientFactory _clientFactory;
        public ImageService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }

        public async Task<T> CreateImageAsync<T>(CreateImageDtoBase imageDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.POST,
                Data = imageDto,
                Url = StaticDitels.ProductApiBase + "/api/v3/image",
                AccessToken = token
            });
        }

        public async Task<T> DeleteImageAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.DELETE,
                Url = StaticDitels.ProductApiBase + $"/api/v3/image/{id}",
                AccessToken = token
            });
        }

        public async Task<T> GetAllImageAsync<T>(string? filter, string? search, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.GET,
                Url = StaticDitels.ProductApiBase + $"/api/v3/images?filter={filter}&search={search}",
                //AccessToken = token                          
            });
        }

        public async Task<T> GetImageByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.GET,
                Url = StaticDitels.ProductApiBase + $"/api/v3/image/{id}",
                AccessToken = token
            });
        }

        public async Task<T> UpdateImageAsync<T>(UpdateImageDtoBase imageDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.PUT,
                Data = imageDto,
                Url = StaticDitels.ProductApiBase + "/api/v3/image",
                AccessToken = token
            });
        }
    }
}
