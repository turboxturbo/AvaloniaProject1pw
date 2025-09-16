using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaProject1pw.Data;
using AvaloniaProject1pw.Models;
using AvaloniaProject1pw.ViewModels;
using System.Linq;

namespace AvaloniaProject1pw;

public partial class CreateAndChangeUser : Window
{
    public CreateAndChangeUser()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();

        if (UserVariableData.seletedUserInMainWindow == null) return;
        FullNameText.Text = UserVariableData.seletedUserInMainWindow.FullName;
        //LoginText.Text = UserVariableData.seletedUserInMainWindow.Login;
        //PasswordText.Text = UserVariableData.seletedUserInMainWindow.Password;
        DescriptionText.Text = UserVariableData.seletedUserInMainWindow.Description;
        PhoneNumberText.Text = UserVariableData.seletedUserInMainWindow.PhoneNumber;
        ComboUsers.SelectedItem = UserVariableData.seletedUserInMainWindow;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var selectedUser = ComboUsers.SelectedItem as User;

        if (UserVariableData.seletedUserInMainWindow != null && selectedUser != null)
        {
            var idUser = UserVariableData.seletedUserInMainWindow.IdUser;
            var thisUser = App.DbContext.Users.FirstOrDefault(x => x.IdUser == idUser);

            if (thisUser == null) return;

            thisUser.PhoneNumber = PhoneNumberText.Text;
            thisUser.Description = DescriptionText.Text;
            thisUser.FullName = FullNameText.Text;
            App.DbContext.SaveChanges();
        }
        else
        {
            
            var newUser = new User()
            {
                FullName = FullNameText.Text,
                Description = DescriptionText.Text,
                PhoneNumber = PhoneNumberText.Text,
            };
            App.DbContext.Users.Add(newUser);
            App.DbContext.SaveChanges();
            //newUser.IdUser 
        }
        

        this.Close();
    }
}