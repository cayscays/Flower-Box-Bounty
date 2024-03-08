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

namespace View
{
    /// <summary>
    /// Interaction logic for AdminMainMenuView.xaml
    /// </summary>
    public partial class AdminMainMenuView : Window
    {
        private ViewModel.AdminMainMenuViewModel _viewModel = new AdminMainMenuViewModel();
        public AdminMainMenuView()
        {
            InitializeComponent();
            WelcomeAdmin.Content = $"Welcome {_viewModel.Username}!";
            DataContext = this;
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

        public void Watch_Game_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.WatchGame(this);

        }
    }
}
