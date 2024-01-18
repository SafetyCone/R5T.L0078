using System;


namespace R5T.L0078.F001
{
    public static class Instances
    {
        public static IClientOperator ClientOperator => F001.ClientOperator.Instance;
        public static IRepositoryOperator RepositoryOperator => F001.RepositoryOperator.Instance;
        public static IValues Values => F001.Values.Instance;
    }
}