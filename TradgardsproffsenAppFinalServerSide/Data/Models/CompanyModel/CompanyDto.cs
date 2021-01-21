using System;
using System.Collections.Generic;
using TradgardsproffsenApp.Entities;

namespace TradgardsproffsenApp.Models
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public double SalesTarget { get; set; }
        public int Invoiced { get; set; }
        public double Left { get; set; }
        public DateTimeOffset? LatestLead { get; set; }
        public string County { get; set; }
        public int Accomplished { get; set; }
        public double HitRate { get; set; }
        public List<ValidatedLead> Leads { get; set; }
        public List<CompanyJob> AvailableJobs { get; set; }

    }
}