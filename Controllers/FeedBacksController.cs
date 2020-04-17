using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManagerAssistant.Data;
using ManagerAssistant.Models;
using Microsoft.AspNetCore.Authorization;

namespace ManagerAssistant.Controllers
{
    public class FeedBacksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeedBacksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FeedBacks
        public async Task<IActionResult> Index()
        {
            return View(await _context.FeedBack.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FIO,Email,Message")] FeedBack feedBack)
        {
            if (ModelState.IsValid)
            {
                feedBack.Id = Guid.NewGuid();
                _context.Add(feedBack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feedBack);
        }

        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedBack = await _context.FeedBack.FindAsync(id);
            if (feedBack == null)
            {
                return NotFound();
            }
            return View(feedBack);
        }

        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedBack = await _context.FeedBack
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedBack == null)
            {
                return NotFound();
            }

            return View(feedBack);
        }

        // POST: FeedBacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var feedBack = await _context.FeedBack.FindAsync(id);
            _context.FeedBack.Remove(feedBack);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedBackExists(Guid id)
        {
            return _context.FeedBack.Any(e => e.Id == id);
        }
    }
}
