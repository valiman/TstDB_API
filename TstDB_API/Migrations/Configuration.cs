namespace TstDB_API.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TstDB_API.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<TstDB_API.DAL.DBContext>
    {
        public Configuration()
        {

            //not recommended for web app.. alltho this will be used for an API.. interesting.
            AutomaticMigrationsEnabled = true;
            
        }

        protected override void Seed(TstDB_API.DAL.DBContext context)
        {
            //same as above, ms style :)
            context.User.AddOrUpdate(o => o.Name,
                new User
                {
                    Name = "KniX",
                    CreationDate = DateTime.Now,
                    Auctions = new List<Auction>()
                    {
                       new Auction()
                        {
                            BidPrice = 8,
                            BuyoutPrice = 9,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddYears(1)
                        }
                    }
                });

            context.User.AddOrUpdate(o => o.Name,
                new User
                {
                    Name = "isSoCool",
                    CreationDate = DateTime.Now,
                    Auctions = new List<Auction>()
                    {
                       new Auction()
                        {
                            BuyoutPrice = 8,
                            BidPrice = 9,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddYears(1)
                        }
                    }
                });


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
