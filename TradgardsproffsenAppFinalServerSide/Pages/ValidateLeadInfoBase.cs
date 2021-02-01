using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradgardsproffsenApp.Data.Services;
using TradgardsproffsenApp.Entities;

namespace TradgardsproffsenApp.Pages
{
    public class ValidateLeadInfoBase : ComponentBase
    {
        public static ValidatedLead lead { get; set; } = new ValidatedLead();
        public static Entities.Job[] jobs { get; set; }

        public static LeadJob[] leadJobs { get; set; }

        [Inject]
        public JobService jobService { get; set; }
        [Inject]
        public ValidatedLeadService validService { get; set; }
        [Inject]
        public LeadJobsService leadJobService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            lead = await validService.GetValidatedLeadByID(int.Parse(Id));
            leadJobs = await leadJobService.GetAllLeadJobs();
            jobs = await jobService.GetJobs();
        }


    }
}
