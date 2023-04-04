using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using VasilekCerozhka.Models;
using VasilekCerozhka.Services.Interfaces.IProductAPI;
using VasilekCerozhka.Models.ViewModels.Category;
using VasilekCerozhka.Models.ProductAPI.Category;

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
        /// 
        /// </summary>
        /// <returns>Open views page CategoryCreate</returns>
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

        /// <summary>
        /// request to ProductAPI (controller: Category / metod: GetById)
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>Open page CategoryEdit</returns>
        public async Task<ActionResult> CategoryEdit(int categoryId)
        {
            if (ModelState.IsValid)
            {
                var respons = await _categoryService.GetCategoryByIdAsync<ResponseDtoBase>(categoryId, null);
                if (respons.Result != null & respons.IsSuccess)
                {
                    UpdateCategoryDtoBase category = JsonConvert.DeserializeObject<UpdateCategoryDtoBase>(Convert.ToString(respons.Result));
                    return View(category);
                }
            }
            return NotFound();
        }

        /// <summary>
        /// request to ProductAPI (controller: Category / metod: Update)
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>Open page CategoryIndex</returns>
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> CategoryEdit(UpdateCategoryDtoBase model)
        {
            if (ModelState.IsValid)
            {
                //var accessToken = await HttpContext.GetTokenAsync("access_token");
                var respons = await _categoryService.UpdateCategoryAsync<ResponseDtoBase>(model, null);
                if (respons.Result != null & respons.IsSuccess)
                {
                    return RedirectToAction(nameof(CategoryIndex));
                }
            }
            return View(model);
        }

        /// <summary>
        /// request to ProductAPI (controller: Category / metod: GetById)
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>Open page CategoryDelete</returns>
        public async Task<ActionResult> CategoryDelete(int categoryId)
        {
            //var accessToken = await HttpContext.GetTokenAsync("access_token");
            var respons = await _categoryService.GetCategoryByIdAsync<ResponseDtoBase>(categoryId, null);
            if (respons != null & respons.IsSuccess)
            {
                CategoryDtoBase? model = JsonConvert.DeserializeObject<CategoryDtoBase>(Convert.ToString(respons.Result));
                return View(model);
            }
            return NotFound();
        }

        /// <summary>
        /// request to ProductAPI (controller: Category / metod: Delete)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Open page CategoryIndex</returns>
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryDelete(CategoryDtoBase model)
        {
            if (ModelState.IsValid)
            {
                //var accessToken = await HttpContext.GetTokenAsync("access_token");
                var respons = await _categoryService.DeleteCategoryAsync<ResponseDtoBase>(model.CategoryId, null);
                if (respons.IsSuccess)
                {
                    return RedirectToAction(nameof(CategoryIndex));
                }
            }
            return View(model);
        }
    }
}
