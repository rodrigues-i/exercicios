using Clients.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Clients.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RemoveUsuario : ContentPage
    {
        private readonly UserApi _api;
        public RemoveUsuario(UserApi api)
        {
            InitializeComponent();
            Title = "Removendo Usuário";
            _api = api;
        }

        private async void btRemove_Usuario_Clicked(object sender, EventArgs e)
        {
            var id = entId.Text;
            if(id == null || id == "")
            {
                await DisplayAlert("Alerta", "O campo id é obrigatório", "Ok");
            }
            else
            {
                try
                {
                    var user = await _api.GetUser(new Guid(id));
                    if(user == null)
                    {
                        await DisplayAlert("Alerta", "Não existe um usuário com este id", "OK");
                    }
                    else
                    {
                        var response = await _api.DeleteUser(new Guid(id));

                        if (response.IsSuccessStatusCode)
                        {
                            await DisplayAlert("Alerta", "Usuário removido com sucesso!", "Ok");
                            entId.Text = "";
                        }
                        else
                        {
                            await DisplayAlert("Alerta", "Não foi possível remover o usuário", "Ok");
                        }
                    }
                }
                catch (Exception)
                {
                    await DisplayAlert("Erro", "Digite um valor válido", "Ok");
                }
            }
        }
    }
}