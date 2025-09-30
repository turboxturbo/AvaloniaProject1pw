using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Linq;
using AvaloniaProject1pw.Data;
using AvaloniaProject1pw.Models;
using AvaloniaProject1pw;

namespace AvaloniaProject1pw;

public partial class CreateAndChangeBasket : Window
{
    private readonly Data.Basket? editibasket;

    public CreateAndChangeBasket(Data.Basket? basketToEdit)
    {
        editibasket = basketToEdit;
        InitializeComponent();
        LoadUsers();
        LoadItems();
        LoadBasketData();
    }

    private void LoadUsers()
    {
        var users = App.DbContext.Users.ToList();
        UserComboBox.ItemsSource = users;
    }

    private void LoadItems()
    {
        var items = App.DbContext.Items.ToList();
        ItemComboBox.ItemsSource = items;
    }

    private void LoadBasketData()
    {
        if (editibasket == null) return;

        CounterText.Text = editibasket.Counter.ToString();

        var selectedUser = UserComboBox.ItemsSource
            .OfType<User>()
            .FirstOrDefault(u => u.IdUser == editibasket.IdUser);
        UserComboBox.SelectedItem = selectedUser;

        var selectedItem = ItemComboBox.ItemsSource
            .OfType<Data.Item>()
            .FirstOrDefault(i => i.IdItem == editibasket.IdItem);
        ItemComboBox.SelectedItem = selectedItem;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (UserComboBox.SelectedItem == null)
        {
            ShowError("Необходимо выбрать пользователя");
            return;
        }

        if (ItemComboBox.SelectedItem == null)
        {
            ShowError("Необходимо выбрать товар");
            return;
        }

        if (string.IsNullOrWhiteSpace(CounterText.Text))
        {
            ShowError("Поле 'Counter' обязательно для заполнения");
            return;
        }

        var selectedUser = (User)UserComboBox.SelectedItem;
        var selectedItem = (Data.Item)ItemComboBox.SelectedItem;

        try
        {
            if (editibasket != null)
            {
                var basket = App.DbContext.Baskets
                    .FirstOrDefault(b => b.IdBasket == editibasket.IdBasket);

                if (basket != null)
                {
                    basket.IdUser = selectedUser.IdUser;
                    basket.IdItem = selectedItem.IdItem;
                    basket.Counter = int.Parse(CounterText.Text);
                }
            }
            else
            {
                var newBasket = new Data.Basket()
                {
                    IdUser = selectedUser.IdUser,
                    IdItem = selectedItem.IdItem,
                    Counter = int.Parse(CounterText.Text),
                };
                App.DbContext.Baskets.Add(newBasket);
            }

            App.DbContext.SaveChanges();
            this.Close();
        }
        catch (Exception ex)
        {
            ShowError($"Ошибка: {ex.Message}");
        }
    }

    private void ShowError(string message)
    {
        var messageBox = new Window
        {
            Title = "Ошибка",
            Content = new TextBlock { Text = message, Margin = new Thickness(20) },
            SizeToContent = SizeToContent.WidthAndHeight,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };
        messageBox.ShowDialog(this);
    }
}