using Airbus.Data.ReadModel;
using Airbus.Data.ReadQuery.Flights;
using AutoMapper;
using Domain.Interface;
using Newtonsoft.Json;
using Project.Business;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class FlightController : Controller
    {
        private IDbContext _dbContext=DatabaseConnection.GetConnection();
        
        private FlightsBusiness FlightsBusiness;

        public FlightController()
        {
            
            FlightsBusiness = new FlightsBusiness();
        }
        

        public ActionResult GetAllFlights()
        {
            return new CustomJsonResult(new {Data=FlightsBusiness.GetAllFlights() }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFlightBYId(Guid flightId)
        {
            return new CustomJsonResult(new { Data = FlightsBusiness.GetFlightBYId(flightId) }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult CreateFlight()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFlight(FlightViewModel flight)
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddFlight()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetFlightBetweenSourceAndDestination(string source,string destination)
        {
            var command = new FetchFlightBetweenSourceAndDestinationCity(source, destination);
            var result=_dbContext.Execute(command);
            var data = Mapper.Map<IEnumerable<Flight>, IEnumerable<FlightViewModel>>(result);

            return View(data);
            //return new CustomJsonResult(new { Data = result }, JsonRequestBehavior.AllowGet); ;
        }

        [HttpGet]
        public ActionResult GetFlightByModelName(string modelName)
        {
            var command = new FetchFlightByModel(modelName);
            var result = _dbContext.Execute(command);

            
            return new CustomJsonResult(new { Data = result }, JsonRequestBehavior.AllowGet); 
        }


    }
}