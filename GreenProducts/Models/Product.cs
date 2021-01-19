using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenProducts.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Supermarket name size must be between 2 and 20!")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "This name contains characters that are not allowed.")]
        public String Name { get; set; }

        public String Image { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category CurrentCategory { get; set; }

        public int? ImpactId { get; set; }
        [ForeignKey("ImpactId")]
        public virtual ImpactCategory CurrentImpact { get; set; }
    }
}
