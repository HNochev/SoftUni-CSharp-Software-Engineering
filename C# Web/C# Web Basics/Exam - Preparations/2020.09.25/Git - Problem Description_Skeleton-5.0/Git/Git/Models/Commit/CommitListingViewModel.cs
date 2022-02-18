using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Models.Commit
{
    public class CommitListingViewModel
    {
        public string Id { get; init; }

        public string RepoName { get; init; }

        public string Description { get; init; }

        public string CreatedOn { get; init; }
    }
}
