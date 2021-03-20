using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //Attiribute- Bir class ıle ılgıle bılgı verme imza verme işlemidir.
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
         //loosely coupled  -- gevşek bagımlılık
         //naming convention
         //IoC Container---Inversion of Control
         //Swagger --Api dokumantasyonu yapmamızı saglar
        IProductService _productService;
         public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public  IActionResult Get()
        {
            //Dependency chain
            Thread.Sleep(1000);
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
                //return Ok(result.Data); sadece datayı yada sadece mesajıda gonderebılırız
            }
            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Post(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
