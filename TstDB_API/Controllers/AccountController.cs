using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TstDB_API.DAL;
using TstDB_API.Models;

namespace TstDB_API.Controllers
{
    public class AccountController : ApiController
    {
        private AuthRepo dbc = null;

        public AccountController()
        {
            dbc = new AuthRepo();
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserLogin userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await dbc.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        // POST api/Account/Register
        [Authorize]
        [Route("GetUserData")]
        public IHttpActionResult GetUserData()
        {
            //var userId = User.Identity.GetUserId();
            //var user = dbc.FindUser.Single(o => o.Id == userId);
            //var auctions = dbC.Auction.Where(o => o.User.Id_IdentityUser == user.Id_IdentityUser).ToList();



            //user.Auctions = auctions;
            /*
            var user = dbc.GetUser();

            if (user == null)
            {
                return BadRequest("User could no be found.");
            }
            */
            var user = dbc.GetUser();
            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbc.Dispose();
            }

            base.Dispose(disposing);
        }
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
