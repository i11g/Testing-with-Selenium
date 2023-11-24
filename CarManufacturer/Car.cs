using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        //private string make;
        //private string model;
        //private int year;

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

    }

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car= new Car();

            car.Make = "VM";
            car.Model = "MK3";
            car.Year = 1992;

            Console.WriteLine($"Make:{car.Make}\nModel:{car.Model}\nYear:{car.Year}");
        }
        
    } 
    
}