namespace VasilekCerozhka.Services.Interfaces.IProductAPI
{
    public interface ICategoryService
    {
        Task<ResponseDtoBase?> GetAllCategoryAsync(string? filter = null, string? search = null);
        Task<ResponseDtoBase?> GetCategoryByIdAsync(int id);
        Task<ResponseDtoBase?> CreateCategoryAsync(CreateCategoryDtoBase categoryDto);
        Task<ResponseDtoBase?> UpdateCategoryAsync(UpdateCategoryDtoBase categoryDto);
        Task<ResponseDtoBase?> DeleteCategoryAsync(int id);
    }
}
