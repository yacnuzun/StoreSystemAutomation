using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet("getall")]
        public JsonResult GetAll()
        {
            var result = _productImageService.GetAll();
            if (!result.Success)
            {
                return new JsonResult(result);
            }
            var jsonImage=JsonConvert.SerializeObject(result);
            return new JsonResult(jsonImage);
        }
        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _productImageService.Get(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [HttpGet("getbyproductid")]
        public IActionResult GetByProductId(int id)
        {
            var result = _productImageService.GetByProductId(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [HttpPost("add")]
        public IActionResult Add(IFormFile file, [FromForm] ProductImage carImage)
        {
            var result = _productImageService.Add(file, carImage);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [HttpPost("update")]
        public IActionResult Update(IFormFile file, [FromForm] ProductImage carImage)
        {
            var result = _productImageService.Update(file, carImage);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(ProductImage carImage)
        {
            var result = _productImageService.Delete(carImage);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
