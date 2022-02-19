using SharedTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using static SharedTrip.Data.DataConstants;

namespace SharedTrip.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateTrip(CreateTripFormModel model)
        {
            var errors = new List<string>();

            if(model.StartPoint == null)
            {
                errors.Add("Enter valid start point.");
            }

            if (model.EndPoint == null)
            {
                errors.Add("Enter valid end point.");
            }

            if (model.DepartureTime == null)
            {
                errors.Add("Enter valid departure time.");
            }

            if (model.Seats < TripSeatsMin || model.Seats > TripSeatsMax)
            {
                errors.Add($"Seats must be between {TripSeatsMin} and {TripSeatsMax} characters long.");
            }

            if (model.Description == null || model.Description.Length > TripDescriptionMaxLength)
            {
                errors.Add($"The provided description is not valid. It must be under {TripDescriptionMaxLength} characters long.");
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

            if (model.Email == null || !Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email '{model.Email}' is not a valid e-mail address.");
            }

            if (model.Password == null || model.Password.Length < UserPasswordMin || model.Password.Length > UserPasswordMax)
            {
                errors.Add($"The provided password is not valid. It must be between {UserPasswordMin} and {UserPasswordMax} characters long.");
            }

            if (model.Password != null && model.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("Password and its confirmation are different.");
            }

            return errors;
        }
    }
}
