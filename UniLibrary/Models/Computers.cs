using UniLibrary.Interfaces;

namespace UniLibrary.Models
{
    public abstract class Computer
    {
        private List<IAvailabilityObserver> obs = new List<IAvailabilityObserver>();

        public int ID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? ComNum { get; set; }
        [Required]
        [StringLength(30)]
        public string? OS { get; set; }
        [StringLength(30)]
        [Required]
        public bool Availability { get; set; }

        //constructer 
        public Computer(int ID, string? ComNum, string? OS)
        {
            this.ID = ID;
            this.ComNum = ComNum;
            this.OS = OS;
            this.Availability = true;
        }

        //adds observer to the computer object

        public void Attach(IAvailabilityObserver x)
        {
            obs.Add(x);
        }
        //takes observer off the computer object

        public void Detach(IAvailabilityObserver x)
        {
            obs.Remove(x);
        }

        //Goes through the list of observers attached to an object and runs the update function
        //on them all. This is run anytime the availability of a computer is changed.
        public void Notify()
        {   
            foreach (IAvailabilityObserver x in obs)
            {
                x.clearLists();
                
            }
            foreach (IAvailabilityObserver x in obs)
            {
                x.Update(x);
                
            }
        }

        //Changes availability of the computer object and runs the Notify function.
        public void ChangeAvailability(Computer comp, bool x)
        {
            comp.Availability = x;
            Notify();
        }
    }
    public class PC : Computer
    {
        //constructer
        public PC(int ID, string? ComNum, string? OS)
        : base(ID, ComNum, OS)
        {
        }


    }



    public class Laptop : Computer
    {
        //constructer
        public Laptop(int ID, string? ComNum, string? OS)
        : base(ID, ComNum, OS)
        {
        }
    }

}
