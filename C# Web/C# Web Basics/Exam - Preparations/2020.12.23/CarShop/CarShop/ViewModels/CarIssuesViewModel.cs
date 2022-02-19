using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
    public class CarIssuesViewModel
    {
        public string Id { get; init; }

        public string Model { get; init; }

        public int Year { get; init; }

        public bool IsMechanic { get; init; }

        public IEnumerable<IssuesViewModel> Issues { get; init; }
    }
}
