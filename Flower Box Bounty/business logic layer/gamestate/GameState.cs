/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Common;
using ItemModule;
using NpcModule;
using PreservePlantModule;
using LevelModule;
using PlantModule;
namespace GamestateModule
{
    public class GameState
    {
        protected int _plantSize = 5;
        protected string _username;

        protected List<Npc> _npcs;
        protected Dictionary<PreserveType, PreserveBuilder> _preserveBuilders = new Dictionary<PreserveType, PreserveBuilder>();
        protected List<IStoredItem> _items;
        protected Plant?[] _plants; // Null value = empty spot in the flower box
        protected Level _level;

        //default
        public GameState()
        {

            _npcs = new List<Npc>();
            _npcs.Add(new Npc("Suzy", "001"));

            _items = new List<IStoredItem>();
            _plants = new Plant?[_plantSize];

            JarBuilder jamJar = new JarBuilder(PreserveType.Jam);
            JarBuilder pickledJar = new JarBuilder(PreserveType.Pickled);
            _preserveBuilders.Add(jamJar.PreserveType, jamJar);
            _preserveBuilders.Add(pickledJar.PreserveType, pickledJar);
            _level = new Level();
        }

        public GameState(List<Npc> npcs,
            JarBuilder jamJar,
            JarBuilder pickledJar,
            List<IStoredItem> items,
            Plant?[] plants,
            Level level,
            string username)
        {
            _username = username;
            _npcs = npcs;
            _preserveBuilders[PreserveType.Jam] = jamJar;
            _preserveBuilders[PreserveType.Pickled] = pickledJar;
            _items = items;
            _plants = plants;
            _level = level;
            _username = username;
        }
        protected GameState(GameState other)
        {
            _npcs = other.GetNpcs();
            _preserveBuilders[PreserveType.Jam] = other.GetJamJar();
            _preserveBuilders[PreserveType.Pickled] = other.GetPickledJar();
            _items = other.GetItems();
            _plants = other.GetPlants();
            _level = other.GetLevel();
            _username = other.GetUsername();
        }

        public List<Npc> GetNpcs() => _npcs.ConvertAll(npc => (Npc)npc.Clone());
        public JarBuilder GetJamJar()
        {
            return (JarBuilder)_preserveBuilders[PreserveType.Jam];
        }

        public JarBuilder GetPickledJar()
        {
            return (JarBuilder)_preserveBuilders[PreserveType.Pickled];
        }

        //TODO move to view model
        public List<string> GetItemsAsStrings()
        {
            List<String> result = new List<string>();
            foreach (var item in _items)
            {
                if (item is not null)
                {
                    result.Add(item.ToString());
                }
            }
            return result;
        }

        public List<IStoredItem> GetItems()
        {
            return Helper.DeepCopy(_items);
        }

        public IStoredItem? GetItem(int index)
        {
            if (Helper.IsLegalIndex<IStoredItem>(_items, index))
                return (IStoredItem)_items[index].Clone();
            else
            {
                return null;
            }
        }

        public Plant?[] GetPlants()
        {
            return Helper.DeepCopy(_plants);
        }

        public Plant? GetPlant(int index)
        {
            return (Plant)_plants[index].Clone();
        }

        public Level GetLevel()
        {

            return (Level)_level.Clone();
        }

        public string GetUsername()
        {
            return _username;
        }
    }
}
