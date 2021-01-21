using System;
using System.Threading.Tasks;
using TradgardsproffsenApp.Entities;
using TradgardsproffsenApp.Models;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;
using System.Net.Http;

namespace TradgardsproffsenApp.Data.Services
{
    public class JobService
    {
        //private string _ApiUrlBase = "https://tradgardsproffsen.azurewebsites.net/api/Jobb";
        private string _LocalUrlBase = "https://localhost:44347/api/Jobb";
        private readonly IHttpClientFactory _clientFactory;

        public JobService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<JobDto[]> GetJobs()
        {
            JobDto[] jobs;
            string sUrl = _LocalUrlBase;

            var request = new HttpRequestMessage(HttpMethod.Get,
                sUrl);

            var client = _clientFactory.CreateClient();

            try
            {
                var respons = await client.GetAsync(sUrl);

                if (respons.IsSuccessStatusCode)
                {
                    var responsToString = await respons.Content.ReadAsStringAsync();
                    jobs = JsonConvert.DeserializeObject<JobDto[]>(responsToString);
                    return jobs;
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
            return null;
        }
    }
}
