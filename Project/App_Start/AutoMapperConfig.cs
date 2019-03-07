using Airbus.Data.ReadModel;
using AutoMapper;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Flight, FlightViewModel>();
            Mapper.CreateMap<Flight, FlightViewModel>().ReverseMap();

            Mapper.CreateMap<Plane, PlaneViewModel>();
            Mapper.CreateMap<Plane, PlaneViewModel>().ReverseMap();

        }
    }
}