using UniLibrary.Factories;

namespace UniLibrary.Models
{

    public class RoomReservation
    {
        public int RoomID { get; set; }
        public Room? Room { get; set; }
        public int ReservationID { get; set; }
        public Reservation? Reservation { get; set; }
    }

}