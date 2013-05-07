using ApprovalTests;
using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject.MockingKernel.Moq;

namespace Tipset.AdminConsole.UnitTests
{
    [TestClass]
    [UseReporter(typeof(DiffReporter))]
    public class ProgramTests
    {
        private static MoqMockingKernel mockingKernel;
        private TemporaryConsoleOutRedirection temporaryConsoleOut;
        
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            mockingKernel = new MoqMockingKernel();
            Program.Kernel = mockingKernel;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            temporaryConsoleOut = new TemporaryConsoleOutRedirection(); 
        }

        [TestCleanup]
        public void TestCleanup()
        {
            temporaryConsoleOut.Dispose();
            mockingKernel.Reset();
        }

        [TestMethod]
        public void NoArgumentsDisplaysHelp()
        {
            var exitCode = Program.Main(ToCommandLineArgs(""));

            VerifyConsoleAndExitCode(exitCode, ExitCodes.InvalidArguments);
        }

        [TestMethod]
        public void HelpShouldWriteHelpToConsole()
        {
            var exitCode = Program.Main(ToCommandLineArgs("--help"));

            VerifyConsoleAndExitCode(exitCode, ExitCodes.InvalidArguments);
        }

        [TestMethod]
        public void CreateSeasonShouldCreateCommandAndExitOk()
        {
            var commandFactory = mockingKernel.GetMock<ICommandFactory>();
            var command = new Mock<ICommand>();
            commandFactory.Setup(x => x.CreateCommand(It.IsAny<string>())).Returns(command.Object);

            var exitCode = Program.Main(ToCommandLineArgs("create-season --start 2012-08-18 --end 2013-05-18"));

            Assert.AreEqual((int)ExitCodes.Ok, exitCode);
            commandFactory.Verify(cf => cf.CreateCommand("create-season"));
        }

        [TestMethod]
        public void CreatePlayerShouldCreateCommandAndExitOk()
        {
            var commandFactory = mockingKernel.GetMock<ICommandFactory>();
            var command = new Mock<ICommand>();
            commandFactory.Setup(x => x.CreateCommand(It.IsAny<string>())).Returns(command.Object);

            var exitCode = Program.Main(ToCommandLineArgs("create-player --name Matias --email matiasjansson@gmail.com"));

            Assert.AreEqual((int)ExitCodes.Ok, exitCode, "unexpected exit code");
            commandFactory.Verify(cf => cf.CreateCommand("create-player"));
        }

        private void VerifyConsoleAndExitCode(int exitCode, ExitCodes expectedExitCode = ExitCodes.Ok)
        {
            Assert.AreEqual((int) expectedExitCode, exitCode, "unexpected exit code");
            Approvals.Verify(temporaryConsoleOut.TemporaryOut);
        }

        private static string[] ToCommandLineArgs(string commandLine)
        {
            return commandLine.Split(' ');
        }
    }
}
