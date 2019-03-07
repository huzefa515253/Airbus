using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace Airbus.Data
{
    public abstract class BaseQuery<T> : IQuery<T>, IOracleQuery<T>
    {
        public abstract T Execute(IDbConnection db);

        public virtual T ExecuteOra(IDbConnection db)
        {
            return Execute(db);
        }
    }

    public abstract class BaseQuery : IQuery, IOracleQuery
    {
        public abstract void Execute(IDbConnection db);


        public virtual void ExecuteOra(IDbConnection db)
        {
            Execute(db);
        }
    }
}
