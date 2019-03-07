using Airbus.Data.ReadModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Airbus.Data.ReadQuery.Flights
{
    public class FetchFlightByModel : BaseQuery<IEnumerable<Flight>>
    {
        string ModelName;

        public FetchFlightByModel(string modelname)
        {
            ModelName = modelname;
        }
        public override IEnumerable<Flight> Execute(IDbConnection db)
        {
            return db.Query<Flight>(@"select f.* from Flights f inner join Plane p on f.planeid=p.id 
  inner join PlaneModel pm on p.ModelNumber=pm.Id
  where pm.Name=@ModelName", new { @ModelName = ModelName });

        }
    }
}
