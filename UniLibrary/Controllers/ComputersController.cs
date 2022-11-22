using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniLibrary.Data;
using UniLibrary.Models;
using UniLibrary.Interfaces;

namespace UniLibrary.Controllers
{
    public class ComputersController : Controller
    {
        private readonly IComputerService _computerService;

        public ComputersController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        // GET: Computers
        public async Task<IActionResult> Index()
        {
              return _computerService.Computer != null ? 
                          View(await _computerService.Computer.ToListAsync()) :
                          Problem("Entity set 'MvcComputerContext.Computer'  is null.");
        }

        // GET: Computers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _computerService.Computer == null)
            {
                return NotFound();
            }

            var computer = await _computerService.Computer
                .FirstOrDefaultAsync(m => m.ID == id);
            if (computer == null)
            {
                return NotFound();
            }

            return View(computer);
        }

        // GET: Computers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Computers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PCNum,OS,Availability")] Computer computer)
        {
            if (ModelState.IsValid)
            {
                _computerService.Add(computer);
                await _computerService.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(computer);
        }

        // GET: Computers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _computerService.Computer == null)
            {
                return NotFound();
            }

            var computer = await _computerService.Computer.FindAsync(id);
            if (computer == null)
            {
                return NotFound();
            }
            return View(computer);
        }

        // POST: Computers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PCNum,OS,Availability")] Computer computer)
        {
            if (id != computer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _computerService.Update(computer);
                    await _computerService.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComputerExists(computer.ID))
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
            return View(computer);
        }

        // GET: Computers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _computerService.Computer == null)
            {
                return NotFound();
            }

            var computer = await _computerService.Computer
                .FirstOrDefaultAsync(m => m.ID == id);
            if (computer == null)
            {
                return NotFound();
            }

            return View(computer);
        }

        // POST: Computers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_computerService.Computer == null)
            {
                return Problem("Entity set 'MvcComputerContext.Computer'  is null.");
            }
            var computer = await _computerService.Computer.FindAsync(id);
            if (computer != null)
            {
                _computerService.Computer.Remove(computer);
            }
            
            await _computerService.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComputerExists(int id)
        {
          return (_computerService.Computer?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
