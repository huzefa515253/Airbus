using System;
using System.Collections.Generic;
using System.Text;

namespace Airbus.Data.ReadModel
{
    public class Plane
    {
        public Guid? Id { set; get; }
        public Guid? ModelNumber { set; get; }
        public DateTime ManufacturingDate { set; get; }
        public int FuelCapacityOnLeftWing { get; set; }
        public int FuelCapacityOnRightWing { get; set; }
        public string MSN { get; set; }
        
    }
}
