using Microsoft.AspNetCore.Authorization;

namespace VasilekCerozhka.Controllers
{
    [Authorize(Roles = $"{UserRoles.ADMIN}")]
    public class CouponController : BaseApiController<CouponController>
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService, IMemoryCache cache, ILogger<CouponController> logger) :base(cache, logger)
        {
            _couponService= couponService;
        }

        /// <summary>
        /// request to CouponAPI (controller: Coupon / metod: Get)
        /// </summary>
        /// <returns>Open page CouponIndex</returns>
        [HttpGet]
        public async Task<IActionResult> CouponIndex()
        {
            var couponVM = new CouponVM(); 
            var respons = await _couponService.GetAllCouponAsync();
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
        [HttpGet]
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CouponCreate(CreateCouponDtoBase model)
        {
            if (ModelState.IsValid)
            {
                var respons = await _couponService.CreateCouponAsync(model);
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
        [HttpGet]
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
                var respons = await _couponService.GetCouponByIdAsync(couponId);
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CouponEdit(UpdateCouponDtoBase model)
        {
            if (ModelState.IsValid)
            {
                var respons = await _couponService.UpdateCouponAsync(model.CouponId,model);
                if (respons.IsSuccess)
                {
                    return RedirectToAction(nameof(CouponIndex));
                }
            }
            return View(model);
        }
        /// <summary>
        /// request to CouponAPI (controller: Coupon / metod: Delete)
        /// </summary>
        /// <param name="couponId"></param>
        /// <returns>Open page CouponIndex</returns>
        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CouponDelete(int couponId)
        {
            if (ModelState.IsValid)
            {
                var respons = await _couponService.DeleteCouponAsync(couponId);
                if (respons.IsSuccess)
                {
                   return RedirectToAction(nameof(CouponIndex));
                }
            }
            return View();
        }
    }
}
