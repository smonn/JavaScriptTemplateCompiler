using System;
using System.Text.RegularExpressions;
using CommandLine;
using JSTC.Compilation;
using JSTC.Config;

namespace JSTC.Tool
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var options = new ProgramOptions();

            if (Parser.Default.ParseArguments(args, options))
            {
                var compiler = new Compiler(options);
                compiler.Compile();

                if (options.Listen)
                {
                    compiler.UpdatedFile += OnUpdatedFile;

                    Console.WriteLine("Listening for file changes at:");
                    Console.WriteLine("\t{0}", options.Path);
                    Console.WriteLine("Enter 'q' to stop listening.");
                    Console.WriteLine();

                    while (Console.Read() != 'q') ;
                }
            }
        }

        private static void OnUpdatedFile(object sender, CompilerEventArgs e)
        {
            Console.WriteLine("Wrote {0} bytes to:", e.FileSize);
            Console.WriteLine("\t{0}", e.FileName);
            Console.WriteLine();
        }
    }
}
