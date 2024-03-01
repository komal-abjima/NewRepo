using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;

namespace ControllersExample.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        //[Route("/")]
        //public string Home()
        //{
        //    return "Hello from home";
        //}

        //ContentType
        [Route("/")]
        [Route("home")]
        public ContentResult Index()
        {
            //return new ContentResult() { Content = "Hello from Index", ContentType = "text/plain" };
            //return Content("Hello from Index", "text/plain");
            return Content("<h1>Hello</h1> <p>Welcome</p>", "text/html");
        }

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person() {Id = Guid.NewGuid(), FirstName = "John", 
            LastName = "Smith", Age = 25};
            //return new JsonResult(person);
            return Json(person);
            //return "{\"Key\" : \"Value\"};"

        }

        //file in wwwroot 
        [Route("file-Download")]
        public VirtualFileResult FileDownload()
        {
            //return new VirtualFileResult("/epfo.pdf", "application/pdf");
            return File("/epfo.pdf", "application/pdf");
        }

        //if file is outerside
        [Route("file-Download-outer")]
        public PhysicalFileResult FileDownloadOuter()
        {
            //return new PhysicalFileResult(@"C:\Users\KomalSharma\Downloads\epfo.pdf", "application/pdf");
            return PhysicalFile(@"C:\Users\KomalSharma\Downloads\epfo.pdf", "application/pdf");
        }

        //third method
        [Route("file3")]
        public FileContentResult File3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\KomalSharma\Downloads\epfo.pdf");
            //return new FileContentResult(bytes, "application/pdf");
            return File(bytes, "application/json");
        }


        [Route("about")]
        public string About()
        {
            return "Hello from About";
        }

        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
        public string Contact()
        {
            return "Hello from Contact";
        }
    }
}
