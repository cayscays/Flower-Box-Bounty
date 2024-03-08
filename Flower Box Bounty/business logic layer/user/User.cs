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
    public class User: IEquatable<User>
    {
        public string Name { get; protected set; }
        public string Password { get; protected set; }

        public User(string name, string password) { Name = name; Password = password; }

        public override string ToString()
        {
            return $"{Name}: {Password}";
        }


        public bool Equals(User? other)
        {
            if(other == null) return false; 
            else return ((Name == other.Name) && (Password == other.Password));
        }
    }
}
