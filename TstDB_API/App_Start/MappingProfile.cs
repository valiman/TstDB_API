using AutoMapper;
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
            CreateMap<Auction, Dto.AuctionDTO>();//.ForMember(o => o.DtoUser, opt => opt.MapFrom(src => src.User));
            CreateMap<User, Dto.UserDTO>();
            CreateMap<User, Dto.AuctionUserDTO>();//.ForMember(o => o.Name, opt => opt.Ignore());
        }
    }
}