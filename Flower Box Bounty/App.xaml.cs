/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UserModule;

namespace Flower_Box_Bounty
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public CurrentUser CurrentUser { get => CurrentUser.GetInstance(); } 

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            CurrentUser.GetInstance();
        }


    }
}
