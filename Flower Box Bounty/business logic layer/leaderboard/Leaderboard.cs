/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LeaderboardModule
{

    public class Leaderboard
    {
        private const int Length = 10;

        private Entry[] _entries;
        
        public Leaderboard()
        {
            _entries = new Entry[Length];
            for (var i = 0; i < _entries.Length; i++)
            {
                _entries[i] = new Entry($"Empty #{i + 1}", (ulong)0);
            }
            Array.Sort(_entries);
        }

        public Leaderboard(Entry[] entries)
        {
            _entries = entries;
        }

        /*
         * If the score is enough to enter the leaderboard:
         * adds a new Entry for the player in the leaderboard
         */
        public void Update(string playerName, ulong score)
        {
            Entry newEntry = new Entry(playerName, score);
            if (ScorePassThreshold(newEntry))
            {
                if (!UpdateEntryScore(newEntry))
                {
                    _entries[_entries.Length - 1] = newEntry;
                }
                Array.Sort(_entries);
            }
        }

        public Entry[] GetEntries()
        {
            return (Entry[])_entries.Select(entry => (Entry)entry.Clone()).ToArray();
        }

        /* 
         * true if found a player to update
         */
        private bool UpdateEntryScore(Entry entry)
        {
            int index = Array.FindIndex(_entries, p => p.Equals(entry));
            if (index > -1)
            {
                _entries[index].Score = entry.Score;
                return true;
            }
            else return false;
        }
        private bool ScorePassThreshold(Entry player)
        {
            return (player.CompareTo(_entries[_entries.Length - 1]) == -1);
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < _entries.Length; i++)
            {
                result += $"{i + 1}.\t{_entries[i]}\n";
            }
            return result;
        }


    }
}
