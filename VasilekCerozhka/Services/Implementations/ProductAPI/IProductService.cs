using VasilekCerozhka.Models.Paging;
using VasilekCerozhka.Models.ProductAPI;

namespace VasilekCerozhka.Services.Implementations.ProductAPI
{
    public interface IProductService
    {
        Task<T> GetAllProductAsync<T>(PagingParameters parameters, string? filter, string? search, string token);
        Task<T> GetProductByIdAsync<T>(int id, string token);
        //Task<T> CreateProductAsync<T>(ProductDtoBase productDto, string token);
        //Task<T> UpdateProductAsync<T>(ProductDtoBase productDto, string token);
        //Task<T> UpdatePatrialProductAsync<T>(int id, ProductDtoBase productDto, string token);
        Task<T> DeleteProductAsync<T>(int id, string token);
    }
}
