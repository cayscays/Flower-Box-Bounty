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
using UserModule;
using static System.Net.Mime.MediaTypeNames;

namespace ViewModel
{
    public class LoginViewModel : ViewModel
    {

        public void Login(string username, string password, Window current)
        {
            try
            {
                if (Service.UserService.Login(username, password))
                {
                    if (Service.UserService.IsAdmin(username, password))
                    {
                        LoginManager(current);
                    }
                    else
                    {
                        LoginPlayer(current, new Player(username, password));
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.");
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
        }
        public void Back(Window current)
        {
            SwitchScreen(current, new View.WelcomeView());
        }

        private void LoginManager(Window current)
        {
            _currentUser.Login(new Administrator());
            GoToAdminMainMenu(current);
        }

        private void LoginPlayer(Window current, User player)
        {
            _currentUser.Login(player);
            GoToPlayerMainMenu(current);
        }


    }
}
