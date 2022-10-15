using Microsoft.AspNetCore.Mvc;

namespace OnlineBingoAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "Hi Everyone!";
        }
    }
}
