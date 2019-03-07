using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class PlaneViewModel
    {
        public Guid? Id { set; get; }
        public Guid? ModelNumber { set; get; }
        public DateTime ManufacturingDate { set; get; }
        int FuelCapacityOnLeftWing { get; set; }
        int FuelCapacityOnRightWing { get; set; }
       
    }
}