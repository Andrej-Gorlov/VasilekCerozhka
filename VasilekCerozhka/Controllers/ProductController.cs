using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VasilekCerozhka.Models.ProductAPI.Product;
using VasilekCerozhka.Models;
using VasilekCerozhka.Services.Interfaces.IProductAPI;
using VasilekCerozhka.Models.Paging;
using VasilekCerozhka.Models.ViewModels.Product;
using VasilekCerozhka.Models.ProductAPI.Image;
using Microsoft.AspNetCore.Mvc.Rendering;
using VasilekCerozhka.Models.ProductAPI.Category;
using Newtonsoft.Json.Linq;

namespace VasilekCerozhka.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IImageService _imageService;
        private readonly ICategoryService _categoryService;
        //private IEnumerable<SelectListItem>? _categorys { get; set; }  почему не записывается???

        public ProductController(IProductService productService, IImageService imageService, ICategoryService categoryService)
        {
            _productService = productService;
            _imageService = imageService; 
            _categoryService = categoryService;
        }
        /// <summary>
        /// request to ProductAPI
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <returns>Open page ProductIndex</returns>
        public async Task<IActionResult> ProductIndex(int page = 1)
        {
            var productVM = new ProductVM();
            var respons = await _productService.GetAllProductAsync<ResponseDtoBase>(new PagingParameters() { PageNumber = page },null,null, null);

            if (respons != null & respons.IsSuccess)
            {
                productVM.products = JsonConvert.DeserializeObject<List<ProductDtoBase>>(Convert.ToString(respons.Result));
                productVM.Paging = respons.PagedList;
            }

            return View(productVM);
        }

        public async Task<IActionResult> ProductCreate()
        {
            var productVM = new CreateProductVM();

            var respons = await _categoryService.GetAllCategoryAsync<ResponseDtoBase>(null, null, null);
            if (respons != null & respons.IsSuccess)
            {
                productVM.Categorys = JsonConvert.DeserializeObject<List<CategoryDtoBase>>(Convert.ToString(respons.Result));
                productVM.SelectCategorys = productVM.Categorys.Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = $"{x.CategoryId},{x.CategoryName}"
                }).DistinctBy(x => x.Text);
            }
            return View(productVM);
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(CreateProductVM model)
        {
            if (ModelState.IsValid)
            {
                //var accessToken = await HttpContext.GetTokenAsync("access_token");

                if (!(model.paramsCategory is null))
                {
                    var parametrs = model.paramsCategory.Split(',');
                    int id;
                    if (int.TryParse(parametrs[0], out id))
                    {
                        model.CreateProduct.Category = new()
                        {
                            CategoryId = id,
                            CategoryName = parametrs[1]
                        };
                    }
                }
                if (model.Images.Count > 0)
                {
                    List<CreateImageDtoBase> second = new();
                    foreach (var item in model.Images)
                    {
                        second.Add(new() { ImageUrl = item });
                    };
                    model.CreateProduct.SecondaryImages = second;
                };






                var respons = await _productService.CreateProductAsync<ResponseDtoBase>(model.CreateProduct, null);

                if (respons.Result != null & respons.IsSuccess)
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
