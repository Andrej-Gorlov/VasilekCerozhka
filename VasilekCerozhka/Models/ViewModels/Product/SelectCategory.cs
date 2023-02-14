using Microsoft.AspNetCore.Mvc.Rendering;
using VasilekCerozhka.Models.ProductAPI.Category;

namespace VasilekCerozhka.Models.ViewModels.Product
{
    public class SelectCategory 
    {
        public IEnumerable<SelectListItem>? SelectCategorys { get; set; }
        public List<CategoryDtoBase>? Categorys { get; set; }
        public string? paramsCategory { get; set; }
        public List<string>? paramsImagesUrl { get; set; }
        public List<string>? Images { get; set; }
    }
}
