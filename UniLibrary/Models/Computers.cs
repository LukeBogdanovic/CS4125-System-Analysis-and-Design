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
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? PCNum { get; set; }
        [Required]
        [StringLength(30)]
        public string? OS { get; set; }
        [StringLength(30)]
        [Required]
        public bool Availability { get; set; }   

        //constructer 
        public Computer(int ID, string? PCNum, string? OS)
        {
            this.ID = ID;
            this.PCNum = PCNum;
            this.OS = OS;
            this.Availability = true;
        }
    }

    public class PC : Computer
    {
        //constructer
        public PC (int ID, string? PCNum, string? OS)
        : base(ID, PCNum, OS)
        {
        }
    }

    // public abstract class ComputerObserver
    // {
    //     public abstract void Update();
    // }

    // public class ConcreteObserver : ComputerObserver
    // {
    //     private string name;
    //     private string observerState;
    //     private PC subject;

    //     // Constructor

    //     public ConcreteObserver(
    //         PC pc, string name)
    //     {
    //         this.subject = subject;
    //         this.name = name;
    //     }

    //     public override void Update()
    //     {
    //        // observerState = subject.SubjectState;
    //         Console.WriteLine("Observer {0}'s new state is {1}",
    //             name, observerState);
    //     }
    // }
}



    

