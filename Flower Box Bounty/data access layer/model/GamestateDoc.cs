/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using Flower_Box_Bounty.data_access_layer.model;
using ItemModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class GamestateDoc : BsonDocBase
    {
        public string Username { get; private set; }
        public StoredItemDoc[] Items { get; private set; }
        public NpcDoc[] Npcs { get; private set; }
        public PlantDoc[] Plants { get; private set; }
        public JarBuilderDoc JamJar { get; private set; }
        public JarBuilderDoc PickledJar { get; private set; }
        public ulong Level { get; private set; }


        public GamestateDoc(GamestateModule.GameState gameState)
        {
            Username = gameState.GetUsername();
            var gameStateItems = gameState.GetItems();
            Items = new StoredItemDoc[gameStateItems.Count];
            for (int i = 0; i < gameStateItems.Count; i++)
            {
                Items[i] = new StoredItemDoc(gameStateItems[i]);
            }
            Level = gameState.GetLevel().LevelNumber;
            JamJar = new JarBuilderDoc(gameState.GetJamJar());
            PickledJar = new JarBuilderDoc(gameState.GetPickledJar());

            Npcs = new NpcDoc[gameState.GetNpcs().Count];
            for (int i = 0; i < gameState.GetNpcs().Count; i++)
            {
                Npcs[i] = new NpcDoc(gameState.GetNpcs()[i]);
            }

            Plants = new PlantDoc[gameState.GetPlants().Length];
            for (int i = 0; i < gameState.GetPlants().Length; i++)
            {
                Plants[i] = new PlantDoc(gameState.GetPlants()[i]);
            }
        }



    }
}
