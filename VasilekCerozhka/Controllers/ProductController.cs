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
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace VasilekCerozhka.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        //private readonly IImageService _imageService;
        private readonly ICategoryService _categoryService;
        //private IEnumerable<SelectListItem>? _categorys { get; set; }  почему не записывается???

        public ProductController(IProductService productService, IImageService imageService, ICategoryService categoryService)
        {
            _productService = productService;
           // _imageService = imageService; 
            _categoryService = categoryService;
        }
        /// <summary>
        /// request to ProductAPI (controller: Product / metod: Get)
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
        /// <summary>
        /// request to ProductAPI (controller: Category / metod: Get)
        /// </summary>
        /// <returns>Open views page create</returns>
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
                    Value = x.CategoryId.ToString(),
                }).DistinctBy(x => x.Text);
            }
            return View(productVM);
        }
        /// <summary>
        /// request to ProductAPI (controller: Product / metod: Create)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Open page ProductIndex</returns>
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
                    int id;
                    if (int.TryParse(model.paramsCategory, out id))
                    {
                        model.CreateProduct.CategoryId = id;
                    }
                }
                if (!(model.Images is null))
                {
                    var second = new List<CreateImageDtoBase>();
                    foreach (var item in model.Images)
                    {
                        second.Add(new() { ImageUrl = item });
                    };
                    model.CreateProduct.SecondaryImages = second;
                };
                var respons = await _productService.CreateProductAsync<ResponseDtoBase>(model.CreateProduct, null);
                if (respons.Result != null & respons.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(model);
        }
        /// <summary>
        /// request to ProductAPI (controller: Product / metod: Get)
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Open page ProductEdit</returns>
        public async Task<IActionResult> ProductEdit(int productId)
        {
            var productVM = new UpdateProductVM();
            //var accessToken = await HttpContext.GetTokenAsync("access_token");
            var responsProduct = await _productService.GetProductByIdAsync<ResponseDtoBase>(productId,null);
            var responseCategory = await _categoryService.GetAllCategoryAsync<ResponseDtoBase>(null,null,null);
            if (responsProduct != null & responsProduct.IsSuccess)
            {
                productVM.product = JsonConvert.DeserializeObject<ProductDtoBase>(Convert.ToString(responsProduct.Result));
                productVM.Categorys = JsonConvert.DeserializeObject<List<CategoryDtoBase>>(Convert.ToString(responseCategory.Result));
                productVM.SelectCategorys = productVM.Categorys.Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString(),
                }).DistinctBy(x => x.Text);
                return View(productVM);
            }
            return NotFound();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(UpdateProductVM model)
        {
            return View(model);
        }
    }
}
