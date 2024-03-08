/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreservePlantModule
{
    public enum PreserveType
    {
        Jam,
        Pickled,
    }

    public static class PreserveTypeExtentions
    {
        private static PreserveType[] _jars = { PreserveType.Jam, PreserveType.Pickled };
        public static bool IsJar(this PreserveType type)
        {
            return _jars.Contains(type);
        }
    }
}
