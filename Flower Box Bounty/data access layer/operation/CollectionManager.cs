/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operation
{
    internal static class CollectionManager
    {
        internal static IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            try
            {
                return ConnectionManager.DatabaseConnection.Database.GetCollection<T>(collectionName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
