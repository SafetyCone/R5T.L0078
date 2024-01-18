using System;


namespace R5T.L0078.F001
{
    public class RepositoryOperator : IRepositoryOperator
    {
        #region Infrastructure

        public static IRepositoryOperator Instance { get; } = new RepositoryOperator();


        private RepositoryOperator()
        {
        }

        #endregion
    }
}
