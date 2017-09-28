using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Lightning_Rewards.Managers;
using Lightning_Rewards.Models;

namespace Lightning_Rewards.Controllers
{
    public class UsersController : ApiController
    {
        private readonly Lightning_RewardsContext _db = new Lightning_RewardsContext();
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [Route("api/Users/Autocomplete")]
        public IQueryable<UserLite> GetUsersAutocomplete(string query)
        {
            return _userManager.GetUsersAutocomplete(query);
        }
    }
}