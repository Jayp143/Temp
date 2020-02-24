using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FurnitureStore.Data;
using FurnitureStore.Models;

namespace FurnitureStore.Controllers
{
    public class ManufacturesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManufacturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Manufactures
        public async Task<IActionResult> Index()
        {
            return View(await _context.Manufacture.ToListAsync());
        }

        // GET: Manufactures/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacture = await _context.Manufacture
                .FirstOrDefaultAsync(m => m.CompanyName == id);
            if (manufacture == null)
            {
                return NotFound();
            }

            return View(manufacture);
        }

        // GET: Manufactures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manufactures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ManufacturerID,CompanyName,ContactNumber,CompanyDetails")] Manufacture manufacture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manufacture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manufacture);
        }

        // GET: Manufactures/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacture = await _context.Manufacture.FindAsync(id);
            if (manufacture == null)
            {
                return NotFound();
            }
            return View(manufacture);
        }

        // POST: Manufactures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ManufacturerID,CompanyName,ContactNumber,CompanyDetails")] Manufacture manufacture)
        {
            if (id != manufacture.CompanyName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manufacture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManufactureExists(manufacture.CompanyName))
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
            return View(manufacture);
        }

        // GET: Manufactures/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacture = await _context.Manufacture
                .FirstOrDefaultAsync(m => m.CompanyName == id);
            if (manufacture == null)
            {
                return NotFound();
            }

            return View(manufacture);
        }

        // POST: Manufactures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var manufacture = await _context.Manufacture.FindAsync(id);
            _context.Manufacture.Remove(manufacture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManufactureExists(string id)
        {
            return _context.Manufacture.Any(e => e.CompanyName == id);
        }
    }
}
