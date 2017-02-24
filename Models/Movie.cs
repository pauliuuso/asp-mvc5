using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace aspnet.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Required]
        public Genre Genre { get; set; }
    }
}