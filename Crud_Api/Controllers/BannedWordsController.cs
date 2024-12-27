using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannedWordsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update()
        {
            return Ok();
        }
    }
}
