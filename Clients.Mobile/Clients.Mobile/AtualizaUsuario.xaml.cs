using Clients.Mobile.Model;
using Clients.Mobile.Services;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Clients.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AtualizaUsuario : ContentPage
    {
        private readonly UserApi _api;
        User _user = null;
        public AtualizaUsuario(UserApi api)
        {
            InitializeComponent();
            Title = "Atualizando Usuário";
            _api = api;
        }

        private async void btBusca_Clicked(object sender, EventArgs e)
        {
            Guid id;
            if(entId.Text == null || entId.Text == "")
            {
                await DisplayAlert("Alerta", "O campo id é obrigatório", "Ok");
            }
            else
            {
                try
                {
                    id = new Guid(entId.Text.Trim());
                }
                catch (Exception)
                {
                    await DisplayAlert("Erro", "Digite um valor válido do tipo guid.", "Ok");
                }

                if (id != Guid.Empty)
                {
                    _user = await _api.GetUser(id);

                    if (_user == null)
                    {
                        await DisplayAlert("Alerta", "Usuário não encontrado", "ok");
                        entId.Text = "";
                    }
                    else
                    {
                        entFirstName.Text = _user.FirstName;
                        entSurname.Text = _user.Surname;
                        entAge.Text = _user.Age.ToString();
                        innerStack2.IsVisible = true;
                    }
                }
            }

        }

        private async void btAtualiza_Usuario_Clicked(object sender, EventArgs e)
        {
            int age;

            if(entFirstName.Text == null || entFirstName.Text == "")
            {
                await DisplayAlert("Alerta", "O campo nome é obrigatório", "Ok");
            }
            else if(entAge.Text == null || entAge.Text == "")
            {
                await DisplayAlert("Alerta", "O campo idade é obrigatório", "Ok");
            }
            else if(!int.TryParse(entAge.Text, out age))
            {
                await DisplayAlert("Erro", "Idade inválida", "Ok");
            } else
            {
                _user.FirstName = entFirstName.Text;
                _user.Surname = entSurname.Text;
                _user.Age = age;
                var response = await _api.UpdateUser(_user);
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Alerta", "Usuário atualizado com sucesso!", "Ok");
                    entId.Text = "";
                    innerStack2.IsVisible = false;
                }
                else
                {
                    await DisplayAlert("Erro", "Não foi possível atualizar o usuário\n" + response.Content, "Ok");
                }
            }
        }
    }
}