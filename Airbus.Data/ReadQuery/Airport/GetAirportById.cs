using Airbus.Data.ReadModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Airbus.Data.ReadQuery.Airports
{
    public class GetAirportById : BaseQuery<Airport>
    {
        Guid AirportId;
        public GetAirportById(Guid airportId)
        {
            AirportId = airportId;
        }

        public override Airport Execute(IDbConnection db)
        {
            return db.Query<Airport>("Select * from Airport where Id=@Id", new { @Id = AirportId }).FirstOrDefault();
        }
        
    }
}
