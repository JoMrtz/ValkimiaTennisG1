using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ValkimiaTennisG1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
