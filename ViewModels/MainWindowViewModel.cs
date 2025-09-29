using AvaloniaProject1pw.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaProject1pw.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public List<User> Users { get; set; }
        public List<Data.Item> Items { get; set; }
        public List<Data.Basket> Basket { get; set; }

        public MainWindowViewModel()
        {
            RefreshData();
            RefreshDataItems();
            RefreshBasketsData();
        }

        public void RefreshData()
        {
            var usersFromDb = App.DbContext.Users.ToList();
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
            //    .Include(b => b.IdUser)
            //    .Include(b => b.IdItem)
            //    .ToList();
            //Basket = basketsFromDb;
            //OnPropertyChanged(nameof(Basket));

            var basketFromDb = App.DbContext.Baskets.ToList();
            Basket = basketFromDb;
            OnPropertyChanged(nameof(Basket));
        }
    }
}
