﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TradgardsproffsenApp.Models;

namespace TradgardsproffsenApp.Entities
{
    public class LeadJob
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public int? ValidatedLeadId { get; set; }
        public int? SentOutLeadId { get; set; }
        public int JobId { get; set; }
    }
}
