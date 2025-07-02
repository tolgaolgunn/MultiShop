using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailServices _productDetailService;
        public ProductDetailsController(IProductDetailServices productDetailService)
        {
            _productDetailService = productDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var productDetails = await _productDetailService.GetAllProductDetailAsync();
            return Ok(productDetails);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var productDetail = await _productDetailService.GetByIdProductDetailAsync(id);
            if (productDetail == null)
            {
                return NotFound();
            }
            return Ok(productDetail);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail([FromBody] CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Product Detail Succesfully Added");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail([FromBody] UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Product Detail Succesfully Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("Product Detail Succesfully Deleted");
        }
    }
}
