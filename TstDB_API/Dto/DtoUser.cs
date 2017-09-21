using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TstDB_API.Dto
{
    public class DtoUser
    {
        public int id { get; set; }
        public DateTime creationDate { get; set; }
        public string name { get; set; }
        public List<DtoAuction> Auctions = new List<DtoAuction>();
    }
}