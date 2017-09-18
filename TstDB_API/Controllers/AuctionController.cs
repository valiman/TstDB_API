using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TstDB_API.DAL;

namespace TstDB_API.Controllers
{
    public class AuctionController : ApiController
    {
        DBContext dbC = new DBContext();
        
        public IHttpActionResult GetAuctions()
        {
            var auctions = dbC.Auction.ToList();

            return Ok(auctions);
        }
    }
}
