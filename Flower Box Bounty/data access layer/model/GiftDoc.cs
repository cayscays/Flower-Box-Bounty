/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using Common;
using Flower_Box_Bounty.data_access_layer.model;
using ItemModule;
using PreservePlantModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class GiftDoc : BsonDocBase
    {
        public StoredItemDoc Item { get; private set; }

        public string GiverUsername { get; private set; }


        public GiftDoc(string giverUsername, IStoredItem gift)
        {
            Item = new StoredItemDoc(gift);
            GiverUsername = giverUsername;
        }

        public IStoredItem GetItem()
        {
            return Item.GetIStoredItem();
        }


    }
}
