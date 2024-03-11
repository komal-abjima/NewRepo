Defination:-
ASP.NET Core Web API is a component (part) of ASP.NET Core, which is used create HTTP-based 
RESTful Services (also known as HTTP services) that can be consumed (invoked) by wide range 
of client applications such as single page applications, mobile application etc.
ASP.net core mvc, Web api, blazor, razor pages.

Restful services(Representaional State Transfer) is an architecture style that defines to 
create HTTP services that receives HTTP GET, POST, PUT, DELETE requests, Perform CRUD 
operations on the appropriate data source, and returns JSON/XML data as response to the 
client.

Browser/Client                         SERVER
XMLHTTPREQUEST or Fetch()             HTTP RESPONSE(JSON/XML) {"Key": "value"}

//web api controllers
Should be either or both: - the class name should be suffixed with "Controller" eg:ProductController
The [ApiController] attribute is applied to the same class or to its base class.
optional - is a public class. inherited from Microsoft.AspNetCore.Mvc.controllerBase.

//EntityFrameworkCore is light weight, extensible and cross platform framework for accessing 
database in .net applications.
.net core app -> entityFrameworkCore -> Database

//Virtual keyword : The virtual keyword in C# allows subclasses to override methods of the base class. 


//IActionResult v/s ActionResult
if you have a condition based solution like if it is true or false then use IActionResult and
return Ok() then and for returning model you can use ActionResult and then result return normal
the three classess are included in IActionResult which are NoContent(), NotFound(), and
BadRequest() result and if you want to return object result then use ActionResult 

interface							class
IActionResult					    OkObjectResult
	^
	|								class
class								CreatedAtActionResult
ActionResult
	^								class
	|								NotFoundObjectResult
class
ObjectResult  <---------		    class
									BadRequestObjectResult

If you want to shows schema on swagger then you have to use producesResult 
[ProducesResponseType(typeof(WeatherForecast[]), StatusCodes.Status200Ok)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
ActionResult is a generic typr if you want to use this then use ActionResult<WeatherForecast> 
type then no need to declare typeof in producesresponsetype , and it is more type safe, 
created() is only used with post request and it used the response type is 201





