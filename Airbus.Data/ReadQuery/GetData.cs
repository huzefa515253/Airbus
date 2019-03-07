using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Airbus.Data.ReadQuery
{
    public class GetData : BaseQuery<dynamic>
    {
        public override dynamic Execute(IDbConnection db)
        {
            return db.Query<dynamic>("select * from [UserEvidences]");
        }
    }
}
