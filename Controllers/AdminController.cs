using Airline_reservation.Models;
using Airline_reservation.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

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
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
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
                var x = _context.UserAccouunts.FirstOrDefault(a => a.UserName == user.UserName && a.Password == user.Password);
                if (x != null)
                {
                    if(x.usertype == 1)
                    {
                        HttpContext.Session.SetString("Admin", x.UserName);
                        return RedirectToAction("Index") ;
                    }
                    else
                    {
                        HttpContext.Session.SetString("User", x.UserName);
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
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddAeroPlane()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddAeroPlane(AeroplaneInfo aeroplaneInfo)
        {
            var addAeroplane = new AeroplaneInfo()
            {
                APlaneName = aeroplaneInfo.APlaneName,
                SeatingCapacity = aeroplaneInfo.SeatingCapacity,
                Price = aeroplaneInfo.Price
            };

            _context.Planeinfo.Add(addAeroplane);
            _context.SaveChanges();
             return RedirectToAction("AddAeroPlane", "Admin");
        }

        public IActionResult DetailAeroPlane()
        {
            if(HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
           var aeroplane = _context.Planeinfo.ToList();
            return View(aeroplane);
        }

        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var FlightDelete = _context.Planeinfo.Find(id);
            _context.Remove(FlightDelete);
            _context.SaveChanges(true);
            return RedirectToAction("DetailFlight", "Admin");
        }

        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var aero = _context.Planeinfo.Find(id);
            var aeroplane  = new AeroplaneInfo()
            {
                APlaneName = aero.APlaneName,
                SeatingCapacity = aero.SeatingCapacity,
                Price = aero.Price
            };

            ViewData["Name"] = aero.APlaneName;
            ViewData["Seat"] = aero.SeatingCapacity;
            ViewData["Price"] = aero.Price;

            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, AeroplaneInfo aeroinfo)
        {
           

            var aeroplane = _context.Planeinfo.Find(id);

            aeroplane.APlaneName = aeroinfo.APlaneName;
            aeroplane.SeatingCapacity = aeroinfo.SeatingCapacity;
            aeroplane.Price = aeroinfo.Price;

            _context.SaveChanges();

            return RedirectToAction("DetailFlight", "Admin");
        }
    }
}
