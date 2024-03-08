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

namespace View
{
    /// <summary>
    /// Interaction logic for MainMenuView.xaml
    /// </summary>
    public partial class PlayerMainMenuView : Window
    {
        private ViewModel.PlayerMainMenuViewModel _viewModel = new ViewModel.PlayerMainMenuViewModel();
        public PlayerMainMenuView()
        {
            
            InitializeComponent();
            WelcomePlayer.Content = $"Welcome {_viewModel.Username}!";
            DataContext = this;
        }

        public void Play_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Play(this);
        }
        public void Help_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Help(this);
        }
        public void Leaderboard_Click(object sender, RoutedEventArgs e)
        {
           _viewModel.Leaderboard(this);
        }
        public void Logout_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Logout(this);
        }
    }
}
