using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace VasilekCerozhka.Controllers
{
    public class AccountController : BaseApiController<AccountController>
    {
        private readonly IAccountsService _accountsService;
        private readonly ITokenProvider _tokenProvider;

        public AccountController(ITokenProvider tokenProvider,IAccountsService accountServices,
            IMemoryCache cache, ILogger<AccountController> logger) : base(cache, logger)
        {
            _accountsService = accountServices;
            _tokenProvider = tokenProvider;
        }

        [HttpGet]
        public IActionResult Register() => View();


        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto register)
        {
            // test data
            var res = await _accountsService.Register(register);
            string token = res.resultAuth.Token;

            await SignInUser(token);
            _tokenProvider.SetToken(token);
            return RedirectToAction("Index", "Home");
        }


        private async Task SignInUser(string model)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(model); 

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Email,
                jwt.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Email).Value));

            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier,
                jwt.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value));

            identity.AddClaim(new Claim(ClaimTypes.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name).Value));

            identity.AddClaim(new Claim(ClaimTypes.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Email).Value));

            identity.AddClaim(new Claim(ClaimTypes.Role,
                jwt.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Role).Value));

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}
