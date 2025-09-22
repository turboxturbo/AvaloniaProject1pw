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
            DataContext = new MainWindowViewModel();
        }

        private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e) // change
        {
            var selectedUser = MainDataGridUsers.SelectedItem as User;

            if (selectedUser == null) return;

            UserVariableData.seletedUserInMainWindow = selectedUser;

            var createAndChangeUserWindow = new CreateAndChangeUser();
            await createAndChangeUserWindow.ShowDialog(this);

            var viewModel = DataContext as MainWindowViewModel;
            viewModel.RefreshData();
        }

        private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e) //add
        {
            UserVariableData.seletedUserInMainWindow = null;

            var createAndChangeUserWindow = new CreateAndChangeUser();
            await createAndChangeUserWindow.ShowDialog(this);

            var viewModel = DataContext as MainWindowViewModel;
            viewModel.RefreshData();
        }

        private async void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e) //login
        {
            var createAndChangeUserWindow = new CreateAndChangeLogin();
            await createAndChangeUserWindow.ShowDialog(this);

            var viewModel = DataContext as MainWindowViewModel;
            viewModel.RefreshData();
        }

        private async void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e) // delete
        {
            var selectedUser = MainDataGridUsers.SelectedItem as User;
            if (selectedUser != null)
            {
                UserVariableData.seletedUserInMainWindow = selectedUser;
                selectedUser = null;
                var viewModel = DataContext as MainWindowViewModel; 
                viewModel.RefreshData(); // обновление бд
            }
        }
    }
}