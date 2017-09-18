namespace TstDB_API.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<TstDB_API.DAL.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TstDB_API.DAL.DBContext context)
        {
            var userA = new User() { creationDate = DateTime.Now, name = "KniX" };
            userA.Auctions.Add(new Auction
            {
                startDate = DateTime.Now,
                endDate = DateTime.Now.AddYears(1),
                bidPrice = 8,
                buyoutPrice = 1336
            });
            var userB = new User() { creationDate = DateTime.Now, name = "isSoCool" };
            userB.Auctions.Add(new Auction
            {
                startDate = DateTime.Now,
                endDate = DateTime.Now.AddYears(1),
                bidPrice = 31,
                buyoutPrice = 56
            });

            //add users
            context.User.AddOrUpdate(userA);
            context.User.AddOrUpdate(userB);

            //commit
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
