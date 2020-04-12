﻿using System;
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
    [Authorize(Roles = "admin, manager, designer")]
    public class DesignersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DesignersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Designers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Designers.ToListAsync());
        }

        // GET: Designers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designer = await _context.Designers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (designer == null)
            {
                return NotFound();
            }

            return View(designer);
        }

        // GET: Designers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Designers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DesignerPosition,Salary,Status,Id,FIO,Adress,NumberTelephone,Email,DataEmployment")] Designer designer)
        {
            if (ModelState.IsValid)
            {
                designer.Id = Guid.NewGuid();
                _context.Add(designer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(designer);
        }

        // GET: Designers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designer = await _context.Designers.FindAsync(id);
            if (designer == null)
            {
                return NotFound();
            }
            return View(designer);
        }

        // POST: Designers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DesignerPosition,Salary,Status,Id,FIO,Adress,NumberTelephone,Email,DataEmployment")] Designer designer)
        {
            if (id != designer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(designer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesignerExists(designer.Id))
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
            return View(designer);
        }

        // GET: Designers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designer = await _context.Designers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (designer == null)
            {
                return NotFound();
            }

            return View(designer);
        }

        // POST: Designers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var designer = await _context.Designers.FindAsync(id);
            _context.Designers.Remove(designer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesignerExists(Guid id)
        {
            return _context.Designers.Any(e => e.Id == id);
        }
    }
}
