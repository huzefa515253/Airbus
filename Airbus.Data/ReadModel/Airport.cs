using System;
using System.Collections.Generic;
using System.Text;

namespace Airbus.Data.ReadModel
{
    public class Airport
    {
        Guid? Id { set; get; }
        string Name { set; get; }
        string CityName { set; get; }

    }
}
