using VasilekCerozhka.Models.Paging;
using VasilekCerozhka.Models.ProductAPI.Product;

namespace VasilekCerozhka.Models.ViewModels
{
    public class ProductVM
    {
        public List<ProductDtoBase>? products { get; set; }
        public PagedList? Paging { get; set; }
    }
}
