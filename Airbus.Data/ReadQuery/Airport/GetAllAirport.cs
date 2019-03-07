using Airbus.Data.ReadModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;

namespace Airbus.Data.ReadQuery.Airports
{
    public class GetAllAirport : BaseQuery<IEnumerable<Airport>>
    {
        public override IEnumerable<Airport> Execute(IDbConnection db)
        {
            return db.Query<Airport>("Select * from Airport");
        }
    }
}
