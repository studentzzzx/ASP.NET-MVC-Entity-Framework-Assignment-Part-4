using System;
using System.Linq;
using System.Web.Mvc;
using Insurance.Models;

namespace Insurance.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                decimal quote = 50m;

                // Age calculation
                int age = DateTime.Now.Year - insuree.DateOfBirth.Year;
                if (insuree.DateOfBirth > DateTime.Now.AddYears(-age)) age--;

                if (age <= 18)
                    quote += 100;
                else if (age >= 19 && age <= 25)
                    quote += 50;
                else if (age >= 26)
                    quote += 25;

                // Car year logic
                if (insuree.CarYear < 2000)
                    quote += 25;
                if (insuree.CarYear > 2015)
                    quote += 25;

                // Car make/model logic
                if (insuree.CarMake.ToLower() == "porsche")
                {
                    quote += 25;
                    if (insuree.CarModel.ToLower() == "911 carrera")
                        quote += 25;
                }

                // Speeding tickets
                quote += insuree.SpeedingTickets * 10;

                // DUI adjustment
                if (insuree.DUI)
                    quote *= 1.25m;

                // Coverage adjustment
                if (insuree.CoverageType.ToLower() == "full")
                    quote *= 1.5m;

                insuree.Quote = quote;

                db.Insurees.Add(insuree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insuree);
        }

        // Admin view
        public ActionResult Admin()
        {
            var insurees = db.Insurees.ToList();
            return View(insurees);
        }
    }
}
