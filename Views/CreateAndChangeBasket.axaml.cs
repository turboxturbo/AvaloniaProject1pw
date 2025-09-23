using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Linq;
using AvaloniaProject1pw.Data;
using AvaloniaProject1pw.Models;

namespace TestSqlGilmi;

public partial class CreateAndChangeBasket : Window
{
    private readonly Basket? _editingBasket;

    public CreateAndChangeBasket(Basket? basketToEdit)
    {
        _editingBasket = basketToEdit;
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
        if (_editingBasket == null) return;

        CounterText.Text = _editingBasket.Counter;

        var selectedUser = UserComboBox.ItemsSource
            .OfType<User>()
            .FirstOrDefault(u => u.IdUser == _editingBasket.UserId);
        UserComboBox.SelectedItem = selectedUser;

        var selectedItem = ItemComboBox.ItemsSource
            .OfType<Item>()
            .FirstOrDefault(i => i.IdItems == _editingBasket.ItemsId);
        ItemComboBox.SelectedItem = selectedItem;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (UserComboBox.SelectedItem == null)
        {
            ShowError("���������� ������� ������������");
            return;
        }

        if (ItemComboBox.SelectedItem == null)
        {
            ShowError("���������� ������� �����");
            return;
        }

        if (string.IsNullOrWhiteSpace(CounterText.Text))
        {
            ShowError("���� 'Counter' ����������� ��� ����������");
            return;
        }

        var selectedUser = (User)UserComboBox.SelectedItem;
        var selectedItem = (Item)ItemComboBox.SelectedItem;

        try
        {
            if (_editingBasket != null)
            {
                var basket = App.DbContext.Baskets
                    .FirstOrDefault(b => b.IdBasket == _editingBasket.IdBasket);

                if (basket != null)
                {
                    basket.UserId = selectedUser.IdUser;
                    basket.ItemsId = selectedItem.IdItems;
                    basket.Counter = CounterText.Text;
                }
            }
            else
            {
                var newBasket = new Basket()
                {
                    UserId = selectedUser.IdUser,
                    ItemsId = selectedItem.IdItems,
                    Counter = CounterText.Text
                };
                App.DbContext.Baskets.Add(newBasket);
            }

            App.DbContext.SaveChanges();
            this.Close();
        }
        catch (Exception ex)
        {
            ShowError($"������: {ex.Message}");
        }
    }

    private void ShowError(string message)
    {
        var messageBox = new Window
        {
            Title = "������",
            Content = new TextBlock { Text = message, Margin = new Thickness(20) },
            SizeToContent = SizeToContent.WidthAndHeight,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };
        messageBox.ShowDialog(this);
    }
}