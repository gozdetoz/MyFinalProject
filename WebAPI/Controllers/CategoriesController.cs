using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            //Dependency chain
             var result = _categoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
                //return Ok(result.Data); sadece datayı yada sadece mesajıda gonderebılırız
            }
            return BadRequest(result);
        }

    }
}
