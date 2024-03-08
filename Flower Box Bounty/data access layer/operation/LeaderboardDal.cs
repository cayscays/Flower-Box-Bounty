/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using MongoDB.Bson;
using MongoDB.Driver;
using Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Operations
{
    public static class LeaderboardDal
    {
        private static FilterDefinition<Models.LeaderboardDoc> _emptyFilter = Builders<Models.LeaderboardDoc>.Filter.Empty;


        public static LeaderboardModule.Leaderboard Read()
        {

            LeaderboardModule.Leaderboard result;
            Models.LeaderboardDoc doc;
            try
            {
                doc = CollectionManager.GetCollection<Models.LeaderboardDoc>(Constants.LeaderboardCollectionName).Find(_ => true).FirstOrDefault();
                result = ConvertToLeaderboard(doc);
            }
            catch { result = null; }

            return result;
        }

        private static LeaderboardModule.Leaderboard ConvertToLeaderboard(Models.LeaderboardDoc leaderboardDocument)
        {
            if (leaderboardDocument is null) return null;
            return new LeaderboardModule.Leaderboard(leaderboardDocument.GetEntries());
        }

        private static Models.LeaderboardDoc ConverToDocument(LeaderboardModule.Leaderboard leaderboard)
        {
            return new Models.LeaderboardDoc(leaderboard.GetEntries());
        }

        public static void Create(LeaderboardModule.Leaderboard leaderboard)
        {
            try
            {
                if (Read() == null)
                {
                    CollectionManager.GetCollection<Models.LeaderboardDoc>(Constants.LeaderboardCollectionName).InsertOne(ConverToDocument(leaderboard));
                }
                else
                {
                    Console.WriteLine("ERROR: Leaderboard already exists on the database.");
                }
            }
            catch { Console.WriteLine("ERROR: can't create Leaderboard"); }
        }

        public static void Update(LeaderboardModule.Leaderboard leaderboard)
        {
            try
            {
                try
                {
                    CollectionManager.GetCollection<Models.LeaderboardDoc>(Constants.LeaderboardCollectionName).DeleteOne(_emptyFilter);
                    CollectionManager.GetCollection<Models.LeaderboardDoc>(Constants.LeaderboardCollectionName).InsertOne(ConverToDocument(leaderboard));
                }
                catch { Create(leaderboard); }
            }
            catch { Console.WriteLine("ERROR: can't update Leaderboard"); }
        }

    }
}
