using Clients.Mobile.Model;
using System.Collections.Generic;
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

            usersListView.ItemsSource = users;
            usersListView.HasUnevenRows = true;  // Expande a altura, assim todos os items são exibidos
        }
    }
}