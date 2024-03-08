/******************************************************************************
 * Author:   cayscays
 * Website:  https://github.com/cayscays/
 *****************************************************************************/

﻿using Flower_Box_Bounty;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace View
{
    public partial class LoginView : Window
    {
        private ViewModel.LoginViewModel _viewModel = new ViewModel.LoginViewModel();
        public LoginView()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            _viewModel.Login(username, password, this);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Back(this);
        }
    }
}
