using Clients.Mobile.Model;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Clients.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscaTodosUsuarios : ContentPage
    {
        private List<User> users;
   
        public BuscaTodosUsuarios(List<User> users)
        {
            this.users = users;
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Title = "Usuários";
            
            if(users.Count == 0)
            {
                DisplayAlert("Alerta", "Não há usuários no sistema, volte e adicione um usuário na página de criar usuário.", "Ok");
            }
            else
            {
                usersListView.ItemsSource = users;
                usersListView.HasUnevenRows = true;  // Expande a altura, assim todos os items são exibidos
            }
        }

        private async void btCopia_Id_Clicked(object sender, System.EventArgs e)
        {
            var button = (Button)sender;
            var id = button.ClassId;

            // Copy id to clipboard
            await Clipboard.SetTextAsync(id);
            if(Clipboard.HasText && await Clipboard.GetTextAsync() == id)
            {
                await DisplayAlert("Alerta", "Id copiado para o clipboard", "Ok");
            }
        }
    }
}