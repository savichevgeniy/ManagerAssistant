using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManagerAssistant;
using ManagerAssistant.Data;
using Microsoft.AspNetCore.Authorization;

namespace ManagerAssistant.Controllers
{
    [Authorize(Roles = "admin, manager, tester")]
    public class TestersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Testers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Testers.ToListAsync());
        }

        // GET: Testers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tester = await _context.Testers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tester == null)
            {
                return NotFound();
            }

            return View(tester);
        }

        // GET: Testers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Testers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TesterPosition,Salary,Status,Id,FIO,Adress,NumberTelephone,Email,DataEmployment")] Tester tester)
        {
            if (ModelState.IsValid)
            {
                tester.Id = Guid.NewGuid();
                _context.Add(tester);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tester);
        }

        // GET: Testers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tester = await _context.Testers.FindAsync(id);
            if (tester == null)
            {
                return NotFound();
            }
            return View(tester);
        }

        // POST: Testers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TesterPosition,Salary,Status,Id,FIO,Adress,NumberTelephone,Email,DataEmployment")] Tester tester)
        {
            if (id != tester.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tester);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TesterExists(tester.Id))
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
            return View(tester);
        }

        // GET: Testers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tester = await _context.Testers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tester == null)
            {
                return NotFound();
            }

            return View(tester);
        }

        // POST: Testers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tester = await _context.Testers.FindAsync(id);
            _context.Testers.Remove(tester);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TesterExists(Guid id)
        {
            return _context.Testers.Any(e => e.Id == id);
        }
    }
}
