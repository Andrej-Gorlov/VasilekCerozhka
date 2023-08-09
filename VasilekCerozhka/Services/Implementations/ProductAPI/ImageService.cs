namespace VasilekCerozhka.Services.Implementations.ProductAPI
{
    public class ImageService : IImageService
    {
        private readonly IBaseService _baseService;
        public ImageService(IBaseService baseService) 
        {
            _baseService = baseService;
        }

        public async Task<ResponseDtoBase?> CreateImageAsync(CreateImageDtoBase imageDto)
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.POST,
                Data = imageDto,
                Url = StaticDitels.ProductApiBase + "/api/v3/image"
            });
        }

        public async Task<ResponseDtoBase?> DeleteImageAsync(int id)
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.DELETE,
                Url = StaticDitels.ProductApiBase + $"/api/v3/image/{id}"
            });
        }

        public async Task<ResponseDtoBase?> GetAllImageAsync(string? filter, string? search)
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.GET,
                Url = StaticDitels.ProductApiBase + $"/api/v3/images?filter={filter}&search={search}"                        
            });
        }

        public async Task<ResponseDtoBase?> GetImageByIdAsync(int id)
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.GET,
                Url = StaticDitels.ProductApiBase + $"/api/v3/image/{id}"
            });
        }

        public async Task<ResponseDtoBase?> UpdateImageAsync(UpdateImageDtoBase imageDto)
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.PUT,
                Data = imageDto,
                Url = StaticDitels.ProductApiBase + "/api/v3/image"
            });
        }
    }
}
