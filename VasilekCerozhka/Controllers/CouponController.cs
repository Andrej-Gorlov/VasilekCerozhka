namespace VasilekCerozhka.Controllers
{
    //[Authorize(Roles = "Admin")]
    //[ValidateAntiForgeryToken]
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        private readonly IMemoryCache _cache;
        public CouponController(ICouponService couponService, IMemoryCache cache)
        {
            _cache= cache;  
            _couponService= couponService;
        }

        /// <summary>
        /// request to CouponAPI (controller: Coupon / metod: Get)
        /// </summary>
        /// <returns>Open page CouponIndex</returns>
        public async Task<IActionResult> CouponIndex()
        {
            var couponVM = new CouponVM();
            //var accessToken = await HttpContext.GetTokenAsync("access_token");
            var respons = await _couponService.GetAllCouponAsync<ResponseDtoBase>(null);
            if (respons != null & respons.IsSuccess)
            {
                couponVM.Coupons = JsonConvert.DeserializeObject<List<CouponDtoBase>>(Convert.ToString(respons.Result));
            }
            return View(couponVM);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Open views page CouponCreate</returns>
        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }
        /// <summary>
        /// request to CouponAPI (controller: Coupon / metod: Create)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Open page CouponIndex</returns>
        [HttpPost]
        public async Task<IActionResult> CouponCreate(CreateCouponDtoBase model)
        {
            if (ModelState.IsValid)
            {
                //var accessToken = await HttpContext.GetTokenAsync("access_token");
                var respons = await _couponService.CreateCouponAsync<ResponseDtoBase>(model, null);
                if (respons.IsSuccess)
                {
                    return RedirectToAction(nameof(CouponIndex));
                }
            }
            return View(model);
        }
        /// <summary>
        /// request to CouponAPI (controller: Coupon / metod: GetById)
        /// </summary>
        /// <param name="couponId"></param>
        /// <returns>Open page CouponEdit</returns>
        public async Task<ActionResult> CouponEdit(int couponId)
        {
            if (ModelState.IsValid)
            {
                var coupon = new UpdateCouponDtoBase();
                _cache.TryGetValue(couponId, out UpdateCouponDtoBase? cache);
                if (cache != null)
                {
                    return View(cache);
                }
                //var accessToken = await HttpContext.GetTokenAsync("access_token");
                var respons = await _couponService.GetCouponByIdAsync<ResponseDtoBase>(couponId, null);
                if (respons.Result != null & respons.IsSuccess)
                {
                    coupon = JsonConvert.DeserializeObject<UpdateCouponDtoBase>(Convert.ToString(respons.Result));
                    _cache.Set(couponId, coupon, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                    return View(coupon);
                }
            }
            return NotFound();
        }
        /// <summary>
        /// request to CouponAPI (controller: Coupon / metod: Update)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Open page CouponIndex</returns>
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> CouponEdit(UpdateCouponDtoBase model)
        {
            if (ModelState.IsValid)
            {
                //var accessToken = await HttpContext.GetTokenAsync("access_token");
                var respons = await _couponService.UpdateCouponAsync<ResponseDtoBase>(model.CouponId,model, null);
                if (respons.IsSuccess)
                {
                    return RedirectToAction(nameof(CouponIndex));
                }
            }
            return View(model);
        }
        /// <summary>
        /// request to CouponAPI (controller: Coupon / metod: GetById)
        /// </summary>
        /// <param name="couponId"></param>
        /// <returns>Open page CouponDelete</returns>
        public async Task<ActionResult> CouponDelete(int couponId)
        {
            if (ModelState.IsValid)
            {
                var model = new CouponDtoBase();
                _cache.TryGetValue(couponId, out CouponDtoBase? cache);
                if (cache != null)
                {
                    return View(cache);
                }
                //var accessToken = await HttpContext.GetTokenAsync("access_token");
                var respons = await _couponService.GetCouponByIdAsync<ResponseDtoBase>(couponId, null);
                if (respons.IsSuccess)
                {
                    model = JsonConvert.DeserializeObject<CouponDtoBase>(Convert.ToString(respons.Result));
                    _cache.Set(couponId, model, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                    return View(model);
                }
            }
            return NotFound();
        }
        /// <summary>
        /// request to CouponAPI (controller: Coupon / metod: Delete)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Open page CouponIndex</returns>
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> CouponDelete(CouponDtoBase model)
        {
            if (ModelState.IsValid)
            {
                //var accessToken = await HttpContext.GetTokenAsync("access_token");
                var respons = await _couponService.DeleteCouponAsync<ResponseDtoBase>(model.CouponId, null);
                if (respons.IsSuccess)
                {
                    return RedirectToAction(nameof(CouponIndex));
                }
            }
            return View(model);
        }
    }
}
