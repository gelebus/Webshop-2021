using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Webshop2021.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        [HttpPost("products")]
        public IActionResult CreateProduct()
        {
            //api
            return View();
        }
    }
}
