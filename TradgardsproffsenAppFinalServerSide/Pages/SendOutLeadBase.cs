using Microsoft.AspNetCore.Components;
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
        public List<Entities.Company> companiesToAdd { get; set; }
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

            //success = await Service.SendLead();
            test = await validService.DeleteValidated(lead.Id);
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
