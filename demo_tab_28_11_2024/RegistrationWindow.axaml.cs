using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using demo_tab_28_11_2024.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace demo_tab_28_11_2024;

public partial class RegistrationWindow : Window
{
    SoloUser _NewUser = new();
    EmailAddressAttribute _EmailValidator = new EmailAddressAttribute(); //Валидатор email
    
    public RegistrationWindow()
    {
        _NewUser.Admin = false;
        InitializeComponent();
        grid_reg.DataContext = _NewUser;
        datepicker_birthday.SelectedDate = new DateTime(_NewUser.DateOfBirth.Year, _NewUser.DateOfBirth.Month, _NewUser.DateOfBirth.Day, 1, 1, 1).ToLocalTime();
    }

    private void ConfirmRegistration(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (tbox_email.Text != null && tbox_email.Text != "" &&
            tbox_reglogin.Text != null && tbox_reglogin.Text != "" &&
            tbox_regpassword.Text != null && tbox_regpassword.Text != "" &&
            tbox_surname.Text != null && tbox_surname.Text != "" &&
            tbox_name.Text != null && tbox_name.Text != "" &&
            !tbox_serie.Text.Contains("_") && !tbox_nomer.Text.Contains("_") &&
            tbox_regpassword.Text.Length >= 8 &&
            _EmailValidator.IsValid(tbox_email.Text))
        {

            _NewUser.UserId = DBHelper.DBContext.SoloUsers.Max(x => x.UserId) + 1;
            _NewUser.DateOfBirth = new DateOnly(datepicker_birthday.SelectedDate.Value.Year, datepicker_birthday.SelectedDate.Value.Month, datepicker_birthday.SelectedDate.Value.Day);

            DBHelper.DBContext.SoloUsers.Add(_NewUser);
            DBHelper.DBContext.SaveChanges();

            EventWindow eventWindow = new EventWindow(_NewUser);
            eventWindow.Show();
            Close();
        }
    }

    private void ReturnToMain(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }
}