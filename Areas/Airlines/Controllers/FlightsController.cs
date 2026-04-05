using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group5Flight.Models;

namespace Group5Flight.Areas.Airlines.Controllers
{
    [Area("Airlines")]
    public class FlightsController : Controller
    {
        private readonly FlightContext _db;

        public FlightsController(FlightContext db)
        {
            _db = db;
        }

        // GET: Airlines/Flights/Index – list all flights + blank add form
        public IActionResult Index()
        {
            var vm = new FlightViewModel
            {
                Flights  = _db.Flights.Include(f => f.Airline).ToList(),
                Airlines = _db.Airlines.ToList()
            };
            return View(vm);
        }

        // POST: Airlines/Flights/Add – save new flight, PRG redirect
        [HttpPost]
        public IActionResult Add(Flight flight)
        {
            if (ModelState.IsValid)
            {
                _db.Flights.Add(flight);
                _db.SaveChanges();
                TempData["message"] = $"Flight {flight.FlightCode} has been added.";
                return RedirectToAction("Index");
            }

            // Re-show form with validation errors
            var vm = new FlightViewModel
            {
                Flights  = _db.Flights.Include(f => f.Airline).ToList(),
                Airlines = _db.Airlines.ToList()
            };
            return View("Index", vm);
        }

        // GET: Airlines/Flights/Edit/5 – show edit form
        public IActionResult Edit(int id)
        {
            var flight = _db.Flights.Find(id);
            if (flight == null) return NotFound();

            var vm = new FlightViewModel
            {
                Flights       = _db.Flights.Include(f => f.Airline).ToList(),
                Airlines      = _db.Airlines.ToList(),
                EditingFlight = flight
            };
            return View("Index", vm);
        }

        // POST: Airlines/Flights/Edit – update flight, PRG redirect
        [HttpPost]
        public IActionResult Edit(Flight flight)
        {
            if (ModelState.IsValid)
            {
                _db.Flights.Update(flight);
                _db.SaveChanges();
                TempData["message"] = $"Flight {flight.FlightCode} has been updated.";
                return RedirectToAction("Index");
            }

            var vm = new FlightViewModel
            {
                Flights       = _db.Flights.Include(f => f.Airline).ToList(),
                Airlines      = _db.Airlines.ToList(),
                EditingFlight = flight
            };
            return View("Index", vm);
        }

        // POST: Airlines/Flights/Delete/5 – delete flight, PRG redirect
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var flight = _db.Flights.Find(id);
            if (flight != null)
            {
                _db.Flights.Remove(flight);
                _db.SaveChanges();
                TempData["message"] = $"Flight {flight.FlightCode} has been deleted.";
            }
            return RedirectToAction("Index");
        }

        // Content-only actions from Phase 1 – kept unchanged per rules
        public IActionResult Manage()
        {
            return Content("Airline Manage Flights Content");
        }

        public IActionResult Regulation()
        {
            return Content("Airline Regulation Content");
        }
    }
}
