using VasilekCerozhka.Models.ProductAPI.Product;

namespace VasilekCerozhka.Models.ViewModels.Product
{
    public class CreateProductVM : SelectCategory 
    {
        public CreateProductDtoBase? CreateProduct { get; set; }
        public List<string>? Images { get; set; }
    }
}
