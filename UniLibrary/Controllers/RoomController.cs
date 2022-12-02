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

        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create()
        {
            await Task.CompletedTask;
            return View();
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

        [HttpPost, Authorize(Policy = "Admin")]
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
