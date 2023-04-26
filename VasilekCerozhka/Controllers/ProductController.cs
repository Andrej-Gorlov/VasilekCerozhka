using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace VasilekCerozhka.Controllers
{
    public class ProductController : BaseApiController<ProductController>
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private SetParams SetParams = new();

        public ProductController(IProductService productService, ICategoryService categoryService, IMemoryCache cache, ILogger<ProductController> logger) :base(cache, logger)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        /// <summary>
        /// request to ProductAPI (controller: Product / metod: Get)
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <returns>Open page ProductIndex</returns>
        [Authorize]
        public async Task<IActionResult> ProductIndex(int page = 1)
        {
            var productVM = new ProductVM();
            var respons = await _productService.GetAllProductAsync<ResponseDtoBase>(new PagingParameters() { maxPageSize = 10, PageNumber = page },null,null, null);
            if (respons != null & respons.IsSuccess)
            {
                productVM.products = JsonConvert.DeserializeObject<List<ProductDtoBase>>(Convert.ToString(respons.Result));
                productVM.Paging = respons.ParameterPaged;
            }
            return View(productVM);
        }
        /// <summary>
        /// request to ProductAPI (controller: Product / metod: Get)
        /// </summary>
        /// <returns>Open views page create</returns>
        public async Task<IActionResult> ProductCreate()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");


            var productVM = new CreateProductVM();

            var respons = await _categoryService.GetAllCategoryAsync<ResponseDtoBase>();
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
                model.CreateProduct.CategoryId = SetParams.IdParams(model.paramsCategory);

                if (model.Images != null)
                {
                    model.CreateProduct.SecondaryImages = SetParams.Images<CreateImageDtoBase>(model.Images);
                }
                //var accessToken = await HttpContext.GetTokenAsync("access_token");
                var respons = await _productService.CreateProductAsync<ResponseDtoBase>(model.CreateProduct, null);
                if (respons.Result != null & respons.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(model);
        }
        /// <summary>
        /// request to ProductAPI (controller: Product / metod: GetById)
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Open page ProductEdit</returns>
        public async Task<IActionResult> ProductEdit(int productId)
        {
            var productVM = new UpdateProductVM();
            //var accessToken = await HttpContext.GetTokenAsync("access_token");
            var responsProduct = await _productService.GetProductByIdAsync<ResponseDtoBase>(productId,null);
            var responseCategory = await _categoryService.GetAllCategoryAsync<ResponseDtoBase>();
            if (responsProduct != null & responsProduct.IsSuccess)
            {
                productVM.UpdateProduct = JsonConvert.DeserializeObject<UpdateProductDtoBase>(Convert.ToString(responsProduct.Result));
                productVM.Categorys = JsonConvert.DeserializeObject<List<CategoryDtoBase>>(Convert.ToString(responseCategory.Result));
                productVM.Images = productVM.UpdateProduct.SecondaryImages.Select( x => x.ImageUrl).ToList();
                productVM.SelectCategorys = productVM.Categorys.Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString(),
                }).DistinctBy(x => x.Text);
                productVM.paramsCategory = productVM.UpdateProduct.Category.CategoryId.ToString();
                return View(productVM);
            }
            return NotFound();
        }

        /// <summary>
        /// request to ProductAPI (controller: Product / metod: Update)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Open page ProductIndex</returns>
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(UpdateProductVM model)
        {
            if (ModelState.IsValid)
            {
                model.UpdateProduct.CategoryId = SetParams.IdParams(model.paramsCategory);
                model.UpdateProduct.SecondaryImages = SetParams.Images<UpdateImageDtoBase>(model.Images);

                var respons = await _productService.UpdateProductAsync<ResponseDtoBase>(model.UpdateProduct, null);
                if (respons != null & respons.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(model);
        }

        /// <summary>
        /// request to ProductAPI (controller: Product / metod: GetById)
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Open page ProductDelete</returns>
        public async Task<IActionResult> ProductDelete(int productId)
        {
            if (ModelState.IsValid)
            {
                var model = new ProductDtoBase();
                _cache.TryGetValue(productId, out ProductDtoBase? productCache);
                if (productCache != null)
                {
                    return View(productCache);
                }
                //var accessToken = await HttpContext.GetTokenAsync("access_token");
                var respons = await _productService.GetProductByIdAsync<ResponseDtoBase>(productId, null);
                if (respons != null & respons.IsSuccess)
                {
                    model = JsonConvert.DeserializeObject<ProductDtoBase>(Convert.ToString(respons.Result));
                    _cache.Set(productId, model, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                    return View(model);
                }
            }
            return NotFound();
        }

        /// <summary>
        /// request to ProductAPI (controller: Product / metod: Delete)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Open page ProductIndex</returns>
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDelete(ProductDtoBase model)
        {
            if (ModelState.IsValid)
            {
                //var accessToken = await HttpContext.GetTokenAsync("access_token");
                var respons = await _productService.DeleteProductAsync<ResponseDtoBase>(model.ProductId, null);
                if (respons.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(model);
        }
    }
}
