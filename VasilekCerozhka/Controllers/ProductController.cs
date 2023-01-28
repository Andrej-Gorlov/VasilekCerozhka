using Microsoft.AspNetCore.Mvc;

namespace VasilekCerozhka.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult ProductIndex()
        {
            return View();
        }
    }
}
