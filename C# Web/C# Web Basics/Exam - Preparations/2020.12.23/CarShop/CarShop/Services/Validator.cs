using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using static CarShop.Data.DataConstants;

namespace CarShop.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateCar(AddCarFormModel model)
        {
            var errors = new List<string>();

            if (model.Model == null || model.Model.Length < CarModelMinLength || model.Model.Length > CarModelMaxLength)
            {
                errors.Add($"Model '{model.Model}' is not valid. It must be between {CarModelMinLength} and {CarModelMaxLength} characters long.");
            }

            if (!Regex.IsMatch(model.PlateNumber, CarPlateNumberRegularExpression))
            {
                errors.Add($"Plate number {model.PlateNumber} is not a valid. It must be in format XX1111XX.");
            }

            if (model.Image == null)
            {
                errors.Add($"Picture URL must be valid.");
            }

            return errors;
        }

        public ICollection<string> ValidateIssue(AddIssueFormModel model)
        {
            var errors = new List<string>();

            if (model.Description == null || model.Description.Length < IssueDescriptionMinLength)
            {
                errors.Add($"Description is not valid. It must be over {UserUsernameMinLength} characters long.");
            }

            return errors;
        }

        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username == null || model.Username.Length < UserUsernameMinLength || model.Username.Length > UserUsernameMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UserUsernameMinLength} and {UserUsernameMaxLength} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < UserPasswordMinLength || model.Password.Length > UserPasswordMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {UserPasswordMinLength} and {UserPasswordMaxLength} characters long.");
            }

            if (model.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            if(model.UserType != UserTypeClient && model.UserType != UserTypeMechanic)
            {
                errors.Add($"Invalid user type. Valid are '{UserTypeClient}' and '{UserTypeMechanic}'");
            }

            return errors;
        }

    }
}
