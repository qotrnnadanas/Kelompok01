﻿using Kelompok01.MVVM.Model;
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

namespace Kelompok01.MVVM.View
{
    /// <summary>
    /// Interaction logic for AnimeEpisodesView.xaml
    /// </summary>
    public partial class AnimeEpisodesView : Page
    {
        public AnimeEpisodesView()
        {
            InitializeComponent();
            AnimeName.Content = "AnimeName";
            ShowEpisodes();
        }

        private void ShowEpisodes()
        {
            Style style = this.FindResource("WideButtonStyle") as Style;
            for (int i = 0; i < 6; i++)
            {
                Grid grid = new Grid();
                grid.Height = 60;

                Button button = new Button();
                button.HorizontalAlignment = HorizontalAlignment.Stretch;
                button.Tag = i;
                button.Content = "Episode" + Convert.ToString(i+1);
                button.Style = style;

                grid.Children.Add(button);
                EpisodesStackPanel.Children.Add(grid);
            }
        }
    }
}