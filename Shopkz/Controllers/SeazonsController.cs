using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shopkz.Data;
using Shopkz.Models;

namespace Shopkz.Controllers
{
    public class SeazonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeazonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Seazons
        public async Task<IActionResult> Index(
             string sortOrder,
             string currentFilter,
             string searchString,
             int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var seazon = from s in _context.Seazon
                        select s;

            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                seazon = seazon.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    seazon = seazon.OrderByDescending(s => s.Name);
                    break;
                default:
                    seazon = seazon.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Seazon>.CreateAsync(seazon.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Seazons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seazon = await _context.Seazon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seazon == null)
            {
                return NotFound();
            }

            return View(seazon);
        }

        // GET: Seazons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seazons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Seazon seazon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seazon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seazon);
        }

        // GET: Seazons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seazon = await _context.Seazon.FindAsync(id);
            if (seazon == null)
            {
                return NotFound();
            }
            return View(seazon);
        }

        // POST: Seazons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Seazon seazon)
        {
            if (id != seazon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seazon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeazonExists(seazon.Id))
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
            return View(seazon);
        }

        // GET: Seazons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seazon = await _context.Seazon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seazon == null)
            {
                return NotFound();
            }

            return View(seazon);
        }

        // POST: Seazons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seazon = await _context.Seazon.FindAsync(id);
            _context.Seazon.Remove(seazon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeazonExists(int id)
        {
            return _context.Seazon.Any(e => e.Id == id);
        }
    }
}
