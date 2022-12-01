using UniLibrary.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniLibrary.Factories;

namespace UniLibrary.ViewModels
{

    public class ReservationViewModel
    {
        [ValidateNever]
        public Reservation? Reservation { get; set; }
        [ValidateNever]
        public IReadOnlyList<Reservation>? Reservations { get; set; }
        [ValidateNever]
        public IReadOnlyList<Room>? Rooms { get; set; }
        [ValidateNever]
        public IReadOnlyList<RoomReservation>? RoomReservations { get; set; }
        [ValidateNever]
        public Room? Room { get; set; }

    }

}