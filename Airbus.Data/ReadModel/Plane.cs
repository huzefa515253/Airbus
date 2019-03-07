using System;
using System.Collections.Generic;
using System.Text;

namespace Airbus.Data.ReadModel
{
    class Plane
    {
        public Guid? Id { set; get; }
        public Guid? ModelNumber { set; get; }
        public DateTime ManufacturingDate { set; get; }
    }
}
