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
using ItemModule;
using NpcModule;
using PreservePlantModule;
using LevelModule;
using PlantModule;
using Common;
using Data.Models;
using Data.Operations;
using System.Xml.Linq;

namespace GamestateModule
{
    public class InteractiveGameState : GameState
    {
        private bool _recivedGiftFromNpcAtCurrentLevel;
        private bool _recivedGiftFromOtherUserAtCurrentLevel;

        public InteractiveGameState(List<Npc> npcs, JarBuilder jamJar, JarBuilder pickledJar, List<IStoredItem> items, Plant?[] plants, Level level, string username) : base(npcs, jamJar, pickledJar, items, plants, level, username)
        {
            _recivedGiftFromNpcAtCurrentLevel = true;
            _recivedGiftFromOtherUserAtCurrentLevel = true;
        }

        public InteractiveGameState() : base() 
        {
            Init();
        }

        public InteractiveGameState(string username)
        {
            _username = username;
            Init();
        }

        private void Init()
        {
            _recivedGiftFromNpcAtCurrentLevel = false;
            _recivedGiftFromOtherUserAtCurrentLevel = false;
            AddIStoredItem(Seed.GetRandomSeed());
            AddIStoredItem(Seed.GetRandomSeed());
        }

        // NPCs
        public void AddNpc(Npc npc)
        {
            _npcs.Add(npc);
        }

        public void RemoveNpc(Npc npc)
        {
            _npcs.Remove(npc);
        }

        // Items

        /*
         * returns true if succeeds
         */
        public bool AddIStoredItem(IStoredItem item)
        {
            try
            {
                _items.Add(item);
                return true;
            }
            catch { return false; }
        }


        public IStoredItem RemoveIStoredItem(int index)
        {
            IStoredItem item = _items[index];
            _items[index] = null;
            return item;
        }


        // Plants

        /*
         * returns true if succeeds
         */
        public bool AddPlant(Plant plant, int index)
        {
            if (!Helper.IsEmptyAt<Plant>(index, _plants)) return false;
            else
            {
                _plants[index] = (Plant)plant.Clone();
                return true;
            }
        }

        public bool AddPlant(int itemIndex)
        {
            if (!Helper.IsLegalIndex<IStoredItem>(_items, itemIndex)) return false;
            if (!(_items[itemIndex] is Seed)) return false;
            bool result = AddPlant(new Plant(((Seed)_items[itemIndex]).CropType));
            if (result) RemoveFromItems(itemIndex);
            return result;
        }

        public bool AddPlant(Plant plant)
        {
            for (int i = 0; i < _plants.Length; i++)
            {
                if (Helper.IsEmptyAt<Plant>(i, _plants))
                {
                    _plants[i] = (Plant)plant.Clone();
                    return true;
                }
            }
            return false;
        }


        public Plant RemovePlant(int index)
        {
            Plant plant = new Plant(_plants[index]);
            _plants[index] = null;
            return plant;
        }

        // Level
        public void SetNextLevel()
        {
            _level.Next();
            _recivedGiftFromNpcAtCurrentLevel = false;
            _recivedGiftFromOtherUserAtCurrentLevel = false;
        }

        private bool RemoveFromJar(int index, JarBuilder jar)
        {
            if (!Helper.IsLegalIndex<CropType>(jar.CropTypes, index)) return false;
            _items.Add(new Crop(jar.CropTypes[index]));
            jar.RemoveCrop(index);
            return true;
        }

        public bool RemoveFromJam(int index)
        {
            return RemoveFromJar(index, (JarBuilder)_preserveBuilders[PreserveType.Jam]);
        }

        public bool RemoveFromPickled(int index)
        {
            return RemoveFromJar(index, (JarBuilder)_preserveBuilders[PreserveType.Pickled]);
        }

        private bool RemoveFromItems(int index)
        {
            if (_items.Count < index) return false;
            _items.RemoveAt(index);
            return true;
        }

        public bool AddToJar(int index, JarBuilder jar)
        {
            if (!Helper.IsLegalIndex<IStoredItem>(_items, index)) return false;
            else if (_items[index] is not Crop) return false;
            Crop crop = (Crop)_items[index];
            jar.AddCrop(crop.CropType);
            _items.RemoveAt(index);
            return true;
        }

        public bool AddToJam(int index)
        {
            return AddToJar(index, (JarBuilder)_preserveBuilders[PreserveType.Jam]);
        }

        public bool AddToPickled(int index)
        {
            return AddToJar(index, (JarBuilder)_preserveBuilders[PreserveType.Pickled]);
        }

        private bool Preserve(JarBuilder jar)
        {
            if (jar.CropTypes.Count == 0) return false;
            _items.Add(new Preseved(jar.PreserveType, jar.RemoveAndReturnAllIngridients()));
            return true;
        }

        public bool PreserveJam()
        {
            return Preserve((JarBuilder)_preserveBuilders[PreserveType.Jam]);
        }


        public bool PreservePickled()
        {
            return Preserve((JarBuilder)_preserveBuilders[PreserveType.Pickled]);
        }

        public void Harvest()
        {
            foreach (Plant plant in _plants)
            {
                if (plant is null) continue;
                if (plant.IsReadyToHarvest())
                {
                    _items.Add(new Crop(plant.GetCropType));
                    _items.Add(new Seed(plant.GetCropType));
                    _plants[Array.IndexOf(_plants, plant)] = null;
                }
            }
        }

        public string GiveGiftToNpc(int selectedIndex)
        {
            string result = GiveGiftToNpc(selectedIndex, 0);
            return result;
        }

        public string GiveGiftToNpc(int itemIndex, int npcIndex)
        {
            if (!Helper.IsLegalIndex<Npc>(_npcs, npcIndex) ||
                !Helper.IsLegalIndex<IStoredItem>(_items, itemIndex)) return null;

            string result = _npcs[npcIndex].ReceiveGift(GetItem(itemIndex));
            RemoveFromItems(itemIndex);
            if (result is not null) SetNextLevel();
            return result;
        }

        public string GiveGiftToRandomPlayer(int itemIndex)
        {
            IStoredItem? item = GetItem(itemIndex);
            GiftsDal.PushGift(new Data.Models.GiftDoc(_username, item));
            RemoveFromItems(itemIndex);
            SetNextLevel();
            return $"Thank you for the {item.ToString()}!";
        }

        public void Water()
        {
            foreach (Plant plant in _plants)
            {
                if (plant is null) continue;
                if (plant.GetWitheringStage == WitheringStage.Yellow)
                {
                    plant.UnWither();
                }
                else if (plant.GetWitheringStage == WitheringStage.Green)
                {
                    plant.Grow();
                }
            }
        }

        public void RemoveDeadPlants()
        {
            foreach (Plant plant in _plants)
            {
                if (plant is null) continue;
                if (plant.GetWitheringStage == WitheringStageExtentions.Max)
                {
                    _plants[Array.IndexOf(_plants, plant)] = null;
                }
            }
        }

        public string[] IncomingGift(Npc npc)
        {

            string[] result = new string[2];
            _items.Add(npc.GiftSeed());
            result[0] = npc.Name;
            result[1] = _items[_items.Count - 1].ToString();
            return result;

        }

        public string[] IncomingGift(string giver, IStoredItem item)
        {
            string[] result = new string[2];
            _items.Add(item);
            result[0] = giver;
            result[1] = _items[_items.Count - 1].ToString();
            return result;
        }

        public string[]? IncomingGift()
        {
            if (_npcs is null || _npcs.Count == 0) return null;
            if (IsTimeForGiftFromNpc())
            {
                _recivedGiftFromNpcAtCurrentLevel = true;
                return IncomingGift(_npcs[Helper.Random.Next(_npcs.Count)]);
            }
            else if (IsTimeForGiftFromOtherUser())
            {
                _recivedGiftFromOtherUserAtCurrentLevel = true;
                var gift = GiftsDal.PopGift(_username);
                return (gift is null) ? null : IncomingGift(gift.GiverUsername, gift.GetItem());
            }
            else return null;
        }

        // Returns true every 5th level starting level 1,
        // or if there are no items in the player's inventory
        private bool IsTimeForGiftFromNpc()
        {
            return
                (_level.LevelNumber % 5 == 1 && !_recivedGiftFromNpcAtCurrentLevel) ||
                (_items.Count == 0);
        }

        // Returns true every 5th level starting level 3.
        private bool IsTimeForGiftFromOtherUser()
        {
            return (_level.LevelNumber % 5 == 3 && !_recivedGiftFromOtherUserAtCurrentLevel);
        }

        public void Save()
        {
            GamestateDal.UpdateGameState(new GamestateDoc(this));
        }
    }
}
