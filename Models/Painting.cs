using eTickets.Data;
using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Painting:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PaintingCategory PaintingCategory { get; set; }

        //Relationships
        public List<Artist_Painting> Artists_Paintings { get; set; }

        //Organizer
        public int OrganizerId { get; set; }
        [ForeignKey("OrganizerId")]
        public Organizer Organizer { get; set; }

        //FundRaiser
        public int FundRaiserId { get; set; }
        [ForeignKey("FundRaiserId")]
        public FundRaiser FundRaiser { get; set; }
    }
}
