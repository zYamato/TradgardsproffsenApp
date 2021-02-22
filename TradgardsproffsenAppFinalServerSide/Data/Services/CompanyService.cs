using System;

using System.Net.Http;
using TradgardsproffsenApp.Entities;
using TradgardsproffsenApp.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace TradgardsproffsenApp.Data.Services
{
    public class CompanyService
    {
        private string _ApiUrlBase = "https://tradgardsproffsen.azurewebsites.net/api/company/";
        private string _LocalUrlBase = "https://localhost:44347/api/company/";
        private readonly IHttpClientFactory _clientFactory;

        public CompanyService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<CompanyDto>> GetAllCompanies()
        {
            List<CompanyDto> company;
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
                    company = JsonConvert.DeserializeObject<List<CompanyDto>>(responsToString);
                    return company;
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
        public async Task<CompanyDto> GetCompanyById(int id)
        {
            CompanyDto company;
            string sUrl = _LocalUrlBase + id;
            var request = new HttpRequestMessage(HttpMethod.Get,
            sUrl);

            var client = _clientFactory.CreateClient();

            try
            {
                string respons = await client.GetStringAsync(sUrl);
                company = JsonConvert.DeserializeObject<CompanyDto>(respons);
                return company;
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {

            }
            return null;
        }
        public async Task<CompanyDto> GetCompanyByName(string name)
        {
            CompanyDto company;
            string sUrl = _LocalUrlBase + name;

            var request = new HttpRequestMessage(HttpMethod.Get,
                sUrl);

            var client = _clientFactory.CreateClient();

            try
            {
                string respons = await client.GetStringAsync(sUrl);
                company = JsonConvert.DeserializeObject<CompanyDto>(respons);
                return company;
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {

            }
            return null;
        }
        public async Task<List<CompanyDto>> GetAllCompanyAsyncName(string searchItem)
        {
            List<CompanyDto> company;
            List<CompanyDto> filteredCompany;
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
                    company = JsonConvert.DeserializeObject<List<CompanyDto>>(responsToString);
                    filteredCompany = company.Where(f => f.Name.ToLower().Contains(searchItem)).ToList();
                    return filteredCompany;
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
        public async Task<List<CompanyDto>> GetAllCompanyAsyncCounty(string searchItem)
        {
            List<CompanyDto> company;
            List<CompanyDto> filteredCompany;
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
                    company = JsonConvert.DeserializeObject<List<CompanyDto>>(responsToString);
                    filteredCompany = company.Where(f => f.County.ToLower().Contains(searchItem)).ToList();
                    return filteredCompany;
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
        public async Task<bool> CreateCompany(CreateCompanyDto company)
        {
            string sUrl = _LocalUrlBase;
            string companyJson = JsonConvert.SerializeObject(company);

            var client = _clientFactory.CreateClient();

            var stringContent = new StringContent(companyJson, Encoding.UTF8, "application/json");
            var respons = await client.PostAsync(sUrl, stringContent);
            Console.WriteLine(respons);
            return true;
        }
        public async Task<bool> UpdateCompany(int id, CompanyDto company)
        {
            string sUrl = _ApiUrlBase + id;
            string toJson = JsonConvert.SerializeObject(company);
            var stringContent = new StringContent(toJson, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Get,
                sUrl);

            var client = _clientFactory.CreateClient();


            var respons = await client.PutAsync(sUrl, stringContent);

            Console.WriteLine("Respons content: ");
            if (respons.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteCompany(int id)
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
        public async Task<>
        public async Task<CompanyDto[]> MatchingLead(ValidatedLeadDto Lead)
        {
            CompanyDto[] companies;
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
                    companies = JsonConvert.DeserializeObject<CompanyDto[]>(responsToString);
                    return companies;
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
