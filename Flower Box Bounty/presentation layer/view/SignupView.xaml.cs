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
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace View
{
    public partial class SignupView : Window
    {
        private ViewModel.SignupViewModel _viewModel = new ViewModel.SignupViewModel();
        public SignupView()
        {
            InitializeComponent();
        }

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            string username = txtNewUsername.Text;
            string password = txtNewPassword.Password;
            string passwordConfirmation = txtNewPasswordConfirmation.Password;
            _viewModel.Signup(username, password, passwordConfirmation, this);

        }

        public void Back_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Back(this);
        }
    }
}
