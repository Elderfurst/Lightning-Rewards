using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lightning_Rewards.Models
{
    [NotMapped]
    public class Dashboard
    {
        public Dictionary<string, int> Letters { get; set; }

        public int UnclaimedCards { get; set; }

        public int UnapprovedCards { get; set; }
    }
}