using Airbus.Data.ReadModel;
using Airbus.Data.ReadQuery.Planes;
using AutoMapper;
using Domain.Interface;
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
        private IDbContext _dbContext = DatabaseConnection.GetConnection();

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
            return new CustomJsonResult(new { Data = PlaneBusiness.GetPlaneById(planeId) }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetPlaneByMSN(string msn)
        {
            var command = new GetPlaneByMSN(msn);
            var result = _dbContext.Execute(command);
            var data=Mapper.Map<Plane, PlaneViewModel>(result);
            return View(data);
            //return new CustomJsonResult(new { Data = result }, JsonRequestBehavior.AllowGet); ;
            
        }
        
    }
}