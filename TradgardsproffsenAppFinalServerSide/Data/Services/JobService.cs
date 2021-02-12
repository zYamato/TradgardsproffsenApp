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
        //private string _ApiUrlBase = "https://tradgardsproffsen.azurewebsites.net/api/job/";
        private string _LocalUrlBase = "https://localhost:44347/api/job/";
        private readonly IHttpClientFactory _clientFactory;

        public JobService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<Job[]> GetJobs()
        {
            Job[] jobs;
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
                    jobs = JsonConvert.DeserializeObject<Job[]>(responsToString);
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
        public async Task<Job> GetJobByID(int id)
        {
            Job job;
            string sUrl = _LocalUrlBase + id;
            var request = new HttpRequestMessage(HttpMethod.Get,
                sUrl);

            var client = _clientFactory.CreateClient();

            try
            {
                string respons = await client.GetStringAsync(sUrl);
                job = JsonConvert.DeserializeObject<Job>(respons);
                job.Id = id;
                return job;
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
