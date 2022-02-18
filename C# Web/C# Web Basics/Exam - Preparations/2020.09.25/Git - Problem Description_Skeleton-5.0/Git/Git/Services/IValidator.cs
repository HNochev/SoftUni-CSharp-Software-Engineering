using Git.Models.Commit;
using Git.Models.Repository;
using Git.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

        ICollection<string> ValidateRepo(CreateRepoFormModel model);

        ICollection<string> ValidateCommit(CreateCommitFormModel model);
    }
}
