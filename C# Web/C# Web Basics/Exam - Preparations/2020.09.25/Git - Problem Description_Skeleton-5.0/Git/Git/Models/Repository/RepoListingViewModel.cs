using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Models.Repository
{
    public class RepoListingViewModel
    {
        public string Id { get; init; }

        public string Name { get; init; }

        public string OwnerName { get; init; }

        public string CreatedOn { get; init; }

        public int CommitsCount { get; init; }
    }
}
