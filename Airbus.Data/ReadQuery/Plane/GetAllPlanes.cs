using Airbus.Data.ReadModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Airbus.Data.ReadQuery.Planes
{
    public class GetAllPlanes : BaseQuery<IEnumerable<Plane>>
    {
       

        public override IEnumerable<Plane> Execute(IDbConnection db)
        {
            return db.Query<Plane>("Select * from Plane");
        }
    }
}
