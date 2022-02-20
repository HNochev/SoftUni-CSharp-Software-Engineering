using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static FootballManager.Data.DataConstants;

namespace FootballManager.Data.Models
{
    public class User
    {
        public User()
        {
            this.UserPlayers = new HashSet<UserPlayer>();
        }

        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(UserUsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [StringLength(UserEmailMax)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public IEnumerable<UserPlayer> UserPlayers { get; init; }
    }
}
