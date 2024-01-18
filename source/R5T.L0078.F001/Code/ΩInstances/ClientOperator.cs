using System;


namespace R5T.L0078.F001
{
    public class ClientOperator : IClientOperator
    {
        #region Infrastructure

        public static IClientOperator Instance { get; } = new ClientOperator();


        private ClientOperator()
        {
        }

        #endregion
    }
}
