/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using PreservePlantModule;

namespace Data.Models
{
    public class JarBuilderDoc : BsonDocBase
    {
        public string[] CropTypes { get; private set; }
        public string PreserveType { get; private set; }

        public JarBuilderDoc(JarBuilder jarBuilder)
        {
            CropTypes = new string[jarBuilder.CropTypes.Count];
            for (int i = 0; i < jarBuilder.CropTypes.Count; i++)
            {
                CropTypes[i] = jarBuilder.CropTypes[i].ToString();
            }
            PreserveType = jarBuilder.PreserveType.ToString();
        }
    }
}