using Clients.Mobile.Model;
using Clients.Mobile.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Clients.Mobile
{
    public partial class MainPage : ContentPage
    {
        private List<User> users;
        private UserApi api;
        public MainPage()
        {
            InitializeComponent();
            api = new UserApi();

            Title = "Gerenciamento de Usuários";
        }

        private async void btLocalizar_Usuarios_Clicked(object sender, EventArgs e)
        {
            try
            {
                users = await api.GetUsers();
            }
            catch(Exception error)
            {
                await DisplayAlert("Erro", error.Message, "Ok");
            }

            await Navigation.PushAsync(new BuscaTodosUsuarios(users));
        }

        private void btCriar_Usuario_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CriaUsuario(api));
        }

        private void btBusca_Usuario_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BuscaUsuarioPorId(api));
        }
    }
}
