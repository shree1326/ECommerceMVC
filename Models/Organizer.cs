using eTickets.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Organizer:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Organizer Logo")]
        [Required(ErrorMessage = "Organizer logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Organizer Name")]
        [Required(ErrorMessage = "Organizer name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Organizer description is required")]
        public string Description { get; set; }

        //Relationships
        public List<Painting> Paintings { get; set; }
    }
}
