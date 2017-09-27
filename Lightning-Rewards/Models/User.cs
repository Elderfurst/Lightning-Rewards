using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lightning_Rewards.Models
{
    public class User
    {
        public long Id { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool IsManager { get; set; }

        public bool IsAdmin { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public virtual ICollection<Card> CreatedCards { get; set; }
        
        public virtual ICollection<Card> ReceivedCards { get; set; }

        public virtual ICollection<Card> ManagedCards { get; set; }
    }
}