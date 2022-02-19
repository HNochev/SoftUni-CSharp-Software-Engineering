using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
    public class AddCarFormModel
    {
        public string Model { get; init; }

        public int Year { get; init; }

        public string Image { get; init; }

        public string PlateNumber { get; init; }
    }
}
