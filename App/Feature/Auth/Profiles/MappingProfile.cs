﻿using AutoMapper;
using Business.Feature.Auth.Commands.Register;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Feature.Auth.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, RegisterCommand>().ReverseMap();
        }
    }
}
