using Airbus.Data.ReadModel;
using Airbus.Data.ReadQuery.Flights;
using AutoMapper;
using Domain.Interface;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Business
{
    public class FlightsBusiness
    {
        private IDbContext _dbContext;

        public FlightsBusiness()
        {
            _dbContext = DatabaseConnection.GetConnection();
        }

        public  IEnumerable<FlightViewModel> GetAllFlights()
        {
            var command = new GetAllFlights();
            var data= _dbContext.Execute(command);
            var result = Mapper.Map<IEnumerable<Flight>, IEnumerable< FlightViewModel>>(data);
            return result;
        }

        public FlightViewModel GetFlightBYId(Guid flightId)
        {
            var command = new GetFlightById(flightId);
            var data= _dbContext.Execute(command);

            var result = Mapper.Map<Flight, FlightViewModel>(data);
            return result;
        }

        public void AddFlight(Flight flight)
        {
           
        }
    }
}