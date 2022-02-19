using System;
using System.ComponentModel.DataAnnotations;

using static CarShop.Data.DataConstants;

namespace CarShop.Data.Model
{
    public class User
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(UserUsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsMechanic { get; set; }
    }
}
