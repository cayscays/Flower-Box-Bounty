/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using Data.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UserModule;

namespace ViewModel
{
    public class SignupViewModel : ViewModel
    {
        public void Signup(string username, string password, string passwordConfirmation, Window current)
        {
            if (!password.Equals(passwordConfirmation))
            {
                MessageBox.Show("Passwords do not match. Please try again.");
                return;
            }
            if (CreateNewPlayer(username, password))
            {
                _currentUser.Login(new Player(username, password));
                SwitchScreen(current, new View.PlayerMainMenuView());
            }
        }

        private bool CreateNewPlayer(string username, string password)
        {
            // If the name and password are valid, creates a new player
            if (!Service.UserService.CreateNewPlayer(username, password))
            {
                MessageBox.Show("Username already exists.");
                return false;
            }
            // Creates a new gamestate for the player
            else
            {
                GamestateDal.CreateGameState(new Data.Models.GamestateDoc(new GamestateModule.InteractiveGameState(username)));
                return true;
            }
        }

        public void Back(Window current)
        {
            SwitchScreen(current, new View.WelcomeView());
        }


    }
}
