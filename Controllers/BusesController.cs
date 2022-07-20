using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusManagement.Data;
using BusManagement.Models;
using Microsoft.AspNetCore.Authorization;

namespace BusManagement.Controllers
{
    public class BusesController : Controller
    {
        private readonly BusManagementContext _context;

        public BusesController(BusManagementContext context)
        {
            _context = context;
        }

        // GET: Buses
        public async Task<IActionResult> Index()
        {
            var busManagementContext = _context.Bus.Include(b => b.Id);
            return View(await busManagementContext.ToListAsync());
        }

        // GET: Buses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bus == null)
            {
                return NotFound();
            }

            var bus = await _context.Bus
                .Include(b => b.Id)
                .FirstOrDefaultAsync(m => m.BusId == id);
            if (bus == null)
            {
                return NotFound();
            }

            return View(bus);
        }

        // GET: Buses/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["Routeid"] = new SelectList(_context.Set<Roadroute>(), "Id", "Id");
            return View();
        }

        // POST: Buses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusId,Manufacturer,Seats,Routeid")] Bus bus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Routeid"] = new SelectList(_context.Set<Roadroute>(), "Id", "Id", bus.Routeid);
            return View(bus);
        }

        // GET: Buses/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bus == null)
            {
                return NotFound();
            }

            var bus = await _context.Bus.FindAsync(id);
            if (bus == null)
            {
                return NotFound();
            }
            ViewData["Routeid"] = new SelectList(_context.Set<Roadroute>(), "Id", "Id", bus.Routeid);
            return View(bus);
        }

        // POST: Buses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusId,Manufacturer,Seats,Routeid")] Bus bus)
        {
            if (id != bus.BusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusExists(bus.BusId))
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
            ViewData["Routeid"] = new SelectList(_context.Set<Roadroute>(), "Id", "Id", bus.Routeid);
            return View(bus);
        }

        // GET: Buses/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bus == null)
            {
                return NotFound();
            }

            var bus = await _context.Bus
                .Include(b => b.Id)
                .FirstOrDefaultAsync(m => m.BusId == id);
            if (bus == null)
            {
                return NotFound();
            }

            return View(bus);
        }

        // POST: Buses/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bus == null)
            {
                return Problem("Entity set 'BusManagementContext.Bus'  is null.");
            }
            var bus = await _context.Bus.FindAsync(id);
            if (bus != null)
            {
                _context.Bus.Remove(bus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusExists(int id)
        {
          return (_context.Bus?.Any(e => e.BusId == id)).GetValueOrDefault();
        }
    }
}
