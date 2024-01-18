using System;


namespace R5T.L0078.O001
{
    public class GitHubClientContextOperations : IGitHubClientContextOperations
    {
        #region Infrastructure

        public static IGitHubClientContextOperations Instance { get; } = new GitHubClientContextOperations();


        private GitHubClientContextOperations()
        {
        }

        #endregion
    }
}
