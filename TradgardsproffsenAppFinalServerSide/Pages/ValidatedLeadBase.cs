using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradgardsproffsenApp.Entities;
using TradgardsproffsenApp.Models;
using TradgardsproffsenApp.Data.Services;

namespace TradgardsproffsenApp.Pages
{
    public class ValidatedLeadBase : ComponentBase
    {
        public static TradgardsproffsenApp.Entities.Lead Lead { get; set; } = new TradgardsproffsenApp.Entities.Lead();

        public JobDto[] jobbs;

        public CreateValidatedLeadDto ValidLead = new CreateValidatedLeadDto
        {
            Id = Lead.Id,
            Name = Lead.Name,
            PhoneNumber = Lead.PhoneNumber,
            Address = Lead.Address,
            PostCode = Lead.PostCode,
            Info = Lead.Info
        };

        [Inject]
        public JobService jobbService { get; set; }
        [Inject]
        public ValidatedLeadService validService{ get; set; }

        [Inject]
        public LeadService LeadsService { get; set; }
        [Parameter]
        public string Id { get; set; }

        public List<JobDto> jobbsToAdd { get; set; } = new List<JobDto>();

        public List<string> CheckBox { get; set; } = new List<string>();


        protected async override Task OnInitializedAsync()
        {
          Lead = await LeadsService.GetLeadByID(int.Parse(Id));
          jobbs = await jobbService.GetJobs();
        }

        public async void HandleValidSubmit()
        {
            foreach(var item in CheckBox)
            {
                JobDto jobb = (from j in jobbs
                                    where j.Name == item
                                    select j).FirstOrDefault();
                jobbsToAdd.Add(jobb);
            }

            bool success;
            Thread.Sleep(10);
            success = await validService.ValideraLeads(ValidLead, jobbsToAdd);
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
            checkBox.Add("Altan & terass");
            checkBox.Add("Beskärning");
            checkBox.Add("Bortforsling:");
            checkBox.Add("Dränering");
            checkBox.Add("Gräsklippning");
            checkBox.Add("Häckklippning");
            checkBox.Add("Markfällning");
            checkBox.Add("Mur & Staket");
            checkBox.Add("Planteringar");
            checkBox.Add("Schaktning");
            checkBox.Add("Sektionsfällning");
            checkBox.Add("Snöröjning/skottning");
            checkBox.Add("Stenläggning");
            checkBox.Add("Stubbfräsning");
            checkBox.Add("Trädgårdsanläggning");
            checkBox.Add("Trädgårdsskötsel");
            return checkBox;
        }
    }
}
