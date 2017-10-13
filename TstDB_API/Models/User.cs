using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TstDB_API.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        public string UserName { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreationDate { get; set; }
        public double Rating { get; set; }
        public virtual ICollection<Auction> Auctions { get; set; }
    }
}