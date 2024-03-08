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

namespace PreservePlantModule
{
    public abstract class PreserveBuilder
    {
        protected PreserveType _preserveType;

        public PreserveType PreserveType { get => _preserveType; }
        
        // Returns true if added the crop:
        public abstract bool AddCrop(CropType crope);


        public abstract List<CropType> RemoveAndReturnAllIngridients();

        public abstract Preseved GetPreserved();
        public abstract void RemoveCrop(int index);
        public override string ToString()
        {
            return $"{_preserveType}";
        }
    }
}
