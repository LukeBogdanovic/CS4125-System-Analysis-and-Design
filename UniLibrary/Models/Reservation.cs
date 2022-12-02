namespace UniLibrary.Models
{

    public class Reservation
    {

        public int ReservationID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int UserID { get; set; }
        public List<RoomReservation>? RoomReservations { get; set; }
        public User? User { get; set; }

    }

}