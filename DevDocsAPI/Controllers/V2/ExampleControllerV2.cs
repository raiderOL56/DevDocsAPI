using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DevDocsAPI.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class ExampleController : ControllerBase
    {
        [MapToApiVersion("2.0")]
        [HttpGet]
        public IActionResult GetSaludo()
        {
            return Ok("Hola, soy V2");
        }
    }
}