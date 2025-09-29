using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Linq;
using AvaloniaProject1pw.Data;
using AvaloniaProject1pw.Models;
using AvaloniaProject1pw.Data;
using System.Diagnostics.Metrics;

namespace AvaloniaProject1pw;

public partial class CreateAndChangeItem : Window
{
    private readonly Data.Item? edititem;

    public CreateAndChangeItem(Data.Item? itemToEdit)
    {
        edititem = itemToEdit;
        InitializeComponent();
        LoadItemData();
    }

    private void LoadItemData()
    {
        if (edititem == null) return;

        NameText.Text = edititem.NameItem;
        PriceText.Text = edititem.Price.ToString();
        DescriptionText.Text = edititem.Description;
        
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameText.Text))
        {
            ShowError("Поле обязательно для заполнения");
            return;
        }

        if (string.IsNullOrWhiteSpace(PriceText.Text))
        {
            ShowError("Поле обязательно для заполнения");
            return;
        }

        try
        {
            if (edititem != null)
            {
                var item = App.DbContext.Items
                    .FirstOrDefault(i => i.IdItem == edititem.IdItem);

                if (item != null)
                {
                    item.NameItem = NameText.Text;
                    item.Price = int.Parse(PriceText.Text);
                    item.Description = DescriptionText.Text;
                }
            }
            else
            {
                var newItem = new Data.Item()
                {
                    NameItem = NameText.Text,
                    Price = int.Parse(PriceText.Text),
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