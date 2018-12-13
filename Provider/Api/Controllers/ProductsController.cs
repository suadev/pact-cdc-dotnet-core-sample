using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Provider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(Faker.GetProducts());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(Faker.GetProducts().FirstOrDefault(q => q.Id == id));
        }
    }
}
