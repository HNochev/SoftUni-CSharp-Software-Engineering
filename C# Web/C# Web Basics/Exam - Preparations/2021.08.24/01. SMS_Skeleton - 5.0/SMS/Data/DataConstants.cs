using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data
{
    public class DataConstants
    {
        public const int UserUrenameMinLength = 5;
        public const int UserUrenameMaxLength = 20;
        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const int UserMinPasswordLength = 6;
        public const int UserMaxPasswordLength = 20;

        public const int ProductMinName = 4;
        public const int ProductMaxName = 20;
        public const double ProductMinPrice = 0.05;
        public const double ProductMaxPrice = 1000.00;


    }
}
