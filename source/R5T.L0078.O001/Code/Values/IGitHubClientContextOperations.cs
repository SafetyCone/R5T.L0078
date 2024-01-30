using System;
using System.Threading.Tasks;

using Octokit;

using R5T.L0078.T000;
using R5T.T0131;


namespace R5T.L0078.O001
{
    /// <summary>
    /// GitHub client operations on contexts with:
    /// <list type="bullet">
    /// <item><see cref="IHasGitHubClient"/></item>
    /// </list>
    /// </summary>
    [ValuesMarker]
    public partial interface IGitHubClientContextOperations : IValuesMarker
    {
        public Task Display_CurrentUser_ToConsole<TContext>(TContext context)
            where TContext : IHasGitHubClient
        {
            return Instances.GitHubClientOperator.Verify_IsWorking(
                context.GitHubClient);
        }

        public Func<TContext, Task> Exists_Repository<TContext>(
            string repositoryOwnerName,
            string repositoryName,
            Func<TContext, bool, Task> outputHandler = default)
            where TContext : IHasGitHubClient
        {
            return async context =>
            {
                var exists = await Instances.GitHubClientOperator.Exists_Repository(
                    context.GitHubClient,
                    repositoryOwnerName,
                    repositoryName);

                await Instances.FunctionOperator.Run(
                    context,
                    exists,
                    outputHandler);
            };
        }

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

        /// <summary>
        /// Quality-of-life overload for <see cref="Verify_GitHubClient_IsWorking{TContext}(TContext)"/>
        /// </summary>
        public Task Verify_IsWorking<TContext>(TContext context)
            where TContext : IWithGitHubClient
        {
            return this.Verify_GitHubClient_IsWorking(context);
        }

        public Task Verify_GitHubClient_IsWorking<TContext>(TContext context)
            where TContext : IWithGitHubClient
        {
            return Instances.GitHubClientOperator.Verify_IsWorking(
                context.GitHubClient);
        }
    }
}
