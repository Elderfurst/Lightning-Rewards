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
        User LoadUser(int userId);

        User AuthenticateUser(string email, string password);
    }
}
