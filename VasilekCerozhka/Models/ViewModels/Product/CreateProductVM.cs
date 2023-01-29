using Microsoft.AspNetCore.Mvc.Rendering;
using VasilekCerozhka.Models.ProductAPI.Category;
using VasilekCerozhka.Models.ProductAPI.Product;

namespace VasilekCerozhka.Models.ViewModels.Product
{
    public class CreateProductVM
    {
        public CreateProductDtoBase? CreateProduct { get; set; }
        public List<string>? Images { get; set; }
        public IEnumerable<SelectListItem>? SelectCategorys { get; set; }
        public List<CategoryDtoBase>? Categorys { get; set; } 
        public string? paramsCategory { get; set; }
    }
}
