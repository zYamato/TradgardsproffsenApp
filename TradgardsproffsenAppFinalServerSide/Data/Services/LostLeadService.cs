using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TradgardsproffsenApp.Data.Services
{
    public class LostLeadService
    {
        private string _LocalUrlBase = "https://localhost:44347/api/lostleads/";
        private readonly IHttpClientFactory _clientFactory;

        public LostLeadService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}
