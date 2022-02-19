using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static SMS.Data.DataConstants;

namespace SMS.Data.Models
{
    public class Product
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(ProductMaxName)]
        public string Name { get; set; }

        [Range(ProductMinPrice, ProductMaxPrice)]
        public decimal Price { get; set; }

        public string CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        public Cart? Cart { get; set; }
    }
}
