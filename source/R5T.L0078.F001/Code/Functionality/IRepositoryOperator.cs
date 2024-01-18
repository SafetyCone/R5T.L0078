using System;
using System.Threading.Tasks;

using Octokit;

using R5T.T0132;


namespace R5T.L0078.F001
{
    /// <summary>
    /// Octokit repository (<see cref="Repository"/>) functionality.
    /// </summary>
    [FunctionalityMarker]
    public partial interface IRepositoryOperator : IFunctionalityMarker
    {
        public async Task<TOutput> From_Repository<TOutput>(
            GitHubClient gitHubClient,
            string repositoryOwnerName,
            string repositoryName,
            Func<Repository, TOutput> function)
        {
            var repository = await Instances.ClientOperator.Get_Repository(
                gitHubClient,
                repositoryOwnerName,
                repositoryName);

            var output = function(repository);
            return output;
        }

        /// <summary>
        /// Determines whether a repository is private.
        /// </summary>
        public bool Is_Private(Repository repository)
        {
            var output = repository.Private;
            return output;
        }
    }
}
