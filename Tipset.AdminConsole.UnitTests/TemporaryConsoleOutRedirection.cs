using System;
using System.IO;

namespace Tipset.AdminConsole.UnitTests
{
    class TemporaryConsoleOutRedirection : IDisposable
    {
        private readonly TextWriter temporaryError;
        private readonly TextWriter temporaryOut;

        private readonly TextWriter originalError;
        private readonly TextWriter originalOut;

        public TemporaryConsoleOutRedirection()
        {
            temporaryError = new StringWriter();
            temporaryOut = new StringWriter();
            
            originalError = Console.Error;
            originalOut = Console.Out;

            Console.SetError(temporaryError);
            Console.SetOut(temporaryOut);
        }

        public TextWriter TemporaryOut
        {
            get { return temporaryOut; }
        }

        public TextWriter TemporaryError
        {
            get { return temporaryError; }
        }

        public void Dispose()
        {
            // var standardOut = new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = true};
            Console.SetError(originalError);
            Console.SetOut(originalOut);
        }
    }
}
