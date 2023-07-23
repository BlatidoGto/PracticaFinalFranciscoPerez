using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaFinalFranciscoPerez.Data;
using PracticaFinalFranciscoPerez.Models;

namespace PracticaFinalFranciscoPerez.Controllers
{
    public class PersonaItemsController : Controller
    {
        private readonly PracticaFinalFranciscoPerezContext _context;

        public PersonaItemsController(PracticaFinalFranciscoPerezContext context)
        {
            _context = context;
        }

        // GET: PersonaItems
        public async Task<IActionResult> Index()
        {
              return _context.PersonaItem != null ? 
                          View(await _context.PersonaItem.ToListAsync()) :
                          Problem("Entity set 'PracticaFinalFranciscoPerezContext.PersonaItem'  is null.");
        }

        // GET: PersonaItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PersonaItem == null)
            {
                return NotFound();
            }

            var personaItem = await _context.PersonaItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personaItem == null)
            {
                return NotFound();
            }

            return View(personaItem);
        }

        // GET: PersonaItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonaItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,IsCompleted")] PersonaItem personaItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personaItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personaItem);
        }

        // GET: PersonaItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PersonaItem == null)
            {
                return NotFound();
            }

            var personaItem = await _context.PersonaItem.FindAsync(id);
            if (personaItem == null)
            {
                return NotFound();
            }
            return View(personaItem);
        }

        // POST: PersonaItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,IsCompleted")] PersonaItem personaItem)
        {
            if (id != personaItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personaItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaItemExists(personaItem.Id))
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
            return View(personaItem);
        }

        // GET: PersonaItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PersonaItem == null)
            {
                return NotFound();
            }

            var personaItem = await _context.PersonaItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personaItem == null)
            {
                return NotFound();
            }

            return View(personaItem);
        }

        // POST: PersonaItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PersonaItem == null)
            {
                return Problem("Entity set 'PracticaFinalFranciscoPerezContext.PersonaItem'  is null.");
            }
            var personaItem = await _context.PersonaItem.FindAsync(id);
            if (personaItem != null)
            {
                _context.PersonaItem.Remove(personaItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaItemExists(int id)
        {
          return (_context.PersonaItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
