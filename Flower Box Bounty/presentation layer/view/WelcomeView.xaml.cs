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
using View;

namespace View
{
    /// <summary>
    /// Interaction logic for WelcomeView.xaml
    /// </summary>
    public partial class WelcomeView : Window
    {
        private ViewModel.WelcomeViewModel _viewModel = new ViewModel.WelcomeViewModel();
        public WelcomeView()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Login(this, new LoginView());
        }

        private void SignupButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Signup(this, new SignupView());
        }
    }
}
