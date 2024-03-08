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
using View;

namespace ViewModel
{
    public class AdminMainMenuViewModel : MainMenuViewModel
    {

        public void WatchGame(Window current)
        {
            SwitchScreen(current, new WatchPlayerGameView());
        }
    }
}
