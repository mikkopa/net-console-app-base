using System;
using System.Reflection;
using System.IO.Compression;
using System.Collections.Concurrent;
using System.CommandLine;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Diagnostics;
using net_console_app_base.Commands;

namespace net_console_app_base;

class Program
{
    /// <summary>
    /// Uses System.CommandLine, read more from https://learn.microsoft.com/en-us/dotnet/standard/commandline/
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    static async Task<int> Main(string[] args)
    {
        var rootCommand = new RootCommand("My tool name");
        rootCommand.AddGlobalOption(GlobalOptions.SourcePathOption);
        rootCommand.AddGlobalOption(GlobalOptions.VerboseOption);

        rootCommand.AddCommand(new MyCommandCommand());

        return await rootCommand.InvokeAsync(args);
    }
}

