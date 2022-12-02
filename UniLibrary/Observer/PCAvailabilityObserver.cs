using UniLibrary.Models;
using UniLibrary.Interfaces;

namespace UniLibrary.Observer
{

    public class PCAvailabilityObserver : IAvailabilityObserver
    {
        private string ComNum;
        private PC pc;
        public List<Computer> available = new List<Computer>();
        public List<Computer> unavailable = new List<Computer>();


        // Constructor

        public PCAvailabilityObserver(PC pc, string ComNum)
        {
            this.pc = pc;
            this.ComNum = ComNum;
        }

        //Clears both the available and unavilable lists and sorts through the computers,
        //putting them in the list that corresponds to their availability.
        public void Update(IAvailabilityObserver x)
        {
            available.Clear();
            unavailable.Clear();
            if (x.GetComputer().Availability == true)
            {
                available.Add(x.GetComputer());
            }
            else
            {
                unavailable.Add(x.GetComputer());
            }

        }

        public Computer GetComputer()
        {
            return pc;
        }
    }

}