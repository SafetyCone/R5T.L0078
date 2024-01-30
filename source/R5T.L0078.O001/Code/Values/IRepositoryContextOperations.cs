using System;
using System.Threading.Tasks;

using R5T.T0131;

using R5T.L0078.T000;


namespace R5T.L0078.O001
{
    /// <summary>
    /// Octokit repository-related context operations (<see cref="IHasRepository"/>, <see cref="IHasGitHubClient"/>).
    /// </summary>
    [ValuesMarker]
    public partial interface IRepositoryContextOperations : IValuesMarker
    {
        public Func<TContext, Task> Is_Private<TContext>(
            Func<TContext, bool, Task> outputHandler = default
            )
            where TContext : IHasRepository
        {
            return async context =>
            {
                var isPrivate = Instances.RepositoryOperator.Is_Private(context.Repository);

                await Instances.FunctionOperator.Run(
                    context,
                    isPrivate,
                    outputHandler);
            };
        }
    }
}
