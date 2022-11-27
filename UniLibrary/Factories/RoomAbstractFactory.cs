using UniLibrary.Interfaces;
namespace UniLibrary.Models
{
    public abstract class RoomAbstractFactory{
        public abstract IRoom CreateRoom(string type);
    }
}
