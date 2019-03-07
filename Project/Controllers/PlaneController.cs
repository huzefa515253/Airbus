using Airbus.Data.ReadModel;
using Project.Business;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class PlaneController : Controller
    {
        private FlightsBusiness FlightsBusiness;
        private PlaneBusiness PlaneBusiness;

        public PlaneController()
        {

            FlightsBusiness = new FlightsBusiness();
            PlaneBusiness = new PlaneBusiness();
        }
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreatePlane(PlaneViewModel flight)
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreatePlane()
        {
            return View();
        }

        public ActionResult GetAllPlanes()
        {
            return new CustomJsonResult(new { Data = PlaneBusiness.GetAllPlane() }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPlanesById(Guid planeId)
        {
            return new CustomJsonResult(new { Data = FlightsBusiness.GetFlightBYId(planeId) }, JsonRequestBehavior.AllowGet);

        }

    }
}