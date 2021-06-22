using System;

namespace Git.ViewModels.Commits
{
    public class CommitListingViewModel
    {
        public string RepositoryName { get; init; }

        public string Description { get; init; }

        public DateTime CreatedOn { get; init; }
    }
}
