using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lightning_Rewards.Models
{
    [NotMapped]
    public class AuthenticationRequest
    {
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}