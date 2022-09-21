using Clients.Mobile.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Mobile.Services
{
    public class UserApi
    {
        const String URL = "http://10.0.2.2:5000/Users";

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

        public async Task<User> GetUser(Guid id)
        {
            String dados = URL + "/" + id;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(dados);

            if(response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(content);
                return user;
            }

            return null;

        }

        public async Task<HttpResponseMessage> UpdateUser(User user)
        {
            String dados = URL + "/" + user.Id;
            string json = JsonConvert.SerializeObject(user);
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(dados, content);

            return response;
        }

        public async Task<HttpResponseMessage> DeleteUser(Guid id)
        {
            String dados = URL + "/" + id;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(dados);

            return response;
        }
    }
}
