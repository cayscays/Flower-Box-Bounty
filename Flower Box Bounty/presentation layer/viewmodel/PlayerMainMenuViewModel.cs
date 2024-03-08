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
using ViewModel;

namespace ViewModel
{
    public class PlayerMainMenuViewModel : MainMenuViewModel
    {
        public void Play(Window current)
        {
            SwitchScreen(current, new View.GameView());
        }


    }
}
