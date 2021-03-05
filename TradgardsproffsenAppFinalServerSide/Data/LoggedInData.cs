using TradgardsproffsenApp.Data.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradgardsproffsenApp.Data
{
    public class LoggedInData
    {
        private readonly CustomLocalStorageService _storage;
        private const string tokenKey = "authToken";
        public LoggedInData(CustomLocalStorageService storage)
        {
            _storage = storage;
        }


        public async Task<string> GetToken()
        {
            var savedToken = await this._storage.GetItem<string>(tokenKey);
            if (!string.IsNullOrEmpty(savedToken))
            {
                string data = JObject.Parse(savedToken)["access_token"].ToString();
                return data;
            }
            return "";


        }

    }
}
