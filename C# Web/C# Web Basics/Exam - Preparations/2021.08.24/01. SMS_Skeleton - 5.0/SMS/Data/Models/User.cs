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
    public class User
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(UserUrenameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; }
    }
}
