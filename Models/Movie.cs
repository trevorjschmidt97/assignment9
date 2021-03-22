using System;
using System.ComponentModel.DataAnnotations;

namespace TrevorSchmidtAssignment3.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int id { get; set; }

        // Required attributes
        [Required(ErrorMessage = "Please enter the category")]  
        public string Category { get; set; }

        [Required(ErrorMessage = "Please enter the title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please enter the director")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Please enter the rating")]
        public string Rating { get; set; }


        // Non-required attributes
        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }
    }
}

