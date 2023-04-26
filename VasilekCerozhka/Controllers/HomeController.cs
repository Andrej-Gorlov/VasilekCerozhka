using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace VasilekCerozhka.Controllers
{
    public class HomeController : BaseApiController<HomeController>
    {
        private readonly ICategoryService _categoryService ;
        private readonly IProductService _productService;


        private readonly IAccountServicesAuth _accountServices;

        public HomeController(IAccountServicesAuth accountServices, ICategoryService categoryService, IProductService productService, IMemoryCache cache, ILogger<HomeController> logger) :base(cache,logger)
        {
            _categoryService = categoryService;
            _productService = productService;


            _accountServices = accountServices;
        }

        public async Task<IActionResult> Index()
        {
           
                var response = await _accountServices.AuthenticateAsync(new("admin@gmail.com", "Admin123!"));
     
              await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(response.resultAuth));

              
             
        


            var categoryVM = new CategoryVM();
            var respons = await _categoryService.GetAllCategoryAsync<ResponseDtoBase>();
            if (respons != null & respons.IsSuccess)
            {
                categoryVM.categorys = JsonConvert.DeserializeObject<List<CategoryDtoBase>>(Convert.ToString(respons.Result));
            }
            return View(categoryVM);
        }

        public async Task<IActionResult> Cards(string category, int page = 1)
        {
            ProductVM list = new();
            var response = await _productService.GetAllProductAsync<ResponseDtoBase>(new PagingParameters() { maxPageSize = 9, PageNumber = page },category,null,null);
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