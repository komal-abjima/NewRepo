using Ecommerce_Website.Data;
using Ecommerce_Website.Models.Employee_Mngmt_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public LoginController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
        {
            var users = _db.users.AsQueryable();
            return Ok(users);
        }

        [HttpPost("signup")]
        public async Task<ActionResult<UserModel>> AddUser([FromBody] UserModel userModel)
        {
            if (userModel == null)
            {
                return BadRequest();
            }
            else
            {
                _db.users.Add(userModel);
                await _db.SaveChangesAsync();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Signup successfully!"
                });
            }

        }



        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserModel userModel)
        {
            if (userModel == null)
            {
                return BadRequest();
            }
            else
            {
                var user = _db.users.Where(a => a.UserName == userModel.UserName
                && a.Password == userModel.Password).FirstOrDefault();
                if (user != null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Logged in successfully!",

                    });
                }
                else
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "User not found."
                    });
                }
            }
        }
        
    }
}
