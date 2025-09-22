using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Linq;
using AvaloniaProject1pw.Data;
using AvaloniaProject1pw.Models;
using AvaloniaProject1pw.ViewModels;

namespace AvaloniaProject1pw;

public partial class ItemUserControl : UserControl
{
    public ItemUserControl()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
    private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        var selectedItem = MainDataGridItems.SelectedItem as Item;
        if (selectedItem == null) return;

        var parent = this.VisualRoot as Window;
        if (parent == null) return;

        var createAndChangeItemWindow = new CreateAndChangeItem(selectedItem);
        await createAndChangeItemWindow.ShowDialog(parent);

        var viewModel = DataContext as MainWindowViewModel;
        viewModel?.RefreshItemsData();
    }

    private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var parent = this.VisualRoot as Window;
        if (parent != null)
        {
            var createAndChangeItemWindow = new CreateAndChangeItem(null);
            await createAndChangeItemWindow.ShowDialog(parent);
            var viewModel = DataContext as MainWindowViewModel;
            viewModel?.RefreshItemsData();
        }
    }
}