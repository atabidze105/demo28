using Avalonia.Controls;
using demo_tab_28_11_2024.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace demo_tab_28_11_2024
{
    public partial class MainWindow : Window
    {
        List<SoloUser> _Users = DBHelper.DBContext.SoloUsers.ToList();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginAsGuest(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            EventWindow eventWindow = new EventWindow();
            eventWindow.Show();
            Close();
        }

        private void Registration(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            Close();
        }

        private void Login(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (tbox_login.Text != "" && tbox_password.Text != "")
            {
                if (_Users.Where(x => x.Login == tbox_login.Text).First().Password == tbox_password.Text)
                {
                    EventWindow eventWindow = new EventWindow(_Users.Where(x => x.Login == tbox_login.Text).First());
                    eventWindow.Show();
                    Close();
                }
            }
        }
    }
}