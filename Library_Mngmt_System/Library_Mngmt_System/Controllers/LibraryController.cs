using Library_Mngmt_System.Data;
using Library_Mngmt_System.EmailServicee;
using Library_Mngmt_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library_Mngmt_System.EmailServicee;

namespace Library_Mngmt_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly EmailServicee.EmailServicee _es;
        
        
        public LibraryController(ApplicationDbContext db, EmailServicee.EmailServicee es)
        {
            _db = db;
            _es = es;
        }
        

        [HttpPost("Register")]
        public ActionResult Register(User user)
        {
            user.Status = AccountStatus.UNAPPROVED;
            user.UserType = UserType.STUDENT;
            user.CreatedOn = DateTime.Now;

            _db.Users.Add(user);
            _db.SaveChanges();

            const string subject = "Account Created";
            var body = $"""
                <html>
                    <body>
                        <h1>Hello, {user.FirstName} {user.LastName}</h1>
                        <h2>
                            Your account has been created and we have sent approval request to admin. 
                            Once the request is approved by admin you will receive email, and you will be
                            able to login in to your account.
                        </h2>
                        <h3>Thanks</h3>
                    </body>
                </html>
            """;

            _es.SendEmail(user.Email, subject, body);

            return Ok("Thank you for registering." +
                "Your account has been sent for approval." +
                "Once it is approved, you will get an email.");
        }

    }
}
