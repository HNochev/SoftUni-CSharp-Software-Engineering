using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static FootballManager.Data.DataConstants;

namespace FootballManager.Data.Models
{
    public class Player
    {
        public Player()
        {
            this.UserPlayers = new HashSet<UserPlayer>();
        }

        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(PlayerFullnameMaxLength)]
        public string FullName { get; init; }

        [Required]
        public string ImageUrl { get; init; }

        [Required]
        [MaxLength(PlayerPositionMaxLength)]
        public string Position { get; init; }

        [Range(PlayerSpeedMin, PlayerSpeedMax)]
        public byte Speed { get; init; }

        [Range(PlayerEnduranceMin, PlayerEnduranceMax)]
        public byte Endurance { get; init; }

        [Required]
        [MaxLength(PlayerDescriptionMaxLength)]
        public string Description { get; init; }

        public IEnumerable<UserPlayer> UserPlayers { get; init; }
    }
}
