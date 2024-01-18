using System;
using System.Threading.Tasks;

using Octokit;

using R5T.L0078.T000;
using R5T.T0131;


namespace R5T.L0078.O001
{
    [ValuesMarker]
    public partial interface IGitHubClientContextOperations : IValuesMarker
    {
        public Func<TContext, Task> Set_GitHubClient<TContext>(
            Task<GitHubClient> gettingGitHubClient)
            where TContext : IWithGitHubClient
        {
            return async context =>
            {
                var gitHubClient = await gettingGitHubClient;

                context.GitHubClient = gitHubClient;
            };
        }

        public Func<TContext, Task> Set_GitHubClient<TContext>(
            GitHubClient gitHubClient)
            where TContext : IWithGitHubClient
        {
            return this.Set_GitHubClient<TContext>(
                Task.FromResult(gitHubClient));
        }

        public Task Verify_IsWorking<TContext>(TContext context)
            where TContext : IWithGitHubClient
        {
            return Instances.ClientOperator.Verify_IsWorking(
                context.GitHubClient);
        }
    }
}
