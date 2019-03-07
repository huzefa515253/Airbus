using System;
using System.Collections.Generic;
using System.Text;

namespace Airbus.Data.ReadModel
{
    public class Flight
    {
        Id 
PlaneId uniqueidentifier, 
HarnessLength int,
GrossWeight int,
AtmosphericPressure int,
RoomTemperature int,
SourceAirport nvarchar(max),
DestinationAirport nvarchar(max),
FuelCapacityOnLeftWing int,
FuelCapacityOnRightWing int,
FuelQuentityOnLeftWing int,
FuelQuentityOnRightWing int,
MaximumAltitudeToBeReached int,
FlightNumber nvarchar(max),
DepartureDateTime datetime,
JourneyDurationInMin int,


        Guid? Id { get; set; }
        Guid? PlaneId { get; set; }
        int HarnessLength { get; set; }
        int GrossWeight { get; set; }
        int AtmosphericPressure { get; set; }
        
        int FuelQuentityOnLeftWing { get; set; }
        int FuelQuentityOnRightWing { get; set; }
        int MaximumAltitudeToBeReached { get; set; }
        string FlightNumber { get; set; }
    }
}
