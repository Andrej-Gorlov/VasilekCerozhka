using VasilekCerozhka.Helpers;
using VasilekCerozhka.Models;
using VasilekCerozhka.Models.Paging;
using VasilekCerozhka.Models.ProductAPI.Category;
using VasilekCerozhka.Services.Interfaces.IProductAPI;

namespace VasilekCerozhka.Services.Implementations.ProductAPI
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly IHttpClientFactory _clientFactory;
        public CategoryService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateCategoryAsync<T>(CreateCategoryDtoBase categoryDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.POST,
                Data = categoryDto,
                Url = StaticDitels.ProductApiBase + "/api/v2/category",
                AccessToken = token
            });
        }

        public async Task<T> DeleteCategoryAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.DELETE,
                Url = StaticDitels.ProductApiBase + $"/api/v2/category/{id}",
                AccessToken = token
            });
        }

        public async Task<T> GetAllCategoryAsync<T>(string? filter, string? search, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.GET,
                Url = StaticDitels.ProductApiBase + $"/api/v2/categorys?filter={filter}&search={search}",
                //AccessToken = token                           
            });
        }

        public async Task<T> GetCategoryByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.GET,
                Url = StaticDitels.ProductApiBase + $"/api/v2/category/{id}",
                AccessToken = token
            });
        }

        public async Task<T> UpdateCategoryAsync<T>(UpdateCategoryDtoBase categoryDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.PUT,
                Data = categoryDto,
                Url = StaticDitels.ProductApiBase + "/api/v2/category",
                AccessToken = token
            });
        }
    }
}
