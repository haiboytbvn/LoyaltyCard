using System;
using System.Collections.Generic;
using System.Text;

namespace LoyaltyCard.Data
{
    public class LoyaltyCardTypeModel : BaseModel
    {
        public string Name { get; set; }
        public string SpentThreshold { get; set; }
        public uint Duration { get; set; }
        public double DiscountPercent { get; set; }
    }
}
