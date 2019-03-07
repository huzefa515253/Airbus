using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Airbus.Data.ReadModel;
using Dapper;

namespace Airbus.Data.ReadQuery.Flights
{
    public  class GetAllFlights : BaseQuery<IEnumerable<Flight>>
    {
        
            public override IEnumerable<Flight> Execute(IDbConnection db)
            {
                return db.Query<Flight>("Select * from Flights");
            }
        
    }
}
