﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lightning_Rewards.Models;

namespace Lightning_Rewards.Managers
{
    public interface IDashboardManager
    {
        Dashboard GetDashboard(long userId);
    }
}
