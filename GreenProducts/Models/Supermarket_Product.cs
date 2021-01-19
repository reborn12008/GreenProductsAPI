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
        [Range(0.01, float.MaxValue)] // To not allow negative values
        [RegularExpression(@"^\d+(,\d{1,2})?$")] // Maximum of 2 decimal points
        public float Price { get; set; }

        public int? SupermarketId { get; set; }

        [ForeignKey("SupermarketId")]
        public virtual Supermarket CurrentSupermarket { get; set; }

        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product CurrentProduct { get; set; }
    }
}
