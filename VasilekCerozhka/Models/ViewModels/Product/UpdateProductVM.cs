using VasilekCerozhka.Models.ProductAPI.Product;

namespace VasilekCerozhka.Models.ViewModels.Product
{
    public class UpdateProductVM : SelectCategory 
    {
        public ProductDtoBase? product { get; set; }
    }
}
