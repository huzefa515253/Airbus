using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Airbus.Data.ReadQuery.Flights
{
    public class GetFlightConsumptionByFlightId : BaseQuery<dynamic>
    {

        Guid? FlightId;

        public GetFlightConsumptionByFlightId(Guid flightId)
        {
            FlightId = flightId;
        }

        public override dynamic Execute(IDbConnection db)
        {
            var query = @" Select (FuelQuentityOnLeftWing+FuelQuentityOnRightWing) as totalfuel, ([FuelConsumptionPerMin]*JourneyDurationInMin) as fuelConsum, ((([FuelConsumptionPerMin]*JourneyDurationInMin) *100)/((FuelQuentityOnLeftWing+FuelQuentityOnRightWing) )) as PercentageConsume  from Flights f
  inner join Plane p on f.PlaneId=p.Id
  inner join PlaneModel pm on pm.Id=p.ModelNumber where f.Id=@Id";
            return db.Query<dynamic>(query, new { @Id = FlightId });
            
        }
    }
}
