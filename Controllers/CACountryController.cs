using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CAPatients.Models;

namespace CAPatients.Controllers
{
    public class CACountryController : Controller
    {
        private readonly PatientsContext _context;

        //inizializing the new Instance of this controller for the project.
        public CACountryController(PatientsContext context)
        {
            _context = context;
        }

        // GET: CACountry
        //It returns Controller to the Index View for this specific controller
        //It shows the main page (index) for this controller
        public async Task<IActionResult> Index()
        {
            return View(await _context.Country.ToListAsync());
        }

        // GET: CACountry/Details/5
        //It returns controller to the Details view for this controller (showed information is different for each controller)
        public async Task<IActionResult> Details(string id)
        {
   
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Country
                .FirstOrDefaultAsync(m => m.CountryCode == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // GET: CACountry/Create
        //It returns controller to the Create view for this controller
        public IActionResult Create()
        {
            return View();
        }

        // POST: CACountry/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //Create Country into the Database
        public async Task<IActionResult> Create([Bind("CountryCode,Name,PostalPattern,PhonePattern,FederalSalesTax")] Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Add(country);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: CACountry/Edit/5
        //It returns controller to the Edit view for this controller
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Country.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            
            return View(country);
        }

        // POST: CACountry/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //Edit Countries into the Database
        public async Task<IActionResult> Edit(string id, [Bind("CountryCode,Name,PostalPattern,PhonePattern,FederalSalesTax")] Country country)
        {
            if (id != country.CountryCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.CountryCode))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: CACountry/Delete/5
        //It returns controller to the Delete view for this controller
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Country
                .FirstOrDefaultAsync(m => m.CountryCode == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: CACountry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        //Delete Country from the Database (confirmed)
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var country = await _context.Country.FindAsync(id);
            _context.Country.Remove(country);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Validates if the data we need to create aready exist in the database
        private bool CountryExists(string id)
        {
            return _context.Country.Any(e => e.CountryCode == id);
        }
    }
}
