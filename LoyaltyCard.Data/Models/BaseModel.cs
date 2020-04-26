using System;
using System.Collections.Generic;
using System.Text;

namespace LoyaltyCard.Data
{
    public class BaseModel
    {
        public string ID { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
