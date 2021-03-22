using Business.Helpers;
using Business.Interfaces.Services;
using Business.IO.Users;
using Domain.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{

    public class UserService : IUserService
    {

       private HttpClient _client = new HttpClient();
        public async Task<UserEntity> Authenticate(string username, string password)
        {
            var auth = await EndPoint(username, password);

            var user = await Task.Run(() => new UserEntity { Success = auth.Success, Error = auth.Error, Username = password, Password = username });
            return user.WithoutPassword();

        }
        public async Task<RetornoAuth> EndPoint(string username, string password)
        {
   
                var request_json = "";
                var content = new StringContent(request_json, Encoding.UTF8, "application/json");
                var authenticationBytes = Encoding.ASCII.GetBytes($"{username}:{password}");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authenticationBytes));
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var result = await _client.PostAsync("https://dev.sitemercado.com.br/api/login", content);

            return JsonConvert.DeserializeObject<RetornoAuth>(await result.Content.ReadAsStringAsync());

        }
    }
}