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
    public enum WitheringStage
    {
        Green,
        Yellow,
        Brown,
    }

    public static class WitheringStageExtentions
    {
        public readonly static WitheringStage Min = WitheringStage.Green;
        public readonly static WitheringStage Max = WitheringStage.Brown;
        public static WitheringStage Wither(WitheringStage witheringStage)
        {
            if (witheringStage < Max) return (witheringStage + 1);
            else return witheringStage;
        }

        public static WitheringStage UnWither(WitheringStage witheringStage)
        {
            if ((witheringStage > Min) && (witheringStage < Max)) return (witheringStage - 1);
            else return witheringStage;
        }
    }
}
