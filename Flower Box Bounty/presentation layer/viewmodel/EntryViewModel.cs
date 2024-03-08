/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class EntryViewModel
    {
        public string Name { get; set; }
        public ulong Score { get; set; }


        public EntryViewModel(LeaderboardModule.Entry entry)
        {
            Name = entry.Name;
            Score = entry.Score;
        }

        public override string ToString() => $"{Name}\t{Score}";
    }
}
