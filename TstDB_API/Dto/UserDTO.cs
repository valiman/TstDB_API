using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace TstDB_API.Dto
{
    public class UserDTO 
    {
        public string Id_IdUser  { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }
        //internal get to avoid "circular reference"
        public List<AuctionDTO> AuctionsDTO { internal get; set; } = new List<AuctionDTO>();
    }
}