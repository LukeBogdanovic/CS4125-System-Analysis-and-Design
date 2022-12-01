using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniLibrary.Models;
using UniLibrary.Interfaces;
using System.Data.Common;

namespace UniLibrary.Controllers
{
#nullable disable
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
            var computers = await _computerService.GetAllComputersAsync(filter: null, orderBy: null);
            return View(computers);
        }

        // GET: Computers/Create
        public async Task<IActionResult> Create()
        {
            await Task.CompletedTask;
            return View();
        }

        // POST: Computers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Computer computer)
        {
            try
            {
                await _computerService.AddAsync(computer);
                TempData["Success"] = "Computer Created Successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (DbException)
            {
                return View();
            }
        }

        // POST: Computers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ComNum,OS,Availability")] Computer computer)
        {
            if (id != computer.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _computerService.UpdateAsync(computer);
                    TempData["Success"] = "Computer Updated Successfully.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await ComputerExists(computer.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        TempData["Error"] = "An Unexpected Error Occured!";
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(computer);
        }

        // GET: Computers/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var computerInDb = await _computerService.GetByIDAsync(id);
            if (computerInDb.Availability == false)
            {
                return Json(new { error = true, message = "You cannot Delete this Computer while it is in Use" });
            }
            await _computerService.DeleteAsync(id);
            return Json(new { success = true, message = "Computer Deleted Successfully" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var computers = await _computerService.GetAllComputersAsync();
            return Json(new { data = computers });
        }

        private async Task<bool> ComputerExists(int id)
        {
            return await _computerService.GetByIDAsync(id) != null;
        }
    }

    public class PCAvailabilityObserver : IAvailabilityObserver
    {
        private string ComNum;
        private PC pc;
        public List<Computer> available = new List<Computer>();
        public List<Computer> unavailable = new List<Computer>();


        // Constructor

        public PCAvailabilityObserver(PC pc, string ComNum)
        {
            this.pc = pc;
            this.ComNum = ComNum;
        }

        public override void Update(IAvailabilityObserver x)
        {
            available.Clear();
            unavailable.Clear();
            if (x.GetComputer().Availability == true)
            {
                available.Add(x.GetComputer());
            } 
            else
            {
                unavailable.Add(x.GetComputer());
            }

        }
        
        public override PC GetComputer()
        {
            return pc;
        }
    }

    public class LaptopAvailabilityObserver : IAvailabilityObserver
    {
        private string ComNum;
        private PC pc;
        public List<Computer> available = new List<Computer>();
        public List<Computer> unavailable = new List<Computer>();


        // Constructor

        public LaptopAvailabilityObserver(PC pc, string ComNum)
        {
            this.pc = pc;
            this.ComNum = ComNum;
            
        }
        public override PC GetComputer()
        {
            return pc;
        }

        public override void Update(IAvailabilityObserver x)
        {
            if (x.GetComputer().Availability == true)
            {
                available.Add(x.GetComputer());
            } 
            else
            {
                unavailable.Add(x.GetComputer());
            }

        }
    }
}