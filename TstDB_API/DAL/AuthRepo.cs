using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TstDB_API.Models;

namespace TstDB_API.DAL
{
    public class AuthRepo : IDisposable
    {
        private DBContext _ctx;

        private UserManager<IdentityUser> _userManager;

        public AuthRepo()
        {
            _ctx = new DBContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserLogin userLogin)
        {
            IdentityUser idUser = new IdentityUser
            {
                UserName = userLogin.UserName
            };

            var result = await _userManager.CreateAsync(idUser, userLogin.Password);

            if (result.Succeeded)
            {
                var user = new User()
                {
                    CreationDate = DateTime.Now,
                    Id_IdentityUser = idUser.Id,
                    UserName = idUser.UserName
                };

                _ctx.User.Add(user);
                _ctx.SaveChanges();
            }

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }
    }
}