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
    public class TableForEmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TableForEmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TableForEmployees
        public async Task<IActionResult> Index()
        {
            return View(await _context.TableForEmployee.ToListAsync());
        }

        // GET: TableForEmployees/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableForEmployee = await _context.TableForEmployee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tableForEmployee == null)
            {
                return NotFound();
            }

            return View(tableForEmployee);
        }

        // GET: TableForEmployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TableForEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Changes,DateStart,DateEnd")] TableForEmployee tableForEmployee)
        {
            if (ModelState.IsValid)
            {
                tableForEmployee.Id = Guid.NewGuid();
                _context.Add(tableForEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tableForEmployee);
        }

        // GET: TableForEmployees/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableForEmployee = await _context.TableForEmployee.FindAsync(id);
            if (tableForEmployee == null)
            {
                return NotFound();
            }
            return View(tableForEmployee);
        }

        // POST: TableForEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Description,Changes,DateStart,DateEnd")] TableForEmployee tableForEmployee)
        {
            if (id != tableForEmployee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableForEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableForEmployeeExists(tableForEmployee.Id))
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
            return View(tableForEmployee);
        }

        // GET: TableForEmployees/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableForEmployee = await _context.TableForEmployee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tableForEmployee == null)
            {
                return NotFound();
            }

            return View(tableForEmployee);
        }

        // POST: TableForEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tableForEmployee = await _context.TableForEmployee.FindAsync(id);
            _context.TableForEmployee.Remove(tableForEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableForEmployeeExists(Guid id)
        {
            return _context.TableForEmployee.Any(e => e.Id == id);
        }
    }
}
