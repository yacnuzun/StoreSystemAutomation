using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result=_productService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _productService.Get(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getproductdetail")]
        public IActionResult GetProductDetail(int id)
        {
            var result = _productService.GetProductDetails(id);
            if (!result.Success)
            {
                return new JsonResult(false);
            }
            var jsonResult = JsonConvert.SerializeObject(result);
            return new JsonResult(jsonResult);
        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result=_productService.Add(product);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result.Message+product.Id);
        }

        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
