using Git.Models.Commit;
using Git.Models.Repository;
using Git.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using static Git.Data.DataConstants;

namespace Git.Services
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
        public ICollection<string> ValidateRepo(CreateRepoFormModel model)
        {
            var errors = new List<string>();

            if (model.Name == null || model.Name.Length < RepoNameMinLength || model.Name.Length > RepoNameMaxLength)
            {
                errors.Add($"Repository name '{model.Name}' is not valid. It must be between {RepoNameMinLength} and {RepoNameMaxLength} characters long.");
            }

            if (model.RepositoryType == null || (model.Name != RepoTypePublic && model.Name == RepoTypePrivate))
            {
                errors.Add($"Repository name '{model.Name}' is not valid. It must be either '{RepoTypePublic}' or '{RepoTypePrivate}' characters long.");
            }

            return errors;
        }

        public ICollection<string> ValidateCommit(CreateCommitFormModel model)
        {
            var errors = new List<string>();

            if (model.Description == null || model.Description.Length < CommitMinDescriptionLength)
            {
                errors.Add($"Commit name '{model.Description}' is not valid. It must be more than {CommitMinDescriptionLength} characters long.");
            }

            return errors;
        }
    }
}
