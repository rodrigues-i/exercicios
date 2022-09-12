using Clients.Mobile.Model;
using Clients.Mobile.Services;
using System;
using Xamarin.Forms;

namespace Clients.Mobile
{
    public partial class MainPage : ContentPage
    {
        private User user;
        private UserApi api;
        public MainPage()
        {
            InitializeComponent();
            api = new UserApi();
        }

        private void MyButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BuscaTodosUsuarios());
        }
    }
}
