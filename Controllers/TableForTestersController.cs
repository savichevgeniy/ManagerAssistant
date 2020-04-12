using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManagerAssistant;
using ManagerAssistant.Data;

namespace ManagerAssistant.Controllers
{
    public class TableForTestersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TableForTestersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TableForTesters
        public async Task<IActionResult> Index()
        {
            return View(await _context.TableForTesters.ToListAsync());
        }

        // GET: TableForTesters/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableForTester = await _context.TableForTesters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tableForTester == null)
            {
                return NotFound();
            }

            return View(tableForTester);
        }

        // GET: TableForTesters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TableForTesters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DateTest,IntegrationTest,SystemTest,Id,Description,Changes,DateStart,DateEnd")] TableForTester tableForTester)
        {
            if (ModelState.IsValid)
            {
                tableForTester.Id = Guid.NewGuid();
                _context.Add(tableForTester);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tableForTester);
        }

        // GET: TableForTesters/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableForTester = await _context.TableForTesters.FindAsync(id);
            if (tableForTester == null)
            {
                return NotFound();
            }
            return View(tableForTester);
        }

        // POST: TableForTesters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DateTest,IntegrationTest,SystemTest,Id,Description,Changes,DateStart,DateEnd")] TableForTester tableForTester)
        {
            if (id != tableForTester.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableForTester);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableForTesterExists(tableForTester.Id))
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
            return View(tableForTester);
        }

        // GET: TableForTesters/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableForTester = await _context.TableForTesters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tableForTester == null)
            {
                return NotFound();
            }

            return View(tableForTester);
        }

        // POST: TableForTesters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tableForTester = await _context.TableForTesters.FindAsync(id);
            _context.TableForTesters.Remove(tableForTester);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableForTesterExists(Guid id)
        {
            return _context.TableForTesters.Any(e => e.Id == id);
        }
    }
}
