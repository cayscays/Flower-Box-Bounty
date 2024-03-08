/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using Flower_Box_Bounty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UserModule;
using View;

namespace ViewModel
{
    public abstract class ViewModel
    {
        protected CurrentUser _currentUser;
        public string Username { get => _currentUser?.User?.Name ?? ""; }

        public ViewModel()
        {
            _currentUser = ((App)Application.Current).CurrentUser;
        }


        protected void SwitchScreen(Window current, Window next)
        {
            next.Show();
            current.Close();
        }

        public void GoToPlayerMainMenu(Window current)
        {
            SwitchScreen(current, new View.PlayerMainMenuView());
        }
        public void GoToMenu(Window current)
        {
            if (Service.UserService.IsAdminUsername(Username))
            {
                GoToAdminMainMenu(current);
            }
            else
            {
                GoToPlayerMainMenu(current);
            }
        }

        public void GoToAdminMainMenu(Window current)
        {
            SwitchScreen(current, new View.AdminMainMenuView());
        }

        public static void DisplayErrorMessage(string message)
        {
            MessageBox.Show("An error occurred: " + message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }


    }
}
