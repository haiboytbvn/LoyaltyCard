using System;
using System.Collections.Generic;
using System.Text;

namespace LoyaltyCard.Data
{
    public class LoyaltyCardModel : BaseModel
    {
        public string Code { get; set; }
        public string Phone { get; set; }
        public uint LoyaltyCartTypeId { get; set; }
        public double Point { get; set; }
        public decimal TotalSpent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
       
    }
}
