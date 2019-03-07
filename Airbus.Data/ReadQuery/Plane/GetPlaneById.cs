using Airbus.Data.ReadModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Airbus.Data.ReadQuery.Planes
{
    public class GetPlaneById : BaseQuery<Plane>
    {
        Guid PlaneId;
        public GetPlaneById(Guid planeId)
        {
            PlaneId = planeId;
        }

        public override Plane Execute(IDbConnection db)
        {
            return db.Query<Plane>("Select * from Plane where Id=@Id", new { @Id = PlaneId }).FirstOrDefault();
        }

        
    }
}
