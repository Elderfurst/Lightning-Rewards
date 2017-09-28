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

        public User LoadUser(int userId)
        {
            return _db.Users.First(x => x.Id == userId);
        }

        public User AuthenticateUser(string email, string password)
        {
            return _db.Users.First(x => x.Email == email && x.Password == password);
        }

        public IQueryable<UserLite> GetUsersAutocomplete(string query)
        {
            return _db.Users.Select(u => new UserLite
            {
                Id = u.Id,
                Name = u.FirstName + " " + u.LastName
            }).Where(ul => ul.Name.Contains(query));
        }
    }
}