using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradgardsproffsenApp.Data.Services;
using TradgardsproffsenApp.Entities;

namespace TradgardsproffsenApp.Pages
{
    public class ValidateLeadInfoBase : ComponentBase
    {
        public static ValidatedLead lead { get; set; } = new ValidatedLead();
        public List<Entities.Job> jobs { get; set; } = new List<Entities.Job>();
        public static LeadJob[] leadJobs { get; set; }
        public List<int> jobListId { get; set; } = new List<int>();


        [Inject]
        public JobService jobService { get; set; }
        [Inject]
        public ValidatedLeadService validService { get; set; }
        [Inject]
        public LeadJobsService leadJobService { get; set; }
        [Inject]
        NavigationManager NaviManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            lead = await validService.GetValidatedLeadByID(int.Parse(Id));
            leadJobs = await leadJobService.GetAllLeadJobs();

            foreach(var leadJob in leadJobs)
            {
                if(leadJob.ValidatedLeadId == lead.Id)
                {
                    jobListId.Add(leadJob.JobId);
                }
            }

            foreach(var id in jobListId)
            {
                Entities.Job job = new Entities.Job();

                job = await jobService.GetJobByID(id);

                jobs.Add(job);
            }
        }

        public void onClickSend(int id)
        {
            NaviManager.NavigateTo($"/sendlead/{id}", forceLoad: true);
        }


    }
}
