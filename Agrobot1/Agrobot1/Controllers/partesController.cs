using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agrobot1.Data;

namespace Agrobot1.Models
{
    public class partesController : Controller
    {
        private readonly Agrobot1Context _context;

        public partesController(Agrobot1Context context)
        {
            _context = context;
        }

        // GET: partes
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: partes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parte = await _context.parte
                .FirstOrDefaultAsync(m => m.id == id);
            if (parte == null)
            {
                return NotFound();
            }

            return View(parte);
        }

        // GET: partes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: partes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id")] parte parte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parte);
        }

        // GET: partes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parte = await _context.parte.FindAsync(id);
            if (parte == null)
            {
                return NotFound();
            }
            return View(parte);
        }

        // POST: partes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id")] parte parte)
        {
            if (id != parte.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!parteExists(parte.id))
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
            return View(parte);
        }

        // GET: partes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parte = await _context.parte
                .FirstOrDefaultAsync(m => m.id == id);
            if (parte == null)
            {
                return NotFound();
            }

            return View(parte);
        }

        // POST: partes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parte = await _context.parte.FindAsync(id);
            _context.parte.Remove(parte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool parteExists(int id)
        {
            return _context.parte.Any(e => e.id == id);
        }
    }
}
