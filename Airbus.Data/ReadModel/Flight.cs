using System;
using System.Collections.Generic;
using System.Text;

namespace Airbus.Data.ReadModel
{
    class Flight
    {
        Guid? Id { get; set; }
        Guid? ModelNumber { get; set; }
        int HarnessLength { get; set; }
        int GrossWeight { get; set; }
        int AtmosphericPressure { get; set; }
        int FuelCapacityOnLeftWing { get; set; }
        int FuelCapacityOnRightWing { get; set; }
        int FuelQuentityOnLeftWing { get; set; }
        int FuelQuentityOnRightWing { get; set; }
        int MaximumAltitudeToBeReached { get; set; }
        string FlightNumber { get; set; }
    }
}
