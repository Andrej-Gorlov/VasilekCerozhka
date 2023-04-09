namespace VasilekCerozhka.Services.Interfaces.IProductAPI
{
    public interface IImageService
    {
        Task<T> GetAllImageAsync<T>(string? filter, string? search, string token);
        Task<T> GetImageByIdAsync<T>(int id, string token);
        Task<T> CreateImageAsync<T>(CreateImageDtoBase imageDto, string token);
        Task<T> UpdateImageAsync<T>(UpdateImageDtoBase imageDto, string token);
        Task<T> DeleteImageAsync<T>(int id, string token);
    }
}
