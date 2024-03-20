using Library_Mngmt_System.Data;
using Library_Mngmt_System.EmailServicee;
using Library_Mngmt_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library_Mngmt_System.EmailServicee;
using Library_Mngmt_System.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;

namespace Library_Mngmt_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly JwtService _js;
        //private readonly EmailService _es;
        
        
        public LibraryController(ApplicationDbContext db, JwtService js)
        {
            _db = db;
            _js = js;

            //_es = es;
        }
        

        [HttpPost("Register")]
        public ActionResult Register(User user)
        {
            user.Status = AccountStatus.UNAPPROVED;
            user.UserType = UserType.STUDENT;
            user.CreatedOn = DateTime.Now;

            _db.Users.Add(user);
            _db.SaveChanges();

            //const string subject = "Account Created";
            //var body = $"""
            //    <html>
            //        <body>
            //            <h1>Hello, {user.FirstName} {user.LastName}</h1>
            //            <h2>
            //                Your account has been created and we have sent approval request to admin. 
            //                Once the request is approved by admin you will receive email, and you will be
            //                able to login in to your account.
            //            </h2>
            //            <h3>Thanks</h3>
            //        </body>
            //    </html>
            //""";

            //_es.SendEmail(user.Email, subject, body);

            return Ok("Thank you for registering." +
                "Your account has been sent for approval." +
                "Once it is approved, you will get an email.");
        }

        [HttpGet("Login")]
        public ActionResult Login(string email, string password)
        {
            if (_db.Users.Any(u => u.Email.Equals(email) && u.Password.Equals(password)))
            {
                var user = _db.Users.Single(user => user.Email.Equals(email) && user.Password.Equals(password));

                if (user.Status == AccountStatus.UNAPPROVED)
                {
                    return Ok("unapproved");
                }

                if (user.Status == AccountStatus.BLOCKED)
                {
                    return Ok("blocked");
                }

                return Ok(_js.GenerateToken(user));
            }
            return Ok("not found");
        }

        [Authorize]
        [HttpGet("GetBooks")]
        public ActionResult GetBooks()
        {
            if (_db.books.Any())
            {
                return Ok(_db.books.Include(b => b.BookCategory).ToList());
            }
            return NotFound();
        }

        [Authorize]
        [HttpPost("OrderBook")]
        public ActionResult OrderBook(int userId, int bookId)
        {
            var canOrder = _db.orders.Count(o => o.UserId == userId && !o.Returned) < 3;

            if (canOrder)
            {
                _db.orders.Add(new()
                {
                    UserId = userId,
                    BookId = bookId,
                    OrderDate = DateTime.Now,
                    ReturnDate = null,
                    Returned = false,
                    FinePaid = 0
                });

                var book = _db.books.Find(bookId);
                if (book is not null)
                {
                    book.Ordered = true;
                }


                _db.SaveChanges();
                return Ok("ordered");
            }

            return Ok("cannot order");
        }


    }
}
