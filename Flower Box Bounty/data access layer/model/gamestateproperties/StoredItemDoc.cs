/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using Common;
using Data.Models;
using ItemModule;
using PreservePlantModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flower_Box_Bounty.data_access_layer.model
{
    public class StoredItemDoc : BsonDocBase
    {
        public string ItemType { get; private set; }
        public string[] CropTypes { get; private set; }

        public string PreserveType { get; private set; }


        public StoredItemDoc(string itemType, string[] cropTypes, string preserveType)
        {
            ItemType = itemType;
            CropTypes = cropTypes;
            PreserveType = preserveType;
        }

        public StoredItemDoc(IStoredItem item)
        {
            if (item is Crop)
            {
                Crop crop = (Crop)item;
                CropTypes = new string[1];
                CropTypes[0] = crop.CropType.ToString();
                ItemType = "Crop";
                PreserveType = "";
            }
            else if (item is Preseved)
            {
                Preseved preseved = (Preseved)item;
                CropTypes = new string[preseved.CropTypes.Count];
                foreach (CropType cropType in preseved.CropTypes)
                {
                    CropTypes[preseved.CropTypes.IndexOf(cropType)] = cropType.ToString();
                }
                ItemType = "Preseved";
                PreserveType = preseved.PreserveType.ToString();
            }
            else if (item is Seed)
            {
                Seed seed = (Seed)item;
                CropTypes = new string[1];
                CropTypes[0] = seed.CropType.ToString();
                ItemType = "Seed";
                PreserveType = "";
            }
            else
            {
                throw new Exception("ERROR: Illegal item type.");
            }
        }

        public string[] GetCropType()
        {
            return Helper.DeepCopy(CropTypes);
        }

        public string GetItemType()
        {
            return ItemType;
        }

        public IStoredItem GetIStoredItem()
        {
            if (ItemType == "Crop")
            {
                return new Crop((CropType)Enum.Parse(typeof(CropType), CropTypes[0]));
            }
            else if (ItemType == "Preseved")
            {
                List<CropType> cropTypes = new List<CropType>();
                foreach (string cropType in CropTypes)
                {
                    cropTypes.Add((CropType)Enum.Parse(typeof(CropType), cropType));
                }
                return new Preseved((PreserveType)Enum.Parse(typeof(PreserveType), PreserveType), cropTypes);
            }
            else if (ItemType == "Seed")
            {
                return new Seed((CropType)Enum.Parse(typeof(CropType), CropTypes[0]));
            }
            else
            {
                throw new Exception("ERROR: Illegal item type.");
            }
        }

    }
}
