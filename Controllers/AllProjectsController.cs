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
    [Authorize(Roles = "admin, manager")]
    public class AllProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AllProjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.AllProjects.ToListAsync());
        }

        // GET: AllProjects/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allProject = await _context.AllProjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allProject == null)
            {
                return NotFound();
            }

            return View(allProject);
        }

        // GET: AllProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AllProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerEvaluatate,Quality,TotalSum,DeadlineAccording,Id,NameProject,Status,Description,DayOnDev,Insurance,TotalDeadline,QuantityPerson,Rent,PaymentForServers,Cost,AverageIncome,TotalIncome,Profit,Tax,CostProject,IdOrder,IdEmployee,IdClient,IdLead")] AllProject allProject)
        {
            if (ModelState.IsValid)
            {
                allProject.Id = Guid.NewGuid();
                _context.Add(allProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allProject);
        }

        // GET: AllProjects/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allProject = await _context.AllProjects.FindAsync(id);
            if (allProject == null)
            {
                return NotFound();
            }
            return View(allProject);
        }

        // POST: AllProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CustomerEvaluatate,Quality,TotalSum,DeadlineAccording,Id,NameProject,Status,Description,DayOnDev,Insurance,TotalDeadline,QuantityPerson,Rent,PaymentForServers,Cost,AverageIncome,TotalIncome,Profit,Tax,CostProject,IdOrder,IdEmployee,IdClient,IdLead")] AllProject allProject)
        {
            if (id != allProject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllProjectExists(allProject.Id))
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
            return View(allProject);
        }

        // GET: AllProjects/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allProject = await _context.AllProjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allProject == null)
            {
                return NotFound();
            }

            return View(allProject);
        }

        // POST: AllProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var allProject = await _context.AllProjects.FindAsync(id);
            _context.AllProjects.Remove(allProject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllProjectExists(Guid id)
        {
            return _context.AllProjects.Any(e => e.Id == id);
        }
    }
}
