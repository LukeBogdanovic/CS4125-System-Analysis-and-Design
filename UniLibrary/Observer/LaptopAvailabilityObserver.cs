using UniLibrary.Models;
using UniLibrary.Interfaces;

namespace UniLibrary.Observer
{

    public class LaptopAvailabilityObserver : IAvailabilityObserver
    {
        private string ComNum;
        private Laptop laptop;
        public List<Computer> available = new List<Computer>();
        public List<Computer> unavailable = new List<Computer>();


        // Constructor
        public LaptopAvailabilityObserver(Laptop laptop, string ComNum)
        {
            this.laptop = laptop;
            this.ComNum = ComNum;

        }
        public Computer GetComputer()
        {
            return laptop;
        }

        public void Update(IAvailabilityObserver x)
        {
            if (x.GetComputer().Availability == true)
            {
                available.Add(x.GetComputer());
            }
            else
            {
                unavailable.Add(x.GetComputer());
            }

        }
    }

}