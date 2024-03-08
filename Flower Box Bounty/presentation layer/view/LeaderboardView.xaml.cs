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
    /// Interaction logic for LeaderboardWindow.xaml
    /// </summary>
    public partial class LeaderboardView : Window
    {
        private ViewModel.LeaderboardViewModel _viewModel = new ViewModel.LeaderboardViewModel();
        public LeaderboardView()
        {
            InitializeComponent();
        }
        public void Menu_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GoToMenu(this);
        }
    }
}