using Airline_reservation.Models;
using Airline_reservation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airline_reservation.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public UserController(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();     
        }

        [HttpPost]
        public IActionResult Register(UserLogin user)
        {
            if (user != null)
            {
                var existingUser = _dbContext.UserAccouunts.FirstOrDefault(a => a.FirstName == user.FirstName);
                if (existingUser == null)
                {
                    var newUser = new UserLogin
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        EmaiL = user.EmaiL,
                        Password = user.Password,
                        CPassword = user.CPassword,
                        Age = user.Age,
                        PhoneNo = user.PhoneNo,
                        NIC = user.NIC,
                        usertype = user.usertype
                    };

                    _dbContext.UserAccouunts.Add(newUser);
                    _dbContext.SaveChanges();

                    if (user.usertype == 1)
                    {
                        HttpContext.Session.SetString("Admin", newUser.FirstName);
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        HttpContext.Session.SetString("User", newUser.FirstName);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User with this First Name already exists.");
                }
            }
            return View();
        }
    }
}
