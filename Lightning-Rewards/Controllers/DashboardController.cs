using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Lightning_Rewards.Managers;
using Lightning_Rewards.Models;

namespace Lightning_Rewards.Controllers
{
    public class DashboardController : ApiController
    {
        private readonly Lightning_RewardsContext _db = new Lightning_RewardsContext();
        private readonly IDashboardManager _dashboardManager;

        public DashboardController(IDashboardManager dashboardManager)
        {
            _dashboardManager = dashboardManager;
        }

        [ResponseType(typeof(Dashboard))]
        public IHttpActionResult GetDashboard(long userId)
        {
            Dashboard dashboard = _dashboardManager.GetDashboard(userId);
            if (dashboard == null)
            {
                return BadRequest();
            }
            return Ok(dashboard);
        }
    }
}
