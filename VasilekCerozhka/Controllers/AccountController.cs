namespace VasilekCerozhka.Controllers
{
    public class AccountController : BaseApiController<AccountController>
    {
        private readonly IAccountServicesAuth _accountServices;

        public AccountController(IAccountServicesAuth accountServices, IMemoryCache cache, ILogger<AccountController> logger) : base(cache, logger)
        {
            _accountServices = accountServices;
        }


        [HttpGet]
        public IActionResult Register() => View();


        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountServices.RegisterAsync(model);
                if (response.resultAuth != null)
                {
                   
                }
            }
            return View(model);
        }


    }
}
