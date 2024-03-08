/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserModule
{
    public class Administrator : User
    {
        
        private const string _name = "admin"; // implicitly static
        private const string _password = "admin"; // implicitly static

        public Administrator() : base(_name , _password)
        {
        }

        public static bool IsAdmin(User user)
        {
            return user.Name == _name;
        }
    }
}
