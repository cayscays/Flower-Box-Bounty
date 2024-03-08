/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Models
{

    public class PlayerDoc : BsonDocBase
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public PlayerDoc(string userName, string password)
        {
            Name = userName;
            Password = password;
        }

    }
}
