using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaloniaProject1pw.Data;

namespace AvaloniaProject1pw.ViewModels
{
    partial class LoginViewModel : ViewModelBase
    {
        public List<Login> Logins { get; set; }

        public LoginViewModel()
        {
            RefreshData();
        }

        public void RefreshData()
        {
            var loginsFromDb = App.DbContext.Logins.ToList();
            Logins = loginsFromDb;
            OnPropertyChanged(nameof(Logins));
        }
    }
}
