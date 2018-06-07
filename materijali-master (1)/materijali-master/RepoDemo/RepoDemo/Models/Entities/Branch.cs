using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RepoDemo.Models.Entities
{
    public class Branch
    {
        public int BranchId { get; set; }

        public double Longitude { get; set; }
        public double Latitute { get; set; }
        [Required]
        public string Address { get; set; }

        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
    }
}