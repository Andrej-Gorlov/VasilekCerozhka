using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VasilekCerozhka.Models.ProductAPI.Product;
using VasilekCerozhka.Models;
using VasilekCerozhka.Services.Interfaces.IProductAPI;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VasilekCerozhka.Models.Paging;
using VasilekCerozhka.Models.ViewModels;

namespace VasilekCerozhka.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> ProductIndex(int page = 1)
        {
            //СreditСardVM cardVM = new();

            //var respons = await _creditСardService.GetСreditСardsAsync<ResponseBase>(new PagingParameters() { PageNumber = page });
            //if (respons != null)
            //{
            //    cardVM.CreditСards = JsonConvert.DeserializeObject<List<СreditСardDTOBase>>(Convert.ToString(respons.Result));
            //    cardVM.Paging = respons.PagedList;
            //}
            //return View(cardVM);

            var productVM = new ProductVM();

            //var accessToken = await HttpContext.GetTokenAsync("access_token");

            var respons = await _productService.GetAllProductAsync<ResponseDtoBase>(new PagingParameters() { PageNumber = page },null,null, null);

            if (respons != null & respons.IsSuccess)
            {
                productVM.products = JsonConvert.DeserializeObject<List<ProductDtoBase>>(Convert.ToString(respons.Result));
                productVM.Paging = respons.PagedList;
            }
            return View(productVM);
        }
    }
}
