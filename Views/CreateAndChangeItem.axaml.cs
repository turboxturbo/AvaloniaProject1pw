using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Linq;
using AvaloniaProject1pw.Data;
using AvaloniaProject1pw.Models;
using AvaloniaProject1pw;

namespace AvaloniaProject1pw;

public partial class CreateAndChangeItem : Window
{
    private readonly Item? edititem;

    public CreateAndChangeItem(Item? itemToEdit)
    {
        edititem = itemToEdit;
        InitializeComponent();
        LoadItemData();
    }

    private void LoadItemData()
    {
        if (edititem == null) return;

        NameText.Text = edititem.NameItem;
        PriceText.Text = edititem.Price;
        DescriptionText.Text = edititem.Description;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameText.Text))
        {
            ShowError("Поле 'Name' обязательно для заполнения");
            return;
        }

        if (string.IsNullOrWhiteSpace(PriceText.Text))
        {
            ShowError("Поле 'Price' обязательно для заполнения");
            return;
        }

        try
        {
            if (edititem != null)
            {
                var item = App.DbContext.Items
                    .FirstOrDefault(i => i.IdItems == edititem.IdItems);

                if (item != null)
                {
                    item.Name = NameText.Text;
                    item.Price = PriceText.Text;
                    item.Opisanie = DescriptionText.Text;
                }
            }
            else
            {
                var newItem = new Item()
                {
                    NameItem = NameText.Text,
                    Price = PriceText.Text,
                    Description = DescriptionText.Text
                };
                App.DbContext.Items.Add(newItem);
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