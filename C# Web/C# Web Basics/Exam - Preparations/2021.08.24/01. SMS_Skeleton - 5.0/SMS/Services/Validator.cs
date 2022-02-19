using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using static SMS.Data.DataConstants;

namespace SMS.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateProduct(CreateProductFormModel model)
        {
            var errors = new List<string>();

            if (model.Name == null || model.Name.Length < ProductMinName || model.Name.Length > ProductMaxName)
            {
                errors.Add($"Name '{model.Name}' is not valid. It must be between {ProductMinName} and {ProductMaxName} characters long.");
            }

            if (model.Price < (decimal)ProductMinPrice || model.Price > (decimal)ProductMaxPrice)
            {
                errors.Add($"The provided price is not valid. It must be between {ProductMinPrice} and {ProductMaxPrice}.");
            }

            return errors;
        }

        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username == null || model.Username.Length < UserUrenameMinLength || model.Username.Length > UserUrenameMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UserUrenameMinLength} and {UserUrenameMaxLength} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password == null || model.Password.Length < UserMinPasswordLength || model.Password.Length > UserMaxPasswordLength)
            {
                errors.Add($"The provided password is not valid. It must be between {UserMinPasswordLength} and {UserMaxPasswordLength} characters long.");
            }

            if (model.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            return errors;
        }
    }
}
