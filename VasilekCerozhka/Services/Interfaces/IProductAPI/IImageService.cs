namespace VasilekCerozhka.Services.Interfaces.IProductAPI
{
    public interface IImageService
    {
        Task<ResponseDtoBase?> GetAllImageAsync(string? filter, string? search);
        Task<ResponseDtoBase?> GetImageByIdAsync(int id);
        Task<ResponseDtoBase?> CreateImageAsync(CreateImageDtoBase imageDto);
        Task<ResponseDtoBase?> UpdateImageAsync(UpdateImageDtoBase imageDto);
        Task<ResponseDtoBase?> DeleteImageAsync(int id);
    }
}
