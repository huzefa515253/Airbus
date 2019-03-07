using Airbus.Data.ReadModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Airbus.Data.ReadQuery.Planes
{
    public class GetPlaneByMSN : BaseQuery<Plane>
    {

        string MSN;
        public GetPlaneByMSN(string msn)
        {
            MSN = msn;
        }

        public override Plane Execute(IDbConnection db)
        {

            return db.Query<Plane>("Select * from Plane where MSN=@MSN", new { @MSN = MSN }).FirstOrDefault();



        }
    }
}
