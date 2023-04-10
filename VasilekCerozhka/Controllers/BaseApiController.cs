namespace VasilekCerozhka.Controllers
{
    public class BaseApiController<T> : Controller
    {
        protected readonly IMemoryCache _cache;
        protected readonly ILogger<T> _logger;
        public BaseApiController(IMemoryCache cache, ILogger<T> logger)
        {
            _cache = cache;
            _logger = logger;
        }
    }
}
