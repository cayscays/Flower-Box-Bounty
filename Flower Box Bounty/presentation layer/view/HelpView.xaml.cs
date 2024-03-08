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
using UserModule;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for HelpView.xaml
    /// </summary>
    public partial class HelpView : Window
    {
        private ViewModel.HelpViewModel _viewModel = new ViewModel.HelpViewModel();
        public HelpView()
        {
            InitializeComponent();
        }

        public void Menu_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GoToMenu(this);  
        }
    }
}
