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
    public class CAMedicationTypesController : Controller
    {
        private readonly PatientsContext _context;

        //inizializing the new Instance of this controller for the project.
        public CAMedicationTypesController(PatientsContext context)
        {
            _context = context;
        }

        // GET: CAMedicationTypes
        //It returns Controller to the Index View for this specific controller
        //It shows the main page (index) for this controller
        public async Task<IActionResult> Index()
        {
            return View(await _context.MedicationType.ToListAsync());
        }

        // GET: CAMedicationTypes/Details/5
        //It returns controller to the Details view for this controller (showed information is different for each controller)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicationType = await _context.MedicationType
                .FirstOrDefaultAsync(m => m.MedicationTypeId == id);
            if (medicationType == null)
            {
                return NotFound();
            }

            return View(medicationType);
        }

        // GET: CAMedicationTypes/Create
        //It returns controller to the Create view for this controller
        public IActionResult Create()
        {
            return View();
        }

        // POST: CAMedicationTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //Create Diagnosis Medication Type into the Database
        public async Task<IActionResult> Create([Bind("MedicationTypeId,Name")] MedicationType medicationType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicationType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicationType);
        }

        // GET: CAMedicationTypes/Edit/5
        //It returns controller to the Edit view for this controller
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicationType = await _context.MedicationType.FindAsync(id);
            if (medicationType == null)
            {
                return NotFound();
            }
            return View(medicationType);
        }

        // POST: CAMedicationTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //Edit Diagnosis Medication Types into the Database
        public async Task<IActionResult> Edit(int id, [Bind("MedicationTypeId,Name")] MedicationType medicationType)
        {
            if (id != medicationType.MedicationTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicationType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicationTypeExists(medicationType.MedicationTypeId))
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
            return View(medicationType);
        }

        // GET: CAMedicationTypes/Delete/5
        //It returns controller to the Delete view for this controller
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicationType = await _context.MedicationType
                .FirstOrDefaultAsync(m => m.MedicationTypeId == id);
            if (medicationType == null)
            {
                return NotFound();
            }

            return View(medicationType);
        }

        // POST: CAMedicationTypes/Delete/5
        //Delete Dispensing Units from the Database (confirmed)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicationType = await _context.MedicationType.FindAsync(id);
            _context.MedicationType.Remove(medicationType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Validates if the data we need to create aready exist in the database
        private bool MedicationTypeExists(int id)
        {
            return _context.MedicationType.Any(e => e.MedicationTypeId == id);
        }
    }
}
