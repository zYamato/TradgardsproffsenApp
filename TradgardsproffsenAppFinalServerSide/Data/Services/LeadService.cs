using System;
using System.Threading.Tasks;
using TradgardsproffsenApp.Entities;
using TradgardsproffsenApp.Models;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;
using System.Net.Http;
using System.Collections.Generic;

namespace TradgardsproffsenApp.Data.Services
{
    public class LeadService
    {
        //private string _ApiUrlBase = "https://tradgardsproffsen.azurewebsites.net/api/leads/";
        private string _LocalUrlBase = "https://localhost:44347/api/leads/";
        private readonly IHttpClientFactory _clientFactory;

        public LeadService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<LeadDto[]> GetLeads()
        {
            LeadDto[] leads;
            string sUrl = _LocalUrlBase;

            var request = new HttpRequestMessage(HttpMethod.Get, sUrl);

            var client = _clientFactory.CreateClient();

            try
            {
                var respons = await client.GetAsync(sUrl);

                if (respons.IsSuccessStatusCode)
                {
                    var responsToString = await respons.Content.ReadAsStringAsync();
                    leads = JsonConvert.DeserializeObject<LeadDto[]>(responsToString);
                    return leads;
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {

            }
            return null;
        }
        public async Task<Lead> GetLeadByID(int id)
        {
            Lead lead;
            string sUrl = _LocalUrlBase + id;
            var request = new HttpRequestMessage(HttpMethod.Get,
                sUrl);

            var client = _clientFactory.CreateClient();

            try
            {
                string respons = await client.GetStringAsync(sUrl);
                lead = JsonConvert.DeserializeObject<Lead>(respons);
                lead.Id = id;
                return lead;
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
        public async Task<bool> DeleteLead(int id)
        {
            string sUrl = _LocalUrlBase + id;

            var request = new HttpRequestMessage(HttpMethod.Get,
            sUrl);
            var client = _clientFactory.CreateClient();

            var respons = await client.DeleteAsync(sUrl);

            Console.WriteLine("Respons content: ");
            if (respons.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

    }
}
