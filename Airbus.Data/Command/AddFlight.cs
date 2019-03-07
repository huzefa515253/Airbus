using Airbus.Data.ReadModel;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Airbus.Data.Command
{
    public class AddFlight : BaseQuery
    {
        public override void Execute(IDbConnection db)
        {
            db.Execute("insert into abc");
        }
    }
}
