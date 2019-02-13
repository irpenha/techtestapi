using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTestApi.Models;

namespace TechTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        // GET api/app
        // GET api/app/root
        [HttpGet]
        [Route("")]
        [Route("root")]
        public IActionResult GetAppRoot()
        {
            return Ok("Hello World");
        }
                
        // GET api/app/health
        [HttpGet]
        [Route("health")]
        [Route("health/{status}")]
        public IActionResult GetAppHealth(string status)
        {
            ObjectResult result = null;
            
            switch (status?.ToLower())
            {
                case "ok":
                    result = Ok(string.Format("Status Code: {0}", StatusCodes.Status200OK));
                    break;
                case "bad":
                    result = BadRequest(string.Format("Status Code: {0}", StatusCodes.Status400BadRequest));
                    break;
                case "error":
                    result = StatusCode(StatusCodes.Status500InternalServerError, string.Format("Status Code: {0}", StatusCodes.Status500InternalServerError));
                    break;
                case "pirate":
                    result = StatusCode(StatusCodes.Status401Unauthorized, string.Format("Status Code: {0}", StatusCodes.Status401Unauthorized));
                    break;
                default:
                    result = NotFound(string.Format("Status Code: {0}", StatusCodes.Status404NotFound));
                    break;
            }
            
            return result;
        }

        // GET api/app/info
        [HttpGet]
        [Route("info")]
        public JsonResult GetAppInfo()
        {
            JsonResult appInfo = new JsonResult(
                new ApplicationInfo() {
                    Name = "MyApplication",
                    Version = 1.0,
                    Description = "Pre-interview technical test"
                }
            );
            
            return appInfo;
        }
    }
}
