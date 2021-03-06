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
    [Authorize(Roles = "admin, manager")]
    public class OtherEmloyeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OtherEmloyeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OtherEmloyees
        public async Task<IActionResult> Index()
        {
            return View(await _context.OtherEmloyees.ToListAsync());
        }

        // GET: OtherEmloyees/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otherEmloyee = await _context.OtherEmloyees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (otherEmloyee == null)
            {
                return NotFound();
            }

            return View(otherEmloyee);
        }

        // GET: OtherEmloyees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OtherEmloyees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Position,Salare,Status,Id,FIO,Adress,NumberTelephone,Email,DataEmployment")] OtherEmloyee otherEmloyee)
        {
            if (ModelState.IsValid)
            {
                otherEmloyee.Id = Guid.NewGuid();
                _context.Add(otherEmloyee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(otherEmloyee);
        }

        // GET: OtherEmloyees/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otherEmloyee = await _context.OtherEmloyees.FindAsync(id);
            if (otherEmloyee == null)
            {
                return NotFound();
            }
            return View(otherEmloyee);
        }

        // POST: OtherEmloyees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Position,Salare,Status,Id,FIO,Adress,NumberTelephone,Email,DataEmployment")] OtherEmloyee otherEmloyee)
        {
            if (id != otherEmloyee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(otherEmloyee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OtherEmloyeeExists(otherEmloyee.Id))
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
            return View(otherEmloyee);
        }

        // GET: OtherEmloyees/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otherEmloyee = await _context.OtherEmloyees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (otherEmloyee == null)
            {
                return NotFound();
            }

            return View(otherEmloyee);
        }

        // POST: OtherEmloyees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var otherEmloyee = await _context.OtherEmloyees.FindAsync(id);
            _context.OtherEmloyees.Remove(otherEmloyee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OtherEmloyeeExists(Guid id)
        {
            return _context.OtherEmloyees.Any(e => e.Id == id);
        }
    }
}
