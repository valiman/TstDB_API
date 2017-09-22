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
        //internal get to avoid "circular reference"
        public List<DtoAuction> Auctions { internal get; set; } = new List<DtoAuction>();
    }
}