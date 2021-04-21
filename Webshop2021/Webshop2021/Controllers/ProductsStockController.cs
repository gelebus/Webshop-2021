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
    public class ProductsStockController : Controller
    {
        private static ApiCalls apiCalls;
        public ProductsStockController()
        {
            if(apiCalls == null)
            {
                apiCalls = new ApiCalls(); 
            }
        }

        //products
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


        //stocks
        [HttpPost("stocks")]
        public async Task<IActionResult> CreateStock([FromBody] StockViewModel stockViewModel)
        {
            return Ok(await apiCalls.CreateStock(stockViewModel));
        }

        [HttpGet("stocks")]
        public async Task<IActionResult> GetStock()
        {
            return Ok(await apiCalls.GetStocks());
        }

        [HttpDelete("stocks/{id}")]
        public async Task<IActionResult> RemoveStock(int id)
        {
            return Ok(await apiCalls.RemoveStock(id));
        }

        [HttpPut("stocks")]
        public async Task<IActionResult> UpdateStock([FromBody] IEnumerable<StockViewModel> stockViewModels)
        {
            return Ok(await apiCalls.UpdateStocks(stockViewModels));
        }
    }
}
