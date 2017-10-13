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
using TstDB_API.Dto;

namespace TstDB_API.Controllers
{
    [Authorize]
    public class AuctionController : ApiController
    {
        DBContext dbC = new DBContext();
        
        //Returns auctions only.
        [AllowAnonymous]
        [Route("api/Auction/GetAuctions")]
        public IHttpActionResult GetAuctions()
        {
            //Due to tables being bound in a way to avoid cross ref we have to
            //work data backwards. :/ fix dis
            var auctions = dbC.User.Include(o => o.Auctions).Where(a => a.Auctions.Count > 0).ToList();
            
            return Ok(auctions);
        }
            
        //Returns users & auctions.
        [Route("api/Auction/GetUsers")]
        public IHttpActionResult GetUsers()
        {
            var users = dbC.User.Select(Mapper.Map<User, UserDTO>).ToList();
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
            var _user = dbC.User.Include(o => o.Auctions).FirstOrDefault(o => o.Id == userId);
            
            if (_user == null)
            {
                var message = "User identity could not be found.";
                return BadRequest(message);
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
