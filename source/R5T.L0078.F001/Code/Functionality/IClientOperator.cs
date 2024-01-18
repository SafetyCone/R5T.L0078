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
    public partial interface IClientOperator : IFunctionalityMarker
    {
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

        public async Task Verify_IsWorking(
            GitHubClient gitHubClient)
        {
            var currentUser = await gitHubClient.User.Current();

            Console.WriteLine($"{currentUser.Name}: user-current-name");
        }
    }
}
