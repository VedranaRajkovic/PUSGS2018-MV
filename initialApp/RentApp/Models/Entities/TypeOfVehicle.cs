using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentApp.Models.Entities
{
    public class TypeOfVehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}