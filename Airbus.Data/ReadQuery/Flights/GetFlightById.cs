using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Airbus.Data.ReadModel;
using Dapper;
using System.Linq;

namespace Airbus.Data.ReadQuery.Flights
{
    public class GetFlightById : BaseQuery<Flight>
    {
        Guid FlightId;
        public GetFlightById(Guid flightId)
        {
            FlightId = flightId;
        }

        public override Flight Execute(IDbConnection db)
        {
            return db.Query<Flight>("Select * from Flight where Id=@Id", new { @Id = FlightId }).FirstOrDefault();
        }
    }
}
