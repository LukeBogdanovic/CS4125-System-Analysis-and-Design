using System.ComponentModel.DataAnnotations;

namespace UniLibrary.Models
{
public abstract class Room
    {
        public int ID { get; set; }
        public string Name {get; set;}
        public int Capacity {get; set;}
        public int Floor {get; set;}
    }
}