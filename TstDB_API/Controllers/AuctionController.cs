using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TstDB_API.DAL;
using System.Data.Entity; //enables IQueryable for include in the dbContext
//using TstDB_API.Models;
using AutoMapper;
using Newtonsoft.Json.Linq;
using System.Data.Entity.Migrations;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using TstDB_API.Models;

namespace TstDB_API.Controllers
{
    [Authorize]
    public class AuctionController : ApiController
    {
        DBContext dbC = new DBContext();

        /*
        //Returns auctions only.
        [AllowAnonymous]
        [Route("api/Auction/GetAuctions")]
        public IHttpActionResult GetAuctions()
        {
            var auctions = dbC.Auction
                .Include(o => o.User)
                .Select(Mapper.Map<Auction, Dto.AuctionDTO>)
                .ToList();

            return Ok(auctions);
        }
        */
            
        //Returns users & auctions.
        [Route("api/Auction/GetUsers")]
        public IHttpActionResult GetUsers()
        {
            var users = dbC.User.Select(Mapper.Map<User, Dto.UserDTO>).ToList();

            return Ok(users);
        }

        //These post calls have to be token-authenticated.
        [Authorize]
        [Route("api/Auction/CreateAuction")]
        public IHttpActionResult CreateAuction([FromBody]JObject data)
        {
            //We use the User that is provided by the ApiController (principal)
            //User _user = data["User"].ToObject<User>();
            var userId = User.Identity.GetUserId();
            Auction _auction = data["Auction"].ToObject<Auction>();

            //check if either object is null
            if (_auction == null || userId == null)
            {
                var message = "Either user or auction is missing.";
                return BadRequest(message);
            }

            //get real user
            //check on Username instead of identity
            var _user = dbC.User.Include(o=>o.Auctions).FirstOrDefault(o => o.Id == userId);
            
            if (_user == null)
            {
                var message = "User identity could not be found.";
                return BadRequest(message);
            }
            
            //debug
            if (_user.Auctions == null)
            {
                return BadRequest("auctions array is null.");
            }
            
            //add auction to user
            _user.Auctions.Add(_auction); //teh fuq

            //add auction to table.
            dbC.Auction.Add(_auction);
            
            try
            {
                dbC.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Auction created.");
        }
    }
}
