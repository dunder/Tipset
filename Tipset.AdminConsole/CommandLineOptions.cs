using System;
using CommandLine;
using CommandLine.Text;

namespace Tipset.AdminConsole
{
    //https://github.com/gsscoder/commandline/wiki/Verb-Commands
    public class CommandLineOptions
    {
        [VerbOption("create-season", HelpText = "Creates a new season starting at yyyy-MM-dd and ending at yyyy-MM-dd")]
        public CreateSeasonSubOptions CreateSeasonSubVerb { get; set; }

        [VerbOption("create-player", HelpText = "Creates a new player with a given name and email address")]
        public CreatePlayerSubOptions CreatePlayerSubVerb { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
        }

        [HelpVerbOption]
        public string GetUsage(string verb)
        {
            return HelpText.AutoBuild(this, verb);
        }
    }

    public class CreateSeasonSubOptions
    {
        [Option("start", Required = true, HelpText = "Season start date (yyyy-MM-dd)")]
        public string Start { get; set; }
        
        [Option("end", Required = true, HelpText = "Season end date (yyyy-MM-dd)")]
        public string End { get; set; }
    }

    public class CreatePlayerSubOptions
    {
        [Option("name", Required = true, HelpText = "Player name e.g. 'Matias'")]
        public string Name { get; set; }
        
        [Option("email", Required = true, HelpText = "Player email e.g. 'firstname.lastname@test.com'")]
        public string Email { get; set; }

    }
}
