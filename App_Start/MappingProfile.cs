using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MovieWebApp.Models;
using MovieWebApp.Dtos;

namespace MovieWebApp.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
 
            // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MemberShipType, MembershipTypeDto>();
         
            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt =>opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>()
            .ForMember(c => c.ID, opt =>opt.Ignore());
 
        }
    }
}