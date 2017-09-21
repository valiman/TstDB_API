﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TstDB_API.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public DateTime creationDate { get; set; }
        public string name { get; set; }
        public virtual List<Auction> Auctions { get; set; }
    }
}