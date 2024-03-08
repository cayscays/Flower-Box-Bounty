/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelModule
{
    public class Level
    {
        private ulong _levelNumber = 1;
        public ulong LevelNumber { get => _levelNumber; }
        public Level() { }
        public Level(Level other)
        {
            _levelNumber = other._levelNumber;
        }
        public Level(ulong levelNumber)
        {
            _levelNumber = levelNumber;
        }


        public void Next()
        {
            _levelNumber++;
        }

        public object Clone()
        {
            return new Level(this);
        }

        public override string ToString()
        {
            return $"Level {_levelNumber}";
        }
    }
}
