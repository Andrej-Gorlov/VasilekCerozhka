namespace VasilekCerozhka.Services.Implementations.ProductAPI
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;
        public ProductService(IBaseService baseService) 
        {
            _baseService = baseService;
        }

        public async Task<ResponseDtoBase?> CreateProductAsync(CreateProductDtoBase productDto)
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.POST,
                Data = productDto,
                Url = StaticDitels.ProductApiBase + "/api/v1/product"
            });
        }

        public async Task<ResponseDtoBase?> DeleteProductAsync(int id)
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.DELETE,
                Url = StaticDitels.ProductApiBase + $"/api/v1/product/{id}"
            });
        }

        public async Task<ResponseDtoBase?> GetAllProductAsync(PagingParameters parameters, string? filter, string? search)
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.GET,
                Url = StaticDitels.ProductApiBase + $"/api/v1/products?PageNumber={parameters.PageNumber}&PageSize={parameters.maxPageSize}&filter={filter}&search={search}"
            });
        }

        public  async Task<ResponseDtoBase?> GetProductByIdAsync(int id)
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.GET,
                Url = StaticDitels.ProductApiBase + $"/api/v1/product/{id}"
            });
        }

        public async Task<ResponseDtoBase?> UpdatePatrialProductAsync(int id, UpdateProductDtoBase productDto)
        {
            // доработать
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.PATCH,
                Data = productDto,
                Url = StaticDitels.ProductApiBase + $"/api/v1/product/{id}"
            });
        }

        public async Task<ResponseDtoBase?> UpdateProductAsync(UpdateProductDtoBase productDto)
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.PUT,
                Data = productDto,
                Url = StaticDitels.ProductApiBase + "/api/v1/product"
            });
        }
    }
}
