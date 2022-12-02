using UniLibrary.Models;

namespace UniLibrary.Interfaces
{
    public interface IAvailabilityObserver
    {
        void Update(IAvailabilityObserver x);
        Computer GetComputer();
        void clearLists();
    }
}