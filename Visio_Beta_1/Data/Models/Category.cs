using System.ComponentModel.DataAnnotations;

namespace Visio_Beta_1.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Designation { get; set; }
    }
}