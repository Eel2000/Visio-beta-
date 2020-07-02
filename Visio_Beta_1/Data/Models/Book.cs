using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Visio_Beta_1.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Pages { get; set; }

        [Required]
        public string Year { get; set; }

        /// <summary>
        /// this categories must be required but its does not workl
        /// we'll try somthing different
        /// </summary>
        [Display(Name ="Categories")]
        public Category BookCategory { get; set; }

        [Required]
        public byte[] Content { get; set; }
    }
}
