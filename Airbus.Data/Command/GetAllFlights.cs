using Airbus.Data.ReadModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;

namespace Airbus.Data.Command
{
    public class GetAllFlights : BaseQuery<IEnumerable<Flight>>
    {
        public override IEnumerable<Flight> Execute(IDbConnection db)
        {
            return db.Query<Flight>("Select * from Flight");
        }
    }
}
