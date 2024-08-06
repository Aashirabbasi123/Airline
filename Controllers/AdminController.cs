using Airline_reservation.Models;
using Airline_reservation.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Airline_reservation.Controllers
{



    public class AdminController : Controller
    {
    private readonly ApplicationDBContext _context;

        public AdminController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Admin") != null)
            {
                return RedirectToAction("Index", "Admin"); // Redirect to Admin dashboard
            }
            else if (HttpContext.Session.GetString("User") != null)
            {
                return RedirectToAction("Index", "Home"); // Redirect to User home page
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLogin user)
        {
            if (user != null)
            {
                var x = _context.UserAccouunts.FirstOrDefault(a => a.FirstName == user.FirstName && a.Password == user.Password);
                if (x != null)
                {
                    if(x.usertype == 1)
                    {
                        HttpContext.Session.SetString("Admin", x.FirstName);
                        return RedirectToAction("Index") ;
                    }
                    else
                    {
                        HttpContext.Session.SetString("User", x.FirstName);
                        return RedirectToAction("Index","Home");
                    }
                }
                else
                {
                    return View("Login");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
