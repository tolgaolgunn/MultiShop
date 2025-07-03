using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet("GetAllCoupons")]
        public async Task<IActionResult> GetAllCoupons()
        {
            var result = await _discountService.GetAllCouponsAsync();
            return Ok(result);
        }
        [HttpGet("GetByIdCoupon/{couponID}")]
        public async Task<IActionResult> GetByIdCoupon(int couponID)
        {
            var result = await _discountService.GetByIdCouponAsync(couponID);
            return Ok(result);
        }
        [HttpPost("CreateCoupon")]
        public async Task<IActionResult> CreateCoupon([FromBody] CreateDiscountCouponDto createCouponDto)
        {
            await _discountService.CreateCouponAsync(createCouponDto);
            return Ok("Coupon Added Successfully");
        }
        [HttpPut("UpdateCoupon")]
        public async Task<IActionResult> UpdateCoupon([FromBody] UpdateDiscountCouponDto updateCouponDto)
        {
            await _discountService.UpdateCouponAsync(updateCouponDto);
            return Ok("Coupon Updated Successfully");
        }
        [HttpDelete("DeleteCoupon/{couponID}")]
        public async Task<IActionResult> DeleteCoupon(int couponID)
        {
            await _discountService.DeleteCouponAsync(couponID);
            return Ok("Coupon Deleted Succesfully");
        }

    
    }
}
