using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Linq;
using AvaloniaProject1pw.Data;
using AvaloniaProject1pw.Models;
using AvaloniaProject1pw.ViewModels;

namespace AvaloniaProject1pw;

public partial class Basket : UserControl
{
    public Basket()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
    private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        var selectedBasket = MainDataGridBaskets.SelectedItem as Basket;
        if (selectedBasket == null) return;

        var parent = this.VisualRoot as Window;
        if (parent == null) return;

        var createAndChangeBasketWindow = new CreateAndChangeBasket(selectedBasket);
        await createAndChangeBasketWindow.ShowDialog(parent);

        var viewModel = DataContext as MainWindowViewModel;
        viewModel?.RefreshBasketsData();
    }

    private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var parent = this.VisualRoot as Window;
        if (parent != null)
        {
            var createAndChangeBasketWindow = new CreateAndChangeBasket(null);
            await createAndChangeBasketWindow.ShowDialog(parent);
            var viewModel = DataContext as MainWindowViewModel;
            viewModel?.RefreshBasketsData();
        }
    }
}