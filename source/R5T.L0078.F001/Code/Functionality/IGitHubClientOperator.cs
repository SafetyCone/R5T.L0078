using System;
using System.Threading.Tasks;

using Octokit;

using R5T.T0132;


namespace R5T.L0078.F001
{
    /// <summary>
    /// GitHub client operator.
    /// </summary>
    [FunctionalityMarker]
    public partial interface IGitHubClientOperator : IFunctionalityMarker
    {
        /// <inheritdoc cref="Delete_Repository_NonIdempotent(GitHubClient, string, string)" path="/summary"/>
        /// <remarks>
        /// The <see cref="IRepositoriesClient.Delete(long)"/> method is non-idempotent.
        /// </remarks>
        public async Task Delete_Repository_NonIdempotent(
            GitHubClient gitHubClient,
            Repository repository)
        {
            await gitHubClient.Repository.Delete(repository.Id);
        }

        /// <summary>
        /// Deletes a repository, throwing an exception if the repository does not exist.
        /// </summary>
        /// <remarks>
        /// The <see cref="IRepositoriesClient.Delete(string, string)"/> method is non-idempotent.
        /// </remarks>
        public async Task Delete_Repository_NonIdempotent(
            GitHubClient gitHubClient,
            string repositoryOwnerName,
            string repositoryName)
        {
            await gitHubClient.Repository.Delete(
                repositoryOwnerName,
                repositoryName);
        }

        /// <summary>
        /// Deletes a repository without throwing an exception if the repository does not exist.
        /// </summary>
        /// <returns>Whether the repository was deleted (whether the repository existed).</returns>
        /// <inheritdoc cref="Delete_Repository_NonIdempotent(GitHubClient, string, string)" path="/remarks"/>
        public async Task<bool> Delete_Repository_Idempotent(
            GitHubClient gitHubClient,
            string repositoryOwnerName,
            string repositoryName)
        {
            var exists = await this.Exists_Repository(
                gitHubClient,
                repositoryOwnerName,
                repositoryName);

            if (exists)
            {
                await this.Delete_Repository_NonIdempotent(
                    gitHubClient,
                    repositoryOwnerName,
                    repositoryName);
            }

            return exists;
        }

        public async Task Display_CurrentUser_ToConsole(
            GitHubClient gitHubClient)
        {
            var currentUser = await gitHubClient.User.Current();

            Console.WriteLine($"{currentUser.Name}: user-current-name");
        }

        public async Task<bool> Exists_Repository(
            GitHubClient gitHubClient,
            string repositoryOwnerName,
            string repositoryName)
        {
            var request = new SearchRepositoriesRequest(repositoryName)
            {
                User = repositoryOwnerName,
                In = new[]
                {
                    InQualifier.Name,
                },
            };

            var result = await gitHubClient.Search.SearchRepo(request);

            var exists = false;

            foreach (var item in result.Items)
            {
                if (item.Name == repositoryName)
                {
                    exists = true;

                    break;
                }
            }

            return exists;
        }

        public GitHubClient Get_GitHubClient(
            string username,
            string password,
            string productHeaderValue)
        {
            var productHeaderValueObject = ProductHeaderValue.Parse(productHeaderValue);

            var credentials = new Credentials(
                username,
                password);

            var gitHubClient = new GitHubClient(productHeaderValueObject)
            {
                Credentials = credentials,
            };

            return gitHubClient;
        }

        public GitHubClient Get_GitHubClient(
            string username,
            string password)
        {
            var productHeaderValue = Instances.Values.DefaultProductHeaderValue;

            return this.Get_GitHubClient(
                username,
                password,
                productHeaderValue);
        }

        public Task<Repository> Get_Repository(
            GitHubClient gitHubClient,
            string repositoryOwnerName,
            string repositoryName)
        {
            var gettingRepository = gitHubClient.Repository.Get(
                repositoryOwnerName,
                repositoryName);

            return gettingRepository;
        }

        public async Task<bool> Is_Private(
            GitHubClient gitHubClient,
            string repositoryOwnerName,
            string repositoryName)
        {
            var output = await Instances.RepositoryOperator.From_Repository(
                gitHubClient,
                repositoryOwnerName,
                repositoryName,
                Instances.RepositoryOperator.Is_Private);

            return output;
        }

        public Task Verify_IsWorking(
            GitHubClient gitHubClient)
        {
            return this.Display_CurrentUser_ToConsole(
                gitHubClient);
        }
    }
}
