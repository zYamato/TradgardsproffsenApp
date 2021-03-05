using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TradgardsproffsenApp.Models.UserModel;

namespace TradgardsproffsenApp.Data.Services
{
    public class UserService
    {
        private const string _LocalUrlBase = "https://localhost:44347/api/Users";
        private readonly IHttpClientFactory _clientFactory;

        public UserService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<UserDto[]> GetAllUsers()
        {
            UserDto[] users;
            string sUrl = _LocalUrlBase;

            var request = new HttpRequestMessage(HttpMethod.Get, sUrl);

            var client = _clientFactory.CreateClient();
            try
            {
                string respons = await client.GetStringAsync(_LocalUrlBase);
                users = JsonConvert.DeserializeObject<UserDto[]>(respons);
                return users;
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {

            }
            return null;
        }

        public async Task<UserDto> GetUser(string username)
        {
            UserDto user;
            string sUrl = _LocalUrlBase;

            var request = new HttpRequestMessage(HttpMethod.Get, sUrl);

            var client = _clientFactory.CreateClient();
            try
            {
                string respons = await client.GetStringAsync(_LocalUrlBase + "/" + username);
                user = JsonConvert.DeserializeObject<UserDto>(respons);
                return user;
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


        public async Task<bool> CreateUser(CreateUserDto newUser)
        {
            {
                string sUrl = "http://localhost:5000/api/account/register";

                var request = new HttpRequestMessage(HttpMethod.Post, sUrl);
                var client = _clientFactory.CreateClient();

                string UserJson = JsonConvert.SerializeObject(newUser);

                var stringContent = new StringContent(UserJson, Encoding.UTF8, "application/json");
                try
                {
                    var response = await client.PostAsync(sUrl, stringContent);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

                return false;


            }
        }
    }
}
