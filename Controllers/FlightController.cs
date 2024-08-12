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

        public ActionResult AddFlight()
        {
            
            ViewBag.Planes = _context.Planeinfo.ToList();
            return View();
        }

    
        [HttpPost]
       
        public ActionResult AddFlight(FlightReservation model)
        {
            var FR = new FlightReservation() 
            {
                Planeid = model.Planeid,
                ResFrom = model.ResFrom,
                ResTo = model.ResTo,
                ResDepDate = model.ResDepDate,
                ResTime = model.ResTime,
                ResReturnDate = model.ResReturnDate,
                ResReturnTime = model.ResReturnTime,
                ResPlane = model.ResPlane,
                ResTicketPrice = model.ResTicketPrice,
                SeatType = model.SeatType,
                TripType = model.TripType,  
            };
    
              _context.FlightReservation.Add(FR);
              _context.SaveChanges();

            ViewBag.Planes = _context.Planeinfo.ToList();
            return RedirectToAction("DetailFlight", "Flight");
        }


        public IActionResult DetailFlight()
        {
            var aeroplane = _context.FlightReservation.Include(f => f.AeroplaneInfo).ToList();
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
