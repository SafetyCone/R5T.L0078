using System;

using Octokit;

using R5T.T0142;


namespace R5T.L0078.T000
{
    [DataTypeMarker]
    public interface IWithGitHubClient :
        IHasGitHubClient
    {
        new GitHubClient GitHubClient { get; set; }
    }
}
