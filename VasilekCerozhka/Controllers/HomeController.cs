namespace VasilekCerozhka.Controllers
{
    public class HomeController : BaseApiController<HomeController>
    {
        private readonly ICategoryService _categoryService ;

        public HomeController(ICategoryService categoryService, IMemoryCache cache, ILogger<HomeController> logger) :base(cache,logger)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categoryVM = new CategoryVM();
            var respons = await _categoryService.GetAllCategoryAsync<ResponseDtoBase>();
            if (respons != null & respons.IsSuccess)
            {
                categoryVM.categorys = JsonConvert.DeserializeObject<List<CategoryDtoBase>>(Convert.ToString(respons.Result));
            }
            return View(categoryVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}