using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TradgardsproffsenApp.Entities;
using TradgardsproffsenApp.Models;

namespace TradgardsproffsenApp.Data.Services
{
    public class LostLeadService
    {
        private string _LocalUrlBase = "https://localhost:44347/api/lostlead/";
        private readonly IHttpClientFactory _clientFactory;

        public LostLeadService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<LostLead[]> GetAllLostLeads()
        {
            LostLead[] lostLeads;
            string sUrl = _LocalUrlBase;

            var request = new HttpRequestMessage(HttpMethod.Get, sUrl);

            var client = _clientFactory.CreateClient();

            try
            {
                var respons = await client.GetAsync(sUrl);

                if (respons.IsSuccessStatusCode)
                {
                    var responsToString = await respons.Content.ReadAsStringAsync();
                    lostLeads = JsonConvert.DeserializeObject<LostLead[]>(responsToString);
                    return lostLeads;
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
        public async Task<LostLead> GetLostLeadById(int id)
        {
                LostLead lead;
                string sUrl = _LocalUrlBase + id;
                var request = new HttpRequestMessage(HttpMethod.Get,
                    sUrl);

                var client = _clientFactory.CreateClient();

                try
                {
                    string respons = await client.GetStringAsync(sUrl);
                    lead = JsonConvert.DeserializeObject<LostLead>(respons);
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
        public async Task<bool> LoseLead(CreateLostLeadDto lead)
        {
            string sUrl = _LocalUrlBase;
            string leadJson = JsonConvert.SerializeObject(lead);

            var client = _clientFactory.CreateClient();

            var stringContent = new StringContent(content: leadJson, encoding: Encoding.UTF8, mediaType: "application/json");
            var respons = await client.PostAsync(sUrl, stringContent);
            Console.WriteLine(respons);
            return true;
        }
    }
}
