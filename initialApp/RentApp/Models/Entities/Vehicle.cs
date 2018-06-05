using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentApp.Models.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Manufactor { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public decimal PricePerHour { get; set; }
        public bool Unavailable { get; set; }
       
        public List<string> Images { get; set; }
        public virtual TypeOfVehicle Type { get; set; }

    }
}