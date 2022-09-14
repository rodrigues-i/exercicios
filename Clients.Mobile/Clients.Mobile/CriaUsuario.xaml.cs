using Clients.Mobile.Model;
using Clients.Mobile.Services;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Clients.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CriaUsuario : ContentPage
    {
        private readonly UserApi _api;
        public CriaUsuario(UserApi api)
        {
            _api = api;
            InitializeComponent();
            Title = "Criando novo usuário";
        }

        private async void btCriaUsuario_Clicked(object sender, EventArgs e)
        {
            var firstName = entFirstName.Text;
            var surname = entSurname.Text;
            int age = 0;

            if(entAge.Text == null)
            {
                await DisplayAlert("Alerta", "O campo idade é obrigatório", "Ok");
            }
            else if(!int.TryParse(entAge.Text.Trim(), out age))
            {
                await DisplayAlert("Alerta", "Informe uma idade válida", "Ok");
            }
            else if (firstName == null || firstName.Trim() == "")
            {
                await DisplayAlert("Alerta", "O campo nome é obrigatório", "Ok");
            }
            else
            {
                var user = new User
                {
                    FirstName = firstName,
                    Surname = surname,
                    Age = age
                };

                try
                {
                    await _api.CreateUser(user);
                    await DisplayAlert("Alerta", "Usuário criado com sucesso!", "Ok");
                    LimparCampos();
                }
                catch (Exception error)
                {
                    await DisplayAlert("Erro", error.Message, "Ok");
                }
            }
        }

        private void LimparCampos()
        {
            entFirstName.Text = "";
            entSurname.Text = "";
            entAge.Text = "";
        }
    }
}