using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TstDB_API.DAL;
using System.Data.Entity; //enables IQueryable for include in the dbContext
using TstDB_API.Models;
using AutoMapper;

namespace TstDB_API.Controllers
{
    public class AuctionController : ApiController
    {
        DBContext dbC = new DBContext();

        //Returns auctions only.
        [Route("api/Auction/GetAuctions")]
        public HttpResponseMessage GetAuctions()
        {
            var auctions = dbC.Auction.Include(o => o.User).Select(Mapper.Map<Auction, Dto.DtoAuction>).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, auctions);
        }

        //Returns users & auctions.
        [Route("api/Auction/GetUsers")]
        public HttpResponseMessage GetUsers()
        {
            var users = dbC.User.Include(o => o.Auctions).Select(Mapper.Map<User, Dto.DtoUser>).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, users);
        }


    }
}
