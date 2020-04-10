using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurnitureStore.Data;
using FurnitureStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace FurnitureStore.Controllers
{
    public class ItemssController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemssController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Items.Include(e => e.Product);
            return View("Index", await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Items = await _context.Items
                .Include(e => e.Product)
                .FirstOrDefaultAsync(m => m.Itemsid == id);
            if (Items == null)
            {
                return NotFound();
            }

            return View(Items);
        }

        // Items/Create
        public IActionResult Create()
        {
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID");
            return View();
        }

        //  Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Itemsid,Model,Size,Price,ProductID")] Items Items)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Items);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID", Items.ProductID);
            return View(Items);
        }

        // Items/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Items = await _context.Items.FindAsync(id);
            if (Items == null)
            {
                return NotFound();
            }
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID", Items.ProductID);
            return View(Items);
        }

        // Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Itemsid,Model,Size,Price,ProductID")] Items Items)
        {
            if (id != Items.Itemsid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Items);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemsExists(Items.Itemsid))
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
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID", Items.ProductID);
            return View(Items);
        }

        private bool ItemsExists(int itemsid)
        {
            throw new NotImplementedException();
        }

        //Items/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Items = await _context.Items
                .Include(e => e.Product)
                .FirstOrDefaultAsync(m => m.Itemsid == id);
            if (Items == null)
            {
                return NotFound();
            }

            return View(Items);
        }

        // Items/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Items = await _context.Items.FindAsync(id);
            _context.Items.Remove(Items);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool Items Exists(int id)
        {
            return _context.Items.Any(e => e.Itemsid == id);
        }
    }
}