using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Data
{
    public class DataConstants
    {
        public const int UserUsernameMinLength = 5;
        public const int UserUsernameMaxLength = 20;
        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const int UserPasswordMin = 6;
        public const int UserPasswordMax = 20;

        public const int TripSeatsMin = 2;
        public const int TripSeatsMax = 6;
        public const int TripDescriptionMaxLength = 80;
    }
}
