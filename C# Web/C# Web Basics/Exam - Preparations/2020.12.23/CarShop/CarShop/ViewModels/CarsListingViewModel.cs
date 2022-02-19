using CarShop.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
    public class CarsListingViewModel
    {
        public string Id { get; init; }

        public string Model { get; init; }

        public int Year { get; set; }

        public string PictureUrl { get; init; }

        public string PlateNumber { get; init; }

        public int RemainingIssues { get; init; }

        public int FixedIssues { get; init; }
    }
}
