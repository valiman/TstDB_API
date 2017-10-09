using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TstDB_API.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TstDB_API.DAL
{
    public class DBContext : IdentityDbContext
    {
        //Use the id db c user instead!
        public DbSet<User> User { get; set; }
        public DbSet<Auction> Auction { get; set; }

        public DBContext()
        {
            Configuration.LazyLoadingEnabled = false;
            //Configuration.ProxyCreationEnabled = false;//xref probs fix, wont include next object :(
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<User>().HasMany<Auction>(c => c.Auctions).WithRequired(c => c.User).WillCascadeOnDelete(true); //add key here.
        }
    }
}