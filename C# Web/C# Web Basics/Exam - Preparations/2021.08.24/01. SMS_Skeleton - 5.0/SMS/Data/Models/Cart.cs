using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data.Models
{
    public class Cart
    {
        public Cart()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public User User { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
