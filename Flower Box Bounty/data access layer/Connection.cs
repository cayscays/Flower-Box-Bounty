/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Data
{
    public class Connection

    {
        private MongoClient _mongoClient;
        private IMongoDatabase _database;
        private string _connectionUrl = Constants.ConnectionUrl;
        private string _dataBaseName = Constants.DatabaseName;
        public IMongoDatabase Database { get => _database; }
        public Connection()
        {

            try
            {
                _mongoClient = new MongoClient(new MongoUrl(_connectionUrl));
                _database = _mongoClient.GetDatabase(_dataBaseName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
