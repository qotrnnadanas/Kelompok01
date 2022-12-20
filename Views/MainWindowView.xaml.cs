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

namespace Kelompok01.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        List<UserControl> userControls = new List<UserControl>();

        public MainWindowView()
        {
            InitializeComponent();

            App.UserProfileFrame = this.UserProfileFrame;

            userControls.AddRange(new List<UserControl>
            {
                new HomeView(),
                new SearchView(null),
                new HistoryView(),
                new SettingView()
            });

            MainContent.Content = userControls[0];
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            App.UserProfileFrame.Navigate(new LoginView());
        }

        private void NavigateMainContent(object sender, RoutedEventArgs e)
        {
            var tag = Convert.ToInt32((sender as RadioButton).Tag);
            MainContent.Content = userControls[tag];
        }

        private void EnterSearch(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                OpenSearch(SearchBox.Text);
                e.Handled = true;
            }
        }

        private void OpenSearch(string keyWord)
        {
            userControls[1] = new SearchView(keyWord);
            Search.IsChecked = true;
            MainContent.Content = userControls[1];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenSearch(SearchBox.Text);
        }
    }
}