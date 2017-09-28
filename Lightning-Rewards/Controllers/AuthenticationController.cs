using Lightning_Rewards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Lightning_Rewards.Managers;

namespace Lightning_Rewards.Controllers
{
    public class AuthenticationController : ApiController
    {
        private readonly Lightning_RewardsContext _db = new Lightning_RewardsContext();
        private readonly IUserManager _userManager;

        public AuthenticationController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        
        [ResponseType(typeof(User))]
        public IHttpActionResult PostAuthentication([FromBody] AuthenticationRequest data)
        {
            AuthenticatedUser user = _userManager.AuthenticateUser(data.Email, data.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }
    }
}
