using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Third_API_Project.Controllers
{
   
    public class TestController : CustomControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }
    }
}
