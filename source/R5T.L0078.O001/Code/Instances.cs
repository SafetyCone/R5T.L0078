using System;


namespace R5T.L0078.O001
{
    public static class Instances
    {
        public static F001.IGitHubClientOperator GitHubClientOperator => F001.GitHubClientOperator.Instance;
        public static L0066.IFunctionOperator FunctionOperator => L0066.FunctionOperator.Instance;
        public static F001.IRepositoryOperator RepositoryOperator => F001.RepositoryOperator.Instance;
    }
}