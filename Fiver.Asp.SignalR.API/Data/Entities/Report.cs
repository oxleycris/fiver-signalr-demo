using System;
using System.ComponentModel.DataAnnotations;

namespace Fiver.Asp.SignalR.API.Data.Entities
{
    public class Report
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
