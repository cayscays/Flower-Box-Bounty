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
using ItemModule;

namespace PreservePlantModule
{
    public class Preseved : IStoredItem
    {
        private PreserveType _presevedType;
        private List<CropType> _cropTypes;
        public PreserveType PreserveType => _presevedType;
        public List<CropType> CropTypes => _cropTypes;

        public Preseved(PreserveType presevedType, List<CropType> cropTypes)
        {
            if (cropTypes.Count == 0)
            {
                throw new Exception();
            }
            _presevedType = presevedType;
            _cropTypes = cropTypes;
        }

        public override string ToString()
        {
            return $"{PreserveType} containing: {string.Join(", ", CropTypes.Select(e => e.ToString()))}";

        }

        object ICloneable.Clone()
        {
            var preservedType = PreserveType;
            var cropTypes = new List<CropType>(_cropTypes);
            return new Preseved(PreserveType, cropTypes);
        }
    }
}
