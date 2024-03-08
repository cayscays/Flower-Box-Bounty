/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaderboardModule;
using View;

namespace ViewModel
{
    public class LeaderboardViewModel : ViewModel
    {
        private LeaderboardModule.Leaderboard _model;
        public ObservableCollection<EntryViewModel> Entries { get; set; }

        public LeaderboardViewModel()
        {
            Entries = new ObservableCollection<EntryViewModel>();
            Update();
        }


        private void Update()
        {
            _model = Service.LeaderboardService.GetLeaderboard();
            Entry[] entries = _model.GetEntries();
            for (int i = 0; i < entries.Length; i++)
            {
                Entries.Add(new EntryViewModel(entries[i]));
            }
        }
    }
}
