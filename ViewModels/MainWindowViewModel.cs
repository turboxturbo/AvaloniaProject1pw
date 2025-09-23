using AvaloniaProject1pw.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaProject1pw.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public List<User> Users { get; set; }
        public List<User> Items { get; set; }
        public List<User> Basket { get; set; }

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
            var basketsFromDb = App.DbContext.Baskets
                .Include(b => b.User)
                .Include(b => b.Items)
                .ToList();
            Baskets = basketsFromDb;
            OnPropertyChanged(nameof(Baskets));
        }
    }
}
