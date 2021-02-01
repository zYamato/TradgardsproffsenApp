using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using TradgardsproffsenApp.Entities;

namespace TradgardsproffsenApp.Data.Services
{
    public class LeadJobsService
    {

        private string _LocalUrlBase = "https://localhost:44347/api/leadjobs/";
        private readonly IHttpClientFactory _clientFactory;

        public LeadJobsService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<LeadJob[]> GetAllLeadJobs()
        {
            LeadJob[] leadJob;
            string sUrl = _LocalUrlBase;

            var request = new HttpRequestMessage(HttpMethod.Get, sUrl);

            var client = _clientFactory.CreateClient();

            try
            {
                var respons = await client.GetAsync(sUrl);

                if (respons.IsSuccessStatusCode)
                {
                    var responsToString = await respons.Content.ReadAsStringAsync();
                    leadJob = JsonConvert.DeserializeObject<LeadJob[]>(responsToString);
                    return leadJob;
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
