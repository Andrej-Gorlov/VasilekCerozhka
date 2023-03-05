using VasilekCerozhka.Helpers;
using VasilekCerozhka.Models;
using VasilekCerozhka.Models.Paging;
using VasilekCerozhka.Models.ProductAPI.Product;
using VasilekCerozhka.Models.ViewModels.Product;
using VasilekCerozhka.Services.Interfaces.IProductAPI;

namespace VasilekCerozhka.Services.Implementations.ProductAPI
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;
        public ProductService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }

        public async Task<T> CreateProductAsync<T>(CreateProductDtoBase productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.POST,
                Data = productDto,
                Url = StaticDitels.ProductApiBase + "/api/v1/product",
                AccessToken = token
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.DELETE,
                Url = StaticDitels.ProductApiBase + $"/api/v1/product/{id}",
                AccessToken = token
            });
        }

        public async Task<T> GetAllProductAsync<T>(PagingParameters parameters, string? filter, string? search, string? token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.GET,
                Url = StaticDitels.ProductApiBase + $"/api/v1/products?PageNumber={parameters.PageNumber}&PageSize={parameters.maxPageSize}&filter={filter}&search={search}",
                //AccessToken = token
            });
        }

        public  async Task<T> GetProductByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.GET,
                Url = StaticDitels.ProductApiBase + $"/api/v1/product/{id}",
                AccessToken = token
            });
        }

        public async Task<T> UpdatePatrialProductAsync<T>(int id, UpdateProductDtoBase productDto, string token)
        {
            // доработать
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.PATCH,
                Data = productDto,
                Url = StaticDitels.ProductApiBase + $"/api/v1/product/{id}",
                AccessToken = token
            });
        }

        public async Task<T> UpdateProductAsync<T>(UpdateProductDtoBase productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.PUT,
                Data = productDto,
                Url = StaticDitels.ProductApiBase + "/api/v1/product",
                AccessToken = token
            });
        }
    }
}
