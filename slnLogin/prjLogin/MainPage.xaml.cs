using prjLogin.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace prjLogin
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        DataBase db;

        public MainPage()
        {
            this.InitializeComponent();
            db = new DataBase();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegisterPage));
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (db.Login(txtUser.Text, txtPassword.Password))
            {
                var message = new MessageDialog("Login Success");
                await message.ShowAsync();
            }
            else
            {
                var message = new MessageDialog("Login Failed");
                await message.ShowAsync();
            }
        }
    }
}
