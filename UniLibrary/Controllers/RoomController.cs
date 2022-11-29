<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniLibrary.Models;
using UniLibrary.Data;

namespace UniLibrary.Controllers
{
    public class RoomController : Controller
    {
        private readonly MvcRoomContext _context;

        public RoomController(MvcRoomContext context)
        {
            _context = context;
        }

        // GET: Room
        public async Task<IActionResult> Index(string roomType, string searchString)
        {
            IQueryable<string> roomQuery = from r in _context.Room orderby r.RoomType select r.RoomType;
            var rooms = from r in _context.Room select r;
            if (!String.IsNullOrEmpty(searchString))
            {
                rooms = rooms.Where(s => s.RoomName.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(roomType))
            {
                rooms = rooms.Where(x => x.RoomType == roomType);
            }
            var roomTypeVM = new RoomsTypeViewModel
            {
                Types = new SelectList(await roomQuery.Distinct().ToListAsync()),
                Rooms = await rooms.ToListAsync()
            };
            return View(roomTypeVM);
        }

        // GET: Room/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Room == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .FirstOrDefaultAsync(m => m.ID == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Room/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,RoomName,RoomType,Capacity")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Room/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Room == null)
            {
                return NotFound();
            }

            var room = await _context.Room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Room/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,RoomName,RoomType,Capacity")] Room room)
        {
            if (id != room.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.ID))
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
            return View(room);
        }

        // GET: Room/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Room == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .FirstOrDefaultAsync(m => m.ID == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Room == null)
            {
                return Problem("Entity set 'MvcRoomContext.Room'  is null.");
            }
            var room = await _context.Room.FindAsync(id);
            if (room != null)
            {
                _context.Room.Remove(room);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Room.Any(e => e.ID == id);
        }
    }
}
=======
using UniLibrary.Interfaces;
using UniLibrary.Models;
using UniLibrary.Factories;
using UniLibrary.ViewModels;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace UniLibrary.Controllers
{

    public class RoomsController : Controller
    {

        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            await Task.CompletedTask;
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var room = await _roomService.GetByIDAsync(id);
            return View(room);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var room = await _roomService.GetByIDAsync(id);
            return View(room);
        }

        [HttpPost]
        public async Task<IActionResult> EditRoom(int id, string name, int capacity, int floor)
        {
            Room room = await _roomService.GetByIDAsync(id);
            if (id != room.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    room.Name = name;
                    room.Capacity = capacity;
                    room.Floor = floor;
                    await _roomService.UpdateAsync(room);
                    TempData["Success"] = "Room Updated Successfully.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await RoomExists(room.ID))
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
            return View(room);
        }

        private async Task<bool> RoomExists(int id)
        {
            return await _roomService.GetByIDAsync(id) != null;
        }

        #region API CALLS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rooms = await _roomService.GetAllRoomsAsync();
            return Json(new { data = rooms });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomViewModel model)
        {
            try
            {
                foreach (var item in await _roomService.GetAllRoomsAsync())
                {
                    if (item.Name != model.Name)
                    {
                        Room? room = null;
                        switch (model.Room!.ToString())
                        {
                            case "MeetingRoom":
                                room = RoomConcreteFactory.getRoom(Models.Enums.Rooms.MeetingRoom);
                                break;
                            case "StudyRoom":
                                room = RoomConcreteFactory.getRoom(Models.Enums.Rooms.StudyRoom);
                                break;
                            case "ComputerRoom":
                                room = RoomConcreteFactory.getRoom(Models.Enums.Rooms.ComputerRoom);
                                break;
                            case "ConferenceRoom":
                                room = RoomConcreteFactory.getRoom(Models.Enums.Rooms.ConferenceRoom);
                                break;
                        }
                        room!.Name = model.Name;
                        room.Capacity = model.Capacity;
                        room.Floor = model.Floor;
                        await _roomService.AddAsync(room);
                        return Json(new { success = true, message = "Room Created Succcessfully" });
                    }
                    else
                    {
                        return Json(new { error = true, message = "Room Already Exists!" });
                    }
                }
            }
            catch (DbException)
            {
                return Json(new { error = true, message = "Something Went Wrong!" });
            }
            return Json(new { error = true, message = "An Unexpected Error Occured!" });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                try
                {
                    await _roomService.DeleteAsync(id);
                    return Json(new { success = true, message = "Room Deleted Succcessfully!" });
                }
                catch (DbException)
                {
                    return Json(new { error = true, message = "Something Went Wrong!" });
                }
            }
            return Json(new { error = true, message = "An Unexpected Error Occured." });
        }
        #endregion
    }

}
>>>>>>> main
