using Microsoft.AspNetCore.Components;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradgardsproffsenApp.Data.Services;
using TradgardsproffsenApp.Models;

namespace TradgardsproffsenApp.Pages
{
    public class SendOutLeadBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        [Inject]
        public ValidatedLeadService validService { get; set; }
        [Inject]
        public SentOutLeadService Service { get; set; }
        [Inject]
        public CompanyService CompanyService { get; set; }

        public static Entities.ValidatedLead lead { get; set; } = new Entities.ValidatedLead();
        public List<CompanyDto> companies { get; set; }
        public List<Entities.Company> companiesToAdd { get; set; } = new List<Entities.Company>();
        public CreateSentOutLeadDto leadToSend = new CreateSentOutLeadDto
        {
            Name = lead.Name,
            Email = lead.Email,
            PhoneNumber = lead.PhoneNumber,
            Address = lead.Address,
            District = lead.District,
            PostCode = lead.PostCode,
            Jobs = lead.Jobs,
            Info = lead.Info,
            URL = lead.URL
        };
        public List<string> CheckBox { get; set; } = new List<string>();
        public bool success;
        protected async override Task OnInitializedAsync()
        {
            lead = await validService.GetValidatedLeadByID(int.Parse(Id));
            companies = await CompanyService.GetAllCompanies();
        }

        public async void HandleValidSubmit()
        {
            foreach (var item in CheckBox)
            {
                CompanyDto company = (from c in companies
                                    where c.Name == item
                                    select c).FirstOrDefault();

                Entities.Company companyToAdd = new Entities.Company
                {
                    Name = company.Name,
                    Email = company.Email,
                    PhoneNumber = company.PhoneNumber,
                    County = company.County,
                    Invoiced = company.Invoiced,
                    Accomplished = company.Accomplished,
                    AvailableJobs = company.AvailableJobs,
                    HitRate = company.HitRate,
                    LatestLead = company.LatestLead,
                    Leads = company.Leads,
                    Left = company.Left,
                    SalesTarget = company.SalesTarget
                };

                companiesToAdd.Add(companyToAdd);
            }
         
            leadToSend.CompaniesSentTo = companiesToAdd;
            bool test;

            success = await Service.SendLead(leadToSend);

            //NOT IMPLEMENTED YET!

            //foreach(var company in leadToSend.CompaniesSentTo)
            //{
                await ExecuteMail(
                    "Jesper.eriksson.99@outlook.com",
                    "Jesper",
                    "Uppdrag från Trädgårdsproffsen",
                    "Hejsan! \n " +
                    "\n " +
                    "Här kommer ett uppdrag från oss på Trädgårdsproffsen. Ring kunden så fort som möjligt, lycka till! \n" +
                    $"{leadToSend.Name}\n" +
                    $"{leadToSend.PhoneNumber}\n" +
                    $"{leadToSend.Address + leadToSend.PostCode + leadToSend.District}\n" +
                    $"{leadToSend.Info}\n" +
                    $"{leadToSend.Description}"
                    );
           // }

            test = await validService.DeleteValidated(lead.Id);
        }
        static async Task ExecuteMail(string email, string name, string subjects, string plaintexts)
        {
            var apiKey = "";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("Jesperceriksson@outlook.com", "Jesper");
            var to = new EmailAddress(email, name);
            var subject = subjects;
            var plaintext = plaintexts;
            var htmlcontent = "<strong></strong>";

            var msg = MailHelper.CreateSingleEmail
                (
                    from,
                    to,
                    subject,
                    plaintext,
                    htmlcontent
                );

            var response = await client.SendEmailAsync(msg);

        }

        public void CheckboxClicked(string CheckId, object checkedValue)
        {
            if ((bool)checkedValue)
            {
                if (!CheckBox.Contains(CheckId))
                {
                    CheckBox.Add(CheckId);
                }
                else
                {
                    if (CheckBox.Contains(CheckId))
                    {
                        CheckBox.Remove(CheckId);
                    }
                }
            }

        }
        public List<string> CheckBoxList()
        {
            List<string> checkBox = new List<string>();

            foreach (var company in companies)
            {
                checkBox.Add(company.Name);
            }
            return checkBox;
        }
    }
}
