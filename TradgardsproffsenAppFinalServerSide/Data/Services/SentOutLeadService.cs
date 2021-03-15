﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TradgardsproffsenApp.Models;

namespace TradgardsproffsenApp.Data.Services
{
    public class SentOutLeadService
    {
        //private string _ApiUrlBase = "https://tradgardsproffsen.azurewebsites.net/api/sentoutleads/";
        private string _LocalUrlBase = "https://localhost:44347/api/sentoutleads/";
        private readonly IHttpClientFactory _clientFactory;

        public SentOutLeadService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<bool> SendLead(CreateSentOutLeadDto lead)
        {
            string sUrl = _LocalUrlBase;
            string leadJson = JsonConvert.SerializeObject(lead);

            var client = _clientFactory.CreateClient();

            var stringContent = new StringContent(content: leadJson, encoding: Encoding.UTF8, mediaType: "application/json");
            var respons = await client.PostAsync(sUrl, stringContent);
            Console.WriteLine(respons);
            return true;
        }
        
        public async Task<SentOutLeadDto[]> GetAllSentOutLeads()
        {
            SentOutLeadDto[] leads;
            string sUrl = _LocalUrlBase;

            var request = new HttpRequestMessage(HttpMethod.Get, sUrl);

            var client = _clientFactory.CreateClient();

            try
            {
                var respons = await client.GetAsync(sUrl);

                if (respons.IsSuccessStatusCode)
                {
                    var responsToString = await respons.Content.ReadAsStringAsync();
                    leads = JsonConvert.DeserializeObject<SentOutLeadDto[]>(responsToString);
                    return leads;
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
