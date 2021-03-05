using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TradgardsproffsenApp.Data.Services
{
    public class TokenService
    {
        private const string _LocalUrlBase = "https://localhost:44347/token";
        private readonly IHttpClientFactory _clientFactory;
        private Task<AuthenticationState> AuthState { get; set; }

        public TokenService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> GetTokenAsync(string userName, string Password)
        {
            string sUrl = _LocalUrlBase;

            var request = new HttpRequestMessage(HttpMethod.Post, sUrl);
            var client = _clientFactory.CreateClient();

            string str = string.Empty;
            var values = new Dictionary<string, string>
              {
               { "username", userName },
               { "password", Password }
            };


            string json = JsonConvert.SerializeObject(values);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync(_LocalUrlBase, httpContent);
                str = await response.Content.ReadAsStringAsync();
                return str;
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {

            }
            return null;


        }

    }
}
