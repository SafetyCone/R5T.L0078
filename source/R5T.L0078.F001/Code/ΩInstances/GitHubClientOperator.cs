using System;


namespace R5T.L0078.F001
{
    public class GitHubClientOperator : IGitHubClientOperator
    {
        #region Infrastructure

        public static IGitHubClientOperator Instance { get; } = new GitHubClientOperator();


        private GitHubClientOperator()
        {
        }

        #endregion
    }
}
