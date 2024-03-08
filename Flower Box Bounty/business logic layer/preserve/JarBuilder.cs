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
    public class JarBuilder : PreserveBuilder

    {

        private List<CropType> _cropTypes = new List<CropType>();

        public List<CropType> CropTypes { get => _cropTypes.Select(e => e).ToList(); }
        public JarBuilder(PreserveType preserveType, List<CropType> cropTypes)
        {
            if (preserveType.IsJar())
            {
                _preserveType = preserveType;
                _cropTypes = cropTypes;
            }
            else
            {
                throw new Exception();
            }
        }
        public JarBuilder(PreserveType preserveType)
        {
            if (preserveType.IsJar())
            {
                _preserveType = preserveType;
            }
            else
            {
                throw new Exception();
            }
        }
        public override bool AddCrop(CropType crope)
        {
            _cropTypes.Add(crope);
            return true;
        }
        public override List<CropType> RemoveAndReturnAllIngridients()
        {
            List<CropType> cropTypesToReturn = new List<CropType>(_cropTypes);
            _cropTypes.Clear();
            return cropTypesToReturn;
        }

        public override Preseved GetPreserved()
        {
            var preseved = new Preseved(_preserveType, _cropTypes);
            return preseved;
        }

        public override void RemoveCrop(int index)
        {
            _cropTypes.RemoveAt(index);
        }
    }
}
