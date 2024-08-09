using Airline_reservation.Models;
using Airline_reservation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Airline_reservation.Controllers
{

    public class FlightController : Controller
    {

        private readonly ApplicationDBContext _context;

        public FlightController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddFlight()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFlight(FlightReservation FR)
        {
            if (ModelState.IsValid)
            {
                _context.FlightReservation.Add(FR);
                _context.SaveChanges();
                return RedirectToAction("DetailFlight", "Flight"); // Redirect to the list of flights or a confirmation page
            }

            // If there is an issue with the model state, return the form view with validation messages
            var locations = new List<string> { "New York", "Los Angeles", "Chicago", "Houston", "Miami" };
            var planes = _context.Planeinfo.Select(p => new { p.PlaneId, p.APlaneName }).ToList();

            ViewBag.Locations = new SelectList(locations);
            ViewBag.Planes = new SelectList(planes, "PlaneId", "APlaneName");

            return RedirectToAction("AddFlight", "Flight");
        }

        public IActionResult DetailFlight()
        {
            var aeroplane = _context.FlightReservation.ToList();
            return View(aeroplane);
        }

        public IActionResult Delete(int id)
        {
            var FlightDelete = _context.FlightReservation.Find(id);
            _context.Remove(FlightDelete);
            _context.SaveChanges(true);
            return RedirectToAction("DetailFlight", "Flight");
        }
    }
}
