using Clients.Mobile.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Mobile.Services
{
    public class UserApi
    {
        const String URL = "http://192.168.1.105:5000/Users";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "Application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");

            return client;
        }

        public async Task<List<User>> GetUsers()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(URL);

            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<User>>(content);
                

                return result;
            }

            return new List<User>();
        }

        public async Task CreateUser(User user)
        {
            String dados = URL;
            string json = JsonConvert.SerializeObject(user);
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(dados, content);

        }
    }
}
