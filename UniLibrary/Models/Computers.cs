using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UniLibrary.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniLibrary.Models
{
    public abstract class Computer
    {
        private List<IAvailabilityObserver> obs = new List< IAvailabilityObserver>();

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

        public void Attach(IAvailabilityObserver x)
        {
            obs.Add(x);
        }
        public void Detach(IAvailabilityObserver x)
        {
            obs.Remove(x);
        }
        public void Notify()
        {
            foreach (IAvailabilityObserver x in obs)
            {
                //x.Update(this);
            }
        }
    }
    public class PC : Computer
    {
        //constructer
        public PC (int ID, string? ComNum, string? OS)
        : base(ID, ComNum, OS)
        {
        }
    }

    public class Laptop : Computer
    {
        //constructer
        public Laptop (int ID, string? ComNum, string? OS)
        : base(ID, ComNum, OS)
        {
        }
    }

    public abstract class IAvailabilityObserver
    {
        public abstract void Update();
    }

    public class PCAvailabilityObserver : IAvailabilityObserver
    {
        private string ComNum;
        private PC pc;


        // Constructor

        public PCAvailabilityObserver(PC pc, string ComNum)
        {
            this.pc = pc;
            this.ComNum = ComNum;
        }

        public override void Update()
        {
           
        }
    }

    public class LaptopAvailabilityObserver : IAvailabilityObserver
    {
        private string ComNum;
        private PC pc;


        // Constructor

        public LaptopAvailabilityObserver(PC pc, string ComNum)
        {
            this.pc = pc;
            this.ComNum = ComNum;
        }

        public override void Update()
        {
           
        }
    }
} 




    

