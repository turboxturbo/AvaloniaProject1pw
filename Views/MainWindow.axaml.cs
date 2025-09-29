using Avalonia.Controls;
using System;
using AvaloniaProject1pw.Data;
using AvaloniaProject1pw.Models;
using AvaloniaProject1pw.ViewModels;
using AvaloniaProject1pw;

namespace AvaloniaProject1pw.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            MainControl.Content = new Users();
        }

        private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainControl.Content = new Users();
        }

        private void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainControl.Content = new Items();
        }

        private void Button_Click_3(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainControl.Content = new Baskets();
        }
    }
}