namespace VasilekCerozhka.Services.Interfaces.IProductAPI
{
    public interface IProductService
    {
        Task<ResponseDtoBase?> GetAllProductAsync(PagingParameters parameters, string? filter, string? search);
        Task<ResponseDtoBase?> GetProductByIdAsync(int id);
        Task<ResponseDtoBase?> CreateProductAsync(CreateProductDtoBase productDto);
        Task<ResponseDtoBase?> UpdateProductAsync(UpdateProductDtoBase productDto);
        Task<ResponseDtoBase?> UpdatePatrialProductAsync(int id, UpdateProductDtoBase productDto);
        Task<ResponseDtoBase?> DeleteProductAsync(int id);
    }
}
