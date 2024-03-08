/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UserModule;

namespace ViewModel
{
    public abstract class MainMenuViewModel : ViewModel
    {
        public void Logout(Window current)
        {
            CurrentUser.GetInstance().Logout();
            SwitchScreen(current, new View.WelcomeView());
        }

        public void Leaderboard(Window current)
        {
            SwitchScreen(current, new View.LeaderboardView());
        }

        public void Help(Window current)
        {
            SwitchScreen(current, new View.HelpView());
        }
    }
}
