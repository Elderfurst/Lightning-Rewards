using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lightning_Rewards.Models
{
    public class User
    {
        public long Id;

        public string Password;

        public string FirstName;

        public string LastName;

        public string Email;

        public bool IsManager;

        public bool IsAdmin;

        public DateTime DateCreated;

        public DateTime DateModified;
    }
}