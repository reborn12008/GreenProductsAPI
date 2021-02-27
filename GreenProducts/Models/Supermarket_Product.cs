using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenProducts.Models
{
    public class Supermarket_Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "Price must be between 2 and 5 characters")]
        public String Price { get; set; }

        public int? SupermarketId { get; set; }

        [ForeignKey("SupermarketId")]
        public virtual Supermarket CurrentSupermarket { get; set; }

        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product CurrentProduct { get; set; }
    }
}
