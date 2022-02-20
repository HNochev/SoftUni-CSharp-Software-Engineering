using FootballManager.ViewModels.Players;
using FootballManager.ViewModels.Users;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using static FootballManager.Data.DataConstants;

namespace FootballManager.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username == null || model.Username.Length < UserUsernameMinLength || model.Username.Length > UserUsernameMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UserUsernameMinLength} and {UserUsernameMaxLength} characters long.");
            }

            if (model.Email == null || model.Email.Length < UserEmailMin || model.Email.Length > UserEmailMax)
            {
                errors.Add($"Email is not valid. It must be between {UserEmailMin} and {UserEmailMax} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
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

        public ICollection<string> ValidatePlayer(AddPlayerFormModel model)
        {
            var errors = new List<string>();

            if (model.FullName == null || model.FullName.Length < PlayerFullnameMinLength || model.FullName.Length > PlayerFullnameMaxLength)
            {
                errors.Add($"Fullname '{model.FullName}' is not valid. It must be between {PlayerFullnameMinLength} and {PlayerFullnameMaxLength} characters long.");
            }

            if (model.ImageUrl == null)
            {
                errors.Add($"Image Url is not valid.");
            }

            if (model.Position == null || model.Position.Length < PlayerPositionMinLength || model.Position.Length > PlayerPositionMaxLength)
            {
                errors.Add($"Position '{model.Position}' is not valid. It must be between {PlayerPositionMinLength} and {PlayerPositionMaxLength} characters long.");
            }

            if (model.Position != PlayerGoalkeeper && model.Position != PlayerRFullback && model.Position != PlayerLFullback && model.Position != PlayerCBack && model.Position != PlayerDefender && model.Position != PlayerStriker && model.Position != PlayerWinger)
            {
                errors.Add($"Player position is not valid. It must be either '{PlayerGoalkeeper}' or '{PlayerRFullback}' or '{PlayerLFullback}' or '{PlayerCBack}' or '{PlayerGoalkeeper}' or '{PlayerDefender}' or '{PlayerStriker}' or '{PlayerWinger}'");
            }

            if (model.Endurance.ToString() == null || model.Speed.ToString() == null)
            {
                errors.Add($"You must enter 'Speed' and 'Endurance'.");
            }

            if (model.Speed < PlayerSpeedMin || model.Speed > PlayerSpeedMax)
            {
                errors.Add($"Speed '{model.Speed}' is not valid. It must be between {PlayerSpeedMin} and {PlayerSpeedMax}.");
            }

            if (model.Endurance < PlayerEnduranceMin || model.Endurance > PlayerEnduranceMax)
            {
                errors.Add($"Speed '{model.Endurance}' is not valid. It must be between {PlayerEnduranceMin} and {PlayerEnduranceMax}.");
            }

            if (model.Description.Length > PlayerDescriptionMaxLength)
            {
                errors.Add($"Description must be less than {PlayerDescriptionMaxLength} characters long.");
            }

            return errors;
        }
    }
}
