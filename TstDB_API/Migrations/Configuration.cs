namespace TstDB_API.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TstDB_API.Models;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<TstDB_API.DAL.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TstDB_API.DAL.DBContext context)
        {
            //Create Id_User
            var IdUser_One = new IdentityUser("KniX");
            var IdUser_Two = new IdentityUser("isSoCoool");

            context.Users.AddOrUpdate(IdUser_One);
            context.Users.AddOrUpdate(IdUser_Two);
            //

            //Create Auction
            var auction_One = new Auction()
            {
                BidPrice = 1,
                BuyoutPrice = 1338,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };

            var auction_Two = new Auction()
            {
                BidPrice = 2,
                BuyoutPrice = 1336,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };

            context.Auction.AddOrUpdate(auction_One);
            context.Auction.AddOrUpdate(auction_Two);

            //Create User
            var user_One = new User()
            {
                Id_IdentityUser = IdUser_One.Id,
                CreationDate = DateTime.Now,
                Auctions = new List<Auction> { auction_One }
            };

            var user_Two = new User()
            {
                Id_IdentityUser = IdUser_Two.Id,
                CreationDate = DateTime.Now,
                Auctions = new List<Auction> { auction_Two }
            };

            context.User.AddOrUpdate(user_One);
            context.User.AddOrUpdate(user_Two);

            //

            //Save to db
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
