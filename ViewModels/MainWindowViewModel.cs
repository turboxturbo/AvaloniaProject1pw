using System;
using System.Collections.Generic;
using System.Linq;
using AvaloniaProject1pw.Data;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaProject1pw.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public List<User> Users { get; set; }
        public List<Data.Item> Items { get; set; }
        public List<Data.Basket> Baskets { get; set; }

        public MainWindowViewModel()
        {
            RefreshData();
            RefreshDataItems();
            RefreshBasketsData();
        }

        public void RefreshData()
        {
            var usersFromDb = App.DbContext.Users
            .Include(u => u.IdRoleNavigation)
            .ToList();
            Users = usersFromDb;
            OnPropertyChanged(nameof(Users));
        }

        public void RefreshDataItems()
        {
            var itemsFromDb = App.DbContext.Items.ToList();
            Items = itemsFromDb;
            OnPropertyChanged(nameof(Items));
        }
        public void RefreshBasketsData()
        {
            //var basketsFromDb = App.DbContext.Baskets
            //    .Include(b => b.IdUserNavigation)
            //    .Include(b => b.IdItemNavigation)
            //    .ToList();
            //Baskets = basketsFromDb;
            //OnPropertyChanged(nameof(Baskets));

            var basketFromDb = App.DbContext.Baskets.ToList();
            Baskets = basketFromDb;
            OnPropertyChanged(nameof(Baskets));
        }
        public async void Delete()
        {
            //if (SelectedUser == null)
            //{
            //    await MessageBox.Show("Выберите пользователя для удаления!");
            //    return;
            //}

            //var result = await MessageBox.Show($"Вы уверены, что хотите удалить пользователя {SelectedUser.Login}?", "Подтверждение удаления", MessageBoxButtons.YesNo);

            //if (result == MessageBoxResult.Yes)
            //{
            //    try
            //    {
            //        App.DbContext.Users.Remove(SelectedUser);
            //        await App.DbContext.SaveChangesAsync();
            //        RefreshUsersList();
            //        SelectedUser = null; // Сбрасываем выбор
            //        await MessageBox.Show("Пользователь успешно удален!");
            //    }
            //    catch (Exception ex)
            //    {
            //        await MessageBox.Show($"Ошибка при удалении: {ex.Message}");
            //    }
            //}
        }
    }
}
