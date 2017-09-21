using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TstDB_API.Dto
{
    public class DtoAuction
    {
        public int id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public double bidPrice { get; set; }
        public double buyoutPrice { get; set; }
        public DtoUser User { get; set; }
    }
}