using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace TstDB_API.Dto
{
    public class AuctionDTO
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double BidPrice { get; set; }
        public double BuyoutPrice { get; set; }
        public UserDTO User { get; set; }
    }
}