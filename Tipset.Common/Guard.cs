using System;

namespace Tipset.Common
{
    public static class Guard
    {
        public static void ArgumentIsNotNull(object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentException(argumentName);
            }
        }
    }
}
