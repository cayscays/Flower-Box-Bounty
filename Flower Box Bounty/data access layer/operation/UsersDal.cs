/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MongoDB.Driver;
using Data.Operations;
using Data.Models;
using Operation;
using UserModule;

namespace Data.Operations
{
    public static class UsersDal
    {
         
        public static bool CreatePlayerWithUniqueName(UserModule.Player player)
        {
            try
            {
                if (GetUserByName(player.Name) is null)
                {
                    CollectionManager.GetCollection<PlayerDoc>(Constants.UsersCollectionName).InsertOne(ConvertToDocument(player));
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static UserModule.User GetUserByName(string name)
        {
            return ConvertToUser(CollectionManager.GetCollection<PlayerDoc>(Constants.UsersCollectionName).Find(u => u.Name == name).FirstOrDefault());
        }

        public static UserModule.Player GetPlayerByName(string name)
        {
            return ConvertToUser(CollectionManager.GetCollection<PlayerDoc>(Constants.UsersCollectionName).Find(u => u.Name == name).FirstOrDefault());
        }

        public static List<UserModule.User> GetAllUsers()
        {
            var userDocs = CollectionManager.GetCollection<PlayerDoc>(Constants.UsersCollectionName).Find(_ => true).ToList();
            List<UserModule.User> usersList = new List<UserModule.User>();
            foreach (var userDoc in userDocs)
            {
                usersList.Add(ConvertToUser(userDoc));
            }
            return usersList;
        }

        private static Models.PlayerDoc ConvertToDocument(UserModule.Player player)
        {

            return new Models.PlayerDoc(player.Name, player.Password);

        }

        private static UserModule.Player ConvertToUser(Models.PlayerDoc playerDoc)
        {
            if (playerDoc is null) return null;
            return new UserModule.Player(playerDoc.Name, playerDoc.Password);
        }
    }

}
