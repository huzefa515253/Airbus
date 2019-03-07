using Airbus.Data.ReadModel;
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
    }
}