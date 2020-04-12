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
    public class TableForDesignersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TableForDesignersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TableForDesigners
        public async Task<IActionResult> Index()
        {
            return View(await _context.TableForDesigners.ToListAsync());
        }

        // GET: TableForDesigners/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableForDesigners = await _context.TableForDesigners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tableForDesigners == null)
            {
                return NotFound();
            }

            return View(tableForDesigners);
        }

        // GET: TableForDesigners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TableForDesigners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TemplateDesign,StatmentColor,PervisionTerm,DateWork,Id,Description,Changes,DateStart,DateEnd")] TableForDesigners tableForDesigners)
        {
            if (ModelState.IsValid)
            {
                tableForDesigners.Id = Guid.NewGuid();
                _context.Add(tableForDesigners);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tableForDesigners);
        }

        // GET: TableForDesigners/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableForDesigners = await _context.TableForDesigners.FindAsync(id);
            if (tableForDesigners == null)
            {
                return NotFound();
            }
            return View(tableForDesigners);
        }

        // POST: TableForDesigners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TemplateDesign,StatmentColor,PervisionTerm,DateWork,Id,Description,Changes,DateStart,DateEnd")] TableForDesigners tableForDesigners)
        {
            if (id != tableForDesigners.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableForDesigners);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableForDesignersExists(tableForDesigners.Id))
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
            return View(tableForDesigners);
        }

        // GET: TableForDesigners/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableForDesigners = await _context.TableForDesigners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tableForDesigners == null)
            {
                return NotFound();
            }

            return View(tableForDesigners);
        }

        // POST: TableForDesigners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tableForDesigners = await _context.TableForDesigners.FindAsync(id);
            _context.TableForDesigners.Remove(tableForDesigners);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableForDesignersExists(Guid id)
        {
            return _context.TableForDesigners.Any(e => e.Id == id);
        }
    }
}
