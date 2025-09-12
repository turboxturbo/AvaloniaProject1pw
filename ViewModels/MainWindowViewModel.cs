using AvaloniaProject1pw.Data;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaProject1pw.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public List<User> Users { get; set; }

        public MainWindowViewModel()
        {
            RefreshData();
        }

        public void RefreshData()
        {
            var usersFromDb = App.DbContext.Users.ToList();
            Users = usersFromDb;
            OnPropertyChanged(nameof(Users));
        }
    }
}
