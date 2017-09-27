using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Lightning_Rewards.Models;

namespace Lightning_Rewards.Managers
{
    public class UserManager : IUserManager
    {
        private readonly Lightning_RewardsContext _db;

        public UserManager(Lightning_RewardsContext db)
        {
            _db = db;
        }

        public User AuthenticateUser(string email, string password)
        {
            return _db.Users.First(x => x.Email == email && x.Password == password);
        }
    }
}