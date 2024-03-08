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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewModel;
using GamestateModule;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using LevelModule;
using Data.Operations;
using Common;
using Service;

namespace View
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : Window
    {
        public Visibility Interactive  { get => _viewModel.Interactive; }
        private ViewModel.GameViewModel _viewModel;
        private DispatcherTimer timer;

        public ObservableCollection<string> JamJar { get; set; }
        public ObservableCollection<string> PickledJar { get; set; }
        public string Npc { get; set; }
        public ObservableCollection<string> Items { get; set; }

        public ObservableCollection<Image> Plants { get; set; }
        public ObservableCollection<Image> FlowerBox { get; set; }
        public string Level { get; set; }


        public GameView()
        {
            _viewModel = new ViewModel.GameViewModel();
            Init();
        }

        public GameView(string username)
        {
            _viewModel = new ViewModel.GameViewModel(username);
            Init();
        }

        private void NpcRefresh(object? sender, EventArgs e)
        {
          if (UserService.IsAdminUsername(_viewModel.Username)) return;

          // If the user is player, carry on:
          if (_viewModel.Npc != null)
            {
                string message  =_viewModel.IncomingGift();
                if (message is not null)
                {
                    MessageBox.Show(message, "Gift", MessageBoxButton.OK, MessageBoxImage.Information);
                    ItemsRefresh();
                }
            }
          
        }


        private void Init()
        {
           Items = new ObservableCollection<string>(_viewModel.Items.Select(s => new string(s.ToCharArray())));
           PickledJar = new ObservableCollection<string>(_viewModel.PickledJarCropList.Select(s => new string(s.ToCharArray())));
           JamJar = new ObservableCollection<string>(_viewModel.JamJarCropList.Select(s => new string(s.ToCharArray())));
           Plants = new ObservableCollection<Image>();
           Level = _viewModel.LevelNumber.ToString();

            InitializeComponent();

            WelcomeUser.Content = $"{_viewModel.PlayersName}'s Flower Box Bounty";

            DataContext = this;

            // flower box:
            FlowerBoxInit();

            // plants rendering:
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += FlowerBoxRefresh;
            timer.Tick += NpcRefresh;
            timer.Start();
        }


        public void Remove_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.RemoveDeadPlants();
        }

        private void LevelRefresh()
        {
            Level = _viewModel.LevelNumber;
            levelLabel.Content = Level;
        }
        public void Plant_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Plant(ItemsListBox.SelectedIndex);
            ItemsRefresh();
        }


        private void Water_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Water();
        }
        private void FlowerBoxInit()
        {
            FlowerBoxImagePanel.Children.Clear();
            FlowerBoxImagePanel.Children.Add(_viewModel.FlowerBoxImage);
        }

        private void FlowerBoxRefresh(object sender, EventArgs e)
        {
            PlantsImagePanel.Children.Clear();
            foreach (Image image in _viewModel.PlantsImages)
            {
                PlantsImagePanel.Children.Add(image);
            }
        }

        public void Menu_Click(object sender, RoutedEventArgs e)
        {
            if (!UserService.IsAdminUsername(_viewModel.Username))
            {
                _viewModel.Save();
            }
            _viewModel.GoToMenu(this);
        }

        public void Save_Click(object sender, RoutedEventArgs e)
        {
           _viewModel.Save();
        }

        public void Harvest_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Harvest();
            ItemsRefresh();
        }

        public void Make_Jam_Click(object sender, RoutedEventArgs e)
        {
          _viewModel.PreserveJam();
            ItemsRefresh();
            JamJarRefresh();
        }

        public void Make_Pickles_Click(object sender, RoutedEventArgs e)
        {
           _viewModel.PreservePickled();
           ItemsRefresh();
            PickledJarRefresh();
        }

        public void Gift_Other_User_Click(object sender, RoutedEventArgs e)
        {
            if (UserService.IsAdminUsername(_viewModel.Username)) return;

            // If the user is a player, carry on:
            _viewModel.GiveGiftToRandomPlayer(ItemsListBox.SelectedIndex);
            ItemsRefresh();
            LevelRefresh();
        }

        public void Gift_Npc_Click(object sender, RoutedEventArgs e)
        {
            string text = _viewModel.GiveGiftToNpc(ItemsListBox.SelectedIndex);

            if (text != null)
            {
                MessageBox.Show(text, "Gift", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            ItemsRefresh();
            LevelRefresh();
        }


        public void Add_To_Jam_Click(object sender, RoutedEventArgs e)
        {
          _viewModel.AddToJam(ItemsListBox.SelectedIndex);
            ItemsRefresh();
            JamJarRefresh();
        }

        public void Add_To_Pickles_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddToPickled(ItemsListBox.SelectedIndex);
            ItemsRefresh();
            PickledJarRefresh();
        }

        public void Remove_From_Jam_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.RemoveFromJam(JamJarListBox.SelectedIndex);
            ItemsRefresh();
            JamJarRefresh();
        }

        private void JamJarRefresh()
        {
            JamJar.Clear();
            foreach (var item in _viewModel.JamJarCropList)
            {
                JamJar.Add(item);
            }
        }

        public void Remove_From_Pickles_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.RemoveFromPickled(PickledJarListBox.SelectedIndex);
            ItemsRefresh();
            PickledJarRefresh();
        }

        private void PickledJarRefresh()
        {
            PickledJar.Clear();
            foreach (var item in _viewModel.PickledJarCropList)
            {
                PickledJar.Add(item);
            }
        }

        private void ItemsRefresh()
        {
            Items.Clear();
            foreach (var item in _viewModel.Items)
            {
                Items.Add(item);
            }
        }

    }
}
