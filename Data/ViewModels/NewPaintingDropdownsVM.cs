using eTickets.Models;
using System.Collections.Generic;

namespace eTickets.Data.ViewModels
{
    public class NewPaintingDropdownsVM
    {
        public NewPaintingDropdownsVM()
        {
            FundRaisers = new List<FundRaiser>();
            Organizers = new List<Organizer>();
            Artists = new List<Artist>();
        }

        public List<FundRaiser> FundRaisers { get; set; }
        public List<Organizer> Organizers { get; set; }
        public List<Artist> Artists { get; set; }
    }
}
