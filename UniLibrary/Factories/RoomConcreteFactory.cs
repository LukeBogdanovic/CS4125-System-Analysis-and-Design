using UniLibrary.Models.Utilities;
using UniLibrary.Interfaces;

namespace UniLibrary.Models
{
    public class RoomConcreteFactory : RoomAbstractFactory
    {
        public override IRoom CreateRoom(string RoomType)
        {
            switch(RoomType)
            {
                case "Conference":
                return new ConferenceRoom()
                case "Computer":
                return new ComputerRoom()
                case "Meeting":
                return new MeetingRoom()
                case "Study":
                return new StudyRoom()
                default:
                throw new ApplicationException(string.Format("Room cannot be created ", RoomType));
            }
        }
    }
}