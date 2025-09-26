using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Linq;
using AvaloniaProject1pw.Data;
using AvaloniaProject1pw.Models;
using AvaloniaProject1pw.ViewModels;

namespace AvaloniaProject1pw;

public partial class Users : UserControl
{
    public Users()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
    private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        var selectedUser = MainDataGridUsers.SelectedItem as User;

        if (selectedUser == null) return;

        UserVariableData.seletedUserInMainWindow = selectedUser;

        var parent = this.VisualRoot as Window;
        if (parent == null) return;
        var createAndChangeUserWindow = new CreateAndChangeUser();
        await createAndChangeUserWindow.ShowDialog(parent);

        var viewModel = DataContext as MainWindowViewModel;
        viewModel.RefreshData();

    }

    private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        UserVariableData.seletedUserInMainWindow = null;

        var createAndChangeUserWindow = new CreateAndChangeUser();
        var parent = this.VisualRoot as Window;

        await createAndChangeUserWindow.ShowDialog(parent);

        var viewModel = DataContext as MainWindowViewModel;
        viewModel.RefreshData();
    }
}