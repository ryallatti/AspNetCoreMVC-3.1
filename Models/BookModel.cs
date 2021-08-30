using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BookStore.Models
{
    public class BookModel
    {
        
        public int Id { get; set; }
        [StringLength(100,MinimumLength = 5)]
        [Required(ErrorMessage ="Please enter the Title of your book")]
        public string Title { get; set; } 
        [Required(ErrorMessage = "Please enter the Author of your book")]
        public string Author { get; set; }
        [StringLength(500, MinimumLength = 30)]
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage = "Please enter the TotalPages of your book")]
        [Display(Name = "Total Pages of book")]
        public int? TotalPages { get; set; }
        public string Language { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
