using UniLibrary.Models;

namespace UniLibrary.Interfaces
{
    public interface IRoom
    {
        abstract T CreateRoom<T>(string type);
    }
}