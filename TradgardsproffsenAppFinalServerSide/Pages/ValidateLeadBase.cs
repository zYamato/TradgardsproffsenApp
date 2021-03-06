﻿using Microsoft.AspNetCore.Components;
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
    public class ValidateLeadBase : ComponentBase
    {
        public static Entities.Lead lead { get; set; } = new Entities.Lead();
        public Entities.Job[] jobs;
        public CreateValidatedLeadDto validLead = new CreateValidatedLeadDto
        {
            Name = lead.Name,
            PhoneNumber = lead.PhoneNumber,
            Address = lead.Address,
            PostCode = lead.PostCode,
            URL = lead.URL,
            Info = lead.Info
        };

        [Inject]
        public JobService jobService { get; set; }
        [Inject]
        public ValidatedLeadService validService{ get; set; }
        [Inject]
        public LeadService leadsService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public List<LeadJob> jobsToAdd { get; set; } = new List<LeadJob>();
        public List<string> CheckBox { get; set; } = new List<string>();
        public bool success;


        protected async override Task OnInitializedAsync()
        {
          lead = await leadsService.GetLeadByID(int.Parse(Id));
          jobs = await jobService.GetJobs();
        }

        public async void HandleValidSubmit()
        {
            foreach(var item in CheckBox)
            {
                Entities.Job job = (from j in jobs
                              where j.Name == item
                              select j).FirstOrDefault();

                LeadJob jobToAdd = new LeadJob
                {
                    JobId = job.Id
                };


                jobsToAdd.Add(jobToAdd);
            }

            validLead.Jobs = jobsToAdd;
            bool test;

            success = await validService.ValidateLead(validLead);
            test = await leadsService.DeleteLead(lead.Id);
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

            foreach(var job in jobs)
            {
                checkBox.Add(job.Name);
            }
            return checkBox;
        }
    }
}
