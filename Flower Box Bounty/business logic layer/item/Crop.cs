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
    public class Crop : IStoredItem
    {
        public CropType CropType { get; private set; }

        public Crop(CropType type)
        {
            CropType = type;
        }

        object ICloneable.Clone()
        {
            return new Crop(CropType);
        }

        public override string ToString()
        {
            return CropType.ToString();
        }
    }
}
