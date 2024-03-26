using Employee_Mngmt_Project.Data;
using Employee_Mngmt_Project.Models;
using EmployeeAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Mngmt_Project.Controllers
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
            var users = _db.Users.AsQueryable();
            return Ok(users);
        }

        //[HttpPost("signup")]
        //public async Task<ActionResult<UserModel>> AddUser([FromBody]UserModel userModel)
        //{
        //    if(userModel == null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        _db.Users.Add(userModel);
        //        await _db.SaveChangesAsync();
        //        return Ok(new
        //        {
        //            StatusCode = 200,
        //            Message = "Signup successfully!"
        //        });
        //    }

        //}

        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] UserModel userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {
                userObj.Password = EncDscPassword.EncryptPassword(userObj.Password);
                _db.Users.Add(userObj);
                _db.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Sign up Successfully"

                });
            }
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody]UserModel userModel)
        //{
        //    if(userModel == null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        var user = _db.Users.Where(a => a.UserName == userModel.UserName 
        //        && a.Password == userModel.Password).FirstOrDefault();
        //        if(user != null)
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 200,
        //                Message = "Logged in successfully!",

        //            });
        //        }
        //        else
        //        {
        //            return NotFound(new
        //            {
        //                StatusCode = 404,
        //                Message = "User not found."
        //            });
        //        }
        //    }
        //}
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {
                var user = _db.Users.Where(a => a.UserName == userObj.UserName).FirstOrDefault();


                if (user != null && EncDscPassword.DecryptPassword(user.Password) == userObj.Password)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Logged In Successfully",
                        UserType = user.UserType,
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "User Not Found"
                    });
                }
            }
        }
    
}
}
