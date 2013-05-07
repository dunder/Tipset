using ApprovalTests;
using ApprovalTests.Reporters;
using CommandLine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tipset.AdminConsole.UnitTests
{
    [TestClass]
    public class CommandLineParserTests
    {
        [TestMethod]
        public void ParserShouldCreateCreateSeasonOptions()
        {
            var options = new CommandLineOptions();
            var command = "";
            object optionsVerb = null;

            const string commandLine = "create-season --start 2012-08-18 --end 2013-05-18";
            var args = commandLine.Split(' ');

            var parserResult = Parser.Default.ParseArguments(args, options, (verb, subOptions) =>
                    {
                        command = verb;
                        optionsVerb = subOptions;
                    });

            Assert.IsTrue(parserResult);
            Assert.IsNotNull(command);
            Assert.AreEqual(args[0], command);
            Assert.IsTrue(optionsVerb is CreateSeasonSubOptions);

            var createSeasonOptions = (CreateSeasonSubOptions)optionsVerb;
            Assert.AreEqual(args[2], createSeasonOptions.Start);
            Assert.AreEqual(args[4], createSeasonOptions.End);
        }

        public void ParserShouldCreatePlayerOptions()
        {
            var options = new CommandLineOptions();
            var command = "";
            object optionsVerb = null;

            const string commandLine = "create-player --name Matias --email matiasjansson@gmail.com";
            var args = commandLine.Split(' ');

            var parserResult = Parser.Default.ParseArguments(args, options, (verb, subOptions) =>
            {
                command = verb;
                optionsVerb = subOptions;
            });

            Assert.IsTrue(parserResult);
            Assert.IsNotNull(command); 
            Assert.AreEqual(args[0], command);
            Assert.IsTrue(optionsVerb is CreateSeasonSubOptions);

            var createPlayerSubOptions = (CreatePlayerSubOptions)optionsVerb;
            Assert.AreEqual(args[2], createPlayerSubOptions.Name);
            Assert.AreEqual(args[4], createPlayerSubOptions.Email);
        }

        [TestMethod]
        [UseReporter(typeof(DiffReporter))]
        public void ParserShouldShowHelp()
        {
            var options = new CommandLineOptions {CreateSeasonSubVerb = new CreateSeasonSubOptions()};

            Approvals.Verify(options.GetUsage());
        }

        [TestMethod]
        [UseReporter(typeof(DiffReporter))]
        public void ParserShouldShowHelpForCreateSeasonOptions()
        {
            var options = new CommandLineOptions {CreateSeasonSubVerb = new CreateSeasonSubOptions()};

            Approvals.Verify(options.GetUsage("create-season"));
        }
    }
}
