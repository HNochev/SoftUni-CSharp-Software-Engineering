using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballManager.Data.Models
{
    public class UserPlayer
    {
        [Required]
        public string UserId { get; init; }

        [ForeignKey(nameof(UserId))]
        public User User { get; init; }

        public int PlayerId { get; init; }

        [ForeignKey(nameof(PlayerId))]
        public Player Player { get; init; }
    }
}
