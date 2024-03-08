/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using Common;
using LeaderboardModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{

    public class LeaderboardDoc : BsonDocBase
    {
        public Entry[] Entries { get; private set; }


        public LeaderboardDoc(Entry[] entries)
        {
            Entries = entries;
        }

        public Entry[] GetEntries()
        {

            return Helper.DeepCopy<Entry>(Entries);
        }

    }


}
