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
    public class CADiagnosisCategoriesController : Controller
    {
        private readonly PatientsContext _context;

        //inizializing the new Instance of this controller for the project.
        public CADiagnosisCategoriesController(PatientsContext context)
        {
            _context = context;
        }

        // GET: CADiagnosisCategories
        //It returns Controller to the Index View for this specific controller
        //It shows the main page (index) for this controller
        public async Task<IActionResult> Index()
        {
            return View(await _context.DiagnosisCategory.ToListAsync());
        }

        // GET: CADiagnosisCategories/Details/5
        //It returns controller to the Details view for this controller (showed information is different for each controller)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnosisCategory = await _context.DiagnosisCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diagnosisCategory == null)
            {
                return NotFound();
            }

            return View(diagnosisCategory);
        }

        // GET: CADiagnosisCategories/Create
        //It returns controller to the Create view for this controller
        public IActionResult Create()
        {
            return View();
        }

        // POST: CADiagnosisCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //Create Diagnosis Category into the Database
        public async Task<IActionResult> Create([Bind("Id,Name")] DiagnosisCategory diagnosisCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diagnosisCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diagnosisCategory);
        }

        // GET: CADiagnosisCategories/Edit/5
        //It returns controller to the Edit view for this controller
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnosisCategory = await _context.DiagnosisCategory.FindAsync(id);
            if (diagnosisCategory == null)
            {
                return NotFound();
            }
            return View(diagnosisCategory);
        }

        // POST: CADiagnosisCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //Edit Diagnosis Categories into the Database
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] DiagnosisCategory diagnosisCategory)
        {
            if (id != diagnosisCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diagnosisCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiagnosisCategoryExists(diagnosisCategory.Id))
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
            return View(diagnosisCategory);
        }

        // GET: CADiagnosisCategories/Delete/5
        //It returns controller to the Delete view for this controller
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnosisCategory = await _context.DiagnosisCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diagnosisCategory == null)
            {
                return NotFound();
            }

            return View(diagnosisCategory);
        }

        // POST: CADiagnosisCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        //Delete Diagnosis Category from the Database (confirmed)
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diagnosisCategory = await _context.DiagnosisCategory.FindAsync(id);
            _context.DiagnosisCategory.Remove(diagnosisCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Validates if the data we need to create aready exist in the database
        private bool DiagnosisCategoryExists(int id)
        {
            return _context.DiagnosisCategory.Any(e => e.Id == id);
        }
    }
}
