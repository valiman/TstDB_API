using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TstDB_API.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TstDB_API.DAL
{
    public class DBContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Auction> Auction { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasMany<Auction>(c => c.Auctions).WithRequired(c => c.User).WillCascadeOnDelete(true); //add key here.
        }
    }
}