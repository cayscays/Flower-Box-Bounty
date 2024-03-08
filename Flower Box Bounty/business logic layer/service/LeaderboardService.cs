/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using Data.Operations;
using LeaderboardModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class LeaderboardService
    {
        public static LeaderboardModule.Leaderboard GetLeaderboard()
        {
            return LeaderboardDal.Read();
        }
    }
}
