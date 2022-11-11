﻿using ShoesStore.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShoesStore_WPF.Views
{
    /// <summary>
    /// Interaction logic for ShoppingListView.xaml
    /// </summary>
    public partial class ShoppingListView : UserControl
    {
        public ShoppingListView()
        {
            InitializeComponent();
        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 30;
            da.To = 50;
            da.Duration = new Duration(TimeSpan.FromSeconds(100));
            da.AutoReverse = true;
        //    B1.BeginAnimation(Button.HeightProperty, da);
        
        }
    }
}
