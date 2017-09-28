using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lightning_Rewards.Models;

namespace Lightning_Rewards.Managers
{
    public interface IUserManager
    {
        AuthenticatedUser AuthenticateUser(string email, string password);

        IQueryable<UserLite> GetUsersAutocomplete(string query);

        IQueryable<UserLite> GetManagers();

        bool UserIsManager(long userId);

        bool UserExists(long userId);
    }
}
