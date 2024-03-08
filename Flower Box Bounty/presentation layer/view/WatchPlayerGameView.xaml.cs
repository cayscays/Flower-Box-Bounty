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
    /// Interaction logic for WatchPlayerGameView.xaml
    /// </summary>
    public partial class WatchPlayerGameView : Window
    {
        private ViewModel.WatchPlayerGameViewModel _viewModel = new ViewModel.WatchPlayerGameViewModel();
        public WatchPlayerGameView()
        {
            InitializeComponent();
        }

        public void Menu_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GoToMenu(this);
        }

        public void Watch_Game_Click(object sender, RoutedEventArgs e)
        {
            if(Usernames_List.SelectedItem is not null) 
            _viewModel.WatchPlayerGame(this, Usernames_List.SelectedItem.ToString());
        }
    }
}
