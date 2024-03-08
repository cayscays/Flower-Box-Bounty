/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using Data.Operations;
using GamestateModule;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;
using UserModule;
using View;
using static MongoDB.Driver.WriteConcern;

namespace ViewModel
{
    public class WatchPlayerGameViewModel : ViewModel
    {
        private List<User> _users;
        public ObservableCollection<string> Usernames { get; set; }


        public WatchPlayerGameViewModel()
        {
            Usernames = new ObservableCollection<string>();
            Update();
        }

        private void Update()
        {
            _users = Service.UserService.GetAllUsers();
            Usernames.Clear();
            foreach (var user in _users)
            {
                Usernames.Add(user.Name);
            }
        }
        public bool WatchPlayerGame(Window current, string? username)
        {
            if (username == null) return false;
            // Check if the username is valid
            if (Service.UserService.GetUserByName(username) is not null)
            {
                // If it is, then load a non interactive version of the player's game
                SwitchScreen(current, new GameView(username));
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}