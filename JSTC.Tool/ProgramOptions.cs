using System;
using CommandLine;
using CommandLine.Text;
using JSTC.Config;

namespace JSTC.Tool
{
    public sealed class ProgramOptions : IJSTCConfiguration
    {
        [Option('p', "path", Required = true, HelpText = "The path to the template folder.")]
        public String Path { get; set; }

        [Option('e', "extension", Required = false, DefaultValue = ".tmpl.html", HelpText = "The file extension of the templates.")]
        public String Extension { get; set; }

        [Option('o', "output", Required = false, DefaultValue = "", HelpText = "The path and filename for the output file.")]
        public String Output { get; set; }

        [Option('j', "jsobject", Required = false, DefaultValue = "template", HelpText = "The name of the JavaScript object.")]
        public String JsObject { get; set; }

        [Option('i', "initjsobject", Required = false, DefaultValue = false, HelpText = "If the JavaScript object should be initialized.")]
        public Boolean InitializeJsObject { get; set; }

        [Option('l', "listen", Required = false, DefaultValue = false, HelpText = "Keep the compiler running and listen to file changes.")]
        public Boolean Listen { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public String GetUsage()
        {
            return HelpText.AutoBuild(this, ht => HelpText.DefaultParsingErrorsHandler(this, ht));
        }
    }
}
