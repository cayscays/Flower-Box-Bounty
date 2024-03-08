/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Data.Operations;
using Data.Models;
using ItemModule;
using Operation;

namespace Data.Operations
{
    public static class GiftsDal

    {
        public static void PushGift(GiftDoc gift)
        {
            
            try
            {
                CollectionManager.GetCollection<GiftDoc>(Constants.GiftsCollectionName).InsertOne(gift);
                Console.WriteLine("gift given");
            }
            catch
            {
                throw new Exception("Can't create gift");
            }
        }

        public static GiftDoc? PopGift()
        {
            try
            {
                return CollectionManager.GetCollection<GiftDoc>(Constants.GiftsCollectionName).FindOneAndDelete<GiftDoc>(_ => true);
            }
            catch
            {
                throw new Exception("Can't read gift from the database");
            }
        }

        /*
         * Returns a gift with a different username than username.
         * It there's none returns null
         */
        public static GiftDoc? PopGift(string username)
        {
            try
            {
                return CollectionManager.GetCollection<GiftDoc>(Constants.GiftsCollectionName).FindOneAndDelete<GiftDoc>(gift => !gift.GiverUsername.Equals(username));
            }
            catch
            {
                throw new Exception("Can't read gift from the database");
            }
        }


    }
}
