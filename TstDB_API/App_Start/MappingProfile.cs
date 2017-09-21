﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TstDB_API.Models;

namespace TstDB_API.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to dto
            CreateMap<Auction, Dto.DtoAuction>().ForMember(o => o.User, opt => opt.Ignore());
            CreateMap<User, Dto.DtoUser>();
        }
    }
}