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
    [Authorize(Roles = "admin, manager, developer")]
    public class TableForDevelopersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TableForDevelopersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TableForDevelopers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TableForDevelopers.ToListAsync());
        }

        // GET: TableForDevelopers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableForDeveloper = await _context.TableForDevelopers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tableForDeveloper == null)
            {
                return NotFound();
            }

            return View(tableForDeveloper);
        }

        // GET: TableForDevelopers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TableForDevelopers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DateDev,StepDev,Id,Description,Changes,DateStart,DateEnd")] TableForDeveloper tableForDeveloper)
        {
            if (ModelState.IsValid)
            {
                tableForDeveloper.Id = Guid.NewGuid();
                _context.Add(tableForDeveloper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tableForDeveloper);
        }

        // GET: TableForDevelopers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableForDeveloper = await _context.TableForDevelopers.FindAsync(id);
            if (tableForDeveloper == null)
            {
                return NotFound();
            }
            return View(tableForDeveloper);
        }

        // POST: TableForDevelopers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DateDev,StepDev,Id,Description,Changes,DateStart,DateEnd")] TableForDeveloper tableForDeveloper)
        {
            if (id != tableForDeveloper.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableForDeveloper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableForDeveloperExists(tableForDeveloper.Id))
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
            return View(tableForDeveloper);
        }

        // GET: TableForDevelopers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableForDeveloper = await _context.TableForDevelopers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tableForDeveloper == null)
            {
                return NotFound();
            }

            return View(tableForDeveloper);
        }

        // POST: TableForDevelopers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tableForDeveloper = await _context.TableForDevelopers.FindAsync(id);
            _context.TableForDevelopers.Remove(tableForDeveloper);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableForDeveloperExists(Guid id)
        {
            return _context.TableForDevelopers.Any(e => e.Id == id);
        }
    }
}
