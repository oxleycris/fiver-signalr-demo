using System.Collections.Generic;

namespace Fiver.Asp.SignalR.Models.ViewModels
{
    public class ReportsViewModel
    {
        public IEnumerable<Report> Reports { get; set; } = new List<Report>();
    }
}
