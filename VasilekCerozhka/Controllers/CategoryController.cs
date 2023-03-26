using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using VasilekCerozhka.Models;
using VasilekCerozhka.Services.Interfaces.IProductAPI;
using VasilekCerozhka.Models.ViewModels.Category;
using VasilekCerozhka.Models.ProductAPI.Category;
using Microsoft.AspNetCore.Mvc.Rendering;
using VasilekCerozhka.Models.ViewModels.Product;
using VasilekCerozhka.Models.ProductAPI.Image;
using VasilekCerozhka.Services.Helpers;
using VasilekCerozhka.Services.Implementations.ProductAPI;

namespace VasilekCerozhka.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMemoryCache _cache;

        public CategoryController(ICategoryService categoryService, IMemoryCache cache)
        {
            _categoryService= categoryService;
            _cache= cache; 
        }
        /// <summary>
        /// request to ProductAPI (controller: Category / metod: Get)
        /// </summary>
        /// <returns>Open page CategoryIndex</returns>
        public async Task<IActionResult> CategoryIndex()
        {
            var categoryVM = new CategoryVM();
            var respons = await _categoryService.GetAllCategoryAsync<ResponseDtoBase>();
            if (respons != null & respons.IsSuccess)
            {
                categoryVM.categorys = JsonConvert.DeserializeObject<List<CategoryDtoBase>>(Convert.ToString(respons.Result));
            }
            return View(categoryVM);
        }
        /// <summary>
        /// request to ProductAPI (controller: Category / metod: Get)
        /// </summary>
        /// <returns>Open views page create</returns>
        public async Task<IActionResult> CategoryCreate()
        {
            return View();
        }
        /// <summary>
        /// request to ProductAPI (controller: Category / metod: Create)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Open page CategoryIndex</returns>
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryCreate(CreateCategoryDtoBase model)
        {
            if (ModelState.IsValid)
            {
                //var accessToken = await HttpContext.GetTokenAsync("access_token");

                var respons = await _categoryService.CreateCategoryAsync<ResponseDtoBase>(model, null);
                if (respons.Result != null & respons.IsSuccess)
                {
                    return RedirectToAction(nameof(CategoryIndex));
                }
            }
            return View(model);
        }
    }
}
