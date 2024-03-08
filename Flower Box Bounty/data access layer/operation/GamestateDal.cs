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
using GamestateModule;
using ItemModule;
using LevelModule;
using NpcModule;
using PlantModule;
using PreservePlantModule;
using Common;
using Flower_Box_Bounty.data_access_layer.model;
using System.Printing;
using Operation;

namespace Data.Operations
{
    public static class GamestateDal
    {
        public static void CreateGameState(GamestateDoc gamestate)
        {
            try
            {
                if (GetGameStateByUsername(gamestate.Username) == null)
                    CollectionManager.GetCollection<GamestateDoc>(Constants.GameStateCollectionName).InsertOne(gamestate);
                else
                    throw new Exception("gamestate for this user already exists.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateGameState(GamestateDoc gamestate)
        {
            try
            {
                if (GetGameStateByUsername(gamestate.Username) is not null)
                {
                    CollectionManager.GetCollection<GamestateDoc>(Constants.GameStateCollectionName).DeleteOne(u => u.Username == gamestate.Username);
                    CollectionManager.GetCollection<GamestateDoc>(Constants.GameStateCollectionName).InsertOne(gamestate);
                }
                else
                    throw new Exception("Can't  save gamestate");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static GamestateModule.GameState GetGameStateByUsername(string username)
        {
            return ConvertToInteractiveGamestate(CollectionManager.GetCollection<GamestateDoc>(Constants.GameStateCollectionName).Find(u => u.Username == username).FirstOrDefault());
        }

        public static GamestateModule.InteractiveGameState ConvertToInteractiveGamestate(GamestateDoc gamestateDoc)
        {
            GamestateModule.GameState gamestate = ConvertToGamestate(gamestateDoc);
            return (gamestate is null) ? null : (InteractiveGameState)gamestate;
        }

        public static GamestateModule.GameState ConvertToGamestate(GamestateDoc gamestate)
        {
            if (gamestate is null) return null;

            List<Npc> npcs = new List<Npc>();
            if (gamestate.Npcs != null)
            {
                foreach (NpcDoc npc in gamestate.Npcs) npcs.Add(new Npc(npc.Name, npc.Id));
            }

            PreservePlantModule.JarBuilder jamJar = ConvertToJarBuilder(gamestate.JamJar);
            PreservePlantModule.JarBuilder pickledJar = ConvertToJarBuilder(gamestate.PickledJar);

            List<IStoredItem> items = new List<IStoredItem>();
            foreach (StoredItemDoc item in gamestate.Items) items.Add(item.GetIStoredItem());

            Plant?[] plants = new Plant?[gamestate.Plants.Length];
            for (int i = 0; i < gamestate.Plants.Length; i++)
            {
                if (gamestate.Plants[i].Empty != true)
                {
                    plants[i] = new Plant(gamestate.Plants[i].CropType, gamestate.Plants[i].GrowthStage, gamestate.Plants[i].WitheringStage);
                }
            }

            Level level = new Level(gamestate.Level);

            string username = gamestate.Username;

            return new GamestateModule.InteractiveGameState(npcs, jamJar, pickledJar, items, plants, level, username);
        }


        private static PreservePlantModule.JarBuilder ConvertToJarBuilder(JarBuilderDoc jarBuilder)
        {
            List<CropType> cropTypes = new List<CropType>();
            foreach (string cropType in jarBuilder.CropTypes)
            {
                cropTypes.Add(Helper.ConvertStringToCropType(cropType));
            }
            return new JarBuilder(ConvertToPreserveType(jarBuilder.PreserveType), cropTypes);
        }

        private static PreservePlantModule.PreserveType ConvertToPreserveType(string preserveType)
        {
            switch (preserveType)
            {
                case "Jam":
                    return PreservePlantModule.PreserveType.Jam;
                case "Pickled":
                    return PreservePlantModule.PreserveType.Pickled;
                default:
                    throw new Exception("Invalid preserve type");
            }
        }


    }
}
