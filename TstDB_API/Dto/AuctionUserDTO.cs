using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace TstDB_API.Dto
{
    public class AuctionUserDTO
    {
        public string Id_IdentityUser { get; set; }
        public string UserName { get; set; }
    }
}