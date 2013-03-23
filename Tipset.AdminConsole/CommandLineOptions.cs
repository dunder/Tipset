using System;
using CommandLine;
using CommandLine.Text;

namespace Tipset.AdminConsole
{
    //https://github.com/gsscoder/commandline/wiki/Verb-Commands
    class CommandLineOptions
    {
        [VerbOption("create-season", HelpText = "Creates a new season starting at yyyy-MM-dd and ending at yyyy-MM-dd")]
        public CreateSeasonSubOptions CreateSeasonSubVerb { get; set; }

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

    class CreateSeasonSubOptions
    {
        [Option("start", Required = true, HelpText = "Season start date (yyyy-mm-dd")]
        public string Start { get; set; }
        
        [Option("end", Required = true, HelpText = "Season end date (yyyy-mm-dd")]
        public string End { get; set; }
        
    }
}
