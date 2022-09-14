using Clients.Mobile.Services;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Clients.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscaUsuarioPorId : ContentPage
    {
        private readonly UserApi _api;
        public BuscaUsuarioPorId(UserApi api)
        {
            InitializeComponent();
            Title = "Buscando Usuário";
            _api = api;
        }

        private async void btBusca_Usuario_Clicked(object sender, EventArgs e)
        {
            Guid id;

            try
            {
                id = new Guid(entId.Text);
            }
            catch(Exception error)
            {
                await DisplayAlert("Erro", error.Message, "Ok");
            }

            if(id != Guid.Empty)
            {
                var user = await _api.GetUser(id);
                if(user == null)
                {
                    await DisplayAlert("Alerta", "Usuário não encontrado", "ok");
                    entId.Text = "";

                    // pega os elementos do userstack
                    foreach(View child in UserStack.Children)
                        {
                            // se o filho for um customLabel, apaga o text da tela
                            if(child.ClassId == "customLabel")
                            {
                                child.IsVisible = false;
                            }
                        }

                }
                else
                {
                    entId.Text = "";
                    UserStack.Children.Add(new Label
                    {
                        Text = "Id: " + user.Id,
                        ClassId = "customLabel"

                    });
                    UserStack.Children.Add(new Label
                    {
                        Text = "Nome: " + user.FirstName,
                        ClassId = "customLabel"
                    });
                    UserStack.Children.Add(new Label
                    {
                        Text = "Sobrenome: " + user.Surname,
                        ClassId = "customLabel"
                    });
                    UserStack.Children.Add(new Label
                    {
                        Text = "Idade: " + user.Age,
                        ClassId = "customLabel"
                    });
                    UserStack.Children.Add(new Label
                    {
                        Text = "Data de Criação: " + user.CreationDate,
                        ClassId = "customLabel"
                    });
                }
            }
        }
    }
}