using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace routing2.Controllers
{
   
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Route ("api/get-all")]
        public string GetAll()
        {
            return "hello from get all";
        }

        [Route ("api/get-all-authors")]
        public string GetAllAuthors() {
            return "hello from get all Authors";
        }
    }
}
