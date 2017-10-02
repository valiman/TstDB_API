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
using Newtonsoft.Json.Linq;
using System.Data.Entity.Migrations;

namespace TstDB_API.Controllers
{
    public class AuctionController : ApiController
    {
        DBContext dbC = new DBContext();

        //Returns auctions only.
        [Route("api/Auction/GetAuctions")]
        public IHttpActionResult GetAuctions()
        {
            var auctions = dbC.Auction
                .Include(o => o.User)
                .Select(Mapper.Map<Auction, Dto.AuctionDTO>)
                .ToList();

            return Ok(auctions);
        }

        //Returns users & auctions.
        [Route("api/Auction/GetUsers")]
        public IHttpActionResult GetUsers()
        {
            var users = dbC.User.Select(Mapper.Map<User, Dto.UserDTO>).ToList();

            return Ok(users);
        }

        //These post calls have to be token-authenticated.
        [Route("api/Auction/CreateAuction")]
        public IHttpActionResult CreateAuction([FromBody]JObject data)
        {
            User _user = data["User"].ToObject<User>();
            Auction _auction = data["Auction"].ToObject<Auction>();

            //check if either object is null
            if (_user == null || _auction == null)
            {
                var message = "Either user or auction is missing.";
                return BadRequest(message);
            }

            //get real user
            var _dbUser = dbC.User.FirstOrDefault(o => o.Id_IdentityUser == _user.Id_IdentityUser);

            if (_dbUser == null)
            {
                var message = "User identity could not be found.";
                return BadRequest(message);
            }

            //set real user w/ real data
            _auction.User = _dbUser;
     
            //add
            dbC.Auction.Add(_auction);
            
            try
            {
                dbC.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
