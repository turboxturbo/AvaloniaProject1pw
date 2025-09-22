using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaProject1pw.Data;

namespace AvaloniaProject1pw;

public partial class CreateAndChangeLogin : Window
{
    public CreateAndChangeLogin()
    {
        InitializeComponent();
    }
    private void AddButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var username = UsernameTB.Text;
        var password = PasswordTB.Text;
        var userIdInput = UserIdTB.Text;



        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            return;
        }

        using var context = new AppDbContext();
        var newLogin = new Login
        {
            Login1 = username,
            Password = password
        };


        if (!string.IsNullOrWhiteSpace(userIdInput))
        {

            if (int.TryParse(userIdInput, out int userId))
            {
                newLogin.IdUser = userId;
            }
        }

        context.Logins.Add(newLogin);
        context.SaveChanges();
        this.Close();
    }
}