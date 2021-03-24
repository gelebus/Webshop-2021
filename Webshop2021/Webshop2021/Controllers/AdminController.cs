using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop2021.Logic;
using Webshop2021.Logic.ViewModels;

namespace Webshop2021.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private ApiCalls apiCalls;
        public AdminController()
        {
            apiCalls = new ApiCalls(); 
        }
        [HttpPost("products")]
        public IActionResult CreateProduct([FromBody]ProductViewmodel product)
        {
            return Ok(apiCalls.CreateProduct(product));
        }
        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            return Ok(apiCalls.GetProducts());
        }
    }
}
