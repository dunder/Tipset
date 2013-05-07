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

        public static void IsNotNull(object guarded, string message)
        {
            if (guarded == null)
            {
                throw new NullReferenceException(message);
            }
        }

        public static void IsParsableInt(string guarded, string message)
        {
            int possibleInt;
            if (!int.TryParse(guarded, out possibleInt))
            {
                throw new FormatException(message);
            }
        }

        public static void ArgumentsCondition(Func<bool> condition, string message)
        {
            if (!condition())
            {
                throw new ArgumentException(message);
            }
        }
    }
}
