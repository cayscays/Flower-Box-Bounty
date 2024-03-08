/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantModule
{
    public enum GrowthStage
    {
        Seeding,
        Vegetative,
        Budding,
        Ripening,
    }

    public static class GrowthStageExtentions
    {
        public readonly static GrowthStage Min = GrowthStage.Seeding;
        public readonly static GrowthStage Max = GrowthStage.Ripening;
    }

}
