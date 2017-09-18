using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TstDB_API.Models
{
    public class Auction
    {
        [Key]
        public int id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public double bidPrice { get; set; }
        public double buyoutPrice { get; set; }
        public User User { get; set; }
    }
}