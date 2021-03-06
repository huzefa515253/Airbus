﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Airbus.Data.ReadModel
{
    public class Flight
    {
        public Guid? Id { get; set; }
        public Guid? PlaneId { get; set; }
        public int HarnessLength { get; set; }
        public int GrossWeight { get; set; }
        public int AtmosphericPressure { get; set; }

        public int FuelQuentityOnLeftWing { get; set; }
        public int FuelQuentityOnRightWing { get; set; }
        public int MaximumAltitudeToBeReached { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public int JourneyDurationInMin { get; set; }

        public Plane Plane { get; set; }
    }
}
