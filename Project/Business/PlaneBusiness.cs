using Airbus.Data.ReadModel;
using Airbus.Data.ReadQuery.Flights;
using Airbus.Data.ReadQuery.Planes;
using AutoMapper;
using Domain.Interface;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Business
{
    public class PlaneBusiness
    {
        private IDbContext _dbContext;

        public PlaneBusiness()
        {
            _dbContext = DatabaseConnection.GetConnection();
        }

        public IEnumerable<PlaneViewModel> GetAllPlane()
        {
            var command = new GetAllPlanes();
            var data = _dbContext.Execute(command);
            var result = Mapper.Map<IEnumerable<Plane>, IEnumerable<PlaneViewModel>>(data);
            return result;
        }

        public PlaneViewModel GetPlaneById(Guid planeId)
        {
            var command = new GetPlaneById(planeId);
            var data = _dbContext.Execute(command);

            var result = Mapper.Map<Plane, PlaneViewModel>(data);
            return result;
        }
    }
}