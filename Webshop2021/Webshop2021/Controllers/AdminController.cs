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
        private static ApiCalls apiCalls;
        public AdminController()
        {
            if(apiCalls == null)
            {
                apiCalls = new ApiCalls(); 
            }
        }
        [HttpPost("products")]
        public async Task<IActionResult> CreateProduct([FromBody]ProductViewmodel product)
        {
            return Ok(await apiCalls.CreateProduct(product));
        }
        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await apiCalls.GetProducts());
        }
        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            return Ok(await apiCalls.GetProduct(id));
        }
        [HttpPut("products")]
        public async Task<IActionResult> UpdateProduct([FromBody]AdminProductViewmodel product)
        {
            return Ok(await apiCalls.UpdateProduct(product));
        }
        [HttpDelete("products/{id}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            return Ok(await apiCalls.RemoveProduct(id));
        }
    }
}
