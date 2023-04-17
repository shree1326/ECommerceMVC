using eTickets.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class NewPaintingVM
    {
        public int Id { get; set; }

        [Display(Name = "Painting name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Painting description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Painting poster URL")]
        [Required(ErrorMessage = "Painting poster URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Painting start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Painting end date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Painting category is required")]
        public PaintingCategory PaintingCategory { get; set; }

        //Relationships
        [Display(Name = "Select artist(s)")]
        [Required(ErrorMessage = "Painting artist(s) is required")]
        public List<int> ArtistIds { get; set; }

        [Display(Name = "Select a organizer")]
        [Required(ErrorMessage = "Painting organizer is required")]
        public int OrganizerId { get; set; }

        [Display(Name = "Select a fundRaiser")]
        [Required(ErrorMessage = "Painting fundRaiser is required")]
        public int FundRaiserId { get; set; }
    }
}
