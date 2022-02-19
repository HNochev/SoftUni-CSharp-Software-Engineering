using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data
{
    public class DataConstants
    {
        public const int UserUsernameMinLength = 4;
        public const int UserUsernameMaxLength = 20;
        public const int UserPasswordMinLength = 5;
        public const int UserPasswordMaxLength = 20;
        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const string UserTypeClient = "Client";
        public const string UserTypeMechanic = "Mechanic";

        public const int CarModelMinLength = 5;
        public const int CarModelMaxLength = 20;
        public const string CarPlateNumberRegularExpression = @"[A-Z]{2}[1-9]{4}[A-Z]{2}";

        public const int IssueDescriptionMinLength = 5;
    }
}
