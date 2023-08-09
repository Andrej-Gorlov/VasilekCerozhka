namespace VasilekCerozhka.Services.Implementations.ProductAPI
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseService _baseService;
        public CategoryService(IBaseService baseService) 
        {
            _baseService = baseService;
        }

        public async Task<ResponseDtoBase?> CreateCategoryAsync(CreateCategoryDtoBase categoryDto)
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.POST,
                Data = categoryDto,
                Url = StaticDitels.ProductApiBase + "/api/v2/category"
            });
        }

        public async Task<ResponseDtoBase?> DeleteCategoryAsync(int id)
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.DELETE,
                Url = StaticDitels.ProductApiBase + $"/api/v2/category/{id}"
            });
        }

        public async Task<ResponseDtoBase?> GetAllCategoryAsync(string? filter, string? search)
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.GET,
                Url = StaticDitels.ProductApiBase + $"/api/v2/categorys?filter={filter}&search={search}"                         
            });
        }

        public async Task<ResponseDtoBase?> GetCategoryByIdAsync(int id)
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.GET,
                Url = StaticDitels.ProductApiBase + $"/api/v2/category/{id}"
            });
        }

        public async Task<ResponseDtoBase?> UpdateCategoryAsync(UpdateCategoryDtoBase categoryDto)
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.PUT,
                Data = categoryDto,
                Url = StaticDitels.ProductApiBase + "/api/v2/category"
            });
        }
    }
}
