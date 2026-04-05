using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group5Flight.Models;

namespace Group5Flight.Controllers
{
    public class HomeController : Controller
    {
        private readonly FlightContext _db;

        public HomeController(FlightContext context)
        {
            _db = context;
        }

        // GET: Home
        public IActionResult Index()
        {
            var sessionHelper = new FlightSession(HttpContext.Session);
            var cookieHelper  = new FlightCookies(Request.Cookies);

            string[] selectedIds = cookieHelper.GetSelectedIds();

            // default date
            if (string.IsNullOrEmpty(sessionHelper.GetActiveDate()))
            {
                sessionHelper.SetActiveDate(DateTime.Today.AddDays(1).ToString("MM/dd/yyyy"));
            }

            FlightViewModel vm = new FlightViewModel
            {
                ActiveFrom    = sessionHelper.GetActiveFrom(),
                ActiveTo      = sessionHelper.GetActiveTo(),
                ActiveDate    = sessionHelper.GetActiveDate(),
                ActiveCabin   = sessionHelper.GetActiveCabin(),
                ActiveAirline = sessionHelper.GetActiveAirline(),
                Airlines      = _db.Airlines.ToList(),
                SelectionCount = selectedIds.Length
            };

            // load cities (distinct)
            var flightsData = _db.Flights.ToList();
            foreach (var item in flightsData)
            {
                if (!vm.FromCities.Any(c => c == item.From))
                    vm.FromCities.Add(item.From);

                if (!vm.ToCities.Any(c => c == item.To))
                    vm.ToCities.Add(item.To);
            }

            // filtering logic
            var flightQuery = _db.Flights.Include(f => f.Airline).AsQueryable();

            if (!string.IsNullOrEmpty(vm.ActiveFrom))
                flightQuery = flightQuery.Where(x => x.From == vm.ActiveFrom);

            if (!string.IsNullOrEmpty(vm.ActiveTo))
                flightQuery = flightQuery.Where(x => x.To == vm.ActiveTo);

            if (!string.IsNullOrEmpty(vm.ActiveDate))
            {
                DateTime selectedDate = DateTime.Parse(vm.ActiveDate);
                flightQuery = flightQuery.Where(x => x.Date.Date == selectedDate.Date);
            }

            if (!string.IsNullOrEmpty(vm.ActiveCabin) && vm.ActiveCabin != "All")
                flightQuery = flightQuery.Where(x => x.CabinType == vm.ActiveCabin);

            if (!string.IsNullOrEmpty(vm.ActiveAirline))
                flightQuery = flightQuery.Where(x => x.Airline != null && x.Airline.Name == vm.ActiveAirline);

            vm.Flights = flightQuery.ToList();

            return View(vm);
        }

        // POST: Save filters (PRG)
        [HttpPost]
        public IActionResult Index(FlightViewModel vm)
        {
            var sessionHelper = new FlightSession(HttpContext.Session);

            sessionHelper.SetActiveFrom(vm.ActiveFrom ?? "");
            sessionHelper.SetActiveTo(vm.ActiveTo ?? "");
            sessionHelper.SetActiveDate(vm.ActiveDate ?? "");
            sessionHelper.SetActiveCabin(vm.ActiveCabin ?? "");
            sessionHelper.SetActiveAirline(vm.ActiveAirline ?? "");

            return RedirectToAction("Index");
        }

        // GET: Details
        public IActionResult Detail(int id)
        {
            var flight = _db.Flights.Include(f => f.Airline)
                                    .FirstOrDefault(f => f.FlightId == id);

            if (flight == null) return NotFound();

            var cookieHelper = new FlightCookies(Request.Cookies);
            var selectedIds  = cookieHelper.GetSelectedIds();

            bool exists = selectedIds.Contains(id.ToString());

            ViewBag.IsSelected = exists;
            ViewBag.SelectionCount = selectedIds.Length;

            return View(flight);
        }

        // POST: Select flight (PRG)
        [HttpPost]
        public IActionResult Select(int id)
        {
            var readCookies  = new FlightCookies(Request.Cookies);
            var writeCookies = new FlightCookies(Response.Cookies);

            var currentIds = readCookies.GetSelectedIds().ToList();

            if (!currentIds.Contains(id.ToString()))
            {
                currentIds.Add(id.ToString());
                writeCookies.SetSelectedIds(currentIds);

                var flight = _db.Flights.Find(id);
                if (flight != null)
                {
                    TempData["message"] = "Flight " + flight.FlightCode + " selected.";
                }
                else
                {
                    TempData["message"] = "Flight not found.";
                }
            }

            return RedirectToAction("Index");
        }

        // GET: Selected flights
        public IActionResult Selections()
        {
            var cookieHelper = new FlightCookies(Request.Cookies);
            var selectedIds  = cookieHelper.GetSelectedIds();

            var result = _db.Flights
                            .Include(f => f.Airline)
                            .ToList()
                            .Where(f => selectedIds.Contains(f.FlightId.ToString()))
                            .ToList();

            ViewBag.SelectionCount = selectedIds.Length;

            return View("Selection", result);
        }

        // POST: Remove one
        [HttpPost]
        public IActionResult CancelSelection(int id)
        {
            var readCookies  = new FlightCookies(Request.Cookies);
            var writeCookies = new FlightCookies(Response.Cookies);

            var updatedIds = readCookies.GetSelectedIds()
                                       .Where(x => x != id.ToString())
                                       .ToList();

            writeCookies.SetSelectedIds(updatedIds);

            var flight = _db.Flights.Find(id);
            if (flight != null)
            {
                TempData["message"] = "Flight " + flight.FlightCode + " removed.";
            }
            else
            {
                TempData["message"] = "Flight not found.";
            }

            return RedirectToAction("Selections");
        }

        // POST: Clear all
        [HttpPost]
        public IActionResult ClearSelections()
        {
            var cookieHelper = new FlightCookies(Response.Cookies);
            cookieHelper.RemoveSelectedIds();

            TempData["message"] = "Selections cleared.";

            return RedirectToAction("Selections");
        }

        public IActionResult Privacy() => View();

        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}