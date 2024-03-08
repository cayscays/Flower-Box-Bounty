/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace ViewModel
{
    public class WelcomeViewModel : ViewModel
    {
        public void Login(Window current, Window next)
        {
            SwitchScreen(current, next);
        }

        public void Signup(Window current, Window next)
        {

            SwitchScreen(current, next);
        }

    }
}
