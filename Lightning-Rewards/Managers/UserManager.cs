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

        public AuthenticatedUser AuthenticateUser(string email, string password)
        {
            return _db.Users.Select(u => new AuthenticatedUser
            {
                Id = u.Id,
                Password = u.Password,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                IsManager = u.IsManager,
                IsAdmin = u.IsAdmin,
                DateCreated = u.DateCreated,
                DateModified = u.DateModified
            }).FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public IQueryable<UserLite> GetUsersAutocomplete(string query)
        {
            return _db.Users.Select(u => new UserLite
            {
                Id = u.Id,
                Name = u.FirstName + " " + u.LastName
            }).Where(ul => ul.Name.Contains(query));
        }

        public IQueryable<UserLite> GetManagers()
        {
            return _db.Users.Where(u => u.IsManager).Select(u => new UserLite
            {
                Id = u.Id,
                Name = u.FirstName + " " + u.LastName
            });
        }

        public bool UserIsManager(long userId)
        {
            return _db.Users.Count(u => u.Id == userId && u.IsManager) > 0;
        }

        public bool UserExists(long userId)
        {
            return _db.Users.Count(u => u.Id == userId) > 0;
        }
    }
}