using System;
using System.Collections.Generic;
using System.Text;

namespace Airbus.Data.ReadModel
{
    public class Airport
    {
        public Guid? Id { set; get; }
        public string Name { set; get; }
        public string CityName { set; get; }

    }
}
