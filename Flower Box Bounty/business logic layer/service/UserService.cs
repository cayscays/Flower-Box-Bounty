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
using UserModule;

namespace Service
{
    public static class UserService
    {
        private static UserModule.Administrator _admin = new UserModule.Administrator();
        public static bool CreateNewPlayer(string username, string password)
        {
            if (IsAdminUsername(username)) return false;
            UserModule.Player player = new UserModule.Player(username, password);
            return Data.Operations.UsersDal.CreatePlayerWithUniqueName(player);
        }

        public static bool IsAdminUsername(string username)
        {
            return _admin.Name.Equals(username);
        }

        public static bool Login(string name, string password)
        {
            if (name == null || password == null) return false;
            else
            {
                if (LoginAdmin(name, password)) return true;
                else if (LoginPlayer(name, password)) return true;
                else return false;
            }
        }
        private static bool LoginPlayer(string name, string password)
        {
            UserModule.Player player = new UserModule.Player(name, password);
            if (player == null) return false;
            else
            {
                UserModule.Player dbPlayer = Data.Operations.UsersDal.GetPlayerByName(player.Name);
                return (player.Equals(dbPlayer));
            }
        }

        private static bool LoginAdmin(string name, string password)
        {
            UserModule.User user = new UserModule.User(name, password);
            if (_admin.Equals(user))
            {
                return true;
            }
            else return false;
        }

        public static bool IsAdmin(string name, string password)
        {
            return _admin.Equals(new UserModule.User(name, password));
        }

        public static List<User> GetAllUsers()
        {
            return Data.Operations.UsersDal.GetAllUsers();
        }

        public static User GetUserByName(string name)
        {
            return Data.Operations.UsersDal.GetUserByName(name);
        }

    }
}
