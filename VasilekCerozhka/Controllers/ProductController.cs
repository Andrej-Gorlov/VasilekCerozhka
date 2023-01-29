using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VasilekCerozhka.Models.ProductAPI.Product;
using VasilekCerozhka.Models;
using VasilekCerozhka.Services.Interfaces.IProductAPI;
using VasilekCerozhka.Models.Paging;
using VasilekCerozhka.Models.ViewModels.Product;
using VasilekCerozhka.Models.ProductAPI.Image;

namespace VasilekCerozhka.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IImageService _imageService;
        public ProductController(IProductService productService, IImageService imageService)
        {
            _productService = productService;
            _imageService = imageService;   
        }
        /// <summary>
        /// request to ProductAPI
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <returns>Open page ProductIndex</returns>
        public async Task<IActionResult> ProductIndex(int page = 1)
        {
            var productVM = new ProductVM();
            var responsProduct = await _productService.GetAllProductAsync<ResponseDtoBase>(new PagingParameters() { PageNumber = page },null,null, null);
            var

            if (responsProduct != null & responsProduct.IsSuccess)
            {
                productVM.products = JsonConvert.DeserializeObject<List<ProductDtoBase>>(Convert.ToString(responsProduct.Result));
                productVM.Categorys = 
                productVM.Paging = responsProduct.PagedList;
            }

            return View(productVM);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(CreateProductVM model)
        {
            if (ModelState.IsValid)
            {
                //var accessToken = await HttpContext.GetTokenAsync("access_token");

                var respons = await _productService.CreateProductAsync<ResponseDtoBase>(model.CreateProduct, null);

                if (respons != null & respons.IsSuccess)
                {
                    var product = new ProductDtoBase();

                    product = JsonConvert.DeserializeObject<ProductDtoBase>(Convert.ToString(respons.Result));

                    foreach (var item in model.Images)
                    {
                        var SecondaryImages = new CreateImageDtoBase()
                        {
                            ProductId = product.ProductId,
                            ImageUrl = item
                        };
                        var pesponsImage = await _imageService.CreateImageAsync<ResponseDtoBase>(SecondaryImages, null);
                    }
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(model);
        }
    }
}
