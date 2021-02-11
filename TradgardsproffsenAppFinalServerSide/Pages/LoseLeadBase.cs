using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradgardsproffsenApp.Data.Services;

namespace TradgardsproffsenApp.Pages
{
    public class LoseLeadBase : ComponentBase
    {

        public Entities.Lead lead { get; set; } = new Entities.Lead();
        public Entities.ValidatedLead validLead { get; set; } = new Entities.ValidatedLead();
        public Entities.SentOutLead aentOutLead { get; set; } = new Entities.SentOutLead();



        [Inject]
        public LeadService leadsService { get; set; }

        [Inject]
        public ValidatedLeadService validatedLeadService { get; set; }


        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            lead = await leadsService.GetLeadByID(int.Parse(Id));
            validLead = await validatedLeadService.GetValidatedLeadByID(int.Parse(Id));
        }
    }
}
