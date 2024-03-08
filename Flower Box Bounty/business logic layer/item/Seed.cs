/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace ItemModule
{
    public class Seed : IStoredItem
    {
        public CropType CropType { get; private set; }

        public Seed(CropType type)
        {
            CropType = type;
        }

        object ICloneable.Clone()
        {
            return new Seed(CropType);
        }

        public override string ToString()
        {
            return CropType.ToString() + " seed";
        }

        public static Seed GetRandomSeed()
        {
            return new Seed((CropType)Helper.Random.Next(0, Helper.CropTypesCount));
        }
    }
}
