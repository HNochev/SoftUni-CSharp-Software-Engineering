using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static CarShop.Data.DataConstants;

namespace CarShop.Data.Model
{
    public class Car
    {
        public Car()
        {
            this.Issues = new HashSet<Issue>();
        }

        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(CarModelMaxLength)]
        public string Model { get; set; }

        public int Year { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        public string PlateNumber { get; set; }

        [Required]
        public string OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public User Owner { get; set; }

        public IEnumerable<Issue> Issues { get; set; }
    }
}
