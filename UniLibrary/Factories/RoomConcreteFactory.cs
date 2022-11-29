using UniLibrary.Models.Utilities;
using UniLibrary.Interfaces;
using UniLibrary.Models.Enums;
using UniLibrary.Factories;

namespace UniLibrary.Models
{
    public static class RoomConcreteFactory
    {
        public static Room getRoom(Rooms RoomType)
        {
            switch (RoomType)
            {
                case Rooms.ConferenceRoom:
                    return new ConferenceRoom();
                case Rooms.ComputerRoom:
                    return new ComputerClassRoom();
                case Rooms.MeetingRoom:
                    return new MeetingRoom();
                case Rooms.StudyRoom:
                    return new StudyRoom();
                default:
                    throw new ApplicationException(string.Format("Room cannot be created ", RoomType));
            }
        }
    }
}