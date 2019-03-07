using Airbus.Data.Data;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Project
{
    public class DatabaseConnection
    {

        public static IDbContext GetConnection()
        {
           return new DbContext(CreateConnection(ConfigurationManager.ConnectionStrings["Airbus"].ConnectionString));
        }

        private static IDbConnection CreateConnection(string connectionString)
        {
            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            var cnn = factory.CreateConnection();
            cnn.ConnectionString = connectionString;
            cnn.Open();

            return cnn;
        }
    }
}