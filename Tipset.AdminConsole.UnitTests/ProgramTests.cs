using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tipset.AdminConsole.UnitTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void NoArgumentsDisplaysHelp()
        {
            var textWriter = new StringWriter();
            Console.SetOut(textWriter);

            int returnCode = Program.Main(new string[] { ""});
        }
    }
}
