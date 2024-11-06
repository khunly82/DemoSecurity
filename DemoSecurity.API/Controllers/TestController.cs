using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoSecurity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet]
        [Authorize(Roles = "Seller")]
        public ActionResult Get()
        {
            var user = User;
            return Ok(42);
        }
    }
}
