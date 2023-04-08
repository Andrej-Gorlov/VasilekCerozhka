using VasilekCerozhka.Models.ProductAPI.Category;

namespace VasilekCerozhka.Services.Interfaces.IProductAPI
{
    public interface ICategoryService
    {
        Task<T> GetAllCategoryAsync<T>(string? filter = null, string? search = null, string? token = null);
        Task<T> GetCategoryByIdAsync<T>(int id, string token);
        Task<T> CreateCategoryAsync<T>(CreateCategoryDtoBase categoryDto, string token);
        Task<T> UpdateCategoryAsync<T>(UpdateCategoryDtoBase categoryDto, string token);
        Task<T> DeleteCategoryAsync<T>(int id, string token);
    }
}
