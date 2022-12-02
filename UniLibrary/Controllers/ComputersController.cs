using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniLibrary.Models;
using UniLibrary.Interfaces;
using System.Data.Common;
using UniLibrary.Observer;

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

        [HttpPost]
        public async Task<IActionResult> Loan(int id)
        {
            var computerInDb = await _computerService.GetByIDAsync(id);
            switch (computerInDb)
            {
                case PC:
                    PC computer = (PC)computerInDb;
                    computer.Attach(new PCAvailabilityObserver(computer, computer.ComNum));
                    computer.ChangeAvailability(computer, false);
                    await _computerService.UpdateAsync(computer);
                    return Json(new { success = true, message = $"Computer {computerInDb.ComNum} borrowed successfully" });
                case Laptop:
                    Laptop laptop = (Laptop)computerInDb;
                    laptop.Attach(new LaptopAvailabilityObserver(laptop, laptop.ComNum));
                    laptop.ChangeAvailability(laptop, false);
                    await _computerService.UpdateAsync(laptop);
                    return Json(new { success = true, message = $"Laptop {computerInDb.ComNum} borrowed successfully" });
            }
            return Json(new { error = true, message = "Unable to borrow successfully" });
        }

        [HttpPost]
        public async Task<IActionResult> Return(int id)
        {
            var computerInDb = await _computerService.GetByIDAsync(id);
            switch (computerInDb)
            {
                case PC:
                    PC computer = (PC)computerInDb;
                    computer.Attach(new PCAvailabilityObserver(computer, computer.ComNum));
                    computer.ChangeAvailability(computer, true);
                    await _computerService.UpdateAsync(computer);
                    return Json(new { success = true, message = $"Computer {computerInDb.ComNum} returned successfully" });
                case Laptop:
                    Laptop laptop = (Laptop)computerInDb;
                    laptop.Attach(new LaptopAvailabilityObserver(laptop, laptop.ComNum));
                    laptop.ChangeAvailability(laptop, true);
                    await _computerService.UpdateAsync(laptop);
                    return Json(new { success = true, message = $"Laptop {computerInDb.ComNum} returned successfully" });
            }
            return Json(new { error = true, message = "Unable to return successfully" });
        }

        private async Task<bool> ComputerExists(int id)
        {
            return await _computerService.GetByIDAsync(id) != null;
        }
    }
}