using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace TstDB_API.Dto
{
    public class AuctionDTO
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double BidPrice { get; set; }
        public double BuyoutPrice { get; set; }
        public string User_Id { get; set; }
    }
}