/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using Common;
using PlantModule;

namespace Data.Models
{
    public class PlantDoc : BsonDocBase
    {
        public bool Empty { get; private set; } // Indicates if this spot in the flower box is empty
        public CropType CropType { get; private set; }
        public GrowthStage GrowthStage { get; private set; }
        public WitheringStage WitheringStage { get; private set; }

        public PlantDoc(Plant plant)
        {
            if (plant is null) Empty = true;
            else
            {
                Empty = false;
                CropType = plant.GetCropType;
                GrowthStage = plant.GetGrowthStage;
                WitheringStage = plant.GetWitheringStage;
            }
        }

    }
}