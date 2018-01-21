using System.ComponentModel.DataAnnotations;

namespace Fiver.Asp.SignalR.API.Models
{
    public class ReportPostRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
