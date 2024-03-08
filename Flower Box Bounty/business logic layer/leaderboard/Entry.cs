/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderboardModule
{
    public class Entry : IComparable<Entry>, IEquatable<Entry>, ICloneable
    {
        public string Name { get; private set; }
        public ulong Score { get; set; }

        public Entry(string name, ulong score)
        {
            Name = name;
            Score = score;
        }

        public Entry(Entry other)
        {
            Name = other.Name;
            Score = other.Score;
        }

        public bool IsEmpty()
        {
            return Name == "Empty";
        }


        public override string ToString()
        {
            return $"Score: {Score}, Name: {Name}";
        }

        /*
        * Larger score is lower:
        * Equal => same as larger
         */
        public int CompareTo(Entry other)
        {
            return (this.Score > other.Score) ? -1 : 1;
        }

        public bool Equals(Entry other)
        {
            return (string.Compare(this.Name, other.Name, StringComparison.Ordinal) == 0);
        }

        public override bool Equals(object obj)
        {
            return Equals((Entry)obj);
        }

        public object Clone()
        {
            return new Entry(Name, Score);
        }
    }
}
