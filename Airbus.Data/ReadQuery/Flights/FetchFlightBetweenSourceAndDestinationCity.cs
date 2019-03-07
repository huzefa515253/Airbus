using Airbus.Data.ReadModel;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
namespace Airbus.Data.ReadQuery.Flights
{
    public class FetchFlightBetweenSourceAndDestinationCity: BaseQuery<IEnumerable<Flight>>
    {

        private string SourceCity;
        private string DestCity;

        public FetchFlightBetweenSourceAndDestinationCity(string sourceCity, string destCity)
        {
            SourceCity = sourceCity;
            DestCity = destCity;
        }

        public override IEnumerable<Flight> Execute(IDbConnection db)
        {
              return db.Query<Flight>(@"  select f.* from flights f inner join Airport a1 on f.SourceAirport=a1.Id
              inner join Airport a2 on f.DestinationAirport=a2.Id
              where a1.City=@Source and a2.City=@Dest", new { Source = SourceCity, @Dest = DestCity });
        }
    }
}
