using UniLibrary.Interfaces;
using UniLibrary.Models;
using UniLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.Common;
using UniLibrary.Factories;

namespace UniLibrary.Controllers
{

    public class ReservationsController : Controller
    {
        private readonly IReserveService _reserveService;
        private readonly IRoomService _roomService;
        private readonly IRoomReservationService _roomReservationService;

        public ReservationsController(IReserveService reserveService, IRoomService roomService, IRoomReservationService roomReservationService)
        {
            _reserveService = reserveService;
            _roomService = roomService;
            _roomReservationService = roomReservationService;
        }

        public async Task<IActionResult> Index(string status)
        {
            ReservationViewModel model = new()
            {
                Reservation = new(),
                Reservations = null,
                Rooms = await _roomService.GetAllRoomsAsync(filter: null, orderBy: null, b => b.RoomReservations!),
                RoomReservations = null
            };
            switch (status)
            {
                case "isActive":
                    model.Reservations = await _reserveService.GetAllReservationsAsync(filter: x => x.StartTime == DateTime.MinValue, orderBy: null, l => l.User!, l => l.RoomReservations!);
                    break;
                default:
                    model.Reservations = await _reserveService.GetAllReservationsAsync(filter: null, orderBy: x => x.OrderByDescending(l => l.ReservationID), l => l.User!, l => l.RoomReservations!);
                    break;
            }
            foreach (var reservation in model.Reservations)
            {
                model.Reservation = _reserveService.GetReservationOrDefault(x => x.ReservationID == reservation.ReservationID, includeProperties: "RoomReservations");
                model.RoomReservations = await _roomReservationService.GetAllRoomReservationsAsync(filter: l => (l.ReservationID == reservation.ReservationID), orderBy: null, b => b.Reservation!, b => b.Room!);
            }
            model.Rooms = await _roomService.GetAllRoomsAsync(filter: null, orderBy: null, b => b.RoomReservations!);
            return View(model);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                try
                {
                    IReadOnlyList<RoomReservation> roomReservations = await _roomReservationService.GetAllRoomReservationsAsync(x => x.ReservationID == id);
                    foreach (var room in roomReservations)
                    {
                        Room roomReservation = await _roomService.GetByIDAsync(room.RoomID);
                        roomReservation.IsAvailable = true;
                        await _roomService.UpdateAsync(roomReservation);
                    }
                    _roomReservationService.RemoveRange(roomReservations);
                    await _reserveService.DeleteAsync(id);
                    return Json(new { success = true, message = "Reservation Deleted Succesfully" });
                }
                catch (DbException)
                {
                    return Json(new { error = true, message = "Something Went Wrong." });
                }
            }
            return Json(new { error = true, message = "An Unexpected Error Occured." });
        }

    }
}