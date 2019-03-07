using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;

namespace Airbus.Data.Data
{
    public class DbContext : IDbContext
    {
        private readonly IDbConnection db;

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        public IDbConnection Connection
        {
            get
            {
                return db;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContext"/> class.
        /// </summary>
        /// <param name="dbconnection">The dbconnection.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public DbContext(IDbConnection dbconnection)
        {
            //if (dbconnection == null)
            //    throw new ArgumentNullException(string.Format(Resources_Core.ArgumentNull, "dbconnection"));

            this.db = dbconnection;

            if (this.db.State == ConnectionState.Closed)
                db.Open();
        }

        /// <summary>
        /// Queries the specified query.
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>Entity Type</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public T Execute<T>(IQuery<T> query)
        {
            //if (query == null)
            //    throw new ArgumentNullException(string.Format(Resources_Core.ArgumentNull, "query"));

            return query.Execute(db);
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public void Execute(IQuery command)
        {
            //if (command == null)
            //    throw new ArgumentNullException(string.Format(Resources_Core.ArgumentNull, "command"));

            command.Execute(db);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            //This is called when Dispose is called explicitly by calling class
            //This ensures that both managed and unmanaged resources are released explicitly

            Dispose(true);

            //Supress the finalization process since we have already dsoposed the object
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                //Release managed resources
                if (this.db != null)
                {
                    if (this.db.State != ConnectionState.Closed)
                        this.db.Close();
                }
            }
        }
    }
}
