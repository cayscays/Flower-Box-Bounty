/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Common;
using Data.Operations;
using Service;

namespace ViewModel
{
    public class GameViewModel : ViewModel
    {
        private GamestateModule.GameState _gamestate;
        private GamestateModule.InteractiveGameState _interactiveGamestate;
        private int _plantSize = 50; // Plant images dimensions
        public string? Npc { get => _gamestate.GetNpcs().ToString(); }
        public List<string> JamJarCropList { get => _gamestate.GetJamJar().CropTypes.Select(e => e.ToString()).ToList(); }
        public List<string> PickledJarCropList { get => _gamestate.GetPickledJar().CropTypes.Select(e => e.ToString()).ToList(); }
        public List<String> Items { get => _gamestate.GetItemsAsStrings(); }
        public string Plants { get => Helper.NullableArrayToString(_gamestate.GetPlants()); }
        public string LevelNumber { get => _gamestate.GetLevel().ToString(); }
        public string PlayersName { get => _gamestate.GetUsername(); }
        public List<Image> PlantsImages { get => _gamestate.GetPlants().Select(e => PlantToImage(e)).ToList(); }
        public Image FlowerBoxImage
        {
            get
            {
                Image image = new Image();
                image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri($"/presentation layer/view/resources/FlowerBox.bmp", UriKind.Relative));
                image.Width = _plantSize * Plants.Length;
                image.Height = _plantSize;
                return image;
            }
        }
        public Visibility Interactive
        {
            get
            {
                bool isAdmin = Service.UserService.IsAdminUsername(Username);
                return isAdmin ? Visibility.Hidden : Visibility.Visible;
            }
        }


        public GameViewModel()
        {
            _interactiveGamestate = (GamestateModule.InteractiveGameState)GamestateDal.GetGameStateByUsername(Username);
            _gamestate = _interactiveGamestate;
        }

        public GameViewModel(string username)
        {
            _gamestate = GamestateDal.GetGameStateByUsername(username);
        }



        public void RemoveFromJam(int index)
        {
            _interactiveGamestate.RemoveFromJam(index);
        }

        public void RemoveFromPickled(int index)
        {
            _interactiveGamestate.RemoveFromPickled(index);
        }

        public Image PlantToImage(PlantModule.Plant plant)
        {
            Image image = new Image();
            if (plant is null)
            {
                image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri($"/presentation layer/view/resources/Empty.bmp", UriKind.Relative));
            }
            else if (plant.GetGrowthStage == PlantModule.GrowthStage.Seeding)
            {
                image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri($"/presentation layer/view/resources/{plant.GetGrowthStage.ToString()}.bmp", UriKind.Relative));
            }
            else if (plant.IsReadyToHarvest())
            {
                image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri($"/presentation layer/view/resources/{plant.GetCropType.ToString()}.bmp", UriKind.Relative));
            }
            else if (plant.GetWitheringStage == PlantModule.WitheringStage.Brown)
            {
                image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri($"/presentation layer/view/resources/Brown.bmp", UriKind.Relative));
            }
            else
            {
                image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri($"/presentation layer/view/resources/{plant.GetGrowthStage.ToString()}.{plant.GetWitheringStage.ToString()}.bmp", UriKind.Relative));
            }

            image.Width = _plantSize;
            image.Height = _plantSize;
            return image;
        }



        public void AddToJam(int selectedIndex)
        {
            _interactiveGamestate.AddToJam(selectedIndex);
        }

        public void AddToPickled(int selectedIndex)
        {
            _interactiveGamestate.AddToPickled(selectedIndex);
        }

        public bool PreserveJam()
        {
            return _interactiveGamestate.PreserveJam();
        }

        public bool PreservePickled()
        {
            return _interactiveGamestate.PreservePickled();
        }

        public void Harvest()
        {
            _interactiveGamestate.Harvest();
        }

        public void Plant(int selectedIndex)
        {
            _interactiveGamestate.AddPlant(selectedIndex);
        }

        public string GiveGiftToNpc(int selectedIndex)
        {
            return _interactiveGamestate.GiveGiftToNpc(selectedIndex);
        }

        public void Water()
        {
            _interactiveGamestate.Water();
        }

        public void RemoveDeadPlants()
        {
            _interactiveGamestate.RemoveDeadPlants();
        }

        public void Save()
        {
            _interactiveGamestate.Save();

            LeaderboardModule.Leaderboard leaderboard;
            // Handle the scenario where no leaderboard exists in the database by creating one
            try
            {
                leaderboard = LeaderboardDal.Read();
                if (leaderboard is null) leaderboard = new LeaderboardModule.Leaderboard();
            }
            catch { leaderboard = new LeaderboardModule.Leaderboard(); }
            leaderboard.Update(Username, _interactiveGamestate.GetLevel().LevelNumber);
            LeaderboardDal.Update(leaderboard);
        }

        public string? IncomingGift()
        {
            if ((_currentUser.IsLoggedIn()) && 
                (!UserService.IsAdminUsername(Username)))
            {
                string[]? giftData = _interactiveGamestate.IncomingGift();
                if (giftData is null)
                {
                    return null;
                }
                else
                {
                    return $"{giftData[0]} gifted you: {giftData[1]}";
                }
            }
            else return null;
        }

        public void GiveGiftToRandomPlayer(int selectedImdex)
        {
            if (Helper.IsLegalIndex<string>(_interactiveGamestate.GetItemsAsStrings(), selectedImdex))
            {
                _interactiveGamestate.GiveGiftToRandomPlayer(selectedImdex);
            }
        }
    }
}
