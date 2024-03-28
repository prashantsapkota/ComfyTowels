using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComfyTowels.Data;
using ComfyTowels.Models;
using Microsoft.AspNetCore.Authorization;

namespace ComfyTowels.Controllers
{
    public class ComfyTowelsController : Controller
    {
        private readonly ComfyTowelsContext _context;

        public ComfyTowelsController(ComfyTowelsContext context)
        {
            _context = context;
        }

        // GET: ComfyTowels
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Towels.ToListAsync());
        }

        // GET: ComfyTowels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var towels = await _context.Towels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (towels == null)
            {
                return NotFound();
            }

            return View(towels);
        }

        // GET: ComfyTowels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ComfyTowels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TowelType,Size,Color,Price")] Towels towels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(towels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(towels);
        }

        // GET: ComfyTowels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var towels = await _context.Towels.FindAsync(id);
            if (towels == null)
            {
                return NotFound();
            }
            return View(towels);
        }

        // POST: ComfyTowels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TowelType,Size,Color,Price")] Towels towels)
        {
            if (id != towels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(towels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TowelsExists(towels.Id))
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
            return View(towels);
        }

        // GET: ComfyTowels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var towels = await _context.Towels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (towels == null)
            {
                return NotFound();
            }

            return View(towels);
        }

        // POST: ComfyTowels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var towels = await _context.Towels.FindAsync(id);
            if (towels != null)
            {
                _context.Towels.Remove(towels);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TowelsExists(int id)
        {
            return _context.Towels.Any(e => e.Id == id);
        }
    }
}
