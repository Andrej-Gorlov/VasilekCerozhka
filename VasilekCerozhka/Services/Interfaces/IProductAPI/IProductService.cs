using VasilekCerozhka.Models.Paging;
using VasilekCerozhka.Models.ProductAPI.Product;

namespace VasilekCerozhka.Services.Interfaces.IProductAPI
{
    public interface IProductService
    {
        Task<T> GetAllProductAsync<T>(PagingParameters parameters, string? filter, string? search, string token);
        Task<T> GetProductByIdAsync<T>(int id, string token);
        Task<T> CreateProductAsync<T>(CreateProductDtoBase productDto, string token);
        Task<T> UpdateProductAsync<T>(UpdateProductDtoBase productDto, string token);
        Task<T> UpdatePatrialProductAsync<T>(int id, UpdateProductDtoBase productDto, string token);
        Task<T> DeleteProductAsync<T>(int id, string token);
    }
}
