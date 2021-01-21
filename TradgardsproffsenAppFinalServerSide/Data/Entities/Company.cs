using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradgardsproffsenApp.Entities
{
    public class Company
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public double SalesTarget { get; set; }

        [Required]
        public int Invoiced { get; set; }

        [Required]
        public double Left { get; set; }

        public DateTimeOffset? LatestLead { get; set; }

        [Required]
        public string County { get; set; }

        public int Accomplished { get; set; }

        public double HitRate { get; set; }

        public List<ValidatedLead> Leads { get; set; }

        public List<CompanyJob> AvailableJobs { get; set; }
    }
}
