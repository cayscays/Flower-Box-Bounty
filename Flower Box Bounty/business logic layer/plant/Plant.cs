/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using Common;
using System;
using System.Timers;

namespace PlantModule
{
    public class Plant : ICloneable
    {

        private CropType _cropType;
        private GrowthStage _growthStage;
        private WitheringStage _witheringStage;
        private Timer _witherTimer;
        private int _witheringStageDuration = 20000; // miliseconds


        public CropType GetCropType => _cropType;
        public GrowthStage GetGrowthStage => _growthStage;
        public WitheringStage GetWitheringStage => _witheringStage;


        public Plant(CropType cropType)
        {
            Init(cropType, GrowthStageExtentions.Min, WitheringStageExtentions.Min);

        }

        public Plant(Plant other)
        {
            Init(other.GetCropType, other.GetGrowthStage, other.GetWitheringStage);

        }

        public Plant(CropType cropType, GrowthStage growthStage, WitheringStage witheringStage)
        {
            Init(cropType, growthStage, witheringStage);
        }

        private void Init(CropType cropType, GrowthStage growthStage, WitheringStage witheringStage)
        {
            _cropType = cropType;
            _growthStage = growthStage;
            _witheringStage = witheringStage;
            InitWitherTimer();
        }

        private void InitWitherTimer()
        {
            _witherTimer = new Timer(_witheringStageDuration);
            _witherTimer.Elapsed += (sender, e) => Wither();
            _witherTimer.Enabled = true;
            _witherTimer.AutoReset = true;
            _witherTimer.Start();
        }


        public bool IsReadyToHarvest()
        {
            return (_growthStage == GrowthStageExtentions.Max);
        }

        public void Grow()
        {
            if ((_growthStage < GrowthStageExtentions.Max) &&
                (_witheringStage == WitheringStageExtentions.Min))
                _growthStage++;
        }

        public void Wither()
        {
            if (!IsReadyToHarvest() && !_growthStage.Equals(GrowthStage.Seeding))
            {
                _witheringStage = WitheringStageExtentions.Wither(_witheringStage);
            }
        }

        public void UnWither()
        {
            _witheringStage = WitheringStageExtentions.UnWither(_witheringStage);
        }

        public override string ToString()
        {
            return $"Crop type: {_cropType} Growth stage: {_growthStage} Withering stage: {_witheringStage}";
        }

        public object Clone()
        {
            return new Plant(this);
        }


    }
}
