using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Consumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerProductController : ControllerBase
    {
        private readonly IProductHttpService _productHttpService;

        public ConsumerProductController(IProductHttpService productHttpService)
        {
            _productHttpService = productHttpService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productHttpService.GetProducts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _productHttpService.GetProduct(id));
        }
    }
}
