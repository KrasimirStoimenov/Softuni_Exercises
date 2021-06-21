using System;
using Git.Data.Models;

namespace Git.ViewModels.Repositories
{
    public class RepositoryListingViewModel
    {
        public string Name { get; init; }

        public string Owner { get; init; }

        public DateTime CreatedOn { get; init; }

        public int CommitsCount { get; init; }
    }
}