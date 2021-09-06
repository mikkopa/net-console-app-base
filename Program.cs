using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommandLine;

namespace net_console_app_base
{
    class Options
    {
        [Option('i', "input", Required = false, HelpText = "Help for input")]
        public string Input { get; set; }

        [Option('o', "output", Required = true, HelpText = "Help for output")]
        public string OutputFile { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            var result = await CommandLine.Parser.Default.ParseArguments<Options>(args)
              .WithParsedAsync(RunOptions);
            result.WithNotParsed(HandleParseError);        
        }

        /// <summary>
        /// The code logic that can use the arguments
        /// </summary>
        /// <param name="opts">The arguments parsed from CLI</param>
        /// <returns></returns>
        static async Task RunOptions(Options opts)
        {
            // check if valid arguments were prodived...
            if (string.IsNullOrEmpty(opts.Input))
            {
                // do something... e.g. set default 
            }

            // rest of logic...
        }

        static void HandleParseError(IEnumerable<Error> errs)
        {
            //handle errors
            Console.WriteLine("Write some usefull info about the app to the user...");
        }
    }
}
