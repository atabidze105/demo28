using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using demo_tab_28_11_2024.Models;
using System;

namespace demo_tab_28_11_2024;

public partial class SoloVisitWindow : Window
{
    SoloUser _LoggedUser;
    public SoloVisitWindow()
    {
        InitializeComponent();
    }
    public SoloVisitWindow(SoloUser user)
    {
        _LoggedUser = user;
        InitializeComponent();
        grid_solovisit.DataContext = _LoggedUser;
        datepicker_birthday.SelectedDate = _LoggedUser.UserId != 0 ? new DateTime(_LoggedUser.DateOfBirth.Year, _LoggedUser.DateOfBirth.Month, _LoggedUser.DateOfBirth.Day, 1, 1, 1).ToLocalTime() : null ;
    }

    private void Return(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        EventWindow eventWindow = new EventWindow(_LoggedUser);
        eventWindow.Show();
        Close();
    }

    private void ClearForm(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

        grid_solovisit.DataContext = new SoloUser();
        datepicker_birthday.SelectedDate = null;
    }
}