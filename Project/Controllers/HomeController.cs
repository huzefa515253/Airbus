using Airbus.Data.Command;
using Airbus.Data.Data;
using Airbus.Data.ReadQuery;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private IDbContext _dbContext;

        
        public HomeController()
        {
            _dbContext = DatabaseConnection.GetConnection();
        }
        public ActionResult Index()
        {

            var command = new GetData();
            var result=_dbContext.Execute(command);


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}