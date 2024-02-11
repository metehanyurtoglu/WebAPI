using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1._1
{
    [ApiController]
    [ApiVersion("1.1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CountriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("v1.1 Countries listed.");
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok("v1.1 Country");
        }

        [HttpPost]
        public IActionResult Create()
        {
            return Ok("v1.1 Country created.");
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok("v1.1 Country updated.");
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("v1.1 Country deleted.");
        }
    }
}
