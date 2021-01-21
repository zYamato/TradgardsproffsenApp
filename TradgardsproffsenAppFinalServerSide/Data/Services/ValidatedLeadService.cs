﻿using Newtonsoft.Json;
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
    public class ValidatedLeadService
    {
        //private string _ApiUrlBase = "https://tradgardsproffsen.azurewebsites.net/api/Valideradeleads/";
        private string _LocalUrlBase = "https://localhost:44347/api/ValidatedLeads";
        private readonly IHttpClientFactory _clientFactory;

        public ValidatedLeadService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public LeadService leadsService { get; set; }

        public async Task<Lead> GetLeadForValidation(int id)
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

        public async Task<bool> ValidateLead(CreateValidatedLeadDto lead, List<LeadJob> jobs)
        {
            string sUrl = _LocalUrlBase;
            lead.Jobs = jobs;
            string leadJson = JsonConvert.SerializeObject(lead);

            var client = _clientFactory.CreateClient();

            var stringContent = new StringContent(leadJson, Encoding.UTF8, "application/json");
            var respons = await client.PostAsync(sUrl, stringContent);

            Console.WriteLine(respons);
            return true;
        }


    }
}
