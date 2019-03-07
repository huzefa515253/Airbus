using Airbus.Data.Data;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Autofac.Integration.Mvc;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Project.App_Start
{
    public class IocConfig
    {
        public static void Build()
        {
            var builder = new ContainerBuilder();
            builder.Register(c =>
                new DbContext(CreateConnection(ConfigurationManager.ConnectionStrings["DigitalCockpit"].ConnectionString)))
                .As<IDbContext>().InstancePerRequest();

        }
        private static IDbConnection CreateConnection(string connectionString)
        {
            //The connection is created from a factory since this is required by the Glimpse.Ado to capture 
            //any database calls.
            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            var cnn = factory.CreateConnection();
            cnn.ConnectionString = connectionString;
            cnn.Open();

            return cnn;
        }
    }
}