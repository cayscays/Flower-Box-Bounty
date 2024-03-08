/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using Data.Operations;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace UserModule
{
    public class CurrentUser
    {

        private static CurrentUser? _instance;
        private static readonly object _lock = new object();
        private User? _user;

        public User? User { get => _user; }

        public static CurrentUser GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new CurrentUser();
                    }
                }
            }
            return _instance;
        }
        private CurrentUser()
        {
            _user = null; // null user is an anonymous user
        }

        public bool Login(User user)
        {
            if (IsLoggedOut())
            {
                UsersDal.GetUserByName(user.Name);
                _user = user;
                return (_user is null) ? false : true;
            }
            else
            {
                return false;
            }
        }

        public bool Logout()
        {
            if (IsLoggedIn())
            {
                _user = null;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsLoggedIn()
        {
            return (_user is not null);
        }

        public bool IsLoggedOut()
        {
            return (_user is null);
        }
    }
}
