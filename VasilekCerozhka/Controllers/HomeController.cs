namespace VasilekCerozhka.Controllers
{
    public class HomeController : BaseApiController<HomeController>
    {
        private readonly ICategoryService _categoryService ;
        private readonly IProductService _productService;
        public HomeController(ICategoryService categoryService, IProductService productService, IMemoryCache cache, ILogger<HomeController> logger) :base(cache,logger)
        {
            _categoryService = categoryService;
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categoryVM = new CategoryVM();
            var respons = await _categoryService.GetAllCategoryAsync();
            if (respons != null & respons.IsSuccess)
            {
                categoryVM.categorys = JsonConvert.DeserializeObject<List<CategoryDtoBase>>(Convert.ToString(respons.Result));
            }
            return View(categoryVM);
        }
        [HttpGet]
        public async Task<IActionResult> Cards(string category, int page = 1)
        {
            ProductVM list = new();
            var response = await _productService.GetAllProductAsync(new PagingParameters() { maxPageSize = 9, PageNumber = page },category,null);
            if (response != null && response.IsSuccess)
            {
                list.products = JsonConvert.DeserializeObject<List<ProductDtoBase>>(Convert.ToString(response.Result));
            }

            return View(list);
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