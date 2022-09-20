using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using B2C2Core.Data;
using B2C2Core.Models;

namespace B2C2Core.Controllers
{
    public class FiliaalsController : Controller
    {
        private readonly AppDbContext _context;

        public FiliaalsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Filiaals
        public async Task<IActionResult> Index()
        {
              return View(await _context.Filiaal.ToListAsync());
        }

        // GET: Filiaals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Filiaal == null)
            {
                return NotFound();
            }

            var filiaal = await _context.Filiaal
                .FirstOrDefaultAsync(m => m.FiliaalId == id);
            if (filiaal == null)
            {
                return NotFound();
            }

            return View(filiaal);
        }

        // GET: Filiaals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filiaals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FiliaalId,Naam")] Filiaal filiaal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filiaal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filiaal);
        }

        // GET: Filiaals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Filiaal == null)
            {
                return NotFound();
            }

            var filiaal = await _context.Filiaal.FindAsync(id);
            if (filiaal == null)
            {
                return NotFound();
            }
            return View(filiaal);
        }

        // POST: Filiaals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FiliaalId,Naam")] Filiaal filiaal)
        {
            if (id != filiaal.FiliaalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filiaal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FiliaalExists(filiaal.FiliaalId))
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
            return View(filiaal);
        }

        // GET: Filiaals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Filiaal == null)
            {
                return NotFound();
            }

            var filiaal = await _context.Filiaal
                .FirstOrDefaultAsync(m => m.FiliaalId == id);
            if (filiaal == null)
            {
                return NotFound();
            }

            return View(filiaal);
        }

        // POST: Filiaals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Filiaal == null)
            {
                return Problem("Entity set 'AppDbContext.Filiaal'  is null.");
            }
            var filiaal = await _context.Filiaal.FindAsync(id);
            if (filiaal != null)
            {
                _context.Filiaal.Remove(filiaal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FiliaalExists(int id)
        {
          return _context.Filiaal.Any(e => e.FiliaalId == id);
        }
    }
}
