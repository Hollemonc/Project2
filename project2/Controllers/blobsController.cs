using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project2.Data;
using project2.Models;

namespace project2.Controllers
{
    public class blobsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public blobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: blobs
        public async Task<IActionResult> Index()
        {
            return View(await _context.blob.ToListAsync());
        }

        // GET: blobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blob = await _context.blob
                .SingleOrDefaultAsync(m => m.ID == id);
            if (blob == null)
            {
                return NotFound();
            }

            return View(blob);
        }

        // GET: blobs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: blobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Body,Timestamp")] blob blob)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blob);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blob);
        }

        // GET: blobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blob = await _context.blob.SingleOrDefaultAsync(m => m.ID == id);
            if (blob == null)
            {
                return NotFound();
            }
            return View(blob);
        }

        // POST: blobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Body,Timestamp")] blob blob)
        {
            if (id != blob.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blob);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!blobExists(blob.ID))
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
            return View(blob);
        }

        // GET: blobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blob = await _context.blob
                .SingleOrDefaultAsync(m => m.ID == id);
            if (blob == null)
            {
                return NotFound();
            }

            return View(blob);
        }

        // POST: blobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blob = await _context.blob.SingleOrDefaultAsync(m => m.ID == id);
            _context.blob.Remove(blob);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool blobExists(int id)
        {
            return _context.blob.Any(e => e.ID == id);
        }
    }
}
