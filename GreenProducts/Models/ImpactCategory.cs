using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenProducts.Models
{
    public class ImpactCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name size must be between 2 and 20!")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "This name contains characters that are not allowed.")]
        public String Designation { get; set; }

        [Required]
        [Range(0,10)]
        public int SeverityLevel { get; set; }
    }
}
