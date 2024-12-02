using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using demo_tab_28_11_2024.Models;

namespace demo_tab_28_11_2024;

public partial class EventWindow : Window
{
    SoloUser _LoggedUser;
    public EventWindow()
    {
        _LoggedUser = new SoloUser();
        InitializeComponent();
        text.Text = "гость";
        img_userphoto.Source = _LoggedUser.UserPhoto;
    }
    public EventWindow(SoloUser user)
    {
        _LoggedUser = user;
        InitializeComponent();
        img_userphoto.Source = _LoggedUser.UserPhoto;
        text.Text = _LoggedUser.UserId != 0 ?  $"выполнен вход: {_LoggedUser.UserSurname} {_LoggedUser.UserName}" : "гость";
    }

    private void LogOut(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void VisitSolo(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        SoloVisitWindow visitWindow = new SoloVisitWindow(_LoggedUser);
        visitWindow.Show();
        Close();
    }

    private void VisitMany(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }

    private void ShowHistory(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }
}