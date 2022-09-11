using Clients.Mobile.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Clients.Mobile.Services
{
    public class UserApi
    {
        const String URL = "http://172.17.224.1:5000/Users";

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
                return JsonConvert.DeserializeObject<List<User>>(content);
            }

            return new List<User>();
        }
    }
}
